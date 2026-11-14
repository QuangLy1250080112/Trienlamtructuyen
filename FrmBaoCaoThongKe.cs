using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Trienlamtructuyen
{
    public partial class FrmBaoCaoThongKe : Form
    {
        private Dictionary<string, double> chartDataList = new Dictionary<string, double>();

        public FrmBaoCaoThongKe()
        {
            InitializeComponent();
            RegisterScreenReaderEvents();
        }

        private void FrmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            ScreenReaderHelper.Speak("Đã mở giao diện Báo Cáo Thống Kê.");

            InitFilterOptions();
            LoadDashboardData();
        }

        #region Tích hợp Screen Reader
        private void RegisterScreenReaderEvents()
        {
            // Đọc khi chọn các điều khiển lọc & thao tác
            cboLoaiBaoCao.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Loại báo cáo. Giá trị hiện tại: {cboLoaiBaoCao.Text}");
            btnThongKe.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Làm mới thống kê.");
            btnXuatReport.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Xuất báo cáo Excel.");

            // Đọc dữ liệu hàng khi duyệt phím di chuyển trên DataGridView chính
            dgvThongKeChiTiet.SelectionChanged += (s, e) =>
            {
                if (dgvThongKeChiTiet.Focused && dgvThongKeChiTiet.CurrentRow != null && dgvThongKeChiTiet.CurrentRow.Index >= 0)
                {
                    ReadDgvRow(dgvThongKeChiTiet, dgvThongKeChiTiet.CurrentRow.Index, "Bảng thống kê chi tiết");
                }
            };

            // Đọc dữ liệu hàng khi duyệt phím di chuyển trên DataGridView phụ
            dgvSubDetail.SelectionChanged += (s, e) =>
            {
                if (dgvSubDetail.Focused && dgvSubDetail.CurrentRow != null && dgvSubDetail.CurrentRow.Index >= 0)
                {
                    ReadDgvRow(dgvSubDetail, dgvSubDetail.CurrentRow.Index, "Bảng chi tiết danh sách");
                }
            };
        }

        private void ReadDgvRow(DataGridView dgv, int rowIndex, string tableName)
        {
            if (rowIndex < 0 || rowIndex >= dgv.Rows.Count) return;
            var row = dgv.Rows[rowIndex];
            if (row.IsNewRow) return;

            string content = $"{tableName}, dòng {rowIndex + 1}: ";

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    string header = dgv.Columns[cell.ColumnIndex].HeaderText;
                    content += $"{header}: {cell.Value}; ";
                }
            }
            ScreenReaderHelper.Speak(content);
        }
        #endregion

        private void InitFilterOptions()
        {
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("Thống kê Media theo Định dạng");
            cboLoaiBaoCao.Items.Add("Thống kê Điểm dừng theo Tuyến Tham Quan");
            cboLoaiBaoCao.Items.Add("Thống kê Phản hồi Người dùng");
            cboLoaiBaoCao.SelectedIndex = 0;
        }

        private void LoadDashboardData()
        {
            try
            {
                // 1. Tổng số hiện vật
                string queryArtifacts = "SELECT COUNT(*) FROM Artifact";
                object? resArtifacts = Database.ExecuteScalar(queryArtifacts);
                lblValArtifacts.Text = resArtifacts != null ? Convert.ToInt32(resArtifacts).ToString("N0") : "0";

                // 2. Số điểm tham quan (Node/Điểm dừng)
                string queryNodes = "SELECT COUNT(*) FROM TuyenThamQuanNode";
                object? resNodes = Database.ExecuteScalar(queryNodes);
                lblValNodes.Text = resNodes != null ? Convert.ToInt32(resNodes).ToString("N0") : "0";

                // 3. Tổng dung lượng Media (MB)
                string queryStorage = "SELECT ISNULL(SUM(fileSizeByte), 0) FROM MediaFile";
                object? resStorage = Database.ExecuteScalar(queryStorage);
                double totalBytes = resStorage != null ? Convert.ToDouble(resStorage) : 0;
                double totalMB = totalBytes / (1024.0 * 1024.0);
                lblValStorage.Text = $"{totalMB:N2} MB";

                // 4. Tổng số phản hồi người dùng
                string queryPhanHoi = "SELECT COUNT(*) FROM PhanHoi";
                object? resPhanHoi = Database.ExecuteScalar(queryPhanHoi);
                lblValPhanHoi.Text = resPhanHoi != null ? Convert.ToInt32(resPhanHoi).ToString("N0") : "0";

                LoadDetailedGridReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Dashboard: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDetailedGridReport()
        {
            chartDataList.Clear();
            dgvSubDetail.DataSource = null; // Xóa bảng chi tiết con khi đổi báo cáo
            string selectedReport = cboLoaiBaoCao.SelectedItem?.ToString() ?? "";

            if (selectedReport == "Thống kê Media theo Định dạng")
            {
                string query = @"
                    SELECT 
                        mediaType AS [Định dạng Media],
                        COUNT(*) AS [Số lượng File],
                        ROUND(SUM(fileSizeByte) / 1048576.0, 2) AS [Tổng dung lượng (MB)],
                        ROUND(AVG(fileSizeByte) / 1048576.0, 2) AS [TB Dung lượng (MB)]
                    FROM MediaFile
                    GROUP BY mediaType";

                DataTable dt = Database.ExecuteQuery(query);
                dgvThongKeChiTiet.DataSource = dt;

                foreach (DataRow row in dt.Rows)
                {
                    string type = row["Định dạng Media"]?.ToString() ?? "Khác";
                    double mb = row["Tổng dung lượng (MB)"] != DBNull.Value ? Convert.ToDouble(row["Tổng dung lượng (MB)"]) : 0;
                    chartDataList[type] = mb;
                }
                lblChartTitle.Text = "Biểu đồ Phân bổ Dung lượng Media (MB)";
            }
            else if (selectedReport == "Thống kê Điểm dừng theo Tuyến Tham Quan")
            {
                string query = @"
                    SELECT 
                        R.routeID AS [Mã Tuyến],
                        R.routeName AS [Tên Tuyến Tham Quan],
                        COUNT(N.nodeID) AS [Số điểm dừng]
                    FROM TuyenThamQuanRoute R
                    LEFT JOIN TuyenThamQuanNode N ON R.routeID = N.routeID
                    GROUP BY R.routeID, R.routeName";

                DataTable dt = Database.ExecuteQuery(query);
                dgvThongKeChiTiet.DataSource = dt;

                foreach (DataRow row in dt.Rows)
                {
                    string route = row["Tên Tuyến Tham Quan"]?.ToString() ?? "Chưa tên";
                    double nodeCount = row["Số điểm dừng"] != DBNull.Value ? Convert.ToDouble(row["Số điểm dừng"]) : 0;
                    chartDataList[route] = nodeCount;
                }
                lblChartTitle.Text = "Biểu đồ Số lượng Điểm dừng theo Tuyến";
            }
            else
            {
                string query = @"
                    SELECT 
                        loaiPhanHoi AS [Loại Phản Hồi],
                        COUNT(*) AS [Số lượng],
                        ROUND(AVG(CAST(rating AS FLOAT)), 1) AS [Đánh giá TB (Sao)]
                    FROM PhanHoi
                    GROUP BY loaiPhanHoi";

                DataTable dt = Database.ExecuteQuery(query);
                dgvThongKeChiTiet.DataSource = dt;

                foreach (DataRow row in dt.Rows)
                {
                    string type = row["Loại Phản Hồi"]?.ToString() ?? "Khác";
                    double count = row["Số lượng"] != DBNull.Value ? Convert.ToDouble(row["Số lượng"]) : 0;
                    chartDataList[type] = count;
                }
                lblChartTitle.Text = "Biểu đồ Số lượng Phản hồi theo Phân loại";
            }

            pnlChartArea.Invalidate();

            // Tự động load chi tiết dòng đầu tiên nếu có
            if (dgvThongKeChiTiet.Rows.Count > 0)
            {
                LoadSubDetailData(0);
            }
        }

        private void dgvThongKeChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadSubDetailData(e.RowIndex);
            }
        }

        private void LoadSubDetailData(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvThongKeChiTiet.Rows.Count) return;

            DataGridViewRow selectedRow = dgvThongKeChiTiet.Rows[rowIndex];
            string selectedReport = cboLoaiBaoCao.SelectedItem?.ToString() ?? "";

            if (selectedReport == "Thống kê Media theo Định dạng")
            {
                string mediaType = selectedRow.Cells["Định dạng Media"].Value?.ToString() ?? "";
                string query = @"
                    SELECT 
                        M.mediaID AS [Mã Media],
                        M.fileName AS [Tên File],
                        M.mediaType AS [Định dạng],
                        ROUND(M.fileSizeByte / 1048576.0, 2) AS [Dung lượng (MB)],
                        A.name AS [Hiện vật liên quan],
                        S.heading AS [Bước câu chuyện]
                    FROM MediaFile M
                    LEFT JOIN Artifact A ON M.artifactId = A.artifactId
                    LEFT JOIN CauChuyenStep S ON M.stepID = S.stepID
                    WHERE M.mediaType = @MediaType";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MediaType", mediaType)
                };

                lblSubTitle.Text = $"DANH SÁCH FILE MEDIA THUỘC ĐỊNH DẠNG: {mediaType.ToUpper()}";
                dgvSubDetail.DataSource = Database.ExecuteQuery(query, parameters);
            }
            else if (selectedReport == "Thống kê Điểm dừng theo Tuyến Tham Quan")
            {
                string routeID = selectedRow.Cells["Mã Tuyến"].Value?.ToString() ?? "";
                string routeName = selectedRow.Cells["Tên Tuyến Tham Quan"].Value?.ToString() ?? "";

                string query = @"
                    SELECT 
                        N.nodeID AS [Mã Điểm dừng],
                        N.nodeName AS [Tên Điểm dừng],
                        S.heading AS [Bước liên quan],
                        A.name AS [Hiện vật liên quan]
                    FROM TuyenThamQuanNode N
                    LEFT JOIN CauChuyenStep S ON N.stepID = S.stepID
                    LEFT JOIN Artifact A ON S.artifactId = A.artifactId
                    WHERE N.routeID = @RouteID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@RouteID", routeID)
                };

                lblSubTitle.Text = $"DANH SÁCH ĐIỂM DỪNG THUỘC TUYẾN: {routeName.ToUpper()}";
                dgvSubDetail.DataSource = Database.ExecuteQuery(query, parameters);
            }
            else if (selectedReport == "Thống kê Phản hồi Người dùng")
            {
                string loaiPhanHoi = selectedRow.Cells["Loại Phản Hồi"].Value?.ToString() ?? "";
                string query = @"
                    SELECT 
                        P.phanHoiID AS [Mã PH],
                        P.nguoiGuiEmail AS [Email Người gửi],
                        P.rating AS [Đánh giá (Sao)],
                        P.noiDung AS [Nội dung Phản hồi],
                        P.ngayGui AS [Ngày gửi]
                    FROM PhanHoi P
                    WHERE P.loaiPhanHoi = @LoaiPhanHoi
                    ORDER BY P.ngayGui DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@LoaiPhanHoi", loaiPhanHoi)
                };

                lblSubTitle.Text = $"DANH SÁCH PHẢN HỒI THUỘC LOẠI: {loaiPhanHoi.ToUpper()}";
                dgvSubDetail.DataSource = Database.ExecuteQuery(query, parameters);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnXuatReport_Click(object sender, EventArgs e)
        {
            if (dgvThongKeChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"BaoCaoThongKe_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        // Xuất Bảng Tổng Quan
                        sb.AppendLine("=== BÁO CÁO TỔNG QUAN ===");
                        for (int i = 0; i < dgvThongKeChiTiet.Columns.Count; i++)
                        {
                            sb.Append($"\"{dgvThongKeChiTiet.Columns[i].HeaderText}\"");
                            if (i < dgvThongKeChiTiet.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();

                        foreach (DataGridViewRow row in dgvThongKeChiTiet.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dgvThongKeChiTiet.Columns.Count; i++)
                                {
                                    string cellVal = row.Cells[i].Value?.ToString() ?? "";
                                    cellVal = cellVal.Replace("\"", "\"\"");
                                    sb.Append($"\"{cellVal}\"");
                                    if (i < dgvThongKeChiTiet.Columns.Count - 1) sb.Append(",");
                                }
                                sb.AppendLine();
                            }
                        }

                        // Xuất Bảng Chi Tiết Con (nếu có)
                        if (dgvSubDetail.Rows.Count > 0)
                        {
                            sb.AppendLine();
                            sb.AppendLine($"=== {lblSubTitle.Text} ===");
                            for (int i = 0; i < dgvSubDetail.Columns.Count; i++)
                            {
                                sb.Append($"\"{dgvSubDetail.Columns[i].HeaderText}\"");
                                if (i < dgvSubDetail.Columns.Count - 1) sb.Append(",");
                            }
                            sb.AppendLine();

                            foreach (DataGridViewRow row in dgvSubDetail.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int i = 0; i < dgvSubDetail.Columns.Count; i++)
                                    {
                                        string cellVal = row.Cells[i].Value?.ToString() ?? "";
                                        cellVal = cellVal.Replace("\"", "\"\"");
                                        sb.Append($"\"{cellVal}\"");
                                        if (i < dgvSubDetail.Columns.Count - 1) sb.Append(",");
                                    }
                                    sb.AppendLine();
                                }
                            }
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất báo cáo CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pnlChartArea_Paint(object sender, PaintEventArgs e)
        {
            if (chartDataList.Count == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int startX = 40;
            int startY = pnlChartArea.Height - 25;
            int chartHeight = Math.Max(20, pnlChartArea.Height - 55);
            int barWidth = 35;
            int gap = 25;

            double maxVal = 1;
            foreach (var val in chartDataList.Values)
            {
                if (val > maxVal) maxVal = val;
            }

            int index = 0;
            Brush barBrush = Brushes.Black;
            Font textFont = new Font("Segoe UI", 8F, FontStyle.Regular);
            Brush textBrush = Brushes.Black;

            g.DrawLine(Pens.Black, startX - 5, startY, startX + chartDataList.Count * (barWidth + gap), startY);

            foreach (var item in chartDataList)
            {
                int currentX = startX + index * (barWidth + gap);
                int calculatedHeight = (int)((item.Value / maxVal) * chartHeight);
                if (calculatedHeight < 3 && item.Value > 0) calculatedHeight = 3;

                int currentY = startY - calculatedHeight;

                g.FillRectangle(barBrush, currentX, currentY, barWidth, calculatedHeight);
                g.DrawRectangle(Pens.Black, currentX, currentY, barWidth, calculatedHeight);

                g.DrawString(item.Value.ToString("N0"), textFont, textBrush, currentX, Math.Max(15, currentY - 14));

                string labelText = item.Key.Length > 8 ? item.Key.Substring(0, 6) + ".." : item.Key;
                g.DrawString(labelText, textFont, textBrush, currentX, startY + 2);

                index++;
            }
        }

        private void cboLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScreenReaderHelper.IsEnabled && cboLoaiBaoCao.Focused)
            {
                ScreenReaderHelper.Speak($"Đã chọn loại báo cáo: {cboLoaiBaoCao.Text}");
            }
            LoadDetailedGridReport();
        }
    }
}