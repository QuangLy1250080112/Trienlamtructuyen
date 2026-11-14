namespace Trienlamtructuyen
{
    partial class FrmBaoCaoThongKe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            pnlFilter = new Panel();
            btnXuatReport = new Button();
            btnThongKe = new Button();
            cboLoaiBaoCao = new ComboBox();
            lblLoaiBaoCao = new Label();
            pnlMetrics = new TableLayoutPanel();
            pnlCardPhanHoi = new Panel();
            lblValPhanHoi = new Label();
            lblTitlePhanHoi = new Label();
            pnlCardStorage = new Panel();
            lblValStorage = new Label();
            lblTitleStorage = new Label();
            pnlCardNodes = new Panel();
            lblValNodes = new Label();
            lblTitleNodes = new Label();
            pnlCardArtifacts = new Panel();
            lblValArtifacts = new Label();
            lblTitleArtifacts = new Label();
            splitBody = new SplitContainer();
            pnlChartArea = new Panel();
            lblChartTitle = new Label();
            splitGridDetails = new SplitContainer();
            dgvThongKeChiTiet = new DataGridView();
            pnlSubDetail = new Panel();
            lblSubTitle = new Label();
            dgvSubDetail = new DataGridView();

            pnlFilter.SuspendLayout();
            pnlMetrics.SuspendLayout();
            pnlCardPhanHoi.SuspendLayout();
            pnlCardStorage.SuspendLayout();
            pnlCardNodes.SuspendLayout();
            pnlCardArtifacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitBody).BeginInit();
            splitBody.Panel1.SuspendLayout();
            splitBody.Panel2.SuspendLayout();
            splitBody.SuspendLayout();
            pnlChartArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitGridDetails).BeginInit();
            splitGridDetails.Panel1.SuspendLayout();
            splitGridDetails.Panel2.SuspendLayout();
            splitGridDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKeChiTiet).BeginInit();
            pnlSubDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubDetail).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(btnXuatReport);
            pnlFilter.Controls.Add(btnThongKe);
            pnlFilter.Controls.Add(cboLoaiBaoCao);
            pnlFilter.Controls.Add(lblLoaiBaoCao);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Font = new Font("Segoe UI", 8F);
            pnlFilter.Location = new Point(4, 4);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(892, 34);
            pnlFilter.TabIndex = 0;
            // 
            // btnXuatReport
            // 
            btnXuatReport.BackColor = Color.White;
            btnXuatReport.FlatAppearance.BorderColor = Color.Black;
            btnXuatReport.FlatStyle = FlatStyle.Flat;
            btnXuatReport.Font = new Font("Segoe UI", 8F);
            btnXuatReport.ForeColor = Color.Black;
            btnXuatReport.Location = new Point(402, 4);
            btnXuatReport.Name = "btnXuatReport";
            btnXuatReport.Size = new Size(85, 24);
            btnXuatReport.TabIndex = 7;
            btnXuatReport.Text = "Xuất Excel";
            btnXuatReport.UseVisualStyleBackColor = false;
            btnXuatReport.Click += btnXuatReport_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.White;
            btnThongKe.FlatAppearance.BorderColor = Color.Black;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.Black;
            btnThongKe.Location = new Point(320, 4);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(76, 24);
            btnThongKe.TabIndex = 6;
            btnThongKe.Text = "Làm mới";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // cboLoaiBaoCao
            // 
            cboLoaiBaoCao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiBaoCao.FormattingEnabled = true;
            cboLoaiBaoCao.Location = new Point(62, 5);
            cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            cboLoaiBaoCao.Size = new Size(250, 21);
            cboLoaiBaoCao.TabIndex = 5;
            cboLoaiBaoCao.SelectedIndexChanged += cboLoaiBaoCao_SelectedIndexChanged;
            // 
            // lblLoaiBaoCao
            // 
            lblLoaiBaoCao.AutoSize = true;
            lblLoaiBaoCao.ForeColor = Color.Black;
            lblLoaiBaoCao.Location = new Point(10, 9);
            lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            lblLoaiBaoCao.Size = new Size(50, 13);
            lblLoaiBaoCao.TabIndex = 4;
            lblLoaiBaoCao.Text = "Báo cáo:";
            // 
            // pnlMetrics
            // 
            pnlMetrics.ColumnCount = 4;
            pnlMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlMetrics.Controls.Add(pnlCardPhanHoi, 3, 0);
            pnlMetrics.Controls.Add(pnlCardStorage, 2, 0);
            pnlMetrics.Controls.Add(pnlCardNodes, 1, 0);
            pnlMetrics.Controls.Add(pnlCardArtifacts, 0, 0);
            pnlMetrics.Dock = DockStyle.Top;
            pnlMetrics.Location = new Point(4, 38);
            pnlMetrics.Name = "pnlMetrics";
            pnlMetrics.RowCount = 1;
            pnlMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlMetrics.Size = new Size(892, 48);
            pnlMetrics.TabIndex = 1;
            // 
            // pnlCardPhanHoi
            // 
            pnlCardPhanHoi.BackColor = Color.White;
            pnlCardPhanHoi.BorderStyle = BorderStyle.FixedSingle;
            pnlCardPhanHoi.Controls.Add(lblValPhanHoi);
            pnlCardPhanHoi.Controls.Add(lblTitlePhanHoi);
            pnlCardPhanHoi.Dock = DockStyle.Fill;
            pnlCardPhanHoi.Location = new Point(672, 2);
            pnlCardPhanHoi.Margin = new Padding(3, 2, 3, 2);
            pnlCardPhanHoi.Name = "pnlCardPhanHoi";
            pnlCardPhanHoi.Size = new Size(217, 44);
            pnlCardPhanHoi.TabIndex = 3;
            // 
            // lblValPhanHoi
            // 
            lblValPhanHoi.AutoSize = true;
            lblValPhanHoi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblValPhanHoi.ForeColor = Color.Black;
            lblValPhanHoi.Location = new Point(6, 19);
            lblValPhanHoi.Name = "lblValPhanHoi";
            lblValPhanHoi.Size = new Size(18, 20);
            lblValPhanHoi.TabIndex = 1;
            lblValPhanHoi.Text = "0";
            // 
            // lblTitlePhanHoi
            // 
            lblTitlePhanHoi.AutoSize = true;
            lblTitlePhanHoi.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitlePhanHoi.ForeColor = Color.DimGray;
            lblTitlePhanHoi.Location = new Point(6, 4);
            lblTitlePhanHoi.Name = "lblTitlePhanHoi";
            lblTitlePhanHoi.Size = new Size(107, 12);
            lblTitlePhanHoi.TabIndex = 0;
            lblTitlePhanHoi.Text = "PHẢN HỒI NGƯỜI DÙNG";
            // 
            // pnlCardStorage
            // 
            pnlCardStorage.BackColor = Color.White;
            pnlCardStorage.BorderStyle = BorderStyle.FixedSingle;
            pnlCardStorage.Controls.Add(lblValStorage);
            pnlCardStorage.Controls.Add(lblTitleStorage);
            pnlCardStorage.Dock = DockStyle.Fill;
            pnlCardStorage.Location = new Point(449, 2);
            pnlCardStorage.Margin = new Padding(3, 2, 3, 2);
            pnlCardStorage.Name = "pnlCardStorage";
            pnlCardStorage.Size = new Size(217, 44);
            pnlCardStorage.TabIndex = 2;
            // 
            // lblValStorage
            // 
            lblValStorage.AutoSize = true;
            lblValStorage.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblValStorage.ForeColor = Color.Black;
            lblValStorage.Location = new Point(6, 19);
            lblValStorage.Name = "lblValStorage";
            lblValStorage.Size = new Size(47, 20);
            lblValStorage.TabIndex = 1;
            lblValStorage.Text = "0 MB";
            // 
            // lblTitleStorage
            // 
            lblTitleStorage.AutoSize = true;
            lblTitleStorage.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitleStorage.ForeColor = Color.DimGray;
            lblTitleStorage.Location = new Point(6, 4);
            lblTitleStorage.Name = "lblTitleStorage";
            lblTitleStorage.Size = new Size(108, 12);
            lblTitleStorage.TabIndex = 0;
            lblTitleStorage.Text = "DUNG LƯỢNG MEDIA";
            // 
            // pnlCardNodes
            // 
            pnlCardNodes.BackColor = Color.White;
            pnlCardNodes.BorderStyle = BorderStyle.FixedSingle;
            pnlCardNodes.Controls.Add(lblValNodes);
            pnlCardNodes.Controls.Add(lblTitleNodes);
            pnlCardNodes.Dock = DockStyle.Fill;
            pnlCardNodes.Location = new Point(226, 2);
            pnlCardNodes.Margin = new Padding(3, 2, 3, 2);
            pnlCardNodes.Name = "pnlCardNodes";
            pnlCardNodes.Size = new Size(217, 44);
            pnlCardNodes.TabIndex = 1;
            // 
            // lblValNodes
            // 
            lblValNodes.AutoSize = true;
            lblValNodes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblValNodes.ForeColor = Color.Black;
            lblValNodes.Location = new Point(6, 19);
            lblValNodes.Name = "lblValNodes";
            lblValNodes.Size = new Size(18, 20);
            lblValNodes.TabIndex = 1;
            lblValNodes.Text = "0";
            // 
            // lblTitleNodes
            // 
            lblTitleNodes.AutoSize = true;
            lblTitleNodes.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitleNodes.ForeColor = Color.DimGray;
            lblTitleNodes.Location = new Point(6, 4);
            lblTitleNodes.Name = "lblTitleNodes";
            lblTitleNodes.Size = new Size(94, 12);
            lblTitleNodes.TabIndex = 0;
            lblTitleNodes.Text = "SỐ ĐIỂM DỪNG";
            // 
            // pnlCardArtifacts
            // 
            pnlCardArtifacts.BackColor = Color.White;
            pnlCardArtifacts.BorderStyle = BorderStyle.FixedSingle;
            pnlCardArtifacts.Controls.Add(lblValArtifacts);
            pnlCardArtifacts.Controls.Add(lblTitleArtifacts);
            pnlCardArtifacts.Dock = DockStyle.Fill;
            pnlCardArtifacts.Location = new Point(3, 2);
            pnlCardArtifacts.Margin = new Padding(3, 2, 3, 2);
            pnlCardArtifacts.Name = "pnlCardArtifacts";
            pnlCardArtifacts.Size = new Size(217, 44);
            pnlCardArtifacts.TabIndex = 0;
            // 
            // lblValArtifacts
            // 
            lblValArtifacts.AutoSize = true;
            lblValArtifacts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblValArtifacts.ForeColor = Color.Black;
            lblValArtifacts.Location = new Point(6, 19);
            lblValArtifacts.Name = "lblValArtifacts";
            lblValArtifacts.Size = new Size(18, 20);
            lblValArtifacts.TabIndex = 1;
            lblValArtifacts.Text = "0";
            // 
            // lblTitleArtifacts
            // 
            lblTitleArtifacts.AutoSize = true;
            lblTitleArtifacts.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitleArtifacts.ForeColor = Color.DimGray;
            lblTitleArtifacts.Location = new Point(6, 4);
            lblTitleArtifacts.Name = "lblTitleArtifacts";
            lblTitleArtifacts.Size = new Size(103, 12);
            lblTitleArtifacts.TabIndex = 0;
            lblTitleArtifacts.Text = "TỔNG SỐ HIỆN VẬT";
            // 
            // splitBody
            // 
            splitBody.Dock = DockStyle.Fill;
            splitBody.Location = new Point(4, 86);
            splitBody.Name = "splitBody";
            // 
            // splitBody.Panel1
            // 
            splitBody.Panel1.Controls.Add(pnlChartArea);
            // 
            // splitBody.Panel2
            // 
            splitBody.Panel2.Controls.Add(splitGridDetails);
            splitBody.Size = new Size(892, 430);
            splitBody.SplitterDistance = 330;
            splitBody.TabIndex = 2;
            // 
            // pnlChartArea
            // 
            pnlChartArea.BackColor = Color.White;
            pnlChartArea.BorderStyle = BorderStyle.FixedSingle;
            pnlChartArea.Controls.Add(lblChartTitle);
            pnlChartArea.Dock = DockStyle.Fill;
            pnlChartArea.Location = new Point(0, 0);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Size = new Size(330, 430);
            pnlChartArea.TabIndex = 0;
            pnlChartArea.Paint += pnlChartArea_Paint;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.Black;
            lblChartTitle.Location = new Point(6, 6);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(103, 13);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Biểu đồ thống kê";
            // 
            // splitGridDetails
            // 
            splitGridDetails.Dock = DockStyle.Fill;
            splitGridDetails.Location = new Point(0, 0);
            splitGridDetails.Name = "splitGridDetails";
            splitGridDetails.Orientation = Orientation.Horizontal;
            // 
            // splitGridDetails.Panel1
            // 
            splitGridDetails.Panel1.Controls.Add(dgvThongKeChiTiet);
            // 
            // splitGridDetails.Panel2
            // 
            splitGridDetails.Panel2.Controls.Add(pnlSubDetail);
            splitGridDetails.Size = new Size(558, 430);
            splitGridDetails.SplitterDistance = 200;
            splitGridDetails.TabIndex = 0;
            // 
            // dgvThongKeChiTiet
            // 
            dgvThongKeChiTiet.AllowUserToAddRows = false;
            dgvThongKeChiTiet.AllowUserToDeleteRows = false;
            dgvThongKeChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKeChiTiet.BackgroundColor = Color.White;
            dgvThongKeChiTiet.BorderStyle = BorderStyle.FixedSingle;
            dgvThongKeChiTiet.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvThongKeChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvThongKeChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 220, 220);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvThongKeChiTiet.DefaultCellStyle = dataGridViewCellStyle2;
            dgvThongKeChiTiet.Dock = DockStyle.Fill;
            dgvThongKeChiTiet.EnableHeadersVisualStyles = false;
            dgvThongKeChiTiet.GridColor = Color.Black;
            dgvThongKeChiTiet.Location = new Point(0, 0);
            dgvThongKeChiTiet.Name = "dgvThongKeChiTiet";
            dgvThongKeChiTiet.ReadOnly = true;
            dgvThongKeChiTiet.RowHeadersVisible = false;
            dgvThongKeChiTiet.RowTemplate.Height = 22;
            dgvThongKeChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKeChiTiet.Size = new Size(558, 200);
            dgvThongKeChiTiet.TabIndex = 0;
            dgvThongKeChiTiet.CellClick += dgvThongKeChiTiet_CellClick;
            // 
            // pnlSubDetail
            // 
            pnlSubDetail.Controls.Add(dgvSubDetail);
            pnlSubDetail.Controls.Add(lblSubTitle);
            pnlSubDetail.Dock = DockStyle.Fill;
            pnlSubDetail.Location = new Point(0, 0);
            pnlSubDetail.Name = "pnlSubDetail";
            pnlSubDetail.Size = new Size(558, 226);
            pnlSubDetail.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            lblSubTitle.BackColor = Color.FromArgb(240, 240, 240);
            lblSubTitle.BorderStyle = BorderStyle.FixedSingle;
            lblSubTitle.Dock = DockStyle.Top;
            lblSubTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSubTitle.ForeColor = Color.Black;
            lblSubTitle.Location = new Point(0, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Padding = new Padding(4, 3, 0, 0);
            lblSubTitle.Size = new Size(558, 24);
            lblSubTitle.TabIndex = 0;
            lblSubTitle.Text = "CHI TIẾT DANH SÁCH";
            // 
            // dgvSubDetail
            // 
            dgvSubDetail.AllowUserToAddRows = false;
            dgvSubDetail.AllowUserToDeleteRows = false;
            dgvSubDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubDetail.BackgroundColor = Color.White;
            dgvSubDetail.BorderStyle = BorderStyle.FixedSingle;
            dgvSubDetail.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSubDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSubDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 8F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(220, 220, 220);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSubDetail.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSubDetail.Dock = DockStyle.Fill;
            dgvSubDetail.EnableHeadersVisualStyles = false;
            dgvSubDetail.GridColor = Color.Black;
            dgvSubDetail.Location = new Point(0, 24);
            dgvSubDetail.Name = "dgvSubDetail";
            dgvSubDetail.ReadOnly = true;
            dgvSubDetail.RowHeadersVisible = false;
            dgvSubDetail.RowTemplate.Height = 22;
            dgvSubDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubDetail.Size = new Size(558, 202);
            dgvSubDetail.TabIndex = 1;
            // 
            // FrmBaoCaoThongKe
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 520);
            Controls.Add(splitBody);
            Controls.Add(pnlMetrics);
            Controls.Add(pnlFilter);
            Font = new Font("Segoe UI", 8F);
            MinimumSize = new Size(800, 400);
            Name = "FrmBaoCaoThongKe";
            Padding = new Padding(4);
            Text = "Báo Cáo Thống Kê";
            Load += FrmBaoCaoThongKe_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlMetrics.ResumeLayout(false);
            pnlCardPhanHoi.ResumeLayout(false);
            pnlCardPhanHoi.PerformLayout();
            pnlCardStorage.ResumeLayout(false);
            pnlCardStorage.PerformLayout();
            pnlCardNodes.ResumeLayout(false);
            pnlCardNodes.PerformLayout();
            pnlCardArtifacts.ResumeLayout(false);
            pnlCardArtifacts.PerformLayout();
            splitBody.Panel1.ResumeLayout(false);
            splitBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitBody).EndInit();
            splitBody.ResumeLayout(false);
            pnlChartArea.ResumeLayout(false);
            pnlChartArea.PerformLayout();
            splitGridDetails.Panel1.ResumeLayout(false);
            splitGridDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitGridDetails).EndInit();
            splitGridDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongKeChiTiet).EndInit();
            pnlSubDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilter;
        private Label lblLoaiBaoCao;
        private ComboBox cboLoaiBaoCao;
        private Button btnThongKe;
        private Button btnXuatReport;

        private TableLayoutPanel pnlMetrics;
        private Panel pnlCardArtifacts;
        private Label lblTitleArtifacts;
        private Label lblValArtifacts;

        private Panel pnlCardNodes;
        private Label lblTitleNodes;
        private Label lblValNodes;

        private Panel pnlCardStorage;
        private Label lblTitleStorage;
        private Label lblValStorage;

        private Panel pnlCardPhanHoi;
        private Label lblTitlePhanHoi;
        private Label lblValPhanHoi;

        private SplitContainer splitBody;
        private Panel pnlChartArea;
        private Label lblChartTitle;

        private SplitContainer splitGridDetails;
        private DataGridView dgvThongKeChiTiet;
        private Panel pnlSubDetail;
        private Label lblSubTitle;
        private DataGridView dgvSubDetail;
    }
}