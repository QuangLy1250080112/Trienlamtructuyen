namespace Trienlamtructuyen
{
    partial class FrmPhanHoi
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
            pnlContent = new Panel();
            btnGuiPhanHoi = new Button();
            txtNoiDung = new TextBox();
            lblNoiDung = new Label();
            numRating = new NumericUpDown();
            lblRating = new Label();
            cboLoaiPhanHoi = new ComboBox();
            lblLoaiPhanHoi = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 240, 240);
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblTitleHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(579, 40);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitleHeader
            // 
            lblTitleHeader.Dock = DockStyle.Fill;
            lblTitleHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitleHeader.ForeColor = Color.Black;
            lblTitleHeader.Location = new Point(0, 0);
            lblTitleHeader.Name = "lblTitleHeader";
            lblTitleHeader.Size = new Size(577, 38);
            lblTitleHeader.TabIndex = 0;
            lblTitleHeader.Text = "GỬI PHẢN HỒI & ĐÁNH GIÁ TRIỂN LÃM";
            lblTitleHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(btnGuiPhanHoi);
            pnlContent.Controls.Add(txtNoiDung);
            pnlContent.Controls.Add(lblNoiDung);
            pnlContent.Controls.Add(numRating);
            pnlContent.Controls.Add(lblRating);
            pnlContent.Controls.Add(cboLoaiPhanHoi);
            pnlContent.Controls.Add(lblLoaiPhanHoi);
            pnlContent.Controls.Add(txtEmail);
            pnlContent.Controls.Add(lblEmail);
            pnlContent.Controls.Add(txtHoTen);
            pnlContent.Controls.Add(lblHoTen);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 40);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(579, 256);
            pnlContent.TabIndex = 1;
            // 
            // btnGuiPhanHoi
            // 
            btnGuiPhanHoi.BackColor = Color.Black;
            btnGuiPhanHoi.FlatAppearance.BorderColor = Color.Black;
            btnGuiPhanHoi.FlatStyle = FlatStyle.Flat;
            btnGuiPhanHoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuiPhanHoi.ForeColor = Color.White;
            btnGuiPhanHoi.Location = new Point(399, 206);
            btnGuiPhanHoi.Name = "btnGuiPhanHoi";
            btnGuiPhanHoi.Size = new Size(160, 32);
            btnGuiPhanHoi.TabIndex = 10;
            btnGuiPhanHoi.Text = "GỬI PHẢN HỒI";
            btnGuiPhanHoi.UseVisualStyleBackColor = false;
            btnGuiPhanHoi.Click += btnGuiPhanHoi_Click;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Font = new Font("Segoe UI", 8.5F);
            txtNoiDung.Location = new Point(120, 100);
            txtNoiDung.Multiline = true;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.ScrollBars = ScrollBars.Vertical;
            txtNoiDung.Size = new Size(439, 95);
            txtNoiDung.TabIndex = 9;
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblNoiDung.Location = new Point(20, 103);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(95, 15);
            lblNoiDung.TabIndex = 8;
            lblNoiDung.Text = "Nội dung ý kiến:";
            // 
            // numRating
            // 
            numRating.Font = new Font("Segoe UI", 8.5F);
            numRating.Location = new Point(460, 60);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(99, 23);
            numRating.TabIndex = 7;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRating.Location = new Point(375, 63);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(82, 15);
            lblRating.TabIndex = 6;
            lblRating.Text = "Đánh giá (Sao):";
            // 
            // cboLoaiPhanHoi
            // 
            cboLoaiPhanHoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhanHoi.Font = new Font("Segoe UI", 8.5F);
            cboLoaiPhanHoi.FormattingEnabled = true;
            cboLoaiPhanHoi.Items.AddRange(new object[] { "Giao diện & Trải nghiệm", "Góp ý nội dung", "Báo lỗi kỹ thuật", "Khác" });
            cboLoaiPhanHoi.Location = new Point(120, 60);
            cboLoaiPhanHoi.Name = "cboLoaiPhanHoi";
            cboLoaiPhanHoi.Size = new Size(230, 21);
            cboLoaiPhanHoi.TabIndex = 5;
            // 
            // lblLoaiPhanHoi
            // 
            lblLoaiPhanHoi.AutoSize = true;
            lblLoaiPhanHoi.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLoaiPhanHoi.Location = new Point(20, 63);
            lblLoaiPhanHoi.Name = "lblLoaiPhanHoi";
            lblLoaiPhanHoi.Size = new Size(84, 15);
            lblLoaiPhanHoi.TabIndex = 4;
            lblLoaiPhanHoi.Text = "Loại phản hồi:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(245, 245, 245);
            txtEmail.Font = new Font("Segoe UI", 8.5F);
            txtEmail.Location = new Point(360, 20);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(199, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 8.5F);
            lblEmail.Location = new Point(315, 23);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtHoTen
            // 
            txtHoTen.BackColor = Color.FromArgb(245, 245, 245);
            txtHoTen.Font = new Font("Segoe UI", 8.5F);
            txtHoTen.Location = new Point(120, 20);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(180, 23);
            txtHoTen.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 8.5F);
            lblHoTen.Location = new Point(20, 23);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(94, 15);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Người gửi (Bạn):";
            // 
            // FrmPhanHoi
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(579, 296);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 8F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPhanHoi";
            Text = "Phản hồi triển lãm";
            Load += FrmPhanHoi_Load;
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitleHeader;
        private Panel pnlContent;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblLoaiPhanHoi;
        private ComboBox cboLoaiPhanHoi;
        private Label lblRating;
        private NumericUpDown numRating;
        private Label lblNoiDung;
        private TextBox txtNoiDung;
        private Button btnGuiPhanHoi;
    }
}