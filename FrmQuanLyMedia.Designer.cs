namespace Trienlamtructuyen
{
    partial class FrmQuanLyMedia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuanLyMedia));
            pnlHeaderBar = new Panel();
            lblFormTitle = new Label();
            pnlMainContainer = new Panel();
            lblMediaID = new Label();
            txtMediaID = new TextBox();
            lblFileName = new Label();
            txtFileName = new TextBox();
            btnChonFile = new Button();
            lblMediaType = new Label();
            cboMediaType = new ComboBox();
            lblFileSize = new Label();
            txtFileSizeByte = new TextBox();
            lblArtifact = new Label();
            cboArtifact = new ComboBox();
            lblStep = new Label();
            cboStep = new ComboBox();
            lblMediaURL = new Label();
            txtMediaURL = new TextBox();
            pnlPreviewBox = new Panel();
            picPreview = new PictureBox();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            pnlMediaPlayer = new Panel();
            btnPlayPauseMedia = new Button();
            btnStopMedia = new Button();
            lblPreviewStatus = new Label();
            pnlActionBar = new Panel();
            btnUploadSave = new Button();
            btnHuy = new Button();
            btnXoa = new Button();
            pnlGridContainer = new Panel();
            dgvMediaList = new DataGridView();

            pnlHeaderBar.SuspendLayout();
            pnlMainContainer.SuspendLayout();
            pnlPreviewBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            pnlMediaPlayer.SuspendLayout();
            pnlActionBar.SuspendLayout();
            pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMediaList).BeginInit();
            SuspendLayout();
            // 
            // pnlHeaderBar
            // 
            pnlHeaderBar.BackColor = Color.Black;
            pnlHeaderBar.Controls.Add(lblFormTitle);
            pnlHeaderBar.Dock = DockStyle.Top;
            pnlHeaderBar.Location = new Point(0, 0);
            pnlHeaderBar.Name = "pnlHeaderBar";
            pnlHeaderBar.Size = new Size(820, 26);
            pnlHeaderBar.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(8, 5);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(185, 15);
            lblFormTitle.Text = "HỆ THỐNG QUẢN LÝ MEDIA FILE";
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMainContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlMainContainer.Controls.Add(lblMediaID);
            pnlMainContainer.Controls.Add(txtMediaID);
            pnlMainContainer.Controls.Add(lblFileName);
            pnlMainContainer.Controls.Add(txtFileName);
            pnlMainContainer.Controls.Add(btnChonFile);
            pnlMainContainer.Controls.Add(lblMediaType);
            pnlMainContainer.Controls.Add(cboMediaType);
            pnlMainContainer.Controls.Add(lblFileSize);
            pnlMainContainer.Controls.Add(txtFileSizeByte);
            pnlMainContainer.Controls.Add(lblArtifact);
            pnlMainContainer.Controls.Add(cboArtifact);
            pnlMainContainer.Controls.Add(lblStep);
            pnlMainContainer.Controls.Add(cboStep);
            pnlMainContainer.Controls.Add(lblMediaURL);
            pnlMainContainer.Controls.Add(txtMediaURL);
            pnlMainContainer.Controls.Add(pnlPreviewBox);
            pnlMainContainer.Location = new Point(4, 30);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Size = new Size(812, 220);
            pnlMainContainer.TabIndex = 1;
            // 
            // lblMediaID
            // 
            lblMediaID.AutoSize = true;
            lblMediaID.Font = new Font("Segoe UI", 8F);
            lblMediaID.Location = new Point(8, 15);
            lblMediaID.Name = "lblMediaID";
            lblMediaID.Size = new Size(56, 13);
            lblMediaID.Text = "Mã Media:";
            // 
            // txtMediaID
            // 
            txtMediaID.BorderStyle = BorderStyle.FixedSingle;
            txtMediaID.Font = new Font("Segoe UI", 8F);
            txtMediaID.Location = new Point(112, 11);
            txtMediaID.Name = "txtMediaID";
            txtMediaID.Size = new Size(115, 22);
            txtMediaID.TabIndex = 0;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Segoe UI", 8F);
            lblFileName.Location = new Point(232, 15);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(46, 13);
            lblFileName.Text = "Tên Tệp:";
            // 
            // txtFileName
            // 
            txtFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFileName.BorderStyle = BorderStyle.FixedSingle;
            txtFileName.Font = new Font("Segoe UI", 8F);
            txtFileName.Location = new Point(282, 11);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(103, 22);
            txtFileName.TabIndex = 1;
            // 
            // btnChonFile
            // 
            btnChonFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChonFile.BackColor = Color.White;
            btnChonFile.FlatAppearance.BorderColor = Color.Black;
            btnChonFile.FlatStyle = FlatStyle.Flat;
            btnChonFile.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnChonFile.Location = new Point(390, 11);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(52, 22);
            btnChonFile.TabIndex = 2;
            btnChonFile.Text = "Chọn...";
            btnChonFile.UseVisualStyleBackColor = false;
            btnChonFile.Click += btnChonFile_Click;
            // 
            // lblMediaType
            // 
            lblMediaType.AutoSize = true;
            lblMediaType.Font = new Font("Segoe UI", 8F);
            lblMediaType.Location = new Point(8, 55);
            lblMediaType.Name = "lblMediaType";
            lblMediaType.Size = new Size(51, 13);
            lblMediaType.Text = "Loại Tệp:";
            // 
            // cboMediaType
            // 
            cboMediaType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMediaType.Font = new Font("Segoe UI", 8F);
            cboMediaType.FormattingEnabled = true;
            cboMediaType.Items.AddRange(new object[] { "Image", "Video", "Audio", "3D" });
            cboMediaType.Location = new Point(112, 51);
            cboMediaType.Name = "cboMediaType";
            cboMediaType.Size = new Size(115, 21);
            cboMediaType.TabIndex = 3;
            cboMediaType.SelectedIndexChanged += cboMediaType_SelectedIndexChanged;
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Font = new Font("Segoe UI", 8F);
            lblFileSize.Location = new Point(232, 55);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(97, 13);
            lblFileSize.Text = "Dung lượng (Byte):";
            // 
            // txtFileSizeByte
            // 
            txtFileSizeByte.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFileSizeByte.BorderStyle = BorderStyle.FixedSingle;
            txtFileSizeByte.Font = new Font("Segoe UI", 8F);
            txtFileSizeByte.Location = new Point(332, 51);
            txtFileSizeByte.Name = "txtFileSizeByte";
            txtFileSizeByte.ReadOnly = true;
            txtFileSizeByte.Size = new Size(110, 22);
            txtFileSizeByte.TabIndex = 4;
            txtFileSizeByte.Text = "0";
            // 
            // lblArtifact
            // 
            lblArtifact.AutoSize = true;
            lblArtifact.Font = new Font("Segoe UI", 8F);
            lblArtifact.Location = new Point(8, 95);
            lblArtifact.Name = "lblArtifact";
            lblArtifact.Size = new Size(51, 13);
            lblArtifact.Text = "Hiện Vật:";
            // 
            // cboArtifact
            // 
            cboArtifact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboArtifact.DropDownStyle = ComboBoxStyle.DropDownList;
            cboArtifact.Font = new Font("Segoe UI", 8F);
            cboArtifact.FormattingEnabled = true;
            cboArtifact.Location = new Point(112, 91);
            cboArtifact.Name = "cboArtifact";
            cboArtifact.Size = new Size(330, 21);
            cboArtifact.TabIndex = 5;
            cboArtifact.SelectedIndexChanged += cboArtifact_SelectedIndexChanged;
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Font = new Font("Segoe UI", 8F);
            lblStep.Location = new Point(8, 135);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(37, 13);
            lblStep.TabIndex = 6;
            lblStep.Text = "Bước:";
            // 
            // cboStep
            // 
            cboStep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboStep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStep.Font = new Font("Segoe UI", 8F);
            cboStep.FormattingEnabled = true;
            cboStep.Location = new Point(112, 131);
            cboStep.Name = "cboStep";
            cboStep.Size = new Size(330, 21);
            cboStep.TabIndex = 7;
            // 
            // lblMediaURL
            // 
            lblMediaURL.AutoSize = true;
            lblMediaURL.Font = new Font("Segoe UI", 8F);
            lblMediaURL.Location = new Point(8, 175);
            lblMediaURL.Name = "lblMediaURL";
            lblMediaURL.Size = new Size(54, 13);
            lblMediaURL.TabIndex = 8;
            lblMediaURL.Text = "Link URL:";
            // 
            // txtMediaURL
            // 
            txtMediaURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMediaURL.BorderStyle = BorderStyle.FixedSingle;
            txtMediaURL.Font = new Font("Segoe UI", 8F);
            txtMediaURL.Location = new Point(112, 171);
            txtMediaURL.Name = "txtMediaURL";
            txtMediaURL.Size = new Size(330, 22);
            txtMediaURL.TabIndex = 9;
            // 
            // pnlPreviewBox
            // 
            pnlPreviewBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlPreviewBox.BorderStyle = BorderStyle.FixedSingle;
            pnlPreviewBox.Controls.Add(picPreview);
            pnlPreviewBox.Controls.Add(axWindowsMediaPlayer1);
            pnlPreviewBox.Controls.Add(pnlMediaPlayer);
            pnlPreviewBox.Controls.Add(lblPreviewStatus);
            pnlPreviewBox.Location = new Point(448, 5);
            pnlPreviewBox.Name = "pnlPreviewBox";
            pnlPreviewBox.Size = new Size(358, 208);
            pnlPreviewBox.TabIndex = 10;
            // 
            // picPreview
            // 
            picPreview.Dock = DockStyle.Fill;
            picPreview.Location = new Point(0, 0);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(356, 206);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 0;
            picPreview.TabStop = false;
            picPreview.Visible = false;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(0, 0);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(356, 182);
            axWindowsMediaPlayer1.TabIndex = 2;
            axWindowsMediaPlayer1.Visible = false;
            // 
            // pnlMediaPlayer
            // 
            pnlMediaPlayer.Controls.Add(btnPlayPauseMedia);
            pnlMediaPlayer.Controls.Add(btnStopMedia);
            pnlMediaPlayer.Dock = DockStyle.Bottom;
            pnlMediaPlayer.Location = new Point(0, 182);
            pnlMediaPlayer.Name = "pnlMediaPlayer";
            pnlMediaPlayer.Size = new Size(356, 24);
            pnlMediaPlayer.TabIndex = 3;
            pnlMediaPlayer.Visible = false;
            // 
            // btnPlayPauseMedia
            // 
            btnPlayPauseMedia.BackColor = Color.Black;
            btnPlayPauseMedia.FlatAppearance.BorderColor = Color.Black;
            btnPlayPauseMedia.FlatStyle = FlatStyle.Flat;
            btnPlayPauseMedia.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnPlayPauseMedia.ForeColor = Color.White;
            btnPlayPauseMedia.Location = new Point(2, 1);
            btnPlayPauseMedia.Name = "btnPlayPauseMedia";
            btnPlayPauseMedia.Size = new Size(174, 22);
            btnPlayPauseMedia.TabIndex = 0;
            btnPlayPauseMedia.Text = "Phát";
            btnPlayPauseMedia.UseVisualStyleBackColor = false;
            btnPlayPauseMedia.Click += btnPlayPauseMedia_Click;
            // 
            // btnStopMedia
            // 
            btnStopMedia.BackColor = Color.White;
            btnStopMedia.FlatAppearance.BorderColor = Color.Black;
            btnStopMedia.FlatStyle = FlatStyle.Flat;
            btnStopMedia.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnStopMedia.ForeColor = Color.Black;
            btnStopMedia.Location = new Point(178, 1);
            btnStopMedia.Name = "btnStopMedia";
            btnStopMedia.Size = new Size(175, 22);
            btnStopMedia.TabIndex = 1;
            btnStopMedia.Text = "Dừng";
            btnStopMedia.UseVisualStyleBackColor = false;
            btnStopMedia.Click += btnStopMedia_Click;
            // 
            // lblPreviewStatus
            // 
            lblPreviewStatus.Dock = DockStyle.Fill;
            lblPreviewStatus.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblPreviewStatus.ForeColor = Color.DimGray;
            lblPreviewStatus.Location = new Point(0, 0);
            lblPreviewStatus.Name = "lblPreviewStatus";
            lblPreviewStatus.Size = new Size(356, 206);
            lblPreviewStatus.TabIndex = 1;
            lblPreviewStatus.Text = "Chưa chọn tệp xem trước";
            lblPreviewStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlActionBar
            // 
            pnlActionBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlActionBar.Controls.Add(btnUploadSave);
            pnlActionBar.Controls.Add(btnHuy);
            pnlActionBar.Controls.Add(btnXoa);
            pnlActionBar.Location = new Point(4, 254);
            pnlActionBar.Name = "pnlActionBar";
            pnlActionBar.Size = new Size(812, 28);
            pnlActionBar.TabIndex = 2;
            // 
            // btnUploadSave
            // 
            btnUploadSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUploadSave.BackColor = Color.Black;
            btnUploadSave.FlatAppearance.BorderColor = Color.Black;
            btnUploadSave.FlatStyle = FlatStyle.Flat;
            btnUploadSave.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnUploadSave.ForeColor = Color.White;
            btnUploadSave.Location = new Point(0, 1);
            btnUploadSave.Name = "btnUploadSave";
            btnUploadSave.Size = new Size(442, 25);
            btnUploadSave.TabIndex = 0;
            btnUploadSave.Text = "THÊM MEDIA MỚI (LƯU CSDL)";
            btnUploadSave.UseVisualStyleBackColor = false;
            btnUploadSave.Click += btnUploadSave_Click;
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy.BackColor = Color.White;
            btnHuy.FlatAppearance.BorderColor = Color.Black;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 8F);
            btnHuy.ForeColor = Color.Black;
            btnHuy.Location = new Point(448, 1);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(175, 25);
            btnHuy.TabIndex = 1;
            btnHuy.Text = "HỦY CHỈNH SỬA";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Visible = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.BackColor = Color.White;
            btnXoa.FlatAppearance.BorderColor = Color.Black;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Black;
            btnXoa.Location = new Point(629, 1);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(183, 25);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "XÓA MEDIA ĐANG CHỌN";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // pnlGridContainer
            // 
            pnlGridContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGridContainer.Controls.Add(dgvMediaList);
            pnlGridContainer.Location = new Point(4, 286);
            pnlGridContainer.Name = "pnlGridContainer";
            pnlGridContainer.Size = new Size(812, 188);
            pnlGridContainer.TabIndex = 3;
            // 
            // dgvMediaList
            // 
            dgvMediaList.AllowUserToAddRows = false;
            dgvMediaList.AllowUserToDeleteRows = false;
            dgvMediaList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMediaList.BackgroundColor = Color.White;
            dgvMediaList.BorderStyle = BorderStyle.Fixed3D;
            dgvMediaList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMediaList.Dock = DockStyle.Fill;
            dgvMediaList.Location = new Point(0, 0);
            dgvMediaList.MultiSelect = false;
            dgvMediaList.Name = "dgvMediaList";
            dgvMediaList.ReadOnly = true;
            dgvMediaList.RowHeadersWidth = 20;
            dgvMediaList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMediaList.Size = new Size(812, 188);
            dgvMediaList.TabIndex = 0;
            dgvMediaList.CellClick += dgvMediaList_CellClick;
            // 
            // FrmQuanLyMedia
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(820, 480);
            Controls.Add(pnlGridContainer);
            Controls.Add(pnlActionBar);
            Controls.Add(pnlMainContainer);
            Controls.Add(pnlHeaderBar);
            Font = new Font("Segoe UI", 8F);
            MinimumSize = new Size(820, 480);
            Name = "FrmQuanLyMedia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Media";
            FormClosing += FrmQuanLyMedia_FormClosing;
            Load += FrmQuanLyMedia_Load;
            pnlHeaderBar.ResumeLayout(false);
            pnlHeaderBar.PerformLayout();
            pnlMainContainer.ResumeLayout(false);
            pnlMainContainer.PerformLayout();
            pnlPreviewBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            pnlMediaPlayer.ResumeLayout(false);
            pnlActionBar.ResumeLayout(false);
            pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMediaList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeaderBar;
        private Label lblFormTitle;
        private Panel pnlMainContainer;
        private Label lblMediaID;
        private TextBox txtMediaID;
        private Label lblFileName;
        private TextBox txtFileName;
        private Button btnChonFile;
        private Label lblMediaType;
        private ComboBox cboMediaType;
        private Label lblFileSize;
        private TextBox txtFileSizeByte;
        private Label lblArtifact;
        private ComboBox cboArtifact;
        private Label lblStep;
        private ComboBox cboStep;
        private Label lblMediaURL;
        private TextBox txtMediaURL;
        private Panel pnlPreviewBox;
        private PictureBox picPreview;
        private Label lblPreviewStatus;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Panel pnlMediaPlayer;
        private Button btnPlayPauseMedia;
        private Button btnStopMedia;
        private Panel pnlActionBar;
        private Button btnUploadSave;
        private Button btnHuy;
        private Button btnXoa;
        private Panel pnlGridContainer;
        private DataGridView dgvMediaList;
    }
}