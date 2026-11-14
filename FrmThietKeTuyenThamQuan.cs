using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmThietKeTuyenThamQuan : Form
    {
        private DataTable dtRoutes = new DataTable();
        private DataTable dtNodes = new DataTable();

        private bool isRouteEditMode = false;
        private bool isNodeEditMode = false;
        private string currentRouteID = string.Empty;
        private string currentNodeID = string.Empty;

        public FrmThietKeTuyenThamQuan()
        {
            InitializeComponent();
        }

        private void FrmThietKeTuyenThamQuan_Load(object sender, EventArgs e)
        {
            SetupDataTables();
            LoadComboboxes();
            LoadRoutesFromDatabase();

            SwitchRouteState(isEditing: false);
            SwitchNodeState(isEditing: false);
        }

        private void SetupDataTables()
        {
            dtRoutes.Columns.Add("routeID", typeof(string));
            dtRoutes.Columns.Add("routeName", typeof(string));
            dtRoutes.PrimaryKey = new DataColumn[] { dtRoutes.Columns["routeID"] };
            dgvRoutes.DataSource = dtRoutes;

            if (dgvRoutes.Columns["routeID"] != null) dgvRoutes.Columns["routeID"].HeaderText = "Mã Tuyến";
            if (dgvRoutes.Columns["routeName"] != null) dgvRoutes.Columns["routeName"].HeaderText = "Tên Tuyến";

            dtNodes.Columns.Add("nodeID", typeof(string));
            dtNodes.Columns.Add("routeID", typeof(string));
            dtNodes.Columns.Add("nodeName", typeof(string));
            dtNodes.Columns.Add("stepID", typeof(string));
            dtNodes.PrimaryKey = new DataColumn[] { dtNodes.Columns["nodeID"] };
            dgvNodes.DataSource = dtNodes;

            if (dgvNodes.Columns["nodeID"] != null) dgvNodes.Columns["nodeID"].HeaderText = "Mã Nút";
            if (dgvNodes.Columns["routeID"] != null) dgvNodes.Columns["routeID"].Visible = false;
            if (dgvNodes.Columns["nodeName"] != null) dgvNodes.Columns["nodeName"].HeaderText = "Tên Nút";
            if (dgvNodes.Columns["stepID"] != null) dgvNodes.Columns["stepID"].HeaderText = "Bước KB";
        }

        private void LoadComboboxes()
        {
            try
            {
                DataTable dtStep = Database.ExecuteQuery("SELECT stepID, heading FROM CauChuyenStep");
                DataTable dtStepCB = dtStep.Copy();
                DataRow drStep = dtStepCB.NewRow();
                drStep["stepID"] = DBNull.Value;
                drStep["heading"] = "-- Không chọn --";
                dtStepCB.Rows.InsertAt(drStep, 0);

                cboStep.DataSource = dtStepCB;
                cboStep.DisplayMember = "heading";
                cboStep.ValueMember = "stepID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách ComboBox: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoutesFromDatabase()
        {
            try
            {
                string query = "SELECT routeID, routeName FROM TuyenThamQuanRoute";
                DataTable dt = Database.ExecuteQuery(query);
                dtRoutes.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dtRoutes.ImportRow(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp tuyến tham quan: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadNodesForRoute(string routeID)
        {
            dtNodes.Rows.Clear();
            if (string.IsNullOrEmpty(routeID)) return;

            try
            {
                string query = @"SELECT nodeID, routeID, nodeName, stepID 
                                FROM TuyenThamQuanNode WHERE routeID = @routeID";
                SqlParameter[] p = new SqlParameter[] { new SqlParameter("@routeID", routeID) };
                DataTable dt = Database.ExecuteQuery(query, p);
                foreach (DataRow row in dt.Rows)
                {
                    dtNodes.ImportRow(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp nút điểm dừng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Chuyển đổi trạng thái Nút bấm (State Switchers)

        private void SwitchRouteState(bool isEditing)
        {
            isRouteEditMode = isEditing;

            btnThemRoute.Visible = !isEditing;
            btnLuuRoute.Visible = isEditing;
            btnHuyRoute.Visible = isEditing;
            btnXoaRoute.Visible = isEditing;

            txtRouteID.ReadOnly = false; // Mở cho phép sửa mã

            if (!isEditing)
            {
                currentRouteID = string.Empty;
                dgvRoutes.ClearSelection();
                txtRouteID.Text = "ROUTE_" + DateTime.Now.ToString("HHmmss");
                txtRouteName.Clear();
                dtNodes.Rows.Clear();
                SwitchNodeState(isEditing: false);
            }
        }

        private void SwitchNodeState(bool isEditing)
        {
            isNodeEditMode = isEditing;

            btnThemNode.Visible = !isEditing;
            btnLuuNode.Visible = isEditing;
            btnHuyNode.Visible = isEditing;
            btnXoaNode.Visible = isEditing;

            txtNodeID.ReadOnly = false; // Mở cho phép sửa mã

            if (!isEditing)
            {
                currentNodeID = string.Empty;
                dgvNodes.ClearSelection();
                txtNodeID.Text = "NODE_" + DateTime.Now.ToString("HHmmss");
                txtNodeName.Clear();
                if (cboStep.Items.Count > 0) cboStep.SelectedIndex = 0;
            }
        }

        #endregion

        #region Xử lý Sự kiện Tuyến Tham Quan (Route Events)

        private void dgvRoutes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRoutes.CurrentRow != null)
            {
                DataGridViewRow row = dgvRoutes.CurrentRow;
                currentRouteID = row.Cells["routeID"].Value?.ToString() ?? "";
                txtRouteID.Text = currentRouteID;
                txtRouteName.Text = row.Cells["routeName"].Value?.ToString();

                SwitchRouteState(isEditing: true);
                LoadNodesForRoute(currentRouteID);
                SwitchNodeState(isEditing: false);
            }
        }

        private void btnThemRoute_Click(object sender, EventArgs e) => SaveRoute();
        private void btnLuuRoute_Click(object sender, EventArgs e) => SaveRoute();

        private void SaveRoute()
        {
            List<string> missingFields = new List<string>();
            if (string.IsNullOrWhiteSpace(txtRouteID.Text)) missingFields.Add("Mã Tuyến");
            if (string.IsNullOrWhiteSpace(txtRouteName.Text)) missingFields.Add("Tên Tuyến");

            if (missingFields.Count > 0)
            {
                MessageBox.Show($"Vui lòng nhập đầy đủ thông tin còn thiếu:\n- {string.Join("\n- ", missingFields)}",
                                "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newRouteID = txtRouteID.Text.Trim();
            string routeName = txtRouteName.Text.Trim();

            try
            {
                if (!isRouteEditMode)
                {
                    string checkQuery = "SELECT COUNT(*) FROM TuyenThamQuanRoute WHERE routeID = @routeID";
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@routeID", newRouteID) }));
                    if (count > 0)
                    {
                        MessageBox.Show("Mã tuyến đã tồn tại trong CSDL!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"INSERT INTO TuyenThamQuanRoute (routeID, routeName) VALUES (@routeID, @routeName)";
                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@routeID", newRouteID),
                        new SqlParameter("@routeName", routeName)
                    };

                    Database.ExecuteNonQuery(query, p);
                    MessageBox.Show("Thêm tuyến tham quan mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!newRouteID.Equals(currentRouteID, StringComparison.OrdinalIgnoreCase))
                    {
                        string checkQuery = "SELECT COUNT(*) FROM TuyenThamQuanRoute WHERE routeID = @routeID";
                        int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@routeID", newRouteID) }));
                        if (count > 0)
                        {
                            MessageBox.Show("Mã tuyến mới đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Đổi routeID mới (bảng TuyenThamQuanNode có ON UPDATE CASCADE tự nhảy theo)
                    string query = "UPDATE TuyenThamQuanRoute SET routeID = @newRouteID, routeName = @routeName WHERE routeID = @oldRouteID";
                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@newRouteID", newRouteID),
                        new SqlParameter("@routeName", routeName),
                        new SqlParameter("@oldRouteID", currentRouteID)
                    };

                    Database.ExecuteNonQuery(query, p);
                    MessageBox.Show("Cập nhật thông tin tuyến thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                currentRouteID = newRouteID;
                LoadRoutesFromDatabase();
                SwitchRouteState(isEditing: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ghi CSDL tuyến: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyRoute_Click(object sender, EventArgs e)
        {
            SwitchRouteState(isEditing: false);
        }

        private void btnXoaRoute_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.CurrentRow != null && isRouteEditMode)
            {
                if (MessageBox.Show($"Bạn có muốn xóa hẳn tuyến [{currentRouteID}] và tất cả các điểm dừng khỏi CSDL không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Database.ExecuteNonQuery("DELETE FROM TuyenThamQuanRoute WHERE routeID = @routeID", new SqlParameter[] { new SqlParameter("@routeID", currentRouteID) });
                        LoadRoutesFromDatabase();
                        dtNodes.Rows.Clear();
                        SwitchRouteState(isEditing: false);
                        MessageBox.Show("Xóa tuyến thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa tuyến: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Xử lý Sự kiện Điểm Dừng Không Gian (Node Events)

        private void dgvNodes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNodes.CurrentRow != null)
            {
                DataGridViewRow row = dgvNodes.CurrentRow;
                currentNodeID = row.Cells["nodeID"].Value?.ToString() ?? "";
                txtNodeID.Text = currentNodeID;
                txtNodeName.Text = row.Cells["nodeName"].Value?.ToString();

                string stepID = row.Cells["stepID"].Value?.ToString() ?? "";
                cboStep.SelectedValue = string.IsNullOrEmpty(stepID) ? DBNull.Value : stepID;

                SwitchNodeState(isEditing: true);
            }
        }

        private void btnThemNode_Click(object sender, EventArgs e) => SaveNode();
        private void btnLuuNode_Click(object sender, EventArgs e) => SaveNode();

        private void SaveNode()
        {
            List<string> missingFields = new List<string>();
            if (string.IsNullOrWhiteSpace(txtNodeID.Text)) missingFields.Add("Mã Nút");
            if (string.IsNullOrWhiteSpace(txtNodeName.Text)) missingFields.Add("Tên Nút");
            if (string.IsNullOrWhiteSpace(currentRouteID)) missingFields.Add("Chưa chọn Tuyến tham quan");

            if (missingFields.Count > 0)
            {
                MessageBox.Show($"Vui lòng kiểm tra các thông tin còn thiếu cho điểm dừng:\n- {string.Join("\n- ", missingFields)}",
                                "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newNodeID = txtNodeID.Text.Trim();
            string nodeName = txtNodeName.Text.Trim();
            object stepVal = (cboStep.SelectedValue == null || cboStep.SelectedValue == DBNull.Value) ? DBNull.Value : cboStep.SelectedValue;

            try
            {
                if (!isNodeEditMode)
                {
                    string checkQuery = "SELECT COUNT(*) FROM TuyenThamQuanNode WHERE nodeID = @nodeID";
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@nodeID", newNodeID) }));
                    if (count > 0)
                    {
                        MessageBox.Show("Mã nút điểm dừng đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"INSERT INTO TuyenThamQuanNode (nodeID, nodeName, routeID, stepID) 
                                    VALUES (@nodeID, @nodeName, @routeID, @stepID)";
                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@nodeID", newNodeID),
                        new SqlParameter("@nodeName", nodeName),
                        new SqlParameter("@routeID", currentRouteID),
                        new SqlParameter("@stepID", stepVal)
                    };

                    Database.ExecuteNonQuery(query, p);
                    MessageBox.Show("Thêm điểm dừng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!newNodeID.Equals(currentNodeID, StringComparison.OrdinalIgnoreCase))
                    {
                        string checkQuery = "SELECT COUNT(*) FROM TuyenThamQuanNode WHERE nodeID = @nodeID";
                        int count = Convert.ToInt32(Database.ExecuteScalar(checkQuery, new SqlParameter[] { new SqlParameter("@nodeID", newNodeID) }));
                        if (count > 0)
                        {
                            MessageBox.Show("Mã nút điểm dừng mới đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "UPDATE TuyenThamQuanNode SET nodeID = @newNodeID, nodeName = @nodeName, stepID = @stepID WHERE nodeID = @oldNodeID";
                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@newNodeID", newNodeID),
                        new SqlParameter("@nodeName", nodeName),
                        new SqlParameter("@stepID", stepVal),
                        new SqlParameter("@oldNodeID", currentNodeID)
                    };

                    Database.ExecuteNonQuery(query, p);
                    MessageBox.Show("Cập nhật điểm dừng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                currentNodeID = newNodeID;
                LoadNodesForRoute(currentRouteID);
                SwitchNodeState(isEditing: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ghi CSDL điểm dừng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyNode_Click(object sender, EventArgs e)
        {
            SwitchNodeState(isEditing: false);
        }

        private void btnXoaNode_Click(object sender, EventArgs e)
        {
            if (dgvNodes.CurrentRow != null && isNodeEditMode)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm dừng [{currentNodeID}] khỏi CSDL?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Database.ExecuteNonQuery("DELETE FROM TuyenThamQuanNode WHERE nodeID = @nodeID", new SqlParameter[] { new SqlParameter("@nodeID", currentNodeID) });
                        MessageBox.Show("Xóa điểm dừng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadNodesForRoute(currentRouteID);
                        SwitchNodeState(isEditing: false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa điểm dừng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
    }
}