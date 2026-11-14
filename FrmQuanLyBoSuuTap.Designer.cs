namespace Trienlamtructuyen
{
    partial class FrmQuanLyBoSuuTap
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
            grpCollection = new GroupBox();
            dgvCollection = new DataGridView();
            pnlCollectionInput = new Panel();
            chkIsPublished = new CheckBox();
            rtbDescription = new RichTextBox();
            lblDescription = new Label();
            txtTheme = new TextBox();
            lblTheme = new Label();
            txtTitle = new TextBox();
            lblTitle = new Label();
            txtCollectionID = new TextBox();
            lblCollectionID = new Label();
            pnlCollectionActions = new Panel();
            btnXoaCollection = new Button();
            btnHuyCollection = new Button();
            btnLuuCollection = new Button();
            btnThemCollection = new Button();
            grpArtifact = new GroupBox();
            dgvArtifact = new DataGridView();
            pnlArtifactInput = new Panel();
            txtMaterial = new TextBox();
            lblMaterial = new Label();
            txtHistoricalPeriod = new TextBox();
            lblHistoricalPeriod = new Label();
            txtOrigin = new TextBox();
            lblOrigin = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtArtifactID = new TextBox();
            lblArtifactID = new Label();
            pnlArtifactActions = new Panel();
            btnXoaArtifact = new Button();
            btnHuyArtifact = new Button();
            btnLuuArtifact = new Button();
            btnThemArtifact = new Button();

            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            grpCollection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCollection).BeginInit();
            pnlCollectionInput.SuspendLayout();
            pnlCollectionActions.SuspendLayout();
            grpArtifact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArtifact).BeginInit();
            pnlArtifactInput.SuspendLayout();
            pnlArtifactActions.SuspendLayout();
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
            splitContainerMain.Panel1.Controls.Add(grpCollection);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(grpArtifact);
            splitContainerMain.Size = new Size(752, 312);
            splitContainerMain.SplitterDistance = 153;
            splitContainerMain.TabIndex = 0;
            // 
            // grpCollection
            // 
            grpCollection.Controls.Add(dgvCollection);
            grpCollection.Controls.Add(pnlCollectionInput);
            grpCollection.Controls.Add(pnlCollectionActions);
            grpCollection.Dock = DockStyle.Fill;
            grpCollection.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            grpCollection.ForeColor = Color.Black;
            grpCollection.Location = new Point(0, 0);
            grpCollection.Name = "grpCollection";
            grpCollection.Padding = new Padding(3);
            grpCollection.Size = new Size(752, 153);
            grpCollection.TabIndex = 0;
            grpCollection.TabStop = false;
            grpCollection.Text = "QUẢN LÝ BỘ SƯU TẬP";
            // 
            // dgvCollection
            // 
            dgvCollection.AllowUserToAddRows = false;
            dgvCollection.AllowUserToDeleteRows = false;
            dgvCollection.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCollection.BackgroundColor = Color.White;
            dgvCollection.BorderStyle = BorderStyle.Fixed3D;
            dgvCollection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCollection.Dock = DockStyle.Fill;
            dgvCollection.Location = new Point(273, 18);
            dgvCollection.MultiSelect = false;
            dgvCollection.Name = "dgvCollection";
            dgvCollection.ReadOnly = true;
            dgvCollection.RowHeadersVisible = false;
            dgvCollection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCollection.Size = new Size(476, 108);
            dgvCollection.TabIndex = 2;
            dgvCollection.CellClick += dgvCollection_CellClick;
            dgvCollection.SelectionChanged += dgvCollection_SelectionChanged;
            // 
            // pnlCollectionInput
            // 
            pnlCollectionInput.Controls.Add(chkIsPublished);
            pnlCollectionInput.Controls.Add(rtbDescription);
            pnlCollectionInput.Controls.Add(lblDescription);
            pnlCollectionInput.Controls.Add(txtTheme);
            pnlCollectionInput.Controls.Add(lblTheme);
            pnlCollectionInput.Controls.Add(txtTitle);
            pnlCollectionInput.Controls.Add(lblTitle);
            pnlCollectionInput.Controls.Add(txtCollectionID);
            pnlCollectionInput.Controls.Add(lblCollectionID);
            pnlCollectionInput.Dock = DockStyle.Left;
            pnlCollectionInput.Font = new Font("Segoe UI", 8F);
            pnlCollectionInput.ForeColor = Color.Black;
            pnlCollectionInput.Location = new Point(3, 18);
            pnlCollectionInput.Name = "pnlCollectionInput";
            pnlCollectionInput.Size = new Size(270, 108);
            pnlCollectionInput.TabIndex = 0;
            // 
            // chkIsPublished
            // 
            chkIsPublished.AutoSize = true;
            chkIsPublished.Location = new Point(85, 87);
            chkIsPublished.Name = "chkIsPublished";
            chkIsPublished.Size = new Size(130, 17);
            chkIsPublished.TabIndex = 8;
            chkIsPublished.Text = "Xuất bản (Công khai)";
            chkIsPublished.UseVisualStyleBackColor = true;
            // 
            // rtbDescription
            // 
            rtbDescription.BorderStyle = BorderStyle.FixedSingle;
            rtbDescription.Location = new Point(85, 56);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(180, 28);
            rtbDescription.TabIndex = 7;
            rtbDescription.Text = "";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(4, 58);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(40, 13);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Mô tả:";
            // 
            // txtTheme
            // 
            txtTheme.BorderStyle = BorderStyle.FixedSingle;
            txtTheme.Location = new Point(85, 38);
            txtTheme.Name = "txtTheme";
            txtTheme.Size = new Size(180, 22);
            txtTheme.TabIndex = 5;
            // 
            // lblTheme
            // 
            lblTheme.AutoSize = true;
            lblTheme.Location = new Point(4, 40);
            lblTheme.Name = "lblTheme";
            lblTheme.Size = new Size(47, 13);
            lblTheme.TabIndex = 10;
            lblTheme.Text = "Chủ đề:";
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Location = new Point(85, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(180, 22);
            txtTitle.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(4, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(84, 13);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Tên bộ sưu tập:";
            // 
            // txtCollectionID
            // 
            txtCollectionID.BorderStyle = BorderStyle.FixedSingle;
            txtCollectionID.Location = new Point(85, 2);
            txtCollectionID.Name = "txtCollectionID";
            txtCollectionID.Size = new Size(180, 22);
            txtCollectionID.TabIndex = 1;
            // 
            // lblCollectionID
            // 
            lblCollectionID.AutoSize = true;
            lblCollectionID.Location = new Point(4, 5);
            lblCollectionID.Name = "lblCollectionID";
            lblCollectionID.Size = new Size(80, 13);
            lblCollectionID.TabIndex = 12;
            lblCollectionID.Text = "Mã bộ sưu tập:";
            // 
            // pnlCollectionActions
            // 
            pnlCollectionActions.Controls.Add(btnXoaCollection);
            pnlCollectionActions.Controls.Add(btnHuyCollection);
            pnlCollectionActions.Controls.Add(btnLuuCollection);
            pnlCollectionActions.Controls.Add(btnThemCollection);
            pnlCollectionActions.Dock = DockStyle.Bottom;
            pnlCollectionActions.Font = new Font("Segoe UI", 8F);
            pnlCollectionActions.Location = new Point(3, 126);
            pnlCollectionActions.Name = "pnlCollectionActions";
            pnlCollectionActions.Size = new Size(746, 24);
            pnlCollectionActions.TabIndex = 1;
            // 
            // btnXoaCollection
            // 
            btnXoaCollection.BackColor = Color.White;
            btnXoaCollection.FlatAppearance.BorderColor = Color.Black;
            btnXoaCollection.FlatStyle = FlatStyle.Flat;
            btnXoaCollection.Location = new Point(165, 1);
            btnXoaCollection.Name = "btnXoaCollection";
            btnXoaCollection.Size = new Size(75, 22);
            btnXoaCollection.TabIndex = 3;
            btnXoaCollection.Text = "Xóa";
            btnXoaCollection.UseVisualStyleBackColor = false;
            btnXoaCollection.Click += btnXoaCollection_Click;
            // 
            // btnHuyCollection
            // 
            btnHuyCollection.BackColor = Color.White;
            btnHuyCollection.FlatAppearance.BorderColor = Color.Black;
            btnHuyCollection.FlatStyle = FlatStyle.Flat;
            btnHuyCollection.Location = new Point(84, 1);
            btnHuyCollection.Name = "btnHuyCollection";
            btnHuyCollection.Size = new Size(75, 22);
            btnHuyCollection.TabIndex = 2;
            btnHuyCollection.Text = "Hủy Sửa";
            btnHuyCollection.UseVisualStyleBackColor = false;
            btnHuyCollection.Click += btnHuyCollection_Click;
            // 
            // btnLuuCollection
            // 
            btnLuuCollection.BackColor = Color.Black;
            btnLuuCollection.FlatAppearance.BorderColor = Color.Black;
            btnLuuCollection.FlatStyle = FlatStyle.Flat;
            btnLuuCollection.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLuuCollection.ForeColor = Color.White;
            btnLuuCollection.Location = new Point(0, 1);
            btnLuuCollection.Name = "btnLuuCollection";
            btnLuuCollection.Size = new Size(78, 22);
            btnLuuCollection.TabIndex = 1;
            btnLuuCollection.Text = "Lưu";
            btnLuuCollection.UseVisualStyleBackColor = false;
            btnLuuCollection.Click += btnLuuCollection_Click;
            // 
            // btnThemCollection
            // 
            btnThemCollection.BackColor = Color.Black;
            btnThemCollection.FlatAppearance.BorderColor = Color.Black;
            btnThemCollection.FlatStyle = FlatStyle.Flat;
            btnThemCollection.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnThemCollection.ForeColor = Color.White;
            btnThemCollection.Location = new Point(0, 1);
            btnThemCollection.Name = "btnThemCollection";
            btnThemCollection.Size = new Size(78, 22);
            btnThemCollection.TabIndex = 0;
            btnThemCollection.Text = "Thêm Mới";
            btnThemCollection.UseVisualStyleBackColor = false;
            btnThemCollection.Click += btnThemCollection_Click;
            // 
            // grpArtifact
            // 
            grpArtifact.Controls.Add(dgvArtifact);
            grpArtifact.Controls.Add(pnlArtifactInput);
            grpArtifact.Controls.Add(pnlArtifactActions);
            grpArtifact.Dock = DockStyle.Fill;
            grpArtifact.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            grpArtifact.ForeColor = Color.Black;
            grpArtifact.Location = new Point(0, 0);
            grpArtifact.Name = "grpArtifact";
            grpArtifact.Padding = new Padding(3);
            grpArtifact.Size = new Size(752, 155);
            grpArtifact.TabIndex = 0;
            grpArtifact.TabStop = false;
            grpArtifact.Text = "DANH SÁCH HIỆN VẬT THUỘC BỘ SƯU TẬP";
            // 
            // dgvArtifact
            // 
            dgvArtifact.AllowUserToAddRows = false;
            dgvArtifact.AllowUserToDeleteRows = false;
            dgvArtifact.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArtifact.BackgroundColor = Color.White;
            dgvArtifact.BorderStyle = BorderStyle.Fixed3D;
            dgvArtifact.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArtifact.Dock = DockStyle.Fill;
            dgvArtifact.Location = new Point(273, 18);
            dgvArtifact.MultiSelect = false;
            dgvArtifact.Name = "dgvArtifact";
            dgvArtifact.ReadOnly = true;
            dgvArtifact.RowHeadersVisible = false;
            dgvArtifact.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArtifact.Size = new Size(476, 110);
            dgvArtifact.TabIndex = 2;
            dgvArtifact.CellClick += dgvArtifact_CellClick;
            dgvArtifact.SelectionChanged += dgvArtifact_SelectionChanged;
            // 
            // pnlArtifactInput
            // 
            pnlArtifactInput.Controls.Add(txtMaterial);
            pnlArtifactInput.Controls.Add(lblMaterial);
            pnlArtifactInput.Controls.Add(txtHistoricalPeriod);
            pnlArtifactInput.Controls.Add(lblHistoricalPeriod);
            pnlArtifactInput.Controls.Add(txtOrigin);
            pnlArtifactInput.Controls.Add(lblOrigin);
            pnlArtifactInput.Controls.Add(txtName);
            pnlArtifactInput.Controls.Add(lblName);
            pnlArtifactInput.Controls.Add(txtArtifactID);
            pnlArtifactInput.Controls.Add(lblArtifactID);
            pnlArtifactInput.Dock = DockStyle.Left;
            pnlArtifactInput.Font = new Font("Segoe UI", 8F);
            pnlArtifactInput.ForeColor = Color.Black;
            pnlArtifactInput.Location = new Point(3, 18);
            pnlArtifactInput.Name = "pnlArtifactInput";
            pnlArtifactInput.Size = new Size(270, 110);
            pnlArtifactInput.TabIndex = 0;
            // 
            // txtMaterial
            // 
            txtMaterial.BorderStyle = BorderStyle.FixedSingle;
            txtMaterial.Location = new Point(85, 84);
            txtMaterial.Name = "txtMaterial";
            txtMaterial.Size = new Size(180, 22);
            txtMaterial.TabIndex = 9;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(4, 87);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(55, 13);
            lblMaterial.TabIndex = 10;
            lblMaterial.Text = "Chất liệu:";
            // 
            // txtHistoricalPeriod
            // 
            txtHistoricalPeriod.BorderStyle = BorderStyle.FixedSingle;
            txtHistoricalPeriod.Location = new Point(85, 63);
            txtHistoricalPeriod.Name = "txtHistoricalPeriod";
            txtHistoricalPeriod.Size = new Size(180, 22);
            txtHistoricalPeriod.TabIndex = 7;
            // 
            // lblHistoricalPeriod
            // 
            lblHistoricalPeriod.AutoSize = true;
            lblHistoricalPeriod.Location = new Point(4, 66);
            lblHistoricalPeriod.Name = "lblHistoricalPeriod";
            lblHistoricalPeriod.Size = new Size(83, 13);
            lblHistoricalPeriod.TabIndex = 11;
            lblHistoricalPeriod.Text = "Thời kỳ lịch sử:";
            // 
            // txtOrigin
            // 
            txtOrigin.BorderStyle = BorderStyle.FixedSingle;
            txtOrigin.Location = new Point(85, 42);
            txtOrigin.Name = "txtOrigin";
            txtOrigin.Size = new Size(180, 22);
            txtOrigin.TabIndex = 5;
            // 
            // lblOrigin
            // 
            lblOrigin.AutoSize = true;
            lblOrigin.Location = new Point(4, 45);
            lblOrigin.Name = "lblOrigin";
            lblOrigin.Size = new Size(49, 13);
            lblOrigin.TabIndex = 12;
            lblOrigin.Text = "Xuất xứ:";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Location = new Point(85, 21);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 22);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(4, 24);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 13);
            lblName.TabIndex = 13;
            lblName.Text = "Tên hiện vật:";
            // 
            // txtArtifactID
            // 
            txtArtifactID.BorderStyle = BorderStyle.FixedSingle;
            txtArtifactID.Location = new Point(85, 0);
            txtArtifactID.Name = "txtArtifactID";
            txtArtifactID.Size = new Size(180, 22);
            txtArtifactID.TabIndex = 1;
            // 
            // lblArtifactID
            // 
            lblArtifactID.AutoSize = true;
            lblArtifactID.Location = new Point(4, 3);
            lblArtifactID.Name = "lblArtifactID";
            lblArtifactID.Size = new Size(69, 13);
            lblArtifactID.TabIndex = 14;
            lblArtifactID.Text = "Mã hiện vật:";
            // 
            // pnlArtifactActions
            // 
            pnlArtifactActions.Controls.Add(btnXoaArtifact);
            pnlArtifactActions.Controls.Add(btnHuyArtifact);
            pnlArtifactActions.Controls.Add(btnLuuArtifact);
            pnlArtifactActions.Controls.Add(btnThemArtifact);
            pnlArtifactActions.Dock = DockStyle.Bottom;
            pnlArtifactActions.Font = new Font("Segoe UI", 8F);
            pnlArtifactActions.Location = new Point(3, 128);
            pnlArtifactActions.Name = "pnlArtifactActions";
            pnlArtifactActions.Size = new Size(746, 24);
            pnlArtifactActions.TabIndex = 1;
            // 
            // btnXoaArtifact
            // 
            btnXoaArtifact.BackColor = Color.White;
            btnXoaArtifact.FlatAppearance.BorderColor = Color.Black;
            btnXoaArtifact.FlatStyle = FlatStyle.Flat;
            btnXoaArtifact.Location = new Point(165, 1);
            btnXoaArtifact.Name = "btnXoaArtifact";
            btnXoaArtifact.Size = new Size(85, 22);
            btnXoaArtifact.TabIndex = 3;
            btnXoaArtifact.Text = "Xóa";
            btnXoaArtifact.UseVisualStyleBackColor = false;
            btnXoaArtifact.Click += btnXoaArtifact_Click;
            // 
            // btnHuyArtifact
            // 
            btnHuyArtifact.BackColor = Color.White;
            btnHuyArtifact.FlatAppearance.BorderColor = Color.Black;
            btnHuyArtifact.FlatStyle = FlatStyle.Flat;
            btnHuyArtifact.Location = new Point(84, 1);
            btnHuyArtifact.Name = "btnHuyArtifact";
            btnHuyArtifact.Size = new Size(75, 22);
            btnHuyArtifact.TabIndex = 2;
            btnHuyArtifact.Text = "Hủy Sửa";
            btnHuyArtifact.UseVisualStyleBackColor = false;
            btnHuyArtifact.Click += btnHuyArtifact_Click;
            // 
            // btnLuuArtifact
            // 
            btnLuuArtifact.BackColor = Color.Black;
            btnLuuArtifact.FlatAppearance.BorderColor = Color.Black;
            btnLuuArtifact.FlatStyle = FlatStyle.Flat;
            btnLuuArtifact.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLuuArtifact.ForeColor = Color.White;
            btnLuuArtifact.Location = new Point(0, 1);
            btnLuuArtifact.Name = "btnLuuArtifact";
            btnLuuArtifact.Size = new Size(78, 22);
            btnLuuArtifact.TabIndex = 1;
            btnLuuArtifact.Text = "Lưu";
            btnLuuArtifact.UseVisualStyleBackColor = false;
            btnLuuArtifact.Click += btnLuuArtifact_Click;
            // 
            // btnThemArtifact
            // 
            btnThemArtifact.BackColor = Color.Black;
            btnThemArtifact.FlatAppearance.BorderColor = Color.Black;
            btnThemArtifact.FlatStyle = FlatStyle.Flat;
            btnThemArtifact.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnThemArtifact.ForeColor = Color.White;
            btnThemArtifact.Location = new Point(0, 1);
            btnThemArtifact.Name = "btnThemArtifact";
            btnThemArtifact.Size = new Size(78, 22);
            btnThemArtifact.TabIndex = 0;
            btnThemArtifact.Text = "Thêm Mới";
            btnThemArtifact.UseVisualStyleBackColor = false;
            btnThemArtifact.Click += btnThemArtifact_Click;
            // 
            // FrmQuanLyBoSuuTap
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 320);
            Controls.Add(splitContainerMain);
            Font = new Font("Segoe UI", 8F);
            MinimumSize = new Size(760, 320);
            Name = "FrmQuanLyBoSuuTap";
            Padding = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Bộ Sưu Tập & Hiện Vật";
            Load += FrmQuanLyBoSuuTap_Load;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            grpCollection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCollection).EndInit();
            pnlCollectionInput.ResumeLayout(false);
            pnlCollectionInput.PerformLayout();
            pnlCollectionActions.ResumeLayout(false);
            grpArtifact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArtifact).EndInit();
            pnlArtifactInput.ResumeLayout(false);
            pnlArtifactInput.PerformLayout();
            pnlArtifactActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private GroupBox grpCollection;
        private Panel pnlCollectionInput;
        private Label lblCollectionID;
        private TextBox txtCollectionID;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblTheme;
        private TextBox txtTheme;
        private Label lblDescription;
        private RichTextBox rtbDescription;
        private CheckBox chkIsPublished;
        private Panel pnlCollectionActions;
        private Button btnThemCollection;
        private Button btnLuuCollection;
        private Button btnHuyCollection;
        private Button btnXoaCollection;
        private DataGridView dgvCollection;

        private GroupBox grpArtifact;
        private Panel pnlArtifactInput;
        private Label lblArtifactID;
        private TextBox txtArtifactID;
        private Label lblName;
        private TextBox txtName;
        private Label lblOrigin;
        private TextBox txtOrigin;
        private Label lblHistoricalPeriod;
        private TextBox txtHistoricalPeriod;
        private Label lblMaterial;
        private TextBox txtMaterial;
        private Panel pnlArtifactActions;
        private Button btnThemArtifact;
        private Button btnLuuArtifact;
        private Button btnHuyArtifact;
        private Button btnXoaArtifact;
        private DataGridView dgvArtifact;
    }
}