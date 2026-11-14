namespace Trienlamtructuyen
{
    partial class FrmDangNhap
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
            pnlHeader = new Panel();
            lblTitleHeader = new Label();
            tabControlAuth = new TabControl();
            tabDangNhap = new TabPage();
            lblQuenMatKhau = new Label();
            chkShowPass = new CheckBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            tabQuenMatKhau = new TabPage();
            lblQuayLaiDangNhap = new Label();
            btnGuiYeuCau = new Button();
            txtEmailReset = new TextBox();
            lblEmailReset = new Label();

            pnlHeader.SuspendLayout();
            tabControlAuth.SuspendLayout();
            tabDangNhap.SuspendLayout();
            tabQuenMatKhau.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblTitleHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(400, 36);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitleHeader
            // 
            lblTitleHeader.Dock = DockStyle.Fill;
            lblTitleHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTitleHeader.ForeColor = Color.Black;
            lblTitleHeader.Location = new Point(0, 0);
            lblTitleHeader.Name = "lblTitleHeader";
            lblTitleHeader.Size = new Size(398, 34);
            lblTitleHeader.TabIndex = 0;
            lblTitleHeader.Text = "HỆ THỐNG TRIỂN LÃM SỐ - ĐĂNG NHẬP";
            lblTitleHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControlAuth
            // 
            tabControlAuth.Controls.Add(tabDangNhap);
            tabControlAuth.Controls.Add(tabQuenMatKhau);
            tabControlAuth.Dock = DockStyle.Fill;
            tabControlAuth.ItemSize = new Size(0, 1);
            tabControlAuth.Location = new Point(0, 36);
            tabControlAuth.Name = "tabControlAuth";
            tabControlAuth.SelectedIndex = 0;
            tabControlAuth.Size = new Size(400, 224);
            tabControlAuth.SizeMode = TabSizeMode.Fixed;
            tabControlAuth.TabIndex = 1;
            // 
            // tabDangNhap
            // 
            tabDangNhap.BackColor = Color.White;
            tabDangNhap.Controls.Add(lblQuenMatKhau);
            tabDangNhap.Controls.Add(chkShowPass);
            tabDangNhap.Controls.Add(btnLogin);
            tabDangNhap.Controls.Add(txtPassword);
            tabDangNhap.Controls.Add(lblPassword);
            tabDangNhap.Controls.Add(txtUsername);
            tabDangNhap.Controls.Add(lblUsername);
            tabDangNhap.Location = new Point(4, 5);
            tabDangNhap.Name = "tabDangNhap";
            tabDangNhap.Padding = new Padding(20, 10, 20, 10);
            tabDangNhap.Size = new Size(392, 215);
            tabDangNhap.TabIndex = 0;
            tabDangNhap.Text = "Đăng Nhập";
            // 
            // lblQuenMatKhau
            // 
            lblQuenMatKhau.AutoSize = true;
            lblQuenMatKhau.Cursor = Cursors.Hand;
            lblQuenMatKhau.Font = new Font("Segoe UI", 8F, FontStyle.Underline);
            lblQuenMatKhau.ForeColor = Color.Black;
            lblQuenMatKhau.Location = new Point(275, 115);
            lblQuenMatKhau.Name = "lblQuenMatKhau";
            lblQuenMatKhau.Size = new Size(93, 13);
            lblQuenMatKhau.TabIndex = 0;
            lblQuenMatKhau.Text = "Quên mật khẩu?";
            lblQuenMatKhau.Click += lblQuenMatKhau_Click;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Font = new Font("Segoe UI", 8F);
            chkShowPass.Location = new Point(20, 114);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(118, 17);
            chkShowPass.TabIndex = 3;
            chkShowPass.Text = "Hiển thị mật khẩu";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.FlatAppearance.BorderColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(20, 148);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(348, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 8.5F);
            txtPassword.Location = new Point(20, 80);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(348, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 8F);
            lblPassword.Location = new Point(20, 62);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(59, 13);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 8.5F);
            txtUsername.Location = new Point(20, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(348, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 8F);
            lblUsername.Location = new Point(20, 14);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(88, 13);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // tabQuenMatKhau
            // 
            tabQuenMatKhau.BackColor = Color.White;
            tabQuenMatKhau.Controls.Add(lblQuayLaiDangNhap);
            tabQuenMatKhau.Controls.Add(btnGuiYeuCau);
            tabQuenMatKhau.Controls.Add(txtEmailReset);
            tabQuenMatKhau.Controls.Add(lblEmailReset);
            tabQuenMatKhau.Location = new Point(4, 5);
            tabQuenMatKhau.Name = "tabQuenMatKhau";
            tabQuenMatKhau.Padding = new Padding(20, 10, 20, 10);
            tabQuenMatKhau.Size = new Size(392, 215);
            tabQuenMatKhau.TabIndex = 1;
            tabQuenMatKhau.Text = "Quên Mật Khẩu";
            // 
            // lblQuayLaiDangNhap
            // 
            lblQuayLaiDangNhap.AutoSize = true;
            lblQuayLaiDangNhap.Cursor = Cursors.Hand;
            lblQuayLaiDangNhap.Font = new Font("Segoe UI", 8F, FontStyle.Underline);
            lblQuayLaiDangNhap.ForeColor = Color.Black;
            lblQuayLaiDangNhap.Location = new Point(135, 130);
            lblQuayLaiDangNhap.Name = "lblQuayLaiDangNhap";
            lblQuayLaiDangNhap.Size = new Size(122, 13);
            lblQuayLaiDangNhap.TabIndex = 0;
            lblQuayLaiDangNhap.Text = "« Quay lại Đăng nhập";
            lblQuayLaiDangNhap.Click += lblQuayLaiDangNhap_Click;
            // 
            // btnGuiYeuCau
            // 
            btnGuiYeuCau.BackColor = Color.Black;
            btnGuiYeuCau.FlatAppearance.BorderColor = Color.Black;
            btnGuiYeuCau.FlatStyle = FlatStyle.Flat;
            btnGuiYeuCau.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGuiYeuCau.ForeColor = Color.White;
            btnGuiYeuCau.Location = new Point(20, 85);
            btnGuiYeuCau.Name = "btnGuiYeuCau";
            btnGuiYeuCau.Size = new Size(348, 30);
            btnGuiYeuCau.TabIndex = 2;
            btnGuiYeuCau.Text = "GỬI YÊU CẦU KHÔI PHỤC";
            btnGuiYeuCau.UseVisualStyleBackColor = false;
            btnGuiYeuCau.Click += btnGuiYeuCau_Click;
            // 
            // txtEmailReset
            // 
            txtEmailReset.Font = new Font("Segoe UI", 8.5F);
            txtEmailReset.Location = new Point(20, 48);
            txtEmailReset.Name = "txtEmailReset";
            txtEmailReset.Size = new Size(348, 23);
            txtEmailReset.TabIndex = 1;
            // 
            // lblEmailReset
            // 
            lblEmailReset.AutoSize = true;
            lblEmailReset.Font = new Font("Segoe UI", 8F);
            lblEmailReset.Location = new Point(20, 25);
            lblEmailReset.Name = "lblEmailReset";
            lblEmailReset.Size = new Size(130, 13);
            lblEmailReset.TabIndex = 3;
            lblEmailReset.Text = "Nhập Email đã đăng ký:";
            // 
            // FrmDangNhap
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 260);
            Controls.Add(tabControlAuth);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 8F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            Load += FrmDangNhap_Load;
            pnlHeader.ResumeLayout(false);
            tabControlAuth.ResumeLayout(false);
            tabDangNhap.ResumeLayout(false);
            tabDangNhap.PerformLayout();
            tabQuenMatKhau.ResumeLayout(false);
            tabQuenMatKhau.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitleHeader;
        private TabControl tabControlAuth;
        private TabPage tabDangNhap;
        private TabPage tabQuenMatKhau;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkShowPass;
        private Button btnLogin;
        private Label lblQuenMatKhau;
        private Label lblEmailReset;
        private TextBox txtEmailReset;
        private Button btnGuiYeuCau;
        private Label lblQuayLaiDangNhap;
    }
}