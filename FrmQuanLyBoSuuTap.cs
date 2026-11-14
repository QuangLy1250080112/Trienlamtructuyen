using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmQuanLyBoSuuTap : Form
    {
        private bool isEditCollection = false;
        private bool isEditArtifact = false;
        private string currentCollectionID = string.Empty;
        private string currentArtifactID = string.Empty;

        public FrmQuanLyBoSuuTap()
        {
            InitializeComponent();
        }

        private void FrmQuanLyBoSuuTap_Load(object sender, EventArgs e)
        {
            LoadCollections();
            SwitchCollectionState(isEditing: false);
            SwitchArtifactState(isEditing: false);
        }

        #region --- QUẢN LÝ TRẠNG THÁI NÚT BẤM (ADD / EDIT STATE) ---

        private void SwitchCollectionState(bool isEditing)
        {
            isEditCollection = isEditing;

            btnThemCollection.Visible = !isEditing;
            btnLuuCollection.Visible = isEditing;
            btnHuyCollection.Visible = isEditing;
            btnXoaCollection.Visible = isEditing;

            txtCollectionID.ReadOnly = false; // Mở cho phép sửa mã

            if (!isEditing)
            {
                currentCollectionID = string.Empty;
                ClearCollectionInput();
            }
        }

        private void SwitchArtifactState(bool isEditing)
        {
            isEditArtifact = isEditing;

            btnThemArtifact.Visible = !isEditing;
            btnLuuArtifact.Visible = isEditing;
            btnHuyArtifact.Visible = isEditing;
            btnXoaArtifact.Visible = isEditing;

            txtArtifactID.ReadOnly = false; // Mở cho phép sửa mã

            if (!isEditing)
            {
                currentArtifactID = string.Empty;
                ClearArtifactInput();
            }
        }

        #endregion

        #region --- XỬ LÝ MASTER: COLLECTION ---

        private void LoadCollections()
        {
            try
            {
                string query = "SELECT collectionID AS [Mã Bộ Sưu Tập], title AS [Tên Bộ Sưu Tập], theme AS [Chủ Đề], description AS [Mô Tả], isPublished AS [Đã Xuất Bản] FROM Collection";
                DataTable dt = Database.ExecuteQuery(query);

                dgvCollection.SelectionChanged -= dgvCollection_SelectionChanged;
                dgvCollection.DataSource = dt;
                dgvCollection.SelectionChanged += dgvCollection_SelectionChanged;

                dgvCollection.ClearSelection();
                SwitchCollectionState(isEditing: false);
                dgvArtifact.DataSource = null;
                SwitchArtifactState(isEditing: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bộ sưu tập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindCollectionFields()
        {
            if (dgvCollection.CurrentRow != null && !dgvCollection.CurrentRow.IsNewRow)
            {
                DataGridViewRow row = dgvCollection.CurrentRow;
                currentCollectionID = row.Cells["Mã Bộ Sưu Tập"].Value?.ToString() ?? "";
                txtCollectionID.Text = currentCollectionID;
                txtTitle.Text = row.Cells["Tên Bộ Sưu Tập"].Value?.ToString() ?? "";
                txtTheme.Text = row.Cells["Chủ Đề"].Value?.ToString() ?? "";
                rtbDescription.Text = row.Cells["Mô Tả"].Value?.ToString() ?? "";
                chkIsPublished.Checked = row.Cells["Đã Xuất Bản"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Đã Xuất Bản"].Value);

                SwitchCollectionState(isEditing: true);
            }
        }

        private void ClearCollectionInput()
        {
            txtCollectionID.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtTheme.Text = string.Empty;
            rtbDescription.Text = string.Empty;
            chkIsPublished.Checked = false;
        }

        private void dgvCollection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCollection.CurrentRow != null)
            {
                BindCollectionFields();

                if (!string.IsNullOrEmpty(currentCollectionID))
                {
                    LoadArtifactsByCollection(currentCollectionID);
                }
            }
        }

        private void dgvCollection_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCollection.CurrentRow != null && dgvCollection.SelectedRows.Count > 0)
            {
                BindCollectionFields();

                if (!string.IsNullOrEmpty(currentCollectionID))
                {
                    LoadArtifactsByCollection(currentCollectionID);
                }
            }
        }

        private void btnThemCollection_Click(object sender, EventArgs e) => SaveCollection();
        private void btnLuuCollection_Click(object sender, EventArgs e) => SaveCollection();

        private void btnHuyCollection_Click(object sender, EventArgs e)
        {
            dgvCollection.ClearSelection();
            SwitchCollectionState(isEditing: false);
            dgvArtifact.DataSource = null;
            SwitchArtifactState(isEditing: false);
        }

        private void SaveCollection()
        {
            string newID = txtCollectionID.Text.Trim();
            string title = txtTitle.Text.Trim();
            string theme = txtTheme.Text.Trim();
            string desc = rtbDescription.Text.Trim();
            bool isPublished = chkIsPublished.Checked;

            if (string.IsNullOrEmpty(newID) || string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Mã và Tên bộ sưu tập không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!isEditCollection)
                {
                    string checkQuery = "SELECT COUNT(*) FROM Collection WHERE collectionID = @id";
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@id", newID) }));
                    if (count > 0)
                    {
                        MessageBox.Show("Mã bộ sưu tập đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertQuery = "INSERT INTO Collection (collectionID, title, description, theme, isPublished) VALUES (@id, @title, @desc, @theme, @isPub)";
                    SqlParameter[] p = {
                        new SqlParameter("@id", newID),
                        new SqlParameter("@title", title),
                        new SqlParameter("@desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc),
                        new SqlParameter("@theme", string.IsNullOrEmpty(theme) ? (object)DBNull.Value : theme),
                        new SqlParameter("@isPub", isPublished)
                    };

                    Database.ExecuteNonQuery(insertQuery, p);
                    MessageBox.Show("Thêm mới bộ sưu tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!newID.Equals(currentCollectionID, StringComparison.OrdinalIgnoreCase))
                    {
                        string checkQuery = "SELECT COUNT(*) FROM Collection WHERE collectionID = @id";
                        int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@id", newID) }));
                        if (count > 0)
                        {
                            MessageBox.Show("Mã bộ sưu tập mới đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Cập nhật collectionID mới (Artifact có ON UPDATE CASCADE tự động nhảy theo)
                    string updateQuery = "UPDATE Collection SET collectionID = @newID, title = @title, description = @desc, theme = @theme, isPublished = @isPub WHERE collectionID = @oldID";
                    SqlParameter[] p = {
                        new SqlParameter("@newID", newID),
                        new SqlParameter("@title", title),
                        new SqlParameter("@desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc),
                        new SqlParameter("@theme", string.IsNullOrEmpty(theme) ? (object)DBNull.Value : theme),
                        new SqlParameter("@isPub", isPublished),
                        new SqlParameter("@oldID", currentCollectionID)
                    };

                    Database.ExecuteNonQuery(updateQuery, p);
                    MessageBox.Show("Cập nhật bộ sưu tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                currentCollectionID = newID;
                LoadCollections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu bộ sưu tập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaCollection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentCollectionID) || !isEditCollection)
            {
                MessageBox.Show("Vui lòng chọn bộ sưu tập cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa bộ sưu tập [{currentCollectionID}]? Các hiện vật thuộc bộ sưu tập này cũng sẽ bị xóa tự động.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM Collection WHERE collectionID = @id";
                    Database.ExecuteNonQuery(deleteQuery, new SqlParameter[] { new SqlParameter("@id", currentCollectionID) });
                    MessageBox.Show("Xóa bộ sưu tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCollections();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa bộ sưu tập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region --- XỬ LÝ DETAIL: ARTIFACT ---

        private void LoadArtifactsByCollection(string collectionId)
        {
            try
            {
                string query = @"SELECT artifactId AS [Mã Hiện Vật], name AS [Tên Hiện Vật], origin AS [Xuất Xứ], historicalPeriod AS [Thời Kỳ], material AS [Chất Liệu] 
                                 FROM Artifact WHERE collectionID = @colID";

                SqlParameter[] parameters = { new SqlParameter("@colID", collectionId) };
                DataTable dt = Database.ExecuteQuery(query, parameters);

                dgvArtifact.SelectionChanged -= dgvArtifact_SelectionChanged;
                dgvArtifact.DataSource = dt;
                dgvArtifact.SelectionChanged += dgvArtifact_SelectionChanged;

                dgvArtifact.ClearSelection();
                SwitchArtifactState(isEditing: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hiện vật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindArtifactFields()
        {
            if (dgvArtifact.CurrentRow != null && !dgvArtifact.CurrentRow.IsNewRow)
            {
                DataGridViewRow row = dgvArtifact.CurrentRow;
                currentArtifactID = row.Cells["Mã Hiện Vật"].Value?.ToString() ?? "";
                txtArtifactID.Text = currentArtifactID;
                txtName.Text = row.Cells["Tên Hiện Vật"].Value?.ToString() ?? "";
                txtOrigin.Text = row.Cells["Xuất Xứ"].Value?.ToString() ?? "";
                txtHistoricalPeriod.Text = row.Cells["Thời Kỳ"].Value?.ToString() ?? "";
                txtMaterial.Text = row.Cells["Chất Liệu"].Value?.ToString() ?? "";

                SwitchArtifactState(isEditing: true);
            }
        }

        private void ClearArtifactInput()
        {
            txtArtifactID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtOrigin.Text = string.Empty;
            txtHistoricalPeriod.Text = string.Empty;
            txtMaterial.Text = string.Empty;
        }

        private void dgvArtifact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvArtifact.CurrentRow != null)
            {
                BindArtifactFields();
            }
        }

        private void dgvArtifact_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArtifact.CurrentRow != null && dgvArtifact.SelectedRows.Count > 0)
            {
                BindArtifactFields();
            }
        }

        private void btnThemArtifact_Click(object sender, EventArgs e) => SaveArtifact();
        private void btnLuuArtifact_Click(object sender, EventArgs e) => SaveArtifact();

        private void btnHuyArtifact_Click(object sender, EventArgs e)
        {
            dgvArtifact.ClearSelection();
            SwitchArtifactState(isEditing: false);
        }

        private void SaveArtifact()
        {
            if (string.IsNullOrEmpty(currentCollectionID) || !isEditCollection)
            {
                MessageBox.Show("Vui lòng chọn một bộ sưu tập trước khi lưu hiện vật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newArtifactID = txtArtifactID.Text.Trim();
            string name = txtName.Text.Trim();
            string origin = txtOrigin.Text.Trim();
            string period = txtHistoricalPeriod.Text.Trim();
            string material = txtMaterial.Text.Trim();

            if (string.IsNullOrEmpty(newArtifactID) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Mã và Tên hiện vật không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!isEditArtifact)
                {
                    string checkQuery = "SELECT COUNT(*) FROM Artifact WHERE artifactId = @artID";
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@artID", newArtifactID) }));
                    if (count > 0)
                    {
                        MessageBox.Show("Mã hiện vật đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertQuery = @"INSERT INTO Artifact (artifactId, name, origin, historicalPeriod, material, collectionID) 
                                           VALUES (@artID, @name, @origin, @period, @material, @colID)";

                    SqlParameter[] p = {
                        new SqlParameter("@artID", newArtifactID),
                        new SqlParameter("@name", name),
                        new SqlParameter("@origin", string.IsNullOrEmpty(origin) ? (object)DBNull.Value : origin),
                        new SqlParameter("@period", string.IsNullOrEmpty(period) ? (object)DBNull.Value : period),
                        new SqlParameter("@material", string.IsNullOrEmpty(material) ? (object)DBNull.Value : material),
                        new SqlParameter("@colID", currentCollectionID)
                    };

                    Database.ExecuteNonQuery(insertQuery, p);
                    MessageBox.Show("Thêm hiện vật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!newArtifactID.Equals(currentArtifactID, StringComparison.OrdinalIgnoreCase))
                    {
                        string checkQuery = "SELECT COUNT(*) FROM Artifact WHERE artifactId = @artID";
                        int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@artID", newArtifactID) }));
                        if (count > 0)
                        {
                            MessageBox.Show("Mã hiện vật mới đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 1. Tạm thời tháo liên kết MediaFile (set NULL) để tránh lỗi FK_MediaFile_Artifact
                        const string detachMedia = "UPDATE MediaFile SET artifactId = NULL WHERE artifactId = @oldID";
                        Database.ExecuteNonQuery(detachMedia, new SqlParameter[] { new SqlParameter("@oldID", currentArtifactID) });

                        // 2. Cập nhật mã hiện vật mới ở bảng Artifact (CauChuyenStep tự động CASCADE theo)
                        string updateQuery = @"UPDATE Artifact 
                                               SET artifactId = @newID, name = @name, origin = @origin, historicalPeriod = @period, material = @material 
                                               WHERE artifactId = @oldID";

                        SqlParameter[] p = {
                            new SqlParameter("@newID", newArtifactID),
                            new SqlParameter("@name", name),
                            new SqlParameter("@origin", string.IsNullOrEmpty(origin) ? (object)DBNull.Value : origin),
                            new SqlParameter("@period", string.IsNullOrEmpty(period) ? (object)DBNull.Value : period),
                            new SqlParameter("@material", string.IsNullOrEmpty(material) ? (object)DBNull.Value : material),
                            new SqlParameter("@oldID", currentArtifactID)
                        };

                        Database.ExecuteNonQuery(updateQuery, p);

                        // 3. Gán lại Mã hiện vật mới cho MediaFile
                        const string reattachMedia = "UPDATE MediaFile SET artifactId = @newID WHERE artifactId IS NULL AND stepID IS NULL";
                        Database.ExecuteNonQuery(reattachMedia, new SqlParameter[] { new SqlParameter("@newID", newArtifactID) });
                    }
                    else
                    {
                        string updateQuery = @"UPDATE Artifact 
                                               SET name = @name, origin = @origin, historicalPeriod = @period, material = @material 
                                               WHERE artifactId = @oldID";

                        SqlParameter[] p = {
                            new SqlParameter("@name", name),
                            new SqlParameter("@origin", string.IsNullOrEmpty(origin) ? (object)DBNull.Value : origin),
                            new SqlParameter("@period", string.IsNullOrEmpty(period) ? (object)DBNull.Value : period),
                            new SqlParameter("@material", string.IsNullOrEmpty(material) ? (object)DBNull.Value : material),
                            new SqlParameter("@oldID", currentArtifactID)
                        };

                        Database.ExecuteNonQuery(updateQuery, p);
                    }

                    MessageBox.Show("Cập nhật hiện vật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                currentArtifactID = newArtifactID;
                LoadArtifactsByCollection(currentCollectionID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hiện vật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaArtifact_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentArtifactID) || !isEditArtifact)
            {
                MessageBox.Show("Vui lòng chọn hiện vật cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa hiện vật [{currentArtifactID}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM Artifact WHERE artifactId = @artID";
                    Database.ExecuteNonQuery(deleteQuery, new SqlParameter[] { new SqlParameter("@artID", currentArtifactID) });
                    MessageBox.Show("Xóa hiện vật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadArtifactsByCollection(currentCollectionID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hiện vật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}