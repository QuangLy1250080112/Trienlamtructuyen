using System;
using System.Data;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Trienlamtructuyen
{
    [SupportedOSPlatform("windows6.1")]
    public partial class FrmBienTapCauChuyen : Form
    {
        private string currentStoryID = string.Empty;
        private string currentStepID = string.Empty;
        private bool isStoryEditMode;
        private bool isStepEditMode;

        public FrmBienTapCauChuyen()
        {
            InitializeComponent();
            RegisterScreenReaderEvents();
        }

        public FrmBienTapCauChuyen(string storyID) : this()
        {
            if (!string.IsNullOrEmpty(storyID))
            {
                currentStoryID = storyID;
            }
        }

        private void FrmBienTapCauChuyen_Load(object sender, EventArgs e)
        {
            ScreenReaderHelper.Speak("Đã mở giao diện Biên Tập Câu Chuyện & Kịch Bản.");

            LoadArtifactDropdown();
            LoadStoriesGrid();

            if (!string.IsNullOrEmpty(currentStoryID))
            {
                SelectStoryInGrid(currentStoryID);
            }
            else
            {
                SwitchToStoryAddMode();
            }
        }

        #region Tích hợp Screen Reader
        private void RegisterScreenReaderEvents()
        {
            // 1. Ô nhập & Thao tác Câu Chuyện
            txtCauChuyenID.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Mã câu chuyện: {txtCauChuyenID.Text}");
            txtTitle.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Tiêu đề câu chuyện: {txtTitle.Text}");
            txtAuthor.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Tác giả: {txtAuthor.Text}");
            cboStatus.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Trạng thái: {cboStatus.Text}");
            rtbSynopsis.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Tóm tắt câu chuyện: {rtbSynopsis.Text}");

            btnThemStory.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Thêm mới câu chuyện.");
            btnLuuStory.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Lưu sửa câu chuyện.");
            btnHuyStory.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Hủy sửa câu chuyện.");
            btnXoaStory.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Xóa câu chuyện.");

            // 2. Ô nhập & Thao tác Bước Kịch Bản (Step)
            txtStepID.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Mã bước: {txtStepID.Text}");
            numStepOrder.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Thứ tự bước: {numStepOrder.Value}");
            txtHeading.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Tiêu đề bước: {txtHeading.Text}");
            rtbContentBody.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Nội dung bước: {rtbContentBody.Text}");
            cboArtifactLink.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Hiện vật đính kèm: {cboArtifactLink.Text}");

            btnThemStep.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Thêm bước mới.");
            btnLuuStep.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Lưu sửa bước.");
            btnHuyStep.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Hủy sửa bước.");
            btnXoaStep.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Xóa bước.");
            btnKiemTraAccessibility.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Kiểm tra trợ năng.");

            // 3. Đọc dữ liệu hàng khi dùng phím di chuyển trên DataGridView
            dgvStories.SelectionChanged += (s, e) =>
            {
                if (dgvStories.Focused && dgvStories.CurrentRow != null && dgvStories.CurrentRow.Index >= 0)
                {
                    ReadDgvRow(dgvStories, dgvStories.CurrentRow.Index, "Danh sách câu chuyện");
                }
            };

            dgvSteps.SelectionChanged += (s, e) =>
            {
                if (dgvSteps.Focused && dgvSteps.CurrentRow != null && dgvSteps.CurrentRow.Index >= 0)
                {
                    ReadDgvRow(dgvSteps, dgvSteps.CurrentRow.Index, "Kịch bản từng bước");
                }
            };
        }

        private void ReadDgvRow(DataGridView dgv, int rowIndex, string tableName)
        {
            if (rowIndex < 0 || rowIndex >= dgv.Rows.Count) return;
            var row = dgv.Rows[rowIndex];
            if (row.IsNewRow) return;

            string content = $"{tableName}, dòng {rowIndex + 1}: ";

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Visible && cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    string header = dgv.Columns[cell.ColumnIndex].HeaderText;
                    content += $"{header}: {cell.Value}; ";
                }
            }
            ScreenReaderHelper.Speak(content);
        }
        #endregion

        private void LoadArtifactDropdown()
        {
            try
            {
                const string query = "SELECT artifactId, name FROM Artifact ORDER BY name ASC";
                DataTable dt = Database.ExecuteQuery(query);

                DataRow dr = dt.NewRow();
                dr["artifactId"] = DBNull.Value;
                dr["name"] = "-- Không liên kết hiện vật --";
                dt.Rows.InsertAt(dr, 0);

                cboArtifactLink.DataSource = dt;
                cboArtifactLink.DisplayMember = "name";
                cboArtifactLink.ValueMember = "artifactId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách hiện vật: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStoriesGrid()
        {
            try
            {
                const string query = "SELECT cauChuyenID AS [Mã Câu Chuyện], title AS [Tiêu Đề], synopsis AS [Tóm Tắt], author AS [Tác Giả], status AS [Trạng Thái] FROM CauChuyen ORDER BY cauChuyenID DESC";
                DataTable dtStories = Database.ExecuteQuery(query);

                dgvStories.CellClick -= dgvStories_CellClick;
                dgvStories.DataSource = dtStories;
                dgvStories.CellClick += dgvStories_CellClick;

                dgvStories.ClearSelection();
                SwitchToStoryAddMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách câu chuyện: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectStoryInGrid(string storyID)
        {
            foreach (DataGridViewRow row in dgvStories.Rows)
            {
                if (row.Cells["Mã Câu Chuyện"].Value?.ToString() == storyID)
                {
                    row.Selected = true;
                    dgvStories.CurrentCell = row.Cells[0];
                    LoadStoryDetailFromRow(row);
                    break;
                }
            }
        }

        private void dgvStories_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvStories.CurrentRow == null) return;
            LoadStoryDetailFromRow(dgvStories.Rows[e.RowIndex]);
        }

        private void LoadStoryDetailFromRow(DataGridViewRow row)
        {
            currentStoryID = row.Cells["Mã Câu Chuyện"].Value?.ToString() ?? string.Empty;
            txtCauChuyenID.Text = currentStoryID;
            txtTitle.Text = row.Cells["Tiêu Đề"].Value?.ToString() ?? string.Empty;
            txtAuthor.Text = row.Cells["Tác Giả"].Value?.ToString() ?? string.Empty;
            rtbSynopsis.Text = row.Cells["Tóm Tắt"].Value?.ToString() ?? string.Empty;

            string status = row.Cells["Trạng Thái"].Value?.ToString() ?? "Draft";
            cboStatus.SelectedItem = status;

            SwitchToStoryEditMode();
            LoadStepsGrid();
        }

        private void LoadStepsGrid()
        {
            if (string.IsNullOrEmpty(currentStoryID))
            {
                dgvSteps.DataSource = null;
                SwitchToStepAddMode();
                return;
            }

            try
            {
                const string querySteps = @"SELECT s.stepID, s.stepOrder, s.heading, s.contentBody, s.artifactId, a.name AS ArtifactName 
                                     FROM CauChuyenStep s 
                                     LEFT JOIN Artifact a ON s.artifactId = a.artifactId 
                                     WHERE s.cauChuyenID = @cauChuyenID 
                                     ORDER BY s.stepOrder ASC";
                SqlParameter[] pSteps = [new SqlParameter("@cauChuyenID", currentStoryID)];
                DataTable dtSteps = Database.ExecuteQuery(querySteps, pSteps);

                dgvSteps.CellClick -= dgvSteps_CellClick;
                dgvSteps.DataSource = dtSteps;
                dgvSteps.CellClick += dgvSteps_CellClick;

                if (dgvSteps.Columns["stepID"] != null) dgvSteps.Columns["stepID"]!.HeaderText = "Mã Bước";
                if (dgvSteps.Columns["stepOrder"] != null) dgvSteps.Columns["stepOrder"]!.HeaderText = "STT";
                if (dgvSteps.Columns["heading"] != null) dgvSteps.Columns["heading"]!.HeaderText = "Tiêu Đề Bước";
                if (dgvSteps.Columns["contentBody"] != null) dgvSteps.Columns["contentBody"]!.HeaderText = "Nội Dung";
                if (dgvSteps.Columns["ArtifactName"] != null) dgvSteps.Columns["ArtifactName"]!.HeaderText = "Hiện Vật";
                if (dgvSteps.Columns["artifactId"] != null) dgvSteps.Columns["artifactId"]!.Visible = false;

                dgvSteps.ClearSelection();
                SwitchToStepAddMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách các bước: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // XỬ LÝ NÚT THAO TÁC CÂU CHUYỆN (CAUCHUYEN)
        // ====================================================================

        private void btnThemStory_Click(object? sender, EventArgs e) => SaveStory();
        private void btnLuuStory_Click(object? sender, EventArgs e) => SaveStory();

        private void SaveStory()
        {
            if (string.IsNullOrWhiteSpace(txtCauChuyenID.Text) || string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã câu chuyện và Tiêu đề!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string newStoryID = txtCauChuyenID.Text.Trim();
                string sql;

                if (isStoryEditMode)
                {
                    if (!newStoryID.Equals(currentStoryID, StringComparison.OrdinalIgnoreCase))
                    {
                        const string checkQuery = "SELECT COUNT(*) FROM CauChuyen WHERE cauChuyenID = @newStoryID";
                        SqlParameter[] pCheck = [new SqlParameter("@newStoryID", newStoryID)];
                        int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, pCheck));

                        if (count > 0)
                        {
                            MessageBox.Show($"Mã câu chuyện mới [{newStoryID}] đã tồn tại trong hệ thống!", "Cảnh báo trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    sql = "UPDATE CauChuyen SET cauChuyenID = @newStoryID, title = @title, synopsis = @synopsis, author = @author, status = @status WHERE cauChuyenID = @oldStoryID";

                    SqlParameter[] parameters = [
                        new SqlParameter("@newStoryID", newStoryID),
                        new SqlParameter("@title", txtTitle.Text.Trim()),
                        new SqlParameter("@synopsis", string.IsNullOrWhiteSpace(rtbSynopsis.Text) ? DBNull.Value : rtbSynopsis.Text.Trim()),
                        new SqlParameter("@author", string.IsNullOrWhiteSpace(txtAuthor.Text) ? DBNull.Value : txtAuthor.Text.Trim()),
                        new SqlParameter("@status", cboStatus.SelectedItem?.ToString() ?? "Draft"),
                        new SqlParameter("@oldStoryID", currentStoryID)
                    ];

                    Database.ExecuteNonQuery(sql, parameters);
                }
                else
                {
                    const string checkQuery = "SELECT COUNT(*) FROM CauChuyen WHERE cauChuyenID = @id";
                    SqlParameter[] pCheck = [new SqlParameter("@id", newStoryID)];
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, pCheck));

                    if (count > 0)
                    {
                        MessageBox.Show($"Mã câu chuyện [{newStoryID}] đã tồn tại trong hệ thống!", "Cảnh báo trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sql = "INSERT INTO CauChuyen (cauChuyenID, title, synopsis, author, status) VALUES (@id, @title, @synopsis, @author, @status)";

                    SqlParameter[] parameters = [
                        new SqlParameter("@id", newStoryID),
                        new SqlParameter("@title", txtTitle.Text.Trim()),
                        new SqlParameter("@synopsis", string.IsNullOrWhiteSpace(rtbSynopsis.Text) ? DBNull.Value : rtbSynopsis.Text.Trim()),
                        new SqlParameter("@author", string.IsNullOrWhiteSpace(txtAuthor.Text) ? DBNull.Value : txtAuthor.Text.Trim()),
                        new SqlParameter("@status", cboStatus.SelectedItem?.ToString() ?? "Draft")
                    ];

                    Database.ExecuteNonQuery(sql, parameters);
                }

                MessageBox.Show(isStoryEditMode ? "Cập nhật câu chuyện thành công!" : "Thêm câu chuyện mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                currentStoryID = newStoryID;
                LoadStoriesGrid();
                SelectStoryInGrid(newStoryID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu câu chuyện: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyStory_Click(object? sender, EventArgs e)
        {
            dgvStories.ClearSelection();
            SwitchToStoryAddMode();
        }

        private void btnXoaStory_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentStoryID) || !isStoryEditMode)
            {
                MessageBox.Show("Vui lòng chọn câu chuyện cần xóa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa câu chuyện [{currentStoryID}] cùng toàn bộ kịch bản các bước của nó?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    const string sql = "DELETE FROM CauChuyen WHERE cauChuyenID = @id";
                    SqlParameter[] p = [new SqlParameter("@id", currentStoryID)];
                    Database.ExecuteNonQuery(sql, p);

                    MessageBox.Show("Xóa câu chuyện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStoriesGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa câu chuyện: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SwitchToStoryAddMode()
        {
            isStoryEditMode = false;
            currentStoryID = string.Empty;

            txtCauChuyenID.ReadOnly = false;
            txtCauChuyenID.Text = $"STO_{DateTime.Now:MMdd_HHmm}";
            txtTitle.Clear();
            txtAuthor.Clear();
            rtbSynopsis.Clear();
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            btnThemStory.Visible = true;
            btnLuuStory.Visible = false;
            btnHuyStory.Visible = false;
            btnXoaStory.Visible = false;

            dgvSteps.DataSource = null;
            SwitchToStepAddMode();
        }

        private void SwitchToStoryEditMode()
        {
            isStoryEditMode = true;
            txtCauChuyenID.ReadOnly = false;

            btnThemStory.Visible = false;
            btnLuuStory.Visible = true;
            btnHuyStory.Visible = true;
            btnXoaStory.Visible = true;
        }

        // ====================================================================
        // XỬ LÝ NÚT THAO TÁC KỊCH BẢN TỪNG BƯỚC (CAUCHUYENSTEP)
        // ====================================================================

        private void dgvSteps_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvSteps.CurrentRow == null) return;

            DataGridViewRow row = dgvSteps.Rows[e.RowIndex];

            currentStepID = row.Cells["stepID"].Value?.ToString() ?? string.Empty;
            txtStepID.Text = currentStepID;

            if (int.TryParse(row.Cells["stepOrder"].Value?.ToString(), out int order))
            {
                numStepOrder.Value = order;
            }
            txtHeading.Text = row.Cells["heading"].Value?.ToString() ?? string.Empty;
            rtbContentBody.Text = row.Cells["contentBody"].Value?.ToString() ?? string.Empty;

            if (row.Cells["artifactId"].Value is { } val && val != DBNull.Value)
            {
                cboArtifactLink.SelectedValue = val.ToString();
            }
            else
            {
                if (cboArtifactLink.Items.Count > 0) cboArtifactLink.SelectedIndex = 0;
            }

            SwitchToStepEditMode();
        }

        private void btnThemStep_Click(object? sender, EventArgs e) => SaveStep();
        private void btnLuuStep_Click(object? sender, EventArgs e) => SaveStep();

        private void SaveStep()
        {
            if (string.IsNullOrWhiteSpace(currentStoryID))
            {
                MessageBox.Show("Vui lòng chọn hoặc lưu một Câu chuyện trước khi thêm các bước kịch bản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStepID.Text) || string.IsNullOrWhiteSpace(txtHeading.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã bước và Tiêu đề bước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string newStepID = txtStepID.Text.Trim();
                object artifactValue = (cboArtifactLink.SelectedValue == null || cboArtifactLink.SelectedValue == DBNull.Value || string.IsNullOrEmpty(cboArtifactLink.SelectedValue.ToString()))
                    ? DBNull.Value
                    : cboArtifactLink.SelectedValue;

                if (isStepEditMode)
                {
                    // Nếu có thay đổi sang Mã bước mới
                    if (!newStepID.Equals(currentStepID, StringComparison.OrdinalIgnoreCase))
                    {
                        // 1. Kiểm tra trùng Mã bước mới trong CSDL
                        const string checkQuery = "SELECT COUNT(*) FROM CauChuyenStep WHERE stepID = @newStepID";
                        SqlParameter[] pCheck = [new SqlParameter("@newStepID", newStepID)];
                        int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, pCheck));

                        if (count > 0)
                        {
                            MessageBox.Show($"Mã bước mới [{newStepID}] đã tồn tại trong CSDL!", "Cảnh báo trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 2. Tạm thời gán stepID = NULL cho các file media đang tham chiếu tới Mã bước CŨ (dùng currentStepID)
                        const string detachMediaSql = "UPDATE MediaFile SET stepID = NULL WHERE stepID = @oldStepID";
                        SqlParameter[] pDetach = [new SqlParameter("@oldStepID", currentStepID)];
                        Database.ExecuteNonQuery(detachMediaSql, pDetach);

                        // 3. Cập nhật mã bước mới ở bảng CauChuyenStep (TuyenThamQuanNode tự động CASCADE theo)
                        const string sqlUpdateStep = "UPDATE CauChuyenStep SET stepID = @newStepID, stepOrder = @stepOrder, heading = @heading, contentBody = @contentBody, artifactId = @artifactId WHERE stepID = @oldStepID";
                        SqlParameter[] parametersStep = [
                            new SqlParameter("@newStepID", newStepID),
                            new SqlParameter("@stepOrder", Convert.ToInt32(numStepOrder.Value)),
                            new SqlParameter("@heading", txtHeading.Text.Trim()),
                            new SqlParameter("@contentBody", string.IsNullOrWhiteSpace(rtbContentBody.Text) ? DBNull.Value : rtbContentBody.Text.Trim()),
                            new SqlParameter("@artifactId", artifactValue),
                            new SqlParameter("@oldStepID", currentStepID)
                        ];
                        Database.ExecuteNonQuery(sqlUpdateStep, parametersStep);

                        // 4. Gán lại Mã bước MỚI (newStepID) cho các tệp MediaFile vừa gán NULL
                        const string reattachMediaSql = "UPDATE MediaFile SET stepID = @newStepID WHERE stepID IS NULL AND artifactId IS NULL";
                        SqlParameter[] pAttach = [new SqlParameter("@newStepID", newStepID)];
                        Database.ExecuteNonQuery(reattachMediaSql, pAttach);
                    }
                    else
                    {
                        // Giữ nguyên mã bước, chỉ sửa thông tin nội dung/hiện vật
                        const string sqlUpdateStep = "UPDATE CauChuyenStep SET stepOrder = @stepOrder, heading = @heading, contentBody = @contentBody, artifactId = @artifactId WHERE stepID = @oldStepID";
                        SqlParameter[] parametersStep = [
                            new SqlParameter("@stepOrder", Convert.ToInt32(numStepOrder.Value)),
                            new SqlParameter("@heading", txtHeading.Text.Trim()),
                            new SqlParameter("@contentBody", string.IsNullOrWhiteSpace(rtbContentBody.Text) ? DBNull.Value : rtbContentBody.Text.Trim()),
                            new SqlParameter("@artifactId", artifactValue),
                            new SqlParameter("@oldStepID", currentStepID)
                        ];
                        Database.ExecuteNonQuery(sqlUpdateStep, parametersStep);
                    }
                }
                else
                {
                    // Thêm mới bước kịch bản
                    const string checkQuery = "SELECT COUNT(*) FROM CauChuyenStep WHERE stepID = @stepID";
                    SqlParameter[] pCheck = [new SqlParameter("@stepID", newStepID)];
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, pCheck));

                    if (count > 0)
                    {
                        MessageBox.Show($"Mã bước [{newStepID}] đã tồn tại trong CSDL!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    const string sqlInsertStep = "INSERT INTO CauChuyenStep (stepID, stepOrder, heading, contentBody, cauChuyenID, artifactId) VALUES (@stepID, @stepOrder, @heading, @contentBody, @cauChuyenID, @artifactId)";
                    SqlParameter[] parametersStep = [
                        new SqlParameter("@stepID", newStepID),
                        new SqlParameter("@stepOrder", Convert.ToInt32(numStepOrder.Value)),
                        new SqlParameter("@heading", txtHeading.Text.Trim()),
                        new SqlParameter("@contentBody", string.IsNullOrWhiteSpace(rtbContentBody.Text) ? DBNull.Value : rtbContentBody.Text.Trim()),
                        new SqlParameter("@cauChuyenID", currentStoryID),
                        new SqlParameter("@artifactId", artifactValue)
                    ];

                    Database.ExecuteNonQuery(sqlInsertStep, parametersStep);
                }

                // Cập nhật lại biến lưu Mã bước hiện tại
                currentStepID = newStepID;

                ReorderStepNumbers();
                LoadStepsGrid();

                MessageBox.Show(isStepEditMode ? "Cập nhật bước kịch bản thành công!" : "Thêm bước kịch bản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi dữ liệu bước: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyStep_Click(object? sender, EventArgs e)
        {
            dgvSteps.ClearSelection();
            SwitchToStepAddMode();
        }

        private void btnXoaStep_Click(object? sender, EventArgs e)
        {
            if (dgvSteps.CurrentRow == null || string.IsNullOrWhiteSpace(txtStepID.Text) || !isStepEditMode)
            {
                MessageBox.Show("Vui lòng chọn bước cần xóa từ bảng kịch bản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string stepID = txtStepID.Text.Trim();

            if (MessageBox.Show($"Xác nhận xóa bước [{stepID}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    const string sql = "DELETE FROM CauChuyenStep WHERE stepID = @stepID";
                    SqlParameter[] p = [new SqlParameter("@stepID", stepID)];
                    Database.ExecuteNonQuery(sql, p);

                    ReorderStepNumbers();
                    LoadStepsGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa bước: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SwitchToStepAddMode()
        {
            isStepEditMode = false;
            currentStepID = string.Empty;
            txtStepID.ReadOnly = false;
            txtStepID.Text = $"STP_{DateTime.Now:MMdd_HHmm}";

            int nextOrder = (dgvSteps.DataSource is DataTable dt) ? dt.Rows.Count + 1 : 1;
            numStepOrder.Value = nextOrder;

            txtHeading.Clear();
            rtbContentBody.Clear();
            if (cboArtifactLink.Items.Count > 0) cboArtifactLink.SelectedIndex = 0;

            btnThemStep.Visible = true;
            btnLuuStep.Visible = false;
            btnHuyStep.Visible = false;
            btnXoaStep.Visible = false;
        }

        private void SwitchToStepEditMode()
        {
            isStepEditMode = true;
            txtStepID.ReadOnly = false;

            btnThemStep.Visible = false;
            btnLuuStep.Visible = true;
            btnHuyStep.Visible = true;
            btnXoaStep.Visible = true;
        }

        private void ReorderStepNumbers()
        {
            try
            {
                const string querySelect = "SELECT stepID FROM CauChuyenStep WHERE cauChuyenID = @cauChuyenID ORDER BY stepOrder ASC";
                SqlParameter[] pSelect = [new SqlParameter("@cauChuyenID", currentStoryID)];
                DataTable dt = Database.ExecuteQuery(querySelect, pSelect);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string stepID = dt.Rows[i]["stepID"].ToString()!;
                    const string queryUpdate = "UPDATE CauChuyenStep SET stepOrder = @newOrder WHERE stepID = @stepID";
                    SqlParameter[] pUpdate = [
                        new SqlParameter("@newOrder", i + 1),
                        new SqlParameter("@stepID", stepID)
                    ];
                    Database.ExecuteNonQuery(queryUpdate, pUpdate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi sắp xếp thứ tự bước: {ex.Message}");
            }
        }

        private void btnKiemTraAccessibility_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentStoryID))
            {
                MessageBox.Show("Vui lòng chọn một câu chuyện để kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                const string query = @"SELECT s.stepID, s.stepOrder, s.heading, 
                                        (SELECT COUNT(*) FROM MediaFile m WHERE m.stepID = s.stepID) AS MediaCount
                                 FROM CauChuyenStep s
                                 WHERE s.cauChuyenID = @cauChuyenID
                                 ORDER BY s.stepOrder ASC";

                SqlParameter[] p = [new SqlParameter("@cauChuyenID", currentStoryID)];
                DataTable dt = Database.ExecuteQuery(query, p);

                string warningMsg = string.Empty;
                int missingCount = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int mediaCount = Convert.ToInt32(row["MediaCount"]);

                    if (mediaCount == 0)
                    {
                        missingCount++;
                        warningMsg += $"- Bước {row["stepOrder"]} [{row["stepID"]}]: Chưa có tệp Đa phương tiện/Audio thuyết minh đính kèm.\n";
                    }
                }

                if (missingCount > 0)
                {
                    MessageBox.Show($"Phát hiện {missingCount} bước chưa gắn tệp Media thuyết minh:\n\n{warningMsg}",
                                    "Cảnh báo Trợ năng Media", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Tất cả các bước kịch bản đều đã được đính kèm tệp Đa phương tiện đầy đủ!",
                                    "Kiểm tra thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra trợ năng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}