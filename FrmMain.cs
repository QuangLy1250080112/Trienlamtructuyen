using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmMain : Form
    {
        private Form? activeForm = null;

        public FrmMain()
        {
            InitializeComponent();

            // Đăng ký nhận câu lệnh giọng nói từ VoiceRecognitionHelper
            VoiceRecognitionHelper.OnCommandRecognized += VoiceRecognition_OnCommandRecognized;
        }

        // 1. XỬ LÝ PHÍM TẮT CTRL + SHIFT + TAB VÀ CTRL + SHIFT + SPACE
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            // Bật/Tắt Screen Reader bằng Ctrl + Shift + Tab
            if (e.Control && e.Shift && e.KeyCode == Keys.Tab)
            {
                ScreenReaderHelper.IsEnabled = !ScreenReaderHelper.IsEnabled;

                if (ScreenReaderHelper.IsEnabled)
                {
                    string userDisplay = string.IsNullOrEmpty(UserSession.FullName) ? "Khách" : UserSession.FullName;
                    ScreenReaderHelper.Speak($"Đã bật chế độ đọc màn hình. Xin chào {userDisplay}. Nhấn Tab để di chuyển qua các nút chức năng, nhấn Enter để chọn.");
                }
                else
                {
                    // Nếu tắt Screen Reader thì tắt luôn Voice Recognition nếu đang mở
                    if (VoiceRecognitionHelper.IsListening)
                    {
                        VoiceRecognitionHelper.Stop();
                    }
                    ScreenReaderHelper.Stop();
                    MessageBox.Show("Đã tắt chế độ đọc màn hình (Screen Reader).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                e.Handled = true;
            }
            // Bật/Tắt Speech Recognition bằng Ctrl + Shift + Space (Chỉ hoạt động khi Screen Reader đang BẬT)
            else if (e.Control && e.Shift && e.KeyCode == Keys.Space)
            {
                if (!ScreenReaderHelper.IsEnabled)
                {
                    MessageBox.Show("Vui lòng bật chế độ đọc màn hình (Ctrl + Shift + Tab) trước khi sử dụng nhận diện giọng nói!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    VoiceRecognitionHelper.ToggleListening();
                }
                e.Handled = true;
            }
        }

        // XỬ LÝ CÁC CÂU LỆNH GIỌNG NÓI NHẬN ĐƯỢC
        private void VoiceRecognition_OnCommandRecognized(string spokenText)
        {
            // Kiểm tra câu lệnh chuyển tab "Khám phá triển lãm" (Hoạt động toàn hệ thống)
            if (spokenText.Contains("khám phá triển lãm") || spokenText.Contains("kham pha trien lam"))
            {
                this.Invoke(new Action(() =>
                {
                    btnNavKhamPha_Click(this, EventArgs.Empty);
                }));
                return;
            }

            // Các câu lệnh còn lại chỉ hoạt động khi đang ở Form Khám phá Triển lãm (FrmKhamPhaTrienLam)
            if (activeForm is FrmKhamPhaTrienLam frmKhamPha)
            {
                this.Invoke(new Action(() =>
                {
                    frmKhamPha.XuLyLenhGiongNoi(spokenText);
                }));
            }
        }

        // 2. PHÁT TIẾNG ĐỌC KHI DÙNG PHÍM TAB DI CHUYỂN QUA CÁC NÚT (GOTFOCUS)
        private void NavButton_GotFocus(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                ScreenReaderHelper.Speak(btn.Text);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Mặc định tự động đăng nhập tài khoản Admin nếu chưa có phiên đăng nhập
            if (string.IsNullOrEmpty(UserSession.UserID))
            {
                AutoLoginAdmin();
            }

            KiemTraKetNoiDatabase();
            UpdateStatusStripInfo();
            PhanQuyenSuDung();

            // Mặc định mở Form Khám phá Triển lãm khi vừa mở ứng dụng
            LoadFormToPanel(new FrmKhamPhaTrienLam());
        }

        private void AutoLoginAdmin()
        {
            try
            {
                string query = "SELECT userID, username, fullName, email, role FROM [User] WHERE username = 'admin'";
                DataTable dt = Database.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    UserSession.UserID = row["userID"].ToString() ?? "USR001";
                    UserSession.Username = row["username"].ToString() ?? "admin";
                    UserSession.FullName = row["fullName"].ToString() ?? "Quản Trị Viên Hệ Thống";
                    UserSession.Email = row["email"].ToString() ?? "admin@trienlam.vn";
                    UserSession.Role = row["role"].ToString() ?? "Admin";
                }
                else
                {
                    UserSession.UserID = "USR001";
                    UserSession.Username = "admin";
                    UserSession.FullName = "Quản Trị Viên Hệ Thống";
                    UserSession.Role = "Admin";
                }
            }
            catch
            {
                UserSession.UserID = "USR001";
                UserSession.Username = "admin";
                UserSession.FullName = "Quản Trị Viên Hệ Thống";
                UserSession.Role = "Admin";
            }
        }

        private void KiemTraKetNoiDatabase()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM [User]";
                Database.ExecuteScalar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL SQL Server (Trienlamtructuyen):\n{ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusStripInfo()
        {
            string userDisplay = string.IsNullOrEmpty(UserSession.FullName) ? "Chưa đăng nhập" : UserSession.FullName;
            string roleDisplay = string.IsNullOrEmpty(UserSession.Role) ? "Khách" : UserSession.Role;

            lblStatusUserInfo.Text = $"Người dùng: {userDisplay} | Vai trò: {roleDisplay}";
            lblStatusTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void PhanQuyenSuDung()
        {
            string role = UserSession.Role;

            switch (role)
            {
                case "Admin":
                    btnNavUser.Visible = true;
                    btnNavBoSuuTap.Visible = true;
                    btnNavCauChuyen.Visible = true;
                    btnNavTuyenThamQuan.Visible = true;
                    btnNavMedia.Visible = true;
                    btnNavThongKe.Visible = true;
                    btnNavKhamPha.Visible = true;
                    btnNavPhanHoi.Visible = false;
                    break;

                case "Curator":
                    btnNavUser.Visible = false;
                    btnNavBoSuuTap.Visible = true;
                    btnNavCauChuyen.Visible = true;
                    btnNavTuyenThamQuan.Visible = true;
                    btnNavMedia.Visible = true;
                    btnNavThongKe.Visible = true;
                    btnNavKhamPha.Visible = true;
                    btnNavPhanHoi.Visible = false;
                    break;

                case "Visitor":
                    btnNavUser.Visible = false;
                    btnNavBoSuuTap.Visible = false;
                    btnNavCauChuyen.Visible = false;
                    btnNavTuyenThamQuan.Visible = false;
                    btnNavMedia.Visible = false;
                    btnNavThongKe.Visible = false;
                    btnNavKhamPha.Visible = true;
                    btnNavPhanHoi.Visible = true;
                    break;

                default:
                    btnNavUser.Visible = false;
                    btnNavBoSuuTap.Visible = false;
                    btnNavCauChuyen.Visible = false;
                    btnNavTuyenThamQuan.Visible = false;
                    btnNavMedia.Visible = false;
                    btnNavThongKe.Visible = false;
                    btnNavKhamPha.Visible = true;
                    btnNavPhanHoi.Visible = false;
                    break;
            }
        }

        private void LoadFormToPanel(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            ScreenReaderHelper.Speak($"Đã mở giao diện {childForm.Text}");
        }

        private void btnNavUser_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmQuanLyUser());
        private void btnNavBoSuuTap_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmQuanLyBoSuuTap());
        private void btnNavCauChuyen_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmBienTapCauChuyen());
        private void btnNavTuyenThamQuan_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmThietKeTuyenThamQuan());
        private void btnNavMedia_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmQuanLyMedia());
        private void btnNavThongKe_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmBaoCaoThongKe());
        private void btnNavKhamPha_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmKhamPhaTrienLam());
        private void btnNavPhanHoi_Click(object sender, EventArgs e) => LoadFormToPanel(new FrmPhanHoi());

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            ScreenReaderHelper.Speak("Xác nhận đăng xuất tài khoản");

            bool hasLoggedInUser = !string.IsNullOrEmpty(UserSession.UserID);

            if (hasLoggedInUser)
            {
                if (MessageBox.Show("Xác nhận đăng xuất tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UserSession.UserID = string.Empty;
                    UserSession.Username = string.Empty;
                    UserSession.FullName = string.Empty;
                    UserSession.Email = string.Empty;
                    UserSession.Role = string.Empty;

                    FrmDangNhap frmLogin = new FrmDangNhap();
                    this.Hide();
                    frmLogin.ShowDialog();

                    this.Show();
                    UpdateStatusStripInfo();
                    PhanQuyenSuDung();
                    LoadFormToPanel(new FrmKhamPhaTrienLam());
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thoát ứng dụng không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblStatusTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}