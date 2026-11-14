namespace Trienlamtructuyen
{
    partial class FrmBienTapCauChuyen
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            splitContainerMain = new SplitContainer();
            grpStory = new GroupBox();
            dgvStories = new DataGridView();
            pnlStoryInput = new Panel();
            lblCauChuyenID = new Label();
            txtCauChuyenID = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblSynopsis = new Label();
            rtbSynopsis = new RichTextBox();
            pnlStoryActions = new Panel();
            btnThemStory = new Button();
            btnLuuStory = new Button();
            btnHuyStory = new Button();
            btnXoaStory = new Button();
            grpSteps = new GroupBox();
            dgvSteps = new DataGridView();
            pnlStepInput = new Panel();
            cboArtifactLink = new ComboBox();
            lblArtifactLink = new Label();
            rtbContentBody = new RichTextBox();
            lblContentBody = new Label();
            txtHeading = new TextBox();
            lblHeading = new Label();
            numStepOrder = new NumericUpDown();
            lblStepOrder = new Label();
            txtStepID = new TextBox();
            lblStepID = new Label();
            pnlStepActions = new Panel();
            btnThemStep = new Button();
            btnLuuStep = new Button();
            btnHuyStep = new Button();
            btnXoaStep = new Button();
            btnKiemTraAccessibility = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            grpStory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStories).BeginInit();
            pnlStoryInput.SuspendLayout();
            pnlStoryActions.SuspendLayout();
            grpSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSteps).BeginInit();
            pnlStepInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStepOrder).BeginInit();
            pnlStepActions.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(4, 4);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(grpStory);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(grpSteps);
            splitContainerMain.Size = new Size(752, 452);
            splitContainerMain.SplitterDistance = 230;
            splitContainerMain.TabIndex = 0;
            // 
            // grpStory
            // 
            grpStory.Controls.Add(dgvStories);
            grpStory.Controls.Add(pnlStoryInput);
            grpStory.Controls.Add(pnlStoryActions);
            grpStory.Dock = DockStyle.Fill;
            grpStory.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            grpStory.ForeColor = Color.Black;
            grpStory.Location = new Point(0, 0);
            grpStory.Name = "grpStory";
            grpStory.Size = new Size(752, 230);
            grpStory.TabIndex = 0;
            grpStory.TabStop = false;
            grpStory.Text = "DANH SÁCH VÀ BIÊN TẬP CÂU CHUYỆN";
            // 
            // dgvStories
            // 
            dgvStories.AllowUserToAddRows = false;
            dgvStories.AllowUserToDeleteRows = false;
            dgvStories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStories.BackgroundColor = Color.White;
            dgvStories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStories.Dock = DockStyle.Fill;
            dgvStories.Location = new Point(343, 20);
            dgvStories.MultiSelect = false;
            dgvStories.Name = "dgvStories";
            dgvStories.ReadOnly = true;
            dgvStories.RowHeadersVisible = false;
            dgvStories.RowHeadersWidth = 47;
            dgvStories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStories.Size = new Size(406, 179);
            dgvStories.TabIndex = 1;
            dgvStories.CellClick += dgvStories_CellClick;
            // 
            // pnlStoryInput
            // 
            pnlStoryInput.Controls.Add(lblCauChuyenID);
            pnlStoryInput.Controls.Add(txtCauChuyenID);
            pnlStoryInput.Controls.Add(lblTitle);
            pnlStoryInput.Controls.Add(txtTitle);
            pnlStoryInput.Controls.Add(lblAuthor);
            pnlStoryInput.Controls.Add(txtAuthor);
            pnlStoryInput.Controls.Add(lblStatus);
            pnlStoryInput.Controls.Add(cboStatus);
            pnlStoryInput.Controls.Add(lblSynopsis);
            pnlStoryInput.Controls.Add(rtbSynopsis);
            pnlStoryInput.Dock = DockStyle.Left;
            pnlStoryInput.Font = new Font("Segoe UI", 8F);
            pnlStoryInput.Location = new Point(3, 20);
            pnlStoryInput.Name = "pnlStoryInput";
            pnlStoryInput.Size = new Size(340, 179);
            pnlStoryInput.TabIndex = 0;
            // 
            // lblCauChuyenID
            // 
            lblCauChuyenID.AutoSize = true;
            lblCauChuyenID.Location = new Point(4, 8);
            lblCauChuyenID.Name = "lblCauChuyenID";
            lblCauChuyenID.Size = new Size(98, 17);
            lblCauChuyenID.TabIndex = 0;
            lblCauChuyenID.Text = "Mã câu chuyện:";
            // 
            // txtCauChuyenID
            // 
            txtCauChuyenID.Location = new Point(108, 5);
            txtCauChuyenID.Name = "txtCauChuyenID";
            txtCauChuyenID.Size = new Size(227, 24);
            txtCauChuyenID.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(4, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(54, 17);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Tiêu đề:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(85, 31);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 24);
            txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(4, 60);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(52, 17);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "Tác giả:";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(85, 57);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(110, 24);
            txtAuthor.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(200, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(73, 17);
            lblStatus.TabIndex = 6;
            lblStatus.Text = " Trạng thái:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Draft", "Published" });
            cboStatus.Location = new Point(275, 57);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(60, 23);
            cboStatus.TabIndex = 7;
            // 
            // lblSynopsis
            // 
            lblSynopsis.AutoSize = true;
            lblSynopsis.Location = new Point(4, 86);
            lblSynopsis.Name = "lblSynopsis";
            lblSynopsis.Size = new Size(55, 17);
            lblSynopsis.TabIndex = 8;
            lblSynopsis.Text = "Tóm tắt:";
            // 
            // rtbSynopsis
            // 
            rtbSynopsis.BorderStyle = BorderStyle.FixedSingle;
            rtbSynopsis.Location = new Point(85, 83);
            rtbSynopsis.Name = "rtbSynopsis";
            rtbSynopsis.Size = new Size(250, 93);
            rtbSynopsis.TabIndex = 9;
            rtbSynopsis.Text = "";
            // 
            // pnlStoryActions
            // 
            pnlStoryActions.Controls.Add(btnThemStory);
            pnlStoryActions.Controls.Add(btnLuuStory);
            pnlStoryActions.Controls.Add(btnHuyStory);
            pnlStoryActions.Controls.Add(btnXoaStory);
            pnlStoryActions.Dock = DockStyle.Bottom;
            pnlStoryActions.Font = new Font("Segoe UI", 8F);
            pnlStoryActions.Location = new Point(3, 199);
            pnlStoryActions.Name = "pnlStoryActions";
            pnlStoryActions.Size = new Size(746, 28);
            pnlStoryActions.TabIndex = 2;
            // 
            // btnThemStory
            // 
            btnThemStory.BackColor = Color.Black;
            btnThemStory.FlatAppearance.BorderColor = Color.Black;
            btnThemStory.FlatStyle = FlatStyle.Flat;
            btnThemStory.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnThemStory.ForeColor = Color.White;
            btnThemStory.Location = new Point(0, 2);
            btnThemStory.Name = "btnThemStory";
            btnThemStory.Size = new Size(110, 24);
            btnThemStory.TabIndex = 0;
            btnThemStory.Text = "THÊM MỚI";
            btnThemStory.UseVisualStyleBackColor = false;
            btnThemStory.Click += btnThemStory_Click;
            // 
            // btnLuuStory
            // 
            btnLuuStory.BackColor = Color.Black;
            btnLuuStory.FlatAppearance.BorderColor = Color.Black;
            btnLuuStory.FlatStyle = FlatStyle.Flat;
            btnLuuStory.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLuuStory.ForeColor = Color.White;
            btnLuuStory.Location = new Point(0, 2);
            btnLuuStory.Name = "btnLuuStory";
            btnLuuStory.Size = new Size(110, 24);
            btnLuuStory.TabIndex = 1;
            btnLuuStory.Text = "LƯU SỬA";
            btnLuuStory.UseVisualStyleBackColor = false;
            btnLuuStory.Click += btnLuuStory_Click;
            // 
            // btnHuyStory
            // 
            btnHuyStory.BackColor = Color.White;
            btnHuyStory.FlatAppearance.BorderColor = Color.Black;
            btnHuyStory.FlatStyle = FlatStyle.Flat;
            btnHuyStory.ForeColor = Color.Black;
            btnHuyStory.Location = new Point(115, 2);
            btnHuyStory.Name = "btnHuyStory";
            btnHuyStory.Size = new Size(90, 24);
            btnHuyStory.TabIndex = 2;
            btnHuyStory.Text = "HỦY SỬA";
            btnHuyStory.UseVisualStyleBackColor = false;
            btnHuyStory.Click += btnHuyStory_Click;
            // 
            // btnXoaStory
            // 
            btnXoaStory.BackColor = Color.White;
            btnXoaStory.FlatAppearance.BorderColor = Color.Black;
            btnXoaStory.FlatStyle = FlatStyle.Flat;
            btnXoaStory.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnXoaStory.ForeColor = Color.Black;
            btnXoaStory.Location = new Point(210, 2);
            btnXoaStory.Name = "btnXoaStory";
            btnXoaStory.Size = new Size(130, 24);
            btnXoaStory.TabIndex = 3;
            btnXoaStory.Text = "XÓA CÂU CHUYỆN";
            btnXoaStory.UseVisualStyleBackColor = false;
            btnXoaStory.Click += btnXoaStory_Click;
            // 
            // grpSteps
            // 
            grpSteps.Controls.Add(dgvSteps);
            grpSteps.Controls.Add(pnlStepInput);
            grpSteps.Controls.Add(pnlStepActions);
            grpSteps.Dock = DockStyle.Fill;
            grpSteps.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            grpSteps.ForeColor = Color.Black;
            grpSteps.Location = new Point(0, 0);
            grpSteps.Name = "grpSteps";
            grpSteps.Size = new Size(752, 218);
            grpSteps.TabIndex = 0;
            grpSteps.TabStop = false;
            grpSteps.Text = "KỊCH BẢN TỪNG BƯỚC (STEPS)";
            // 
            // dgvSteps
            // 
            dgvSteps.AllowUserToAddRows = false;
            dgvSteps.AllowUserToDeleteRows = false;
            dgvSteps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSteps.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSteps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 220, 220);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSteps.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSteps.Dock = DockStyle.Fill;
            dgvSteps.EnableHeadersVisualStyles = false;
            dgvSteps.GridColor = Color.Black;
            dgvSteps.Location = new Point(343, 20);
            dgvSteps.MultiSelect = false;
            dgvSteps.Name = "dgvSteps";
            dgvSteps.ReadOnly = true;
            dgvSteps.RowHeadersVisible = false;
            dgvSteps.RowHeadersWidth = 47;
            dgvSteps.RowTemplate.Height = 22;
            dgvSteps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSteps.Size = new Size(406, 167);
            dgvSteps.TabIndex = 1;
            dgvSteps.CellClick += dgvSteps_CellClick;
            // 
            // pnlStepInput
            // 
            pnlStepInput.Controls.Add(cboArtifactLink);
            pnlStepInput.Controls.Add(lblArtifactLink);
            pnlStepInput.Controls.Add(rtbContentBody);
            pnlStepInput.Controls.Add(lblContentBody);
            pnlStepInput.Controls.Add(txtHeading);
            pnlStepInput.Controls.Add(lblHeading);
            pnlStepInput.Controls.Add(numStepOrder);
            pnlStepInput.Controls.Add(lblStepOrder);
            pnlStepInput.Controls.Add(txtStepID);
            pnlStepInput.Controls.Add(lblStepID);
            pnlStepInput.Dock = DockStyle.Left;
            pnlStepInput.Font = new Font("Segoe UI", 8F);
            pnlStepInput.ForeColor = Color.Black;
            pnlStepInput.Location = new Point(3, 20);
            pnlStepInput.Name = "pnlStepInput";
            pnlStepInput.Size = new Size(340, 167);
            pnlStepInput.TabIndex = 0;
            // 
            // cboArtifactLink
            // 
            cboArtifactLink.DropDownStyle = ComboBoxStyle.DropDownList;
            cboArtifactLink.FormattingEnabled = true;
            cboArtifactLink.Location = new Point(85, 142);
            cboArtifactLink.Name = "cboArtifactLink";
            cboArtifactLink.Size = new Size(250, 23);
            cboArtifactLink.TabIndex = 9;
            // 
            // lblArtifactLink
            // 
            lblArtifactLink.AutoSize = true;
            lblArtifactLink.Location = new Point(4, 145);
            lblArtifactLink.Name = "lblArtifactLink";
            lblArtifactLink.Size = new Size(58, 17);
            lblArtifactLink.TabIndex = 8;
            lblArtifactLink.Text = "Hiện vật:";
            // 
            // rtbContentBody
            // 
            rtbContentBody.BorderStyle = BorderStyle.FixedSingle;
            rtbContentBody.Location = new Point(85, 55);
            rtbContentBody.Name = "rtbContentBody";
            rtbContentBody.Size = new Size(250, 81);
            rtbContentBody.TabIndex = 7;
            rtbContentBody.Text = "";
            // 
            // lblContentBody
            // 
            lblContentBody.AutoSize = true;
            lblContentBody.Location = new Point(4, 58);
            lblContentBody.Name = "lblContentBody";
            lblContentBody.Size = new Size(66, 17);
            lblContentBody.TabIndex = 6;
            lblContentBody.Text = "Nội dung:";
            // 
            // txtHeading
            // 
            txtHeading.Location = new Point(85, 28);
            txtHeading.Name = "txtHeading";
            txtHeading.Size = new Size(250, 24);
            txtHeading.TabIndex = 5;
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Location = new Point(4, 31);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(54, 17);
            lblHeading.TabIndex = 4;
            lblHeading.Text = "Tiêu đề:";
            // 
            // numStepOrder
            // 
            numStepOrder.Location = new Point(275, 2);
            numStepOrder.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStepOrder.Name = "numStepOrder";
            numStepOrder.Size = new Size(60, 24);
            numStepOrder.TabIndex = 3;
            numStepOrder.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblStepOrder
            // 
            lblStepOrder.AutoSize = true;
            lblStepOrder.Location = new Point(230, 5);
            lblStepOrder.Name = "lblStepOrder";
            lblStepOrder.Size = new Size(49, 17);
            lblStepOrder.TabIndex = 2;
            lblStepOrder.Text = "Thứ tự:";
            // 
            // txtStepID
            // 
            txtStepID.Location = new Point(85, 2);
            txtStepID.Name = "txtStepID";
            txtStepID.Size = new Size(135, 24);
            txtStepID.TabIndex = 1;
            // 
            // lblStepID
            // 
            lblStepID.AutoSize = true;
            lblStepID.Location = new Point(4, 5);
            lblStepID.Name = "lblStepID";
            lblStepID.Size = new Size(64, 17);
            lblStepID.TabIndex = 0;
            lblStepID.Text = "Mã bước:";
            // 
            // pnlStepActions
            // 
            pnlStepActions.Controls.Add(btnThemStep);
            pnlStepActions.Controls.Add(btnLuuStep);
            pnlStepActions.Controls.Add(btnHuyStep);
            pnlStepActions.Controls.Add(btnXoaStep);
            pnlStepActions.Controls.Add(btnKiemTraAccessibility);
            pnlStepActions.Dock = DockStyle.Bottom;
            pnlStepActions.Font = new Font("Segoe UI", 8F);
            pnlStepActions.Location = new Point(3, 187);
            pnlStepActions.Name = "pnlStepActions";
            pnlStepActions.Size = new Size(746, 28);
            pnlStepActions.TabIndex = 2;
            // 
            // btnThemStep
            // 
            btnThemStep.BackColor = Color.Black;
            btnThemStep.FlatAppearance.BorderColor = Color.Black;
            btnThemStep.FlatStyle = FlatStyle.Flat;
            btnThemStep.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnThemStep.ForeColor = Color.White;
            btnThemStep.Location = new Point(0, 2);
            btnThemStep.Name = "btnThemStep";
            btnThemStep.Size = new Size(110, 24);
            btnThemStep.TabIndex = 0;
            btnThemStep.Text = "THÊM BƯỚC";
            btnThemStep.UseVisualStyleBackColor = false;
            btnThemStep.Click += btnThemStep_Click;
            // 
            // btnLuuStep
            // 
            btnLuuStep.BackColor = Color.Black;
            btnLuuStep.FlatAppearance.BorderColor = Color.Black;
            btnLuuStep.FlatStyle = FlatStyle.Flat;
            btnLuuStep.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLuuStep.ForeColor = Color.White;
            btnLuuStep.Location = new Point(0, 2);
            btnLuuStep.Name = "btnLuuStep";
            btnLuuStep.Size = new Size(110, 24);
            btnLuuStep.TabIndex = 1;
            btnLuuStep.Text = "LƯU SỬA BƯỚC";
            btnLuuStep.UseVisualStyleBackColor = false;
            btnLuuStep.Click += btnLuuStep_Click;
            // 
            // btnHuyStep
            // 
            btnHuyStep.BackColor = Color.White;
            btnHuyStep.FlatAppearance.BorderColor = Color.Black;
            btnHuyStep.FlatStyle = FlatStyle.Flat;
            btnHuyStep.ForeColor = Color.Black;
            btnHuyStep.Location = new Point(115, 2);
            btnHuyStep.Name = "btnHuyStep";
            btnHuyStep.Size = new Size(90, 24);
            btnHuyStep.TabIndex = 2;
            btnHuyStep.Text = "HỦY SỬA";
            btnHuyStep.UseVisualStyleBackColor = false;
            btnHuyStep.Click += btnHuyStep_Click;
            // 
            // btnXoaStep
            // 
            btnXoaStep.BackColor = Color.White;
            btnXoaStep.FlatAppearance.BorderColor = Color.Black;
            btnXoaStep.FlatStyle = FlatStyle.Flat;
            btnXoaStep.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnXoaStep.ForeColor = Color.Black;
            btnXoaStep.Location = new Point(210, 2);
            btnXoaStep.Name = "btnXoaStep";
            btnXoaStep.Size = new Size(95, 24);
            btnXoaStep.TabIndex = 3;
            btnXoaStep.Text = "XÓA BƯỚC";
            btnXoaStep.UseVisualStyleBackColor = false;
            btnXoaStep.Click += btnXoaStep_Click;
            // 
            // btnKiemTraAccessibility
            // 
            btnKiemTraAccessibility.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKiemTraAccessibility.BackColor = Color.White;
            btnKiemTraAccessibility.FlatAppearance.BorderColor = Color.Black;
            btnKiemTraAccessibility.FlatStyle = FlatStyle.Flat;
            btnKiemTraAccessibility.ForeColor = Color.Black;
            btnKiemTraAccessibility.Location = new Point(576, 2);
            btnKiemTraAccessibility.Name = "btnKiemTraAccessibility";
            btnKiemTraAccessibility.Size = new Size(170, 24);
            btnKiemTraAccessibility.TabIndex = 4;
            btnKiemTraAccessibility.Text = "KIỂM TRA TRỢ NĂNG";
            btnKiemTraAccessibility.UseVisualStyleBackColor = false;
            btnKiemTraAccessibility.Click += btnKiemTraAccessibility_Click;
            // 
            // FrmBienTapCauChuyen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 460);
            Controls.Add(splitContainerMain);
            Font = new Font("Segoe UI", 8F);
            MinimumSize = new Size(760, 460);
            Name = "FrmBienTapCauChuyen";
            Padding = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Biên Tập Câu Chuyện & Kịch Bản";
            Load += FrmBienTapCauChuyen_Load;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            grpStory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStories).EndInit();
            pnlStoryInput.ResumeLayout(false);
            pnlStoryInput.PerformLayout();
            pnlStoryActions.ResumeLayout(false);
            grpSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSteps).EndInit();
            pnlStepInput.ResumeLayout(false);
            pnlStepInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStepOrder).EndInit();
            pnlStepActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private GroupBox grpStory;
        private Panel pnlStoryInput;
        private Label lblCauChuyenID;
        private TextBox txtCauChuyenID;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblSynopsis;
        private RichTextBox rtbSynopsis;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Panel pnlStoryActions;
        private Button btnThemStory;
        private Button btnLuuStory;
        private Button btnHuyStory;
        private Button btnXoaStory;
        private DataGridView dgvStories;

        private GroupBox grpSteps;
        private Panel pnlStepInput;
        private Label lblStepID;
        private TextBox txtStepID;
        private Label lblStepOrder;
        private NumericUpDown numStepOrder;
        private Label lblHeading;
        private TextBox txtHeading;
        private Label lblContentBody;
        private RichTextBox rtbContentBody;
        private Label lblArtifactLink;
        private ComboBox cboArtifactLink;
        private Panel pnlStepActions;
        private Button btnThemStep;
        private Button btnLuuStep;
        private Button btnHuyStep;
        private Button btnXoaStep;
        private Button btnKiemTraAccessibility;
        private DataGridView dgvSteps;
    }
}