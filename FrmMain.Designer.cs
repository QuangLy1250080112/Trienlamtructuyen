namespace Trienlamtructuyen
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            pnlSidebar = new Panel();
            flpNavMenu = new FlowLayoutPanel();
            btnNavUser = new Button();
            btnNavBoSuuTap = new Button();
            btnNavCauChuyen = new Button();
            btnNavTuyenThamQuan = new Button();
            btnNavMedia = new Button();
            btnNavThongKe = new Button();
            btnNavKhamPha = new Button();
            btnNavPhanHoi = new Button();
            btnDangXuat = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
            pnlLineDivider = new Panel();
            pnlContent = new Panel();
            statusStrip = new StatusStrip();
            lblStatusUserInfo = new ToolStripStatusLabel();
            lblStatusTime = new ToolStripStatusLabel();
            timerClock = new System.Windows.Forms.Timer(components);

            pnlSidebar.SuspendLayout();
            flpNavMenu.SuspendLayout();
            pnlLogo.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(240, 240, 240);
            pnlSidebar.Controls.Add(flpNavMenu);
            pnlSidebar.Controls.Add(btnDangXuat);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(180, 296);
            pnlSidebar.TabIndex = 0;
            // 
            // flpNavMenu
            // 
            flpNavMenu.AutoScroll = true;
            flpNavMenu.Controls.Add(btnNavUser);
            flpNavMenu.Controls.Add(btnNavBoSuuTap);
            flpNavMenu.Controls.Add(btnNavCauChuyen);
            flpNavMenu.Controls.Add(btnNavTuyenThamQuan);
            flpNavMenu.Controls.Add(btnNavMedia);
            flpNavMenu.Controls.Add(btnNavThongKe);
            flpNavMenu.Controls.Add(btnNavKhamPha);
            flpNavMenu.Controls.Add(btnNavPhanHoi);
            flpNavMenu.Dock = DockStyle.Fill;
            flpNavMenu.FlowDirection = FlowDirection.TopDown;
            flpNavMenu.Location = new Point(0, 35);
            flpNavMenu.Name = "flpNavMenu";
            flpNavMenu.Size = new Size(180, 233);
            flpNavMenu.TabIndex = 1;
            flpNavMenu.WrapContents = false;
            // 
            // btnNavUser
            // 
            btnNavUser.AccessibleName = "Quản lý User";
            btnNavUser.BackColor = Color.White;
            btnNavUser.FlatAppearance.BorderColor = Color.Black;
            btnNavUser.FlatStyle = FlatStyle.Flat;
            btnNavUser.Font = new Font("Segoe UI", 8F);
            btnNavUser.ForeColor = Color.Black;
            btnNavUser.Location = new Point(1, 1);
            btnNavUser.Margin = new Padding(1);
            btnNavUser.Name = "btnNavUser";
            btnNavUser.Size = new Size(178, 30);
            btnNavUser.TabIndex = 0;
            btnNavUser.Text = "Quản lý User";
            btnNavUser.TextAlign = ContentAlignment.MiddleLeft;
            btnNavUser.UseVisualStyleBackColor = false;
            btnNavUser.Click += btnNavUser_Click;
            btnNavUser.GotFocus += NavButton_GotFocus;
            // 
            // btnNavBoSuuTap
            // 
            btnNavBoSuuTap.AccessibleName = "Bộ sưu tập và hiện vật";
            btnNavBoSuuTap.BackColor = Color.White;
            btnNavBoSuuTap.FlatAppearance.BorderColor = Color.Black;
            btnNavBoSuuTap.FlatStyle = FlatStyle.Flat;
            btnNavBoSuuTap.Font = new Font("Segoe UI", 8F);
            btnNavBoSuuTap.ForeColor = Color.Black;
            btnNavBoSuuTap.Location = new Point(1, 33);
            btnNavBoSuuTap.Margin = new Padding(1);
            btnNavBoSuuTap.Name = "btnNavBoSuuTap";
            btnNavBoSuuTap.Size = new Size(178, 30);
            btnNavBoSuuTap.TabIndex = 1;
            btnNavBoSuuTap.Text = "Bộ sưu tập và hiện vật";
            btnNavBoSuuTap.TextAlign = ContentAlignment.MiddleLeft;
            btnNavBoSuuTap.UseVisualStyleBackColor = false;
            btnNavBoSuuTap.Click += btnNavBoSuuTap_Click;
            btnNavBoSuuTap.GotFocus += NavButton_GotFocus;
            // 
            // btnNavCauChuyen
            // 
            btnNavCauChuyen.AccessibleName = "Biên tập Câu chuyện";
            btnNavCauChuyen.BackColor = Color.White;
            btnNavCauChuyen.FlatAppearance.BorderColor = Color.Black;
            btnNavCauChuyen.FlatStyle = FlatStyle.Flat;
            btnNavCauChuyen.Font = new Font("Segoe UI", 8F);
            btnNavCauChuyen.ForeColor = Color.Black;
            btnNavCauChuyen.Location = new Point(1, 65);
            btnNavCauChuyen.Margin = new Padding(1);
            btnNavCauChuyen.Name = "btnNavCauChuyen";
            btnNavCauChuyen.Size = new Size(178, 30);
            btnNavCauChuyen.TabIndex = 2;
            btnNavCauChuyen.Text = "Biên tập Câu chuyện";
            btnNavCauChuyen.TextAlign = ContentAlignment.MiddleLeft;
            btnNavCauChuyen.UseVisualStyleBackColor = false;
            btnNavCauChuyen.Click += btnNavCauChuyen_Click;
            btnNavCauChuyen.GotFocus += NavButton_GotFocus;
            // 
            // btnNavTuyenThamQuan
            // 
            btnNavTuyenThamQuan.AccessibleName = "Tuyến tham quan";
            btnNavTuyenThamQuan.BackColor = Color.White;
            btnNavTuyenThamQuan.FlatAppearance.BorderColor = Color.Black;
            btnNavTuyenThamQuan.FlatStyle = FlatStyle.Flat;
            btnNavTuyenThamQuan.Font = new Font("Segoe UI", 8F);
            btnNavTuyenThamQuan.ForeColor = Color.Black;
            btnNavTuyenThamQuan.Location = new Point(1, 97);
            btnNavTuyenThamQuan.Margin = new Padding(1);
            btnNavTuyenThamQuan.Name = "btnNavTuyenThamQuan";
            btnNavTuyenThamQuan.Size = new Size(178, 30);
            btnNavTuyenThamQuan.TabIndex = 3;
            btnNavTuyenThamQuan.Text = "Tuyến tham quan";
            btnNavTuyenThamQuan.TextAlign = ContentAlignment.MiddleLeft;
            btnNavTuyenThamQuan.UseVisualStyleBackColor = false;
            btnNavTuyenThamQuan.Click += btnNavTuyenThamQuan_Click;
            btnNavTuyenThamQuan.GotFocus += NavButton_GotFocus;
            // 
            // btnNavMedia
            // 
            btnNavMedia.AccessibleName = "Quản lý Media";
            btnNavMedia.BackColor = Color.White;
            btnNavMedia.FlatAppearance.BorderColor = Color.Black;
            btnNavMedia.FlatStyle = FlatStyle.Flat;
            btnNavMedia.Font = new Font("Segoe UI", 8F);
            btnNavMedia.ForeColor = Color.Black;
            btnNavMedia.Location = new Point(1, 129);
            btnNavMedia.Margin = new Padding(1);
            btnNavMedia.Name = "btnNavMedia";
            btnNavMedia.Size = new Size(178, 30);
            btnNavMedia.TabIndex = 4;
            btnNavMedia.Text = "Quản lý Media";
            btnNavMedia.TextAlign = ContentAlignment.MiddleLeft;
            btnNavMedia.UseVisualStyleBackColor = false;
            btnNavMedia.Click += btnNavMedia_Click;
            btnNavMedia.GotFocus += NavButton_GotFocus;
            // 
            // btnNavThongKe
            // 
            btnNavThongKe.AccessibleName = "Báo cáo Thống kê";
            btnNavThongKe.BackColor = Color.White;
            btnNavThongKe.FlatAppearance.BorderColor = Color.Black;
            btnNavThongKe.FlatStyle = FlatStyle.Flat;
            btnNavThongKe.Font = new Font("Segoe UI", 8F);
            btnNavThongKe.ForeColor = Color.Black;
            btnNavThongKe.Location = new Point(1, 161);
            btnNavThongKe.Margin = new Padding(1);
            btnNavThongKe.Name = "btnNavThongKe";
            btnNavThongKe.Size = new Size(178, 30);
            btnNavThongKe.TabIndex = 5;
            btnNavThongKe.Text = "Báo cáo Thống kê";
            btnNavThongKe.TextAlign = ContentAlignment.MiddleLeft;
            btnNavThongKe.UseVisualStyleBackColor = false;
            btnNavThongKe.Click += btnNavThongKe_Click;
            btnNavThongKe.GotFocus += NavButton_GotFocus;
            // 
            // btnNavKhamPha
            // 
            btnNavKhamPha.AccessibleName = "Khám phá Triển lãm";
            btnNavKhamPha.BackColor = Color.White;
            btnNavKhamPha.FlatAppearance.BorderColor = Color.Black;
            btnNavKhamPha.FlatStyle = FlatStyle.Flat;
            btnNavKhamPha.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnNavKhamPha.ForeColor = Color.Black;
            btnNavKhamPha.Location = new Point(1, 193);
            btnNavKhamPha.Margin = new Padding(1);
            btnNavKhamPha.Name = "btnNavKhamPha";
            btnNavKhamPha.Size = new Size(178, 30);
            btnNavKhamPha.TabIndex = 6;
            btnNavKhamPha.Text = "Khám phá Triển lãm";
            btnNavKhamPha.TextAlign = ContentAlignment.MiddleLeft;
            btnNavKhamPha.UseVisualStyleBackColor = false;
            btnNavKhamPha.Click += btnNavKhamPha_Click;
            btnNavKhamPha.GotFocus += NavButton_GotFocus;
            // 
            // btnNavPhanHoi
            // 
            btnNavPhanHoi.AccessibleName = "Gửi Phản Hồi";
            btnNavPhanHoi.BackColor = Color.White;
            btnNavPhanHoi.FlatAppearance.BorderColor = Color.Black;
            btnNavPhanHoi.FlatStyle = FlatStyle.Flat;
            btnNavPhanHoi.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnNavPhanHoi.ForeColor = Color.Black;
            btnNavPhanHoi.Location = new Point(1, 225);
            btnNavPhanHoi.Margin = new Padding(1);
            btnNavPhanHoi.Name = "btnNavPhanHoi";
            btnNavPhanHoi.Size = new Size(178, 30);
            btnNavPhanHoi.TabIndex = 7;
            btnNavPhanHoi.Text = "Gửi Phản Hồi";
            btnNavPhanHoi.TextAlign = ContentAlignment.MiddleLeft;
            btnNavPhanHoi.UseVisualStyleBackColor = false;
            btnNavPhanHoi.Click += btnNavPhanHoi_Click;
            btnNavPhanHoi.GotFocus += NavButton_GotFocus;
            // 
            // btnDangXuat
            // 
            btnDangXuat.AccessibleName = "Đăng xuất";
            btnDangXuat.BackColor = Color.Black;
            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.FlatAppearance.BorderColor = Color.Black;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(0, 268);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(180, 28);
            btnDangXuat.TabIndex = 8;
            btnDangXuat.Text = "ĐĂNG XUẤT";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            btnDangXuat.GotFocus += NavButton_GotFocus;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.White;
            pnlLogo.BorderStyle = BorderStyle.FixedSingle;
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(180, 35);
            pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLogo.ForeColor = Color.Black;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(178, 33);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "TRIỂN LÃM SỐ";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLineDivider
            // 
            pnlLineDivider.BackColor = Color.Black;
            pnlLineDivider.Dock = DockStyle.Left;
            pnlLineDivider.Location = new Point(180, 0);
            pnlLineDivider.Name = "pnlLineDivider";
            pnlLineDivider.Size = new Size(1, 296);
            pnlLineDivider.TabIndex = 1;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(181, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(579, 296);
            pnlContent.TabIndex = 2;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.White;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatusUserInfo, lblStatusTime });
            statusStrip.Location = new Point(0, 296);
            statusStrip.Name = "statusStrip";
            statusStrip.RenderMode = ToolStripRenderMode.System;
            statusStrip.Size = new Size(760, 24);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 3;
            // 
            // lblStatusUserInfo
            // 
            lblStatusUserInfo.Font = new Font("Segoe UI", 8F);
            lblStatusUserInfo.ForeColor = Color.Black;
            lblStatusUserInfo.Name = "lblStatusUserInfo";
            lblStatusUserInfo.Size = new Size(150, 19);
            lblStatusUserInfo.Text = "Tài khoản: N/A | Vai trò: N/A";
            // 
            // lblStatusTime
            // 
            lblStatusTime.Font = new Font("Segoe UI", 8F);
            lblStatusTime.ForeColor = Color.Black;
            lblStatusTime.Name = "lblStatusTime";
            lblStatusTime.Size = new Size(595, 19);
            lblStatusTime.Spring = true;
            lblStatusTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 320);
            Controls.Add(pnlContent);
            Controls.Add(pnlLineDivider);
            Controls.Add(pnlSidebar);
            Controls.Add(statusStrip);
            Font = new Font("Segoe UI", 8F);
            IsMdiContainer = true;
            KeyPreview = true;
            MinimumSize = new Size(760, 320);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Triển lãm Trực tuyến";
            Load += FrmMain_Load;
            KeyDown += FrmMain_KeyDown;
            pnlSidebar.ResumeLayout(false);
            flpNavMenu.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSidebar;
        private FlowLayoutPanel flpNavMenu;
        private Panel pnlLineDivider;
        private Panel pnlLogo;
        private Label lblLogo;
        private Button btnNavUser;
        private Button btnNavBoSuuTap;
        private Button btnNavCauChuyen;
        private Button btnNavTuyenThamQuan;
        private Button btnNavMedia;
        private Button btnNavThongKe;
        private Button btnNavKhamPha;
        private Button btnNavPhanHoi;
        private Button btnDangXuat;
        private Panel pnlContent;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatusUserInfo;
        private ToolStripStatusLabel lblStatusTime;
        private System.Windows.Forms.Timer timerClock;
    }
}