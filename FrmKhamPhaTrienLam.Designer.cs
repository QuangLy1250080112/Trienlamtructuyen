namespace Trienlamtructuyen
{
    partial class FrmKhamPhaTrienLam
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
            splitContainerMain = new SplitContainer();
            pnlJourneyContent = new Panel();
            pnlContentBody = new Panel();
            txtStepContent = new TextBox();
            grpArtifact = new GroupBox();
            picQRCode = new PictureBox();
            pnlMediaContainer = new Panel();
            picMedia = new PictureBox();
            lblCollectionDesc = new Label();
            lblArtifactMeta = new Label();
            lblArtifactHeader = new Label();
            pnlStoryHeader = new Panel();
            lblStepTitle = new Label();
            lblStorySynopsis = new Label();
            lblStoryHeader = new Label();
            pnlNodeInfo = new Panel();
            lblNodeTitle = new Label();
            pnlRightSide = new Panel();
            pnlTimeline = new Panel();
            lstTimeline = new ListBox();
            lblTimelineHeader = new Label();
            pnlNav = new Panel();
            btnPrevNode = new Button();
            lblStepCounter = new Label();
            btnNextNode = new Button();
            pnlRouteSelect = new Panel();
            lblRouteInfo = new Label();
            cboRoutes = new ComboBox();
            lblSelectRoute = new Label();

            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            pnlJourneyContent.SuspendLayout();
            pnlContentBody.SuspendLayout();
            grpArtifact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picMedia).BeginInit();
            pnlStoryHeader.SuspendLayout();
            pnlNodeInfo.SuspendLayout();
            pnlRightSide.SuspendLayout();
            pnlTimeline.SuspendLayout();
            pnlNav.SuspendLayout();
            pnlRouteSelect.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.FixedPanel = FixedPanel.Panel2;
            splitContainerMain.Location = new Point(4, 4);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(pnlJourneyContent);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(pnlRightSide);
            splitContainerMain.Size = new Size(952, 572);
            splitContainerMain.SplitterDistance = 680;
            splitContainerMain.TabIndex = 0;
            // 
            // pnlJourneyContent
            // 
            pnlJourneyContent.BorderStyle = BorderStyle.FixedSingle;
            pnlJourneyContent.Controls.Add(pnlContentBody);
            pnlJourneyContent.Controls.Add(pnlStoryHeader);
            pnlJourneyContent.Controls.Add(pnlNodeInfo);
            pnlJourneyContent.Dock = DockStyle.Fill;
            pnlJourneyContent.Location = new Point(0, 0);
            pnlJourneyContent.Name = "pnlJourneyContent";
            pnlJourneyContent.Padding = new Padding(6);
            pnlJourneyContent.Size = new Size(680, 572);
            pnlJourneyContent.TabIndex = 0;
            // 
            // pnlContentBody
            // 
            pnlContentBody.Controls.Add(txtStepContent);
            pnlContentBody.Controls.Add(grpArtifact);
            pnlContentBody.Dock = DockStyle.Fill;
            pnlContentBody.Location = new Point(6, 116);
            pnlContentBody.Name = "pnlContentBody";
            pnlContentBody.Size = new Size(666, 448);
            pnlContentBody.TabIndex = 2;
            pnlContentBody.Resize += pnlContentBody_Resize;
            // 
            // txtStepContent
            // 
            txtStepContent.BackColor = Color.White;
            txtStepContent.BorderStyle = BorderStyle.FixedSingle;
            txtStepContent.Font = new Font("Segoe UI", 9.5F);
            txtStepContent.Location = new Point(0, 0);
            txtStepContent.Multiline = true;
            txtStepContent.Name = "txtStepContent";
            txtStepContent.ReadOnly = true;
            txtStepContent.ScrollBars = ScrollBars.Vertical;
            txtStepContent.Size = new Size(320, 440);
            txtStepContent.TabIndex = 0;
            // 
            // grpArtifact
            // 
            grpArtifact.Controls.Add(picQRCode);
            grpArtifact.Controls.Add(pnlMediaContainer);
            grpArtifact.Controls.Add(picMedia);
            grpArtifact.Controls.Add(lblCollectionDesc);
            grpArtifact.Controls.Add(lblArtifactMeta);
            grpArtifact.Controls.Add(lblArtifactHeader);
            grpArtifact.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            grpArtifact.ForeColor = Color.Black;
            grpArtifact.Location = new Point(330, 0);
            grpArtifact.Name = "grpArtifact";
            grpArtifact.Padding = new Padding(6);
            grpArtifact.Size = new Size(330, 440);
            grpArtifact.TabIndex = 1;
            grpArtifact.TabStop = false;
            grpArtifact.Text = "HIỆN VẬT THAM QUAN";
            // 
            // picQRCode
            // 
            picQRCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picQRCode.BorderStyle = BorderStyle.FixedSingle;
            picQRCode.Location = new Point(245, 18);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(77, 77);
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            picQRCode.TabIndex = 5;
            picQRCode.TabStop = false;
            picQRCode.Visible = false;
            // 
            // pnlMediaContainer
            // 
            pnlMediaContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMediaContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlMediaContainer.Location = new Point(8, 220);
            pnlMediaContainer.Name = "pnlMediaContainer";
            pnlMediaContainer.Size = new Size(314, 212);
            pnlMediaContainer.TabIndex = 4;
            pnlMediaContainer.Visible = false;
            // 
            // picMedia
            // 
            picMedia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picMedia.BorderStyle = BorderStyle.FixedSingle;
            picMedia.Location = new Point(8, 220);
            picMedia.Name = "picMedia";
            picMedia.Size = new Size(314, 212);
            picMedia.SizeMode = PictureBoxSizeMode.Zoom;
            picMedia.TabIndex = 3;
            picMedia.TabStop = false;
            // 
            // lblCollectionDesc
            // 
            lblCollectionDesc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCollectionDesc.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblCollectionDesc.ForeColor = Color.DimGray;
            lblCollectionDesc.Location = new Point(8, 116);
            lblCollectionDesc.Name = "lblCollectionDesc";
            lblCollectionDesc.Size = new Size(314, 98);
            lblCollectionDesc.TabIndex = 2;
            lblCollectionDesc.Text = "Mô tả bộ sưu tập...";
            // 
            // lblArtifactMeta
            // 
            lblArtifactMeta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblArtifactMeta.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            lblArtifactMeta.ForeColor = Color.Black;
            lblArtifactMeta.Location = new Point(8, 54);
            lblArtifactMeta.Name = "lblArtifactMeta";
            lblArtifactMeta.Size = new Size(230, 60);
            lblArtifactMeta.TabIndex = 1;
            lblArtifactMeta.Text = "Bộ sưu tập | Thời kỳ | Chất liệu | Xuất xứ";
            // 
            // lblArtifactHeader
            // 
            lblArtifactHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblArtifactHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblArtifactHeader.ForeColor = Color.DarkBlue;
            lblArtifactHeader.Location = new Point(8, 18);
            lblArtifactHeader.Name = "lblArtifactHeader";
            lblArtifactHeader.Size = new Size(230, 34);
            lblArtifactHeader.TabIndex = 0;
            lblArtifactHeader.Text = "Tên hiện vật";
            // 
            // pnlStoryHeader
            // 
            pnlStoryHeader.BackColor = Color.FromArgb(248, 249, 250);
            pnlStoryHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlStoryHeader.Controls.Add(lblStepTitle);
            pnlStoryHeader.Controls.Add(lblStorySynopsis);
            pnlStoryHeader.Controls.Add(lblStoryHeader);
            pnlStoryHeader.Dock = DockStyle.Top;
            pnlStoryHeader.Location = new Point(6, 38);
            pnlStoryHeader.Name = "pnlStoryHeader";
            pnlStoryHeader.Padding = new Padding(6);
            pnlStoryHeader.Size = new Size(666, 78);
            pnlStoryHeader.TabIndex = 1;
            // 
            // lblStepTitle
            // 
            lblStepTitle.AutoSize = true;
            lblStepTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStepTitle.ForeColor = Color.DarkGreen;
            lblStepTitle.Location = new Point(6, 54);
            lblStepTitle.Name = "lblStepTitle";
            lblStepTitle.Size = new Size(95, 15);
            lblStepTitle.TabIndex = 2;
            lblStepTitle.Text = "Bước kịch bản 1";
            // 
            // lblStorySynopsis
            // 
            lblStorySynopsis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStorySynopsis.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblStorySynopsis.ForeColor = Color.DimGray;
            lblStorySynopsis.Location = new Point(6, 28);
            lblStorySynopsis.Name = "lblStorySynopsis";
            lblStorySynopsis.Size = new Size(652, 22);
            lblStorySynopsis.TabIndex = 1;
            lblStorySynopsis.Text = "Tóm tắt kịch bản câu chuyện...";
            // 
            // lblStoryHeader
            // 
            lblStoryHeader.AutoSize = true;
            lblStoryHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStoryHeader.ForeColor = Color.Black;
            lblStoryHeader.Location = new Point(6, 6);
            lblStoryHeader.Name = "lblStoryHeader";
            lblStoryHeader.Size = new Size(111, 19);
            lblStoryHeader.TabIndex = 0;
            lblStoryHeader.Text = "Tên câu chuyện";
            // 
            // pnlNodeInfo
            // 
            pnlNodeInfo.Controls.Add(lblNodeTitle);
            pnlNodeInfo.Dock = DockStyle.Top;
            pnlNodeInfo.Location = new Point(6, 6);
            pnlNodeInfo.Name = "pnlNodeInfo";
            pnlNodeInfo.Size = new Size(666, 32);
            pnlNodeInfo.TabIndex = 0;
            // 
            // lblNodeTitle
            // 
            lblNodeTitle.AutoSize = true;
            lblNodeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNodeTitle.ForeColor = Color.Black;
            lblNodeTitle.Location = new Point(2, 4);
            lblNodeTitle.Name = "lblNodeTitle";
            lblNodeTitle.Size = new Size(202, 20);
            lblNodeTitle.TabIndex = 0;
            lblNodeTitle.Text = "Tên điểm dừng";
            // 
            // pnlRightSide
            // 
            pnlRightSide.Controls.Add(pnlTimeline);
            pnlRightSide.Controls.Add(pnlNav);
            pnlRightSide.Controls.Add(pnlRouteSelect);
            pnlRightSide.Dock = DockStyle.Fill;
            pnlRightSide.Location = new Point(0, 0);
            pnlRightSide.Name = "pnlRightSide";
            pnlRightSide.Size = new Size(268, 572);
            pnlRightSide.TabIndex = 0;
            // 
            // pnlTimeline
            // 
            pnlTimeline.BorderStyle = BorderStyle.FixedSingle;
            pnlTimeline.Controls.Add(lstTimeline);
            pnlTimeline.Controls.Add(lblTimelineHeader);
            pnlTimeline.Dock = DockStyle.Fill;
            pnlTimeline.Location = new Point(0, 58);
            pnlTimeline.Name = "pnlTimeline";
            pnlTimeline.Size = new Size(268, 482);
            pnlTimeline.TabIndex = 1;
            // 
            // lstTimeline
            // 
            lstTimeline.BorderStyle = BorderStyle.None;
            lstTimeline.Dock = DockStyle.Fill;
            lstTimeline.Font = new Font("Segoe UI", 8.5F);
            lstTimeline.FormattingEnabled = true;
            lstTimeline.HorizontalScrollbar = true;
            lstTimeline.ItemHeight = 15;
            lstTimeline.Location = new Point(0, 26);
            lstTimeline.Name = "lstTimeline";
            lstTimeline.Size = new Size(266, 454);
            lstTimeline.TabIndex = 1;
            lstTimeline.SelectedIndexChanged += lstTimeline_SelectedIndexChanged;
            // 
            // lblTimelineHeader
            // 
            lblTimelineHeader.BackColor = Color.FromArgb(230, 230, 230);
            lblTimelineHeader.Dock = DockStyle.Top;
            lblTimelineHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTimelineHeader.ForeColor = Color.Black;
            lblTimelineHeader.Location = new Point(0, 0);
            lblTimelineHeader.Name = "lblTimelineHeader";
            lblTimelineHeader.Padding = new Padding(6, 0, 0, 0);
            lblTimelineHeader.Size = new Size(266, 26);
            lblTimelineHeader.TabIndex = 0;
            lblTimelineHeader.Text = "DANH SÁCH ĐIỂM DỪNG";
            lblTimelineHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlNav
            // 
            pnlNav.BorderStyle = BorderStyle.FixedSingle;
            pnlNav.Controls.Add(btnPrevNode);
            pnlNav.Controls.Add(lblStepCounter);
            pnlNav.Controls.Add(btnNextNode);
            pnlNav.Dock = DockStyle.Bottom;
            pnlNav.Location = new Point(0, 540);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(268, 32);
            pnlNav.TabIndex = 2;
            // 
            // btnPrevNode
            // 
            btnPrevNode.BackColor = Color.Black;
            btnPrevNode.FlatAppearance.BorderColor = Color.Black;
            btnPrevNode.FlatStyle = FlatStyle.Flat;
            btnPrevNode.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnPrevNode.ForeColor = Color.White;
            btnPrevNode.Location = new Point(3, 4);
            btnPrevNode.Name = "btnPrevNode";
            btnPrevNode.Size = new Size(75, 22);
            btnPrevNode.TabIndex = 0;
            btnPrevNode.Text = "◄ Trước";
            btnPrevNode.UseVisualStyleBackColor = false;
            btnPrevNode.Click += btnPrevNode_Click;
            // 
            // lblStepCounter
            // 
            lblStepCounter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStepCounter.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStepCounter.ForeColor = Color.Black;
            lblStepCounter.Location = new Point(84, 6);
            lblStepCounter.Name = "lblStepCounter";
            lblStepCounter.Size = new Size(98, 18);
            lblStepCounter.TabIndex = 1;
            lblStepCounter.Text = "0 / 0";
            lblStepCounter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNextNode
            // 
            btnNextNode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNextNode.BackColor = Color.Black;
            btnNextNode.FlatAppearance.BorderColor = Color.Black;
            btnNextNode.FlatStyle = FlatStyle.Flat;
            btnNextNode.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnNextNode.ForeColor = Color.White;
            btnNextNode.Location = new Point(188, 4);
            btnNextNode.Name = "btnNextNode";
            btnNextNode.Size = new Size(75, 22);
            btnNextNode.TabIndex = 2;
            btnNextNode.Text = "Tiếp ►";
            btnNextNode.UseVisualStyleBackColor = false;
            btnNextNode.Click += btnNextNode_Click;
            // 
            // pnlRouteSelect
            // 
            pnlRouteSelect.BorderStyle = BorderStyle.FixedSingle;
            pnlRouteSelect.Controls.Add(lblRouteInfo);
            pnlRouteSelect.Controls.Add(cboRoutes);
            pnlRouteSelect.Controls.Add(lblSelectRoute);
            pnlRouteSelect.Dock = DockStyle.Top;
            pnlRouteSelect.Location = new Point(0, 0);
            pnlRouteSelect.Name = "pnlRouteSelect";
            pnlRouteSelect.Padding = new Padding(4);
            pnlRouteSelect.Size = new Size(268, 58);
            pnlRouteSelect.TabIndex = 0;
            // 
            // lblRouteInfo
            // 
            lblRouteInfo.AutoSize = true;
            lblRouteInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblRouteInfo.ForeColor = Color.DimGray;
            lblRouteInfo.Location = new Point(4, 38);
            lblRouteInfo.Name = "lblRouteInfo";
            lblRouteInfo.Size = new Size(101, 13);
            lblRouteInfo.TabIndex = 2;
            lblRouteInfo.Text = "Tổng số điểm dừng: 0";
            // 
            // cboRoutes
            // 
            cboRoutes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboRoutes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoutes.Font = new Font("Segoe UI", 8.5F);
            cboRoutes.FormattingEnabled = true;
            cboRoutes.Location = new Point(4, 16);
            cboRoutes.Name = "cboRoutes";
            cboRoutes.Size = new Size(258, 21);
            cboRoutes.TabIndex = 1;
            cboRoutes.SelectedIndexChanged += cboRoutes_SelectedIndexChanged;
            // 
            // lblSelectRoute
            // 
            lblSelectRoute.AutoSize = true;
            lblSelectRoute.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSelectRoute.ForeColor = Color.Black;
            lblSelectRoute.Location = new Point(4, 1);
            lblSelectRoute.Name = "lblSelectRoute";
            lblSelectRoute.Size = new Size(140, 15);
            lblSelectRoute.TabIndex = 0;
            lblSelectRoute.Text = "TUYẾN THAM QUAN:";
            // 
            // FrmKhamPhaTrienLam
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(960, 580);
            Controls.Add(splitContainerMain);
            Font = new Font("Segoe UI", 8F);
            MinimumSize = new Size(960, 580);
            Name = "FrmKhamPhaTrienLam";
            Padding = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khám Phá Triển Lãm Trực Tuyến";
            Load += FrmKhamPhaTrienLam_Load;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            pnlJourneyContent.ResumeLayout(false);
            pnlContentBody.ResumeLayout(false);
            pnlContentBody.PerformLayout();
            grpArtifact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)picMedia).EndInit();
            pnlStoryHeader.ResumeLayout(false);
            pnlStoryHeader.PerformLayout();
            pnlNodeInfo.ResumeLayout(false);
            pnlNodeInfo.PerformLayout();
            pnlRightSide.ResumeLayout(false);
            pnlTimeline.ResumeLayout(false);
            pnlNav.ResumeLayout(false);
            pnlRouteSelect.ResumeLayout(false);
            pnlRouteSelect.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;

        // Trái: Không gian trưng bày
        private Panel pnlJourneyContent;
        private Panel pnlNodeInfo;
        private Label lblNodeTitle;
        private Panel pnlStoryHeader;
        private Label lblStoryHeader;
        private Label lblStorySynopsis;
        private Label lblStepTitle;
        private Panel pnlContentBody;
        private TextBox txtStepContent;

        private GroupBox grpArtifact;
        private Label lblArtifactHeader;
        private Label lblArtifactMeta;
        private Label lblCollectionDesc;
        private PictureBox picMedia;
        private Panel pnlMediaContainer;
        private PictureBox picQRCode;

        // Phải: Danh sách & Chọn tuyến
        private Panel pnlRightSide;
        private Panel pnlRouteSelect;
        private Label lblSelectRoute;
        private ComboBox cboRoutes;
        private Label lblRouteInfo;
        private Panel pnlTimeline;
        private Label lblTimelineHeader;
        private ListBox lstTimeline;
        private Panel pnlNav;
        private Button btnPrevNode;
        private Label lblStepCounter;
        private Button btnNextNode;
    }
}