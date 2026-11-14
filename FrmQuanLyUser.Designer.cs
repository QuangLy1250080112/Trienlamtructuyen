namespace Trienlamtructuyen
{
    partial class FrmQuanLyUser
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTopBar = new Panel();
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearchUser = new TextBox();
            lblRoleFilter = new Label();
            cboRoleFilter = new ComboBox();
            btnSearch = new Button();
            btnResetSearch = new Button();

            pnlInput = new Panel();
            lblUserID = new Label();
            txtUserID = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();

            pnlButtons = new Panel();
            btnAddUser = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            btnClearForm = new Button();

            dgvUser = new DataGridView();

            pnlTopBar.SuspendLayout();
            pnlInput.SuspendLayout();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.White;
            pnlTopBar.BorderStyle = BorderStyle.FixedSingle;
            pnlTopBar.Controls.Add(lblTitle);
            pnlTopBar.Controls.Add(lblSearch);
            pnlTopBar.Controls.Add(txtSearchUser);
            pnlTopBar.Controls.Add(lblRoleFilter);
            pnlTopBar.Controls.Add(cboRoleFilter);
            pnlTopBar.Controls.Add(btnSearch);
            pnlTopBar.Controls.Add(btnResetSearch);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(4, 4);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(752, 32);
            pnlTopBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(4, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(122, 13);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 8F);
            lblSearch.ForeColor = Color.Black;
            lblSearch.Location = new Point(230, 8);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(29, 13);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Tìm:";
            // 
            // txtSearchUser
            // 
            txtSearchUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearchUser.BorderStyle = BorderStyle.FixedSingle;
            txtSearchUser.Font = new Font("Segoe UI", 8F);
            txtSearchUser.Location = new Point(265, 4);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.Size = new Size(140, 22);
            txtSearchUser.TabIndex = 2;
            // 
            // lblRoleFilter
            // 
            lblRoleFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRoleFilter.AutoSize = true;
            lblRoleFilter.Font = new Font("Segoe UI", 8F);
            lblRoleFilter.ForeColor = Color.Black;
            lblRoleFilter.Location = new Point(415, 8);
            lblRoleFilter.Name = "lblRoleFilter";
            lblRoleFilter.Size = new Size(43, 13);
            lblRoleFilter.TabIndex = 3;
            lblRoleFilter.Text = "Lọc vai:";
            // 
            // cboRoleFilter
            // 
            cboRoleFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoleFilter.Font = new Font("Segoe UI", 8F);
            cboRoleFilter.FormattingEnabled = true;
            cboRoleFilter.Location = new Point(460, 4);
            cboRoleFilter.Name = "cboRoleFilter";
            cboRoleFilter.Size = new Size(100, 21);
            cboRoleFilter.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.Black;
            btnSearch.FlatAppearance.BorderColor = Color.Black;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(568, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 23);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnResetSearch
            // 
            btnResetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnResetSearch.BackColor = Color.White;
            btnResetSearch.FlatAppearance.BorderColor = Color.Black;
            btnResetSearch.FlatStyle = FlatStyle.Flat;
            btnResetSearch.Font = new Font("Segoe UI", 7.5F);
            btnResetSearch.ForeColor = Color.Black;
            btnResetSearch.Location = new Point(654, 3);
            btnResetSearch.Name = "btnResetSearch";
            btnResetSearch.Size = new Size(90, 23);
            btnResetSearch.TabIndex = 6;
            btnResetSearch.Text = "Làm mới";
            btnResetSearch.UseVisualStyleBackColor = false;
            btnResetSearch.Click += btnResetSearch_Click;
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.White;
            pnlInput.BorderStyle = BorderStyle.FixedSingle;
            pnlInput.Controls.Add(lblUserID);
            pnlInput.Controls.Add(txtUserID);
            pnlInput.Controls.Add(lblUsername);
            pnlInput.Controls.Add(txtUsername);
            pnlInput.Controls.Add(lblRole);
            pnlInput.Controls.Add(cboRole);
            pnlInput.Controls.Add(lblFullName);
            pnlInput.Controls.Add(txtFullName);
            pnlInput.Controls.Add(lblEmail);
            pnlInput.Controls.Add(txtEmail);
            pnlInput.Dock = DockStyle.Top;
            pnlInput.Font = new Font("Segoe UI", 8F);
            pnlInput.Location = new Point(4, 36);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(752, 58);
            pnlInput.TabIndex = 1;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Location = new Point(4, 8);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(50, 13);
            lblUserID.TabIndex = 0;
            lblUserID.Text = "Mã User:";
            // 
            // txtUserID
            // 
            txtUserID.BorderStyle = BorderStyle.FixedSingle;
            txtUserID.Location = new Point(60, 5);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(110, 22);
            txtUserID.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(180, 8);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(61, 13);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Tài khoản:";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(245, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(160, 22);
            txtUsername.TabIndex = 3;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(420, 8);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(43, 13);
            lblRole.TabIndex = 4;
            lblRole.Text = "Vai trò:";
            // 
            // cboRole
            // 
            cboRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(470, 5);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(275, 21);
            cboRole.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(4, 33);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(60, 13);
            lblFullName.TabIndex = 6;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Location = new Point(60, 30);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(345, 22);
            txtFullName.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(420, 33);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(37, 13);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(470, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(275, 22);
            txtEmail.TabIndex = 9;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.White;
            pnlButtons.Controls.Add(btnAddUser);
            pnlButtons.Controls.Add(btnEditUser);
            pnlButtons.Controls.Add(btnDeleteUser);
            pnlButtons.Controls.Add(btnClearForm);
            pnlButtons.Dock = DockStyle.Top;
            pnlButtons.Font = new Font("Segoe UI", 8F);
            pnlButtons.Location = new Point(4, 94);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(752, 26);
            pnlButtons.TabIndex = 2;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.Black;
            btnAddUser.FlatAppearance.BorderColor = Color.Black;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(0, 2);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(80, 22);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Thêm";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = Color.White;
            btnEditUser.FlatAppearance.BorderColor = Color.Black;
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnEditUser.ForeColor = Color.Black;
            btnEditUser.Location = new Point(86, 2);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(80, 22);
            btnEditUser.TabIndex = 1;
            btnEditUser.Text = "Cập nhật";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.White;
            btnDeleteUser.FlatAppearance.BorderColor = Color.Black;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 7.5F);
            btnDeleteUser.ForeColor = Color.Black;
            btnDeleteUser.Location = new Point(172, 2);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(80, 22);
            btnDeleteUser.TabIndex = 2;
            btnDeleteUser.Text = "Xóa";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnClearForm
            // 
            btnClearForm.BackColor = Color.White;
            btnClearForm.FlatAppearance.BorderColor = Color.Black;
            btnClearForm.FlatStyle = FlatStyle.Flat;
            btnClearForm.Font = new Font("Segoe UI", 7.5F);
            btnClearForm.Location = new Point(258, 2);
            btnClearForm.Name = "btnClearForm";
            btnClearForm.Size = new Size(80, 22);
            btnClearForm.TabIndex = 3;
            btnClearForm.Text = "Nhập mới";
            btnClearForm.UseVisualStyleBackColor = false;
            btnClearForm.Click += btnClearForm_Click;
            // 
            // dgvUser
            // 
            dgvUser.AllowUserToAddRows = false;
            dgvUser.AllowUserToDeleteRows = false;
            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUser.BackgroundColor = Color.White;
            dgvUser.BorderStyle = BorderStyle.Fixed3D;
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Dock = DockStyle.Fill;
            dgvUser.Location = new Point(4, 120);
            dgvUser.MultiSelect = false;
            dgvUser.Name = "dgvUser";
            dgvUser.ReadOnly = true;
            dgvUser.RowHeadersVisible = false;
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.Size = new Size(752, 196);
            dgvUser.TabIndex = 3;
            dgvUser.CellClick += dgvUser_CellClick;
            // 
            // FrmQuanLyUser
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 320);
            Controls.Add(dgvUser);
            Controls.Add(pnlButtons);
            Controls.Add(pnlInput);
            Controls.Add(pnlTopBar);
            Font = new Font("Segoe UI", 8F);
            MinimumSize = new Size(760, 320);
            Name = "FrmQuanLyUser";
            Padding = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Người Dùng & Phân Quyền";
            Load += FrmQuanLyUser_Load;
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopBar;
        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearchUser;
        private Label lblRoleFilter;
        private ComboBox cboRoleFilter;
        private Button btnSearch;
        private Button btnResetSearch;

        private Panel pnlInput;
        private Label lblUserID;
        private TextBox txtUserID;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRole;
        private ComboBox cboRole;

        private Panel pnlButtons;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnClearForm;

        private DataGridView dgvUser;
    }
}