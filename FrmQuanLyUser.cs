using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmQuanLyUser : Form
    {
        public FrmQuanLyUser()
        {
            InitializeComponent();
        }

        private void FrmQuanLyUser_Load(object sender, EventArgs e)
        {
            InitComboBoxes();
            LoadDataUser();
        }

        private void InitComboBoxes()
        {
            string[] roles = { "Admin", "Curator", "Visitor" };

            cboRole.Items.Clear();
            cboRole.Items.AddRange(roles);
            cboRole.SelectedIndex = 0;

            cboRoleFilter.Items.Clear();
            cboRoleFilter.Items.Add("Tất cả");
            cboRoleFilter.Items.AddRange(roles);
            cboRoleFilter.SelectedIndex = 0;
        }

        private void LoadDataUser(string keyword = "", string roleFilter = "Tất cả")
        {
            try
            {
                string query = "SELECT userID AS [Mã User], username AS [Tên đăng nhập], fullName AS [Họ và tên], email AS [Email], role AS [Vai trò] FROM [User] WHERE 1=1";

                var parametersList = new System.Collections.Generic.List<SqlParameter>();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (username LIKE @keyword OR fullName LIKE @keyword OR email LIKE @keyword OR userID LIKE @keyword)";
                    parametersList.Add(new SqlParameter("@keyword", $"%{keyword}%"));
                }

                if (roleFilter != "Tất cả" && !string.IsNullOrEmpty(roleFilter))
                {
                    query += " AND role = @role";
                    parametersList.Add(new SqlParameter("@role", roleFilter));
                }

                query += " ORDER BY userID ASC";

                DataTable dt = Database.ExecuteQuery(query, parametersList.ToArray());
                dgvUser.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvUser.Rows.Count)
            {
                DataGridViewRow row = dgvUser.Rows[e.RowIndex];

                txtUserID.Text = row.Cells["Mã User"].Value?.ToString();
                txtUsername.Text = row.Cells["Tên đăng nhập"].Value?.ToString();
                txtFullName.Text = row.Cells["Họ và tên"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                cboRole.SelectedItem = row.Cells["Vai trò"].Value?.ToString();

                txtUserID.ReadOnly = true;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isAdding: true)) return;

            try
            {
                string query = "INSERT INTO [User] (userID, username, fullName, email, role) VALUES (@userID, @username, @fullName, @email, @role)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@userID", txtUserID.Text.Trim()),
                    new SqlParameter("@username", txtUsername.Text.Trim()),
                    new SqlParameter("@fullName", txtFullName.Text.Trim()),
                    new SqlParameter("@email", txtEmail.Text.Trim()),
                    new SqlParameter("@role", cboRole.SelectedItem?.ToString() ?? "Visitor")
                };

                int result = Database.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm người dùng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataUser();
                    ClearInputForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm người dùng (có thể trùng Mã User, Username hoặc Email):\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(isAdding: false)) return;

            try
            {
                string query = "UPDATE [User] SET username = @username, fullName = @fullName, email = @email, role = @role WHERE userID = @userID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@userID", txtUserID.Text.Trim()),
                    new SqlParameter("@username", txtUsername.Text.Trim()),
                    new SqlParameter("@fullName", txtFullName.Text.Trim()),
                    new SqlParameter("@email", txtEmail.Text.Trim()),
                    new SqlParameter("@role", cboRole.SelectedItem?.ToString() ?? "Visitor")
                };

                int result = Database.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataUser();
                    ClearInputForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật người dùng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();

            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userID.Equals(UserSession.UserID, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không thể xóa tài khoản hiện đang đăng nhập vào hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng [Mã: {userID}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM [User] WHERE userID = @userID";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@userID", userID)
                    };

                    int result = Database.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataUser();
                        ClearInputForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa người dùng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchUser.Text.Trim();
            string roleFilter = cboRoleFilter.SelectedItem?.ToString() ?? "Tất cả";
            LoadDataUser(keyword, roleFilter);
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtSearchUser.Clear();
            cboRoleFilter.SelectedIndex = 0;
            LoadDataUser();
        }

        private void ClearInputForm()
        {
            txtUserID.Clear();
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            cboRole.SelectedIndex = 0;

            txtUserID.ReadOnly = false;
            txtUserID.Focus();
        }

        private bool ValidateInput(bool isAdding)
        {
            if (isAdding && string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập Mã người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserID.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }
    }
}