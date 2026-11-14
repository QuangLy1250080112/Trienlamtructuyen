namespace Trienlamtructuyen
{
    partial class FrmThietKeTuyenThamQuan
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
            grpRoute = new GroupBox();
            dgvRoutes = new DataGridView();
            pnlRouteInput = new Panel();
            txtRouteName = new TextBox();
            lblRouteName = new Label();
            txtRouteID = new TextBox();
            lblRouteID = new Label();
            pnlRouteActions = new Panel();
            btnXoaRoute = new Button();
            btnHuyRoute = new Button();
            btnLuuRoute = new Button();
            btnThemRoute = new Button();
            grpNodes = new GroupBox();
            dgvNodes = new DataGridView();
            pnlNodeInput = new Panel();
            cboStep = new ComboBox();
            lblStep = new Label();
            txtNodeName = new TextBox();
            lblNodeName = new Label();
            txtNodeID = new TextBox();
            lblNodeID = new Label();
            pnlNodeActions = new Panel();
            btnXoaNode = new Button();
            btnHuyNode = new Button();
            btnLuuNode = new Button();
            btnThemNode = new Button();

            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            grpRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoutes).BeginInit();
            pnlRouteInput.SuspendLayout();
            pnlRouteActions.SuspendLayout();
            grpNodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNodes).BeginInit();
            pnlNodeInput.SuspendLayout();
            pnlNodeActions.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(4, 4);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(grpRoute);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(grpNodes);
            splitContainerMain.Size = new Size(772, 332);
            splitContainerMain.SplitterDistance = 360;
            splitContainerMain.TabIndex = 0;
            // 
            // grpRoute
            // 
            grpRoute.Controls.Add(dgvRoutes);
            grpRoute.Controls.Add(pnlRouteInput);
            grpRoute.Controls.Add(pnlRouteActions);
            grpRoute.Dock = DockStyle.Fill;
            grpRoute.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            grpRoute.ForeColor = Color.Black;
            grpRoute.Location = new Point(0, 0);
            grpRoute.Name = "grpRoute";
            grpRoute.Padding = new Padding(3);
            grpRoute.Size = new Size(360, 332);
            grpRoute.TabIndex = 0;
            grpRoute.TabStop = false;
            grpRoute.Text = "TUYẾN THAM QUAN";
            // 
            // dgvRoutes
            // 
            dgvRoutes.AllowUserToAddRows = false;
            dgvRoutes.AllowUserToDeleteRows = false;
            dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoutes.BackgroundColor = Color.White;
            dgvRoutes.BorderStyle = BorderStyle.Fixed3D;
            dgvRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoutes.Dock = DockStyle.Fill;
            dgvRoutes.Location = new Point(3, 80);
            dgvRoutes.MultiSelect = false;
            dgvRoutes.Name = "dgvRoutes";
            dgvRoutes.ReadOnly = true;
            dgvRoutes.RowHeadersVisible = false;
            dgvRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoutes.Size = new Size(354, 225);
            dgvRoutes.TabIndex = 1;
            dgvRoutes.CellClick += dgvRoutes_CellClick;
            // 
            // pnlRouteInput
            // 
            pnlRouteInput.Controls.Add(txtRouteName);
            pnlRouteInput.Controls.Add(lblRouteName);
            pnlRouteInput.Controls.Add(txtRouteID);
            pnlRouteInput.Controls.Add(lblRouteID);
            pnlRouteInput.Dock = DockStyle.Top;
            pnlRouteInput.Font = new Font("Segoe UI", 8F);
            pnlRouteInput.Location = new Point(3, 18);
            pnlRouteInput.Name = "pnlRouteInput";
            pnlRouteInput.Size = new Size(354, 62);
            pnlRouteInput.TabIndex = 0;
            // 
            // txtRouteName
            // 
            txtRouteName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRouteName.BorderStyle = BorderStyle.FixedSingle;
            txtRouteName.Location = new Point(85, 33);
            txtRouteName.Name = "txtRouteName";
            txtRouteName.Size = new Size(265, 22);
            txtRouteName.TabIndex = 3;
            // 
            // lblRouteName
            // 
            lblRouteName.AutoSize = true;
            lblRouteName.Location = new Point(4, 36);
            lblRouteName.Name = "lblRouteName";
            lblRouteName.Size = new Size(60, 13);
            lblRouteName.TabIndex = 2;
            lblRouteName.Text = "Tên tuyến:";
            // 
            // txtRouteID
            // 
            txtRouteID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRouteID.BorderStyle = BorderStyle.FixedSingle;
            txtRouteID.Location = new Point(85, 4);
            txtRouteID.Name = "txtRouteID";
            txtRouteID.Size = new Size(265, 22);
            txtRouteID.TabIndex = 1;
            // 
            // lblRouteID
            // 
            lblRouteID.AutoSize = true;
            lblRouteID.Location = new Point(4, 8);
            lblRouteID.Name = "lblRouteID";
            lblRouteID.Size = new Size(58, 13);
            lblRouteID.TabIndex = 0;
            lblRouteID.Text = "Mã tuyến:";
            // 
            // pnlRouteActions
            // 
            pnlRouteActions.Controls.Add(btnXoaRoute);
            pnlRouteActions.Controls.Add(btnHuyRoute);
            pnlRouteActions.Controls.Add(btnLuuRoute);
            pnlRouteActions.Controls.Add(btnThemRoute);
            pnlRouteActions.Dock = DockStyle.Bottom;
            pnlRouteActions.Font = new Font("Segoe UI", 8F);
            pnlRouteActions.Location = new Point(3, 305);
            pnlRouteActions.Name = "pnlRouteActions";
            pnlRouteActions.Size = new Size(354, 24);
            pnlRouteActions.TabIndex = 2;
            // 
            // btnXoaRoute
            // 
            btnXoaRoute.BackColor = Color.White;
            btnXoaRoute.FlatAppearance.BorderColor = Color.Black;
            btnXoaRoute.FlatStyle = FlatStyle.Flat;
            btnXoaRoute.Location = new Point(175, 1);
            btnXoaRoute.Name = "btnXoaRoute";
            btnXoaRoute.Size = new Size(75, 22);
            btnXoaRoute.TabIndex = 3;
            btnXoaRoute.Text = "Xóa";
            btnXoaRoute.UseVisualStyleBackColor = false;
            btnXoaRoute.Click += btnXoaRoute_Click;
            // 
            // btnHuyRoute
            // 
            btnHuyRoute.BackColor = Color.White;
            btnHuyRoute.FlatAppearance.BorderColor = Color.Black;
            btnHuyRoute.FlatStyle = FlatStyle.Flat;
            btnHuyRoute.Location = new Point(90, 1);
            btnHuyRoute.Name = "btnHuyRoute";
            btnHuyRoute.Size = new Size(78, 22);
            btnHuyRoute.TabIndex = 2;
            btnHuyRoute.Text = "Hủy Sửa";
            btnHuyRoute.UseVisualStyleBackColor = false;
            btnHuyRoute.Click += btnHuyRoute_Click;
            // 
            // btnLuuRoute
            // 
            btnLuuRoute.BackColor = Color.Black;
            btnLuuRoute.FlatAppearance.BorderColor = Color.Black;
            btnLuuRoute.FlatStyle = FlatStyle.Flat;
            btnLuuRoute.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLuuRoute.ForeColor = Color.White;
            btnLuuRoute.Location = new Point(0, 1);
            btnLuuRoute.Name = "btnLuuRoute";
            btnLuuRoute.Size = new Size(84, 22);
            btnLuuRoute.TabIndex = 1;
            btnLuuRoute.Text = "Lưu Sửa";
            btnLuuRoute.UseVisualStyleBackColor = false;
            btnLuuRoute.Click += btnLuuRoute_Click;
            // 
            // btnThemRoute
            // 
            btnThemRoute.BackColor = Color.Black;
            btnThemRoute.FlatAppearance.BorderColor = Color.Black;
            btnThemRoute.FlatStyle = FlatStyle.Flat;
            btnThemRoute.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnThemRoute.ForeColor = Color.White;
            btnThemRoute.Location = new Point(0, 1);
            btnThemRoute.Name = "btnThemRoute";
            btnThemRoute.Size = new Size(84, 22);
            btnThemRoute.TabIndex = 0;
            btnThemRoute.Text = "Thêm Tuyến";
            btnThemRoute.UseVisualStyleBackColor = false;
            btnThemRoute.Click += btnThemRoute_Click;
            // 
            // grpNodes
            // 
            grpNodes.Controls.Add(dgvNodes);
            grpNodes.Controls.Add(pnlNodeInput);
            grpNodes.Controls.Add(pnlNodeActions);
            grpNodes.Dock = DockStyle.Fill;
            grpNodes.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            grpNodes.ForeColor = Color.Black;
            grpNodes.Location = new Point(0, 0);
            grpNodes.Name = "grpNodes";
            grpNodes.Padding = new Padding(3);
            grpNodes.Size = new Size(408, 332);
            grpNodes.TabIndex = 0;
            grpNodes.TabStop = false;
            grpNodes.Text = "ĐIỂM DỪNG";
            // 
            // dgvNodes
            // 
            dgvNodes.AllowUserToAddRows = false;
            dgvNodes.AllowUserToDeleteRows = false;
            dgvNodes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNodes.BackgroundColor = Color.White;
            dgvNodes.BorderStyle = BorderStyle.Fixed3D;
            dgvNodes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNodes.Dock = DockStyle.Fill;
            dgvNodes.Location = new Point(3, 98);
            dgvNodes.MultiSelect = false;
            dgvNodes.Name = "dgvNodes";
            dgvNodes.ReadOnly = true;
            dgvNodes.RowHeadersVisible = false;
            dgvNodes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNodes.Size = new Size(402, 207);
            dgvNodes.TabIndex = 1;
            dgvNodes.CellClick += dgvNodes_CellClick;
            // 
            // pnlNodeInput
            // 
            pnlNodeInput.Controls.Add(cboStep);
            pnlNodeInput.Controls.Add(lblStep);
            pnlNodeInput.Controls.Add(txtNodeName);
            pnlNodeInput.Controls.Add(lblNodeName);
            pnlNodeInput.Controls.Add(txtNodeID);
            pnlNodeInput.Controls.Add(lblNodeID);
            pnlNodeInput.Dock = DockStyle.Top;
            pnlNodeInput.Font = new Font("Segoe UI", 8F);
            pnlNodeInput.Location = new Point(3, 18);
            pnlNodeInput.Name = "pnlNodeInput";
            pnlNodeInput.Size = new Size(402, 80);
            pnlNodeInput.TabIndex = 0;
            // 
            // cboStep
            // 
            cboStep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboStep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStep.FormattingEnabled = true;
            cboStep.Location = new Point(70, 52);
            cboStep.Name = "cboStep";
            cboStep.Size = new Size(328, 21);
            cboStep.TabIndex = 5;
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Location = new Point(4, 55);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(54, 13);
            lblStep.TabIndex = 4;
            lblStep.Text = "Bước KB:";
            // 
            // txtNodeName
            // 
            txtNodeName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNodeName.BorderStyle = BorderStyle.FixedSingle;
            txtNodeName.Location = new Point(70, 27);
            txtNodeName.Name = "txtNodeName";
            txtNodeName.Size = new Size(328, 22);
            txtNodeName.TabIndex = 3;
            // 
            // lblNodeName
            // 
            lblNodeName.AutoSize = true;
            lblNodeName.Location = new Point(4, 30);
            lblNodeName.Name = "lblNodeName";
            lblNodeName.Size = new Size(49, 13);
            lblNodeName.TabIndex = 2;
            lblNodeName.Text = "Tên nút:";
            // 
            // txtNodeID
            // 
            txtNodeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNodeID.BorderStyle = BorderStyle.FixedSingle;
            txtNodeID.Location = new Point(70, 2);
            txtNodeID.Name = "txtNodeID";
            txtNodeID.Size = new Size(328, 22);
            txtNodeID.TabIndex = 1;
            // 
            // lblNodeID
            // 
            lblNodeID.AutoSize = true;
            lblNodeID.Location = new Point(4, 5);
            lblNodeID.Name = "lblNodeID";
            lblNodeID.Size = new Size(47, 13);
            lblNodeID.TabIndex = 0;
            lblNodeID.Text = "Mã nút:";
            // 
            // pnlNodeActions
            // 
            pnlNodeActions.Controls.Add(btnXoaNode);
            pnlNodeActions.Controls.Add(btnHuyNode);
            pnlNodeActions.Controls.Add(btnLuuNode);
            pnlNodeActions.Controls.Add(btnThemNode);
            pnlNodeActions.Dock = DockStyle.Bottom;
            pnlNodeActions.Font = new Font("Segoe UI", 8F);
            pnlNodeActions.Location = new Point(3, 305);
            pnlNodeActions.Name = "pnlNodeActions";
            pnlNodeActions.Size = new Size(402, 24);
            pnlNodeActions.TabIndex = 2;
            // 
            // btnXoaNode
            // 
            btnXoaNode.BackColor = Color.White;
            btnXoaNode.FlatAppearance.BorderColor = Color.Black;
            btnXoaNode.FlatStyle = FlatStyle.Flat;
            btnXoaNode.Location = new Point(175, 1);
            btnXoaNode.Name = "btnXoaNode";
            btnXoaNode.Size = new Size(75, 22);
            btnXoaNode.TabIndex = 3;
            btnXoaNode.Text = "Xóa";
            btnXoaNode.UseVisualStyleBackColor = false;
            btnXoaNode.Click += btnXoaNode_Click;
            // 
            // btnHuyNode
            // 
            btnHuyNode.BackColor = Color.White;
            btnHuyNode.FlatAppearance.BorderColor = Color.Black;
            btnHuyNode.FlatStyle = FlatStyle.Flat;
            btnHuyNode.Location = new Point(90, 1);
            btnHuyNode.Name = "btnHuyNode";
            btnHuyNode.Size = new Size(78, 22);
            btnHuyNode.TabIndex = 2;
            btnHuyNode.Text = "Hủy Sửa";
            btnHuyNode.UseVisualStyleBackColor = false;
            btnHuyNode.Click += btnHuyNode_Click;
            // 
            // btnLuuNode
            // 
            btnLuuNode.BackColor = Color.Black;
            btnLuuNode.FlatAppearance.BorderColor = Color.Black;
            btnLuuNode.FlatStyle = FlatStyle.Flat;
            btnLuuNode.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLuuNode.ForeColor = Color.White;
            btnLuuNode.Location = new Point(0, 1);
            btnLuuNode.Name = "btnLuuNode";
            btnLuuNode.Size = new Size(84, 22);
            btnLuuNode.TabIndex = 1;
            btnLuuNode.Text = "Lưu Sửa";
            btnLuuNode.UseVisualStyleBackColor = false;
            btnLuuNode.Click += btnLuuNode_Click;
            // 
            // btnThemNode
            // 
            btnThemNode.BackColor = Color.Black;
            btnThemNode.FlatAppearance.BorderColor = Color.Black;
            btnThemNode.FlatStyle = FlatStyle.Flat;
            btnThemNode.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnThemNode.ForeColor = Color.White;
            btnThemNode.Location = new Point(0, 1);
            btnThemNode.Name = "btnThemNode";
            btnThemNode.Size = new Size(84, 22);
            btnThemNode.TabIndex = 0;
            btnThemNode.Text = "Thêm Nút";
            btnThemNode.UseVisualStyleBackColor = false;
            btnThemNode.Click += btnThemNode_Click;
            // 
            // FrmThietKeTuyenThamQuan
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(780, 340);
            Controls.Add(splitContainerMain);
            Font = new Font("Segoe UI", 8F);
            MinimumSize = new Size(780, 340);
            Name = "FrmThietKeTuyenThamQuan";
            Padding = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thiết Kế Tuyến Tham Quan & Điểm Dừng";
            Load += FrmThietKeTuyenThamQuan_Load;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            grpRoute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoutes).EndInit();
            pnlRouteInput.ResumeLayout(false);
            pnlRouteInput.PerformLayout();
            pnlRouteActions.ResumeLayout(false);
            grpNodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNodes).EndInit();
            pnlNodeInput.ResumeLayout(false);
            pnlNodeInput.PerformLayout();
            pnlNodeActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;

        private GroupBox grpRoute;
        private Panel pnlRouteInput;
        private Label lblRouteID;
        private TextBox txtRouteID;
        private Label lblRouteName;
        private TextBox txtRouteName;
        private DataGridView dgvRoutes;
        private Panel pnlRouteActions;
        private Button btnThemRoute;
        private Button btnLuuRoute;
        private Button btnHuyRoute;
        private Button btnXoaRoute;

        private GroupBox grpNodes;
        private Panel pnlNodeInput;
        private Label lblNodeID;
        private TextBox txtNodeID;
        private Label lblNodeName;
        private TextBox txtNodeName;
        private Label lblStep;
        private ComboBox cboStep;
        private DataGridView dgvNodes;
        private Panel pnlNodeActions;
        private Button btnThemNode;
        private Button btnLuuNode;
        private Button btnHuyNode;
        private Button btnXoaNode;
    }
}