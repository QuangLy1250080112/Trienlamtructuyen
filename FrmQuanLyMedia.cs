using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmQuanLyMedia : Form
    {
        private string selectedFilePath = "";
        private bool isEditMode = false;

        public FrmQuanLyMedia()
        {
            InitializeComponent();
        }

        private void FrmQuanLyMedia_Load(object sender, EventArgs e)
        {
            LoadArtifactDropdown();
            LoadStepDropdown();
            LoadMediaGrid();
            SwitchToAddMode();
        }

        private void LoadArtifactDropdown()
        {
            try
            {
                string query = "SELECT artifactId, name FROM Artifact";
                DataTable dt = Database.ExecuteQuery(query);

                DataRow dr = dt.NewRow();
                dr["artifactId"] = DBNull.Value;
                dr["name"] = "-- Chọn Hiện Vật --";
                dt.Rows.InsertAt(dr, 0);

                cboArtifact.DataSource = dt;
                cboArtifact.DisplayMember = "name";
                cboArtifact.ValueMember = "artifactId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách hiện vật: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStepDropdown()
        {
            try
            {
                string query = @"
                    SELECT s.stepID, (st.title + ' - Bước ' + CAST(s.stepOrder AS varchar) + ': ' + s.heading) AS StepDisplay 
                    FROM CauChuyenStep s
                    INNER JOIN CauChuyen st ON s.cauChuyenID = st.cauChuyenID";
                DataTable dt = Database.ExecuteQuery(query);

                DataRow dr = dt.NewRow();
                dr["stepID"] = DBNull.Value;
                dr["StepDisplay"] = "-- Chọn Bước KB --";
                dt.Rows.InsertAt(dr, 0);

                cboStep.DataSource = dt;
                cboStep.DisplayMember = "StepDisplay";
                cboStep.ValueMember = "stepID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách bước kịch bản: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // HÀM XỬ LÝ SỰ KIỆN DUY NHẤT (ĐÃ THÊM KIỂM TRA AN TOÀN TRÁNH LỖI CS0111)
        // ====================================================================
        private void cboArtifact_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra an toàn: Nếu cboStep chưa nạp xong dữ liệu thì ngắt ngay
            if (cboStep.DataSource == null || cboStep.Items.Count == 0) return;

            // Nếu người dùng chọn một Hiện vật cụ thể (khác NULL và khác rỗng)
            if (cboArtifact.SelectedValue != null &&
                cboArtifact.SelectedValue != DBNull.Value &&
                !string.IsNullOrEmpty(cboArtifact.SelectedValue.ToString()))
            {
                cboStep.SelectedIndex = 0;
                cboStep.Enabled = false;
            }
            else
            {
                cboStep.Enabled = true;
            }
        }

        private void LoadMediaGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        m.mediaID AS [Mã Media],
                        m.fileName AS [Tên Tệp],
                        m.mediaType AS [Loại],
                        m.fileSizeByte AS [Dung Lượng (Byte)],
                        COALESCE(a.name, N'--') AS [Hiện Vật],
                        COALESCE(s.heading, N'--') AS [Bước KB],
                        m.mediaURL AS [Link URL],
                        m.artifactId,
                        m.stepID
                    FROM MediaFile m
                    LEFT JOIN Artifact a ON m.artifactId = a.artifactId
                    LEFT JOIN CauChuyenStep s ON m.stepID = s.stepID
                    ORDER BY m.mediaID DESC";

                DataTable dtMedia = Database.ExecuteQuery(query);
                dgvMediaList.DataSource = dtMedia;

                if (dgvMediaList.Columns["artifactId"] != null) dgvMediaList.Columns["artifactId"].Visible = false;
                if (dgvMediaList.Columns["stepID"] != null) dgvMediaList.Columns["stepID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách Media: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMediaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMediaList.CurrentRow == null) return;

            DataGridViewRow row = dgvMediaList.Rows[e.RowIndex];

            SwitchToEditMode();

            txtMediaID.Text = row.Cells["Mã Media"].Value?.ToString();
            txtFileName.Text = row.Cells["Tên Tệp"].Value?.ToString();

            string mediaType = row.Cells["Loại"].Value?.ToString() ?? "Image";
            cboMediaType.SelectedItem = mediaType;
            txtFileSizeByte.Text = row.Cells["Dung Lượng (Byte)"].Value?.ToString();

            // Hiển thị Link URL từ dòng đang chọn
            txtMediaURL.Text = (row.Cells["Link URL"].Value != DBNull.Value) ? row.Cells["Link URL"].Value?.ToString() : "";

            object artVal = row.Cells["artifactId"].Value;
            object stepVal = row.Cells["stepID"].Value;

            if (artVal != null && artVal != DBNull.Value && !string.IsNullOrEmpty(artVal.ToString()))
            {
                cboArtifact.SelectedValue = artVal.ToString();
            }
            else
            {
                cboArtifact.SelectedIndex = 0;
                if (stepVal != null && stepVal != DBNull.Value && !string.IsNullOrEmpty(stepVal.ToString()))
                    cboStep.SelectedValue = stepVal.ToString();
                else
                    cboStep.SelectedIndex = 0;
            }

            ResolveAndSetPreviewFilePath(txtFileName.Text.Trim());
        }

        private void ResolveAndSetPreviewFilePath(string fName)
        {
            if (string.IsNullOrEmpty(fName))
            {
                selectedFilePath = "";
                PreviewSelectedFile();
                return;
            }

            if (File.Exists(fName))
            {
                selectedFilePath = Path.GetFullPath(fName);
            }
            else
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string pathInBase = Path.Combine(baseDir, fName);

                if (File.Exists(pathInBase))
                {
                    selectedFilePath = pathInBase;
                }
                else
                {
                    selectedFilePath = fName;
                }
            }

            PreviewSelectedFile();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Tất cả tệp media (*.jpg;*.png;*.mp3;*.mp4;*.gltf;*.glb)|*.jpg;*.png;*.mp3;*.mp4;*.gltf;*.glb|Hình ảnh (*.jpg;*.png)|*.jpg;*.png|Âm thanh (*.mp3)|*.mp3|Video (*.mp4)|*.mp4|Mô hình 3D (*.gltf;*.glb)|*.gltf;*.glb";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = ofd.FileName;
                    string fileNameOnly = Path.GetFileName(sourcePath);
                    string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileNameOnly);

                    try
                    {
                        if (!File.Exists(destPath) && !sourcePath.Equals(destPath, StringComparison.OrdinalIgnoreCase))
                        {
                            File.Copy(sourcePath, destPath, true);
                        }
                        selectedFilePath = destPath;
                    }
                    catch
                    {
                        selectedFilePath = sourcePath;
                    }

                    txtFileName.Text = fileNameOnly;
                    FileInfo fi = new FileInfo(selectedFilePath);
                    txtFileSizeByte.Text = fi.Length.ToString();

                    string ext = Path.GetExtension(selectedFilePath).ToLower();
                    if (ext == ".jpg" || ext == ".png") cboMediaType.SelectedItem = "Image";
                    else if (ext == ".mp3") cboMediaType.SelectedItem = "Audio";
                    else if (ext == ".mp4") cboMediaType.SelectedItem = "Video";
                    else if (ext == ".gltf" || ext == ".glb") cboMediaType.SelectedItem = "3D";

                    PreviewSelectedFile();
                }
            }
        }

        private void cboMediaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewSelectedFile();
        }

        private void PreviewSelectedFile()
        {
            StopMediaPreview();

            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }

            picPreview.Visible = false;
            axWindowsMediaPlayer1.Visible = false;
            pnlMediaPlayer.Visible = false;
            lblPreviewStatus.Visible = false;

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                lblPreviewStatus.Text = "Chưa chọn tệp xem trước";
                lblPreviewStatus.Visible = true;
                return;
            }

            string mediaType = cboMediaType.SelectedItem?.ToString() ?? "";

            if (mediaType == "Image")
            {
                if (File.Exists(selectedFilePath))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                fs.CopyTo(ms);
                                ms.Position = 0;
                                picPreview.Image = Image.FromStream(ms);
                            }
                        }
                        picPreview.Visible = true;
                    }
                    catch
                    {
                        lblPreviewStatus.Text = $"[HÌNH ẢNH]\nKhông thể đọc hình ảnh:\n{Path.GetFileName(selectedFilePath)}";
                        lblPreviewStatus.Visible = true;
                    }
                }
                else
                {
                    lblPreviewStatus.Text = $"[HÌNH ẢNH]\n{Path.GetFileName(selectedFilePath)}\n(Tệp không tồn tại ở thư mục ứng dụng)";
                    lblPreviewStatus.Visible = true;
                }
            }
            else if (mediaType == "Video" || mediaType == "Audio")
            {
                if (File.Exists(selectedFilePath))
                {
                    axWindowsMediaPlayer1.Visible = true;
                    pnlMediaPlayer.Visible = true;
                    axWindowsMediaPlayer1.URL = selectedFilePath;
                }
                else
                {
                    lblPreviewStatus.Text = $"[{mediaType.ToUpper()}]\n{Path.GetFileName(selectedFilePath)}\n(Tệp không tồn tại ở thư mục ứng dụng)";
                    lblPreviewStatus.Visible = true;
                }
            }
            else if (mediaType == "3D")
            {
                lblPreviewStatus.Text = $"[MÔ HÌNH 3D]\n{Path.GetFileName(selectedFilePath)}";
                lblPreviewStatus.Visible = true;
            }
        }

        private void btnPlayPauseMedia_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.Visible && !string.IsNullOrEmpty(axWindowsMediaPlayer1.URL))
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void btnStopMedia_Click(object sender, EventArgs e)
        {
            StopMediaPreview();
        }

        private void StopMediaPreview()
        {
            try
            {
                if (axWindowsMediaPlayer1.URL != null)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                }
            }
            catch { }
        }

        private void btnUploadSave_Click(object sender, EventArgs e)
        {
            string mediaID = txtMediaID.Text.Trim();
            if (string.IsNullOrWhiteSpace(mediaID))
            {
                MessageBox.Show("Vui lòng nhập Mã Media!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMediaID.Focus();
                return;
            }

            string fileName = txtFileName.Text.Trim();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("Vui lòng chọn Tệp Media!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mediaType = cboMediaType.SelectedItem?.ToString() ?? "Image";
            long fileSize = long.TryParse(txtFileSizeByte.Text, out long fs) ? fs : 0;
            string mediaUrl = txtMediaURL.Text.Trim();

            object artifactId = (cboArtifact.SelectedValue == DBNull.Value || cboArtifact.SelectedValue == null) ? DBNull.Value : cboArtifact.SelectedValue;
            object stepId = (cboStep.SelectedValue == DBNull.Value || cboStep.SelectedValue == null || !cboStep.Enabled) ? DBNull.Value : cboStep.SelectedValue;
            object mediaUrlVal = string.IsNullOrWhiteSpace(mediaUrl) ? DBNull.Value : mediaUrl;

            try
            {
                string queryMedia = @"
                    IF EXISTS (SELECT 1 FROM MediaFile WHERE mediaID = @MediaID)
                        UPDATE MediaFile 
                        SET fileName=@FileName, mediaType=@MediaType, fileSizeByte=@FileSize, artifactId=@ArtifactID, stepID=@StepID, mediaURL=@MediaURL 
                        WHERE mediaID=@MediaID
                    ELSE
                        INSERT INTO MediaFile (mediaID, fileName, mediaType, fileSizeByte, artifactId, stepID, mediaURL)
                        VALUES (@MediaID, @FileName, @MediaType, @FileSize, @ArtifactID, @StepID, @MediaURL)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MediaID", mediaID),
                    new SqlParameter("@FileName", fileName),
                    new SqlParameter("@MediaType", mediaType),
                    new SqlParameter("@FileSize", fileSize),
                    new SqlParameter("@ArtifactID", artifactId),
                    new SqlParameter("@StepID", stepId),
                    new SqlParameter("@MediaURL", mediaUrlVal)
                };

                Database.ExecuteNonQuery(queryMedia, parameters);
                MessageBox.Show(isEditMode ? "Cập nhật thông tin Media thành công!" : "Thêm Media mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMediaGrid();
                SwitchToAddMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực thi CSDL: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SwitchToAddMode();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMediaID.Text))
            {
                MessageBox.Show("Vui lòng chọn Tệp Media cần xóa từ bảng bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mediaID = txtMediaID.Text.Trim();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa tệp Media [{mediaID}] khỏi CSDL?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM MediaFile WHERE mediaID = @MediaID";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MediaID", mediaID) };

                    int rows = Database.ExecuteNonQuery(query, parameters);
                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa tệp Media thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMediaGrid();
                        SwitchToAddMode();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa Media: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SwitchToAddMode()
        {
            isEditMode = false;
            StopMediaPreview();
            selectedFilePath = "";

            txtMediaID.ReadOnly = false;
            txtMediaID.Enabled = true;
            txtMediaID.Text = "MED_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            txtFileName.Clear();
            txtMediaURL.Clear();
            txtFileSizeByte.Text = "0";

            if (cboMediaType.Items.Count > 0) cboMediaType.SelectedIndex = 0;
            cboMediaType.Enabled = false; // KHÔNG CHO PHÉP CHỈNH SỬA LOẠI TỆP (Tự động nhận diện khi chọn tệp)

            if (cboArtifact.Items.Count > 0) cboArtifact.SelectedIndex = 0;

            if (cboStep.Items.Count > 0) cboStep.SelectedIndex = 0;
            cboStep.Enabled = true;

            btnUploadSave.Text = "THÊM MEDIA MỚI";
            btnUploadSave.BackColor = Color.Black;
            btnUploadSave.ForeColor = Color.White;

            btnHuy.Visible = false;

            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }
            picPreview.Visible = false;
            axWindowsMediaPlayer1.Visible = false;
            pnlMediaPlayer.Visible = false;

            lblPreviewStatus.Text = "Chưa chọn tệp xem trước";
            lblPreviewStatus.Visible = true;
        }

        private void SwitchToEditMode()
        {
            isEditMode = true;

            txtMediaID.ReadOnly = true;
            txtMediaID.Enabled = true;
            cboMediaType.Enabled = false; // KHÔNG CHO PHÉP CHỈNH SỬA LOẠI TỆP KHI XEM/SỬA MEDIA

            btnUploadSave.Text = "LƯU CHỈNH SỬA";
            btnUploadSave.BackColor = Color.Black;
            btnUploadSave.ForeColor = Color.White;

            btnHuy.Visible = true;
        }

        private void FrmQuanLyMedia_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMediaPreview();
        }
    }
}