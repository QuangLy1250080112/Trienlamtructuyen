using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmPhanHoi : Form
    {
        public FrmPhanHoi()
        {
            InitializeComponent();
        }

        private void FrmPhanHoi_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng đang đăng nhập
            txtHoTen.Text = string.IsNullOrEmpty(UserSession.FullName) ? "Khách vãng lai" : UserSession.FullName;
            txtEmail.Text = string.IsNullOrEmpty(UserSession.Email) ? "N/A" : UserSession.Email;

            // Mặc định chọn loại phản hồi đầu tiên
            if (cboLoaiPhanHoi.Items.Count > 0)
            {
                cboLoaiPhanHoi.SelectedIndex = 0;
            }
        }

        private string TaoMaPhanHoiTuDong()
        {
            try
            {
                string query = "SELECT TOP 1 phanHoiID FROM [PhanHoi] ORDER BY phanHoiID DESC";
                object result = Database.ExecuteScalar(query);

                if (result != null && result != DBNull.Value)
                {
                    string lastID = result.ToString() ?? "FB000";
                    if (lastID.StartsWith("FB") && int.TryParse(lastID.Substring(2), out int number))
                    {
                        return $"FB{(number + 1):D3}";
                    }
                }
            }
            catch
            {
                // Dự phòng nếu lỗi truy vấn
            }

            return "FB" + DateTime.Now.ToString("fff");
        }

        private void btnGuiPhanHoi_Click(object sender, EventArgs e)
        {
            string noiDung = txtNoiDung.Text.Trim();
            string loaiPhanHoi = cboLoaiPhanHoi.SelectedItem?.ToString() ?? "Khác";
            int rating = Convert.ToInt32(numRating.Value);
            string email = string.IsNullOrEmpty(UserSession.Email) ? "visitor.anonymous@trienlam.vn" : UserSession.Email;
            string userID = string.IsNullOrEmpty(UserSession.UserID) ? null : UserSession.UserID;

            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung ý kiến phản hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return;
            }

            try
            {
                string phanHoiID = TaoMaPhanHoiTuDong();
                string query = @"INSERT INTO [PhanHoi] ([phanHoiID], [nguoiGuiEmail], [loaiPhanHoi], [rating], [noiDung], [ngayGui], [userID]) 
                                VALUES (@phanHoiID, @nguoiGuiEmail, @loaiPhanHoi, @rating, @noiDung, GETDATE(), @userID)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@phanHoiID", SqlDbType.VarChar) { Value = phanHoiID },
                    new SqlParameter("@nguoiGuiEmail", SqlDbType.VarChar) { Value = email },
                    new SqlParameter("@loaiPhanHoi", SqlDbType.NVarChar) { Value = loaiPhanHoi },
                    new SqlParameter("@rating", SqlDbType.Int) { Value = rating },
                    new SqlParameter("@noiDung", SqlDbType.NVarChar) { Value = noiDung },
                    new SqlParameter("@userID", SqlDbType.VarChar) { Value = (object)userID ?? DBNull.Value }
                };

                int rowsAffected = Database.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cảm ơn bạn đã gửi phản hồi & đánh giá cho triển lãm!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNoiDung.Clear();
                    numRating.Value = 5;
                    cboLoaiPhanHoi.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Không thể gửi phản hồi. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu dữ liệu: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}