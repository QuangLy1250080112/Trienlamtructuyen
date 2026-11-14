using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient; // Nếu dự án dùng System.Data.SqlClient, hãy đổi thành: using System.Data.SqlClient;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void SwitchTab(int tabIndex)
        {
            if (tabIndex >= 0 && tabIndex < tabControlAuth.TabCount)
            {
                tabControlAuth.SelectedIndex = tabIndex;
                if (tabIndex == 0)
                {
                    txtUsername.Focus();
                }
                else if (tabIndex == 1)
                {
                    txtEmailReset.Focus();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraDangNhap(username, password))
            {
                MessageBox.Show($"Đăng nhập thành công!\nChào mừng {UserSession.FullName} ({UserSession.Role}).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng Form Đăng nhập để quay lại FrmMain đã mở trước đó
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private bool KiemTraDangNhap(string username, string password)
        {
            try
            {
                string hashedPassword = GetMd5Hash(password);

                string query = "SELECT userID, username, fullName, email, role FROM [User] WHERE username = @username AND [password] = @password";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", SqlDbType.VarChar) { Value = username },
                    new SqlParameter("@password", SqlDbType.VarChar) { Value = hashedPassword }
                };

                DataTable dt = Database.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    UserSession.UserID = row["userID"].ToString() ?? string.Empty;
                    UserSession.Username = row["username"].ToString() ?? string.Empty;
                    UserSession.FullName = row["fullName"].ToString() ?? string.Empty;
                    UserSession.Email = row["email"].ToString() ?? string.Empty;
                    UserSession.Role = row["role"].ToString() ?? string.Empty;

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn CSDL: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            string email = txtEmailReset.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email để khôi phục mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT COUNT(*) FROM [User] WHERE email = @email";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@email", SqlDbType.VarChar) { Value = email }
                };

                object? result = Database.ExecuteScalar(query, parameters);
                int count = result != null ? Convert.ToInt32(result) : 0;

                if (count > 0)
                {
                    MessageBox.Show("Yêu cầu khôi phục mật khẩu đã được gửi! Vui lòng kiểm tra hộp thư Email.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmailReset.Clear();
                    SwitchTab(0);
                }
                else
                {
                    MessageBox.Show("Email không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        private void lblQuenMatKhau_Click(object sender, EventArgs e)
        {
            SwitchTab(1);
        }

        private void lblQuayLaiDangNhap_Click(object sender, EventArgs e)
        {
            SwitchTab(0);
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}