using Microsoft.Data.SqlClient;
using QRCoder;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Trienlamtructuyen
{
    public partial class FrmKhamPhaTrienLam : Form
    {
        private DataTable dtRouteNodes;
        private int currentStepIndex = -1;
        private AxWMPLib.AxWindowsMediaPlayer dynamicMediaPlayer;

        public FrmKhamPhaTrienLam()
        {
            InitializeComponent();
            InitDynamicMediaPlayer();
            RegisterScreenReaderEvents();

            // Đăng ký sự kiện Click vào ô ảnh để phóng to toàn màn hình
            picMedia.Cursor = Cursors.Hand;
            picMedia.Click += picMedia_Click;
        }

        /// <summary>
        /// Xử lý các câu lệnh giọng nói dành riêng cho FrmKhamPhaTrienLam
        /// </summary>
        public void XuLyLenhGiongNoi(string command)
        {
            string cmd = command.ToLower().Trim();

            // 1. "Điểm dừng" -> Đọc tên điểm dừng
            if (cmd.Contains("điểm dừng") || cmd.Contains("diem dung"))
            {
                ScreenReaderHelper.Speak(lblNodeTitle.Text);
            }
            // 2. "Tên câu chuyện" -> Đọc tên câu chuyện
            else if (cmd.Contains("tên câu chuyện") || cmd.Contains("ten cau chuyen") || cmd.Contains("câu chuyện"))
            {
                ScreenReaderHelper.Speak(lblStoryHeader.Text);
            }
            // 3. "Nội dung" -> Đọc contentBody
            else if (cmd.Contains("nội dung") || cmd.Contains("noi dung"))
            {
                ScreenReaderHelper.Speak($"Nội dung thuyết minh: {txtStepContent.Text}");
            }
            // 4. "Tuyến tham quan" -> Đọc tên tuyến tham quan
            else if (cmd.Contains("tuyến tham quan") || cmd.Contains("tuyen tham quan") || cmd.Contains("tuyến"))
            {
                ScreenReaderHelper.Speak($"Tuyến tham quan hiện tại: {cboRoutes.Text}");
            }
            // 5. "mở/chơi Media" -> play nếu là video hoặc audio, nếu là ảnh thì giữ nguyên
            else if (cmd.Contains("mở media") || cmd.Contains("chơi media") || cmd.Contains("phát media") || cmd.Contains("mo media") || cmd.Contains("choi media"))
            {
                if (pnlMediaContainer.Visible && dynamicMediaPlayer != null)
                {
                    try
                    {
                        dynamicMediaPlayer.Ctlcontrols.play();
                        ScreenReaderHelper.Speak("Đang phát media.");
                    }
                    catch { }
                }
            }
            // 6. "tắt/dừng Media" -> dừng play nếu là video hoặc audio, nếu là ảnh thì giữ nguyên
            else if (cmd.Contains("tắt media") || cmd.Contains("dừng media") || cmd.Contains("tat media") || cmd.Contains("dung media"))
            {
                if (pnlMediaContainer.Visible && dynamicMediaPlayer != null)
                {
                    try
                    {
                        dynamicMediaPlayer.Ctlcontrols.stop();
                        ScreenReaderHelper.Speak("Đã dừng media.");
                    }
                    catch { }
                }
            }
        }

        private void InitDynamicMediaPlayer()
        {
            try
            {
                dynamicMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
                ((System.ComponentModel.ISupportInitialize)(dynamicMediaPlayer)).BeginInit();
                dynamicMediaPlayer.Dock = DockStyle.Fill;
                dynamicMediaPlayer.Enabled = true;
                pnlMediaContainer.Controls.Add(dynamicMediaPlayer);
                ((System.ComponentModel.ISupportInitialize)(dynamicMediaPlayer)).EndInit();
            }
            catch
            {
            }
        }

        private void FrmKhamPhaTrienLam_Load(object sender, EventArgs e)
        {
            ScreenReaderHelper.Speak("Đã mở giao diện Khám Phá Triển Lãm Trực Tuyến.");
            LoadRouteList();
        }

        #region Tích hợp Screen Reader
        private void RegisterScreenReaderEvents()
        {
            // 1. Đọc khi chọn Tuyến tham quan
            cboRoutes.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Tuyến tham quan. Giá trị hiện tại: {cboRoutes.Text}");

            // 2. Đọc khi duyệt qua danh sách điểm dừng (ListBox timeline)
            lstTimeline.SelectedIndexChanged += (s, e) =>
            {
                if (lstTimeline.Focused && lstTimeline.SelectedItem != null)
                {
                    ScreenReaderHelper.Speak($"Đã chọn: {lstTimeline.SelectedItem}");
                }
            };

            // 3. Đọc cho các ô văn bản và nút điều hướng
            txtStepContent.GotFocus += (s, e) => ScreenReaderHelper.Speak($"Nội dung thuyết minh: {txtStepContent.Text}");
            btnPrevNode.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Điểm dừng trước.");
            btnNextNode.GotFocus += (s, e) => ScreenReaderHelper.Speak("Nút Điểm dừng tiếp theo.");
        }
        #endregion

        private void LoadRouteList()
        {
            try
            {
                string query = "SELECT routeID, routeName FROM TuyenThamQuanRoute";
                DataTable dtRoutes = Database.ExecuteQuery(query);

                cboRoutes.DataSource = dtRoutes;
                cboRoutes.DisplayMember = "routeName";
                cboRoutes.ValueMember = "routeID";

                if (dtRoutes.Rows.Count > 0)
                {
                    cboRoutes.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách tuyến tham quan: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoutes.SelectedValue == null) return;

            if (ScreenReaderHelper.IsEnabled && cboRoutes.Focused)
            {
                ScreenReaderHelper.Speak($"Đã chọn tuyến: {cboRoutes.Text}");
            }

            string selectedRouteID = cboRoutes.SelectedValue.ToString()!;
            LoadJourneyData(selectedRouteID);
        }

        private void LoadJourneyData(string routeID)
        {
            try
            {
                string query = @"
                    SELECT 
                        r.routeID, r.routeName,
                        n.nodeID, n.nodeName,
                        st.cauChuyenID, st.title AS StoryTitle, st.author AS StoryAuthor, st.synopsis AS StorySynopsis,
                        s.stepID, s.stepOrder, s.heading AS StepHeading, s.contentBody AS StepContent,
                        a.artifactId, a.name AS ArtifactName, a.origin AS ArtifactOrigin, 
                        a.historicalPeriod AS ArtifactPeriod, a.material AS ArtifactMaterial,
                        col.collectionID, col.title AS CollectionTitle, col.theme AS CollectionTheme, col.description AS CollectionDesc,
                        m.mediaID, m.fileName, m.mediaType, m.mediaURL
                    FROM TuyenThamQuanRoute r
                    INNER JOIN TuyenThamQuanNode n ON r.routeID = n.routeID
                    LEFT JOIN CauChuyenStep s ON n.stepID = s.stepID
                    LEFT JOIN CauChuyen st ON s.cauChuyenID = st.cauChuyenID
                    LEFT JOIN Artifact a ON s.artifactId = a.artifactId
                    LEFT JOIN Collection col ON a.collectionID = col.collectionID
                    LEFT JOIN MediaFile m ON (
                        (s.stepID IS NOT NULL AND m.stepID = s.stepID) OR
                        (a.artifactId IS NOT NULL AND m.artifactId = a.artifactId)
                    )
                    WHERE r.routeID = @RouteID
                    ORDER BY n.nodeID ASC";

                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RouteID", routeID) };
                DataTable dtRaw = Database.ExecuteQuery(query, parameters);

                lstTimeline.Items.Clear();

                if (dtRaw == null || dtRaw.Rows.Count == 0)
                {
                    lblRouteInfo.Text = "Tuyến chưa có điểm dừng.";
                    ClearJourneyDisplay();
                    return;
                }

                DataView view = new DataView(dtRaw);
                dtRouteNodes = view.ToTable(true,
                    "nodeID", "nodeName",
                    "StoryTitle", "StoryAuthor", "StorySynopsis", "stepOrder", "StepHeading", "StepContent",
                    "ArtifactName", "ArtifactOrigin", "ArtifactPeriod", "ArtifactMaterial",
                    "CollectionTitle", "CollectionTheme", "CollectionDesc",
                    "mediaType", "fileName", "mediaURL");

                lblRouteInfo.Text = "";

                int maxItemWidth = 0;
                using (Graphics g = lstTimeline.CreateGraphics())
                {
                    for (int i = 0; i < dtRouteNodes.Rows.Count; i++)
                    {
                        DataRow row = dtRouteNodes.Rows[i];
                        string nodeName = row["nodeName"]?.ToString() ?? $"Điểm {i + 1}";
                        string stepHeading = row["StepHeading"]?.ToString() ?? "";
                        string displayTitle = !string.IsNullOrEmpty(stepHeading) ? $"{nodeName} - {stepHeading}" : nodeName;
                        string itemText = $"[{i + 1}] {displayTitle}";

                        lstTimeline.Items.Add(itemText);

                        int itemWidth = (int)g.MeasureString(itemText, lstTimeline.Font).Width;
                        if (itemWidth > maxItemWidth) maxItemWidth = itemWidth;
                    }
                }
                lstTimeline.HorizontalExtent = maxItemWidth + 20;

                currentStepIndex = 0;
                lstTimeline.SelectedIndex = 0;
                DisplayNodeStepDetail(currentStepIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp dữ liệu hành trình: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstTimeline_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTimeline.SelectedIndex >= 0)
            {
                currentStepIndex = lstTimeline.SelectedIndex;
                DisplayNodeStepDetail(currentStepIndex);
            }
        }

        private void DisplayNodeStepDetail(int index)
        {
            if (dtRouteNodes == null || index < 0 || index >= dtRouteNodes.Rows.Count) return;

            if (dynamicMediaPlayer != null && dynamicMediaPlayer.URL != null)
            {
                try { dynamicMediaPlayer.Ctlcontrols.stop(); } catch { }
            }

            DataRow row = dtRouteNodes.Rows[index];

            // 1. Tên điểm dừng
            lblNodeTitle.Text = $"ĐIỂM DỪNG [{index + 1}/{dtRouteNodes.Rows.Count}]: {row["nodeName"]}";

            // 2. Thông tin Câu chuyện
            string storyTitle = row["StoryTitle"]?.ToString() ?? "";
            if (!string.IsNullOrEmpty(storyTitle))
            {
                lblStoryHeader.Text = $"CÂU CHUYỆN: {storyTitle} (Tác giả: {row["StoryAuthor"]})";
                string synopsis = row["StorySynopsis"]?.ToString() ?? "";
                lblStorySynopsis.Text = string.IsNullOrEmpty(synopsis) ? "" : $"Tóm tắt: {synopsis}";
                lblStepTitle.Text = $"Bước {row["stepOrder"]}: {row["StepHeading"]}";
                txtStepContent.Text = row["StepContent"]?.ToString() ?? "";
            }
            else
            {
                lblStoryHeader.Text = "CÂU CHUYỆN: (Tham quan tự do)";
                lblStorySynopsis.Text = "";
                lblStepTitle.Text = "Nội dung thuyết minh điểm dừng";
                txtStepContent.Text = "Điểm dừng tham quan tự do, không thuộc kịch bản câu chuyện.";
            }

            // 3. Thông tin Hiện vật & Media
            string artifactName = row["ArtifactName"]?.ToString() ?? "";
            string mediaType = row["mediaType"]?.ToString() ?? "";
            string fileName = row["fileName"]?.ToString() ?? "";
            string mediaUrl = row["mediaURL"]?.ToString() ?? "";

            if (!string.IsNullOrEmpty(artifactName) || !string.IsNullOrEmpty(fileName))
            {
                grpArtifact.Visible = true;

                if (!string.IsNullOrEmpty(artifactName))
                {
                    lblArtifactHeader.Text = $"HIỆN VẬT: {artifactName}";
                    string colTitle = row["CollectionTitle"]?.ToString() ?? "";
                    string colTheme = row["CollectionTheme"]?.ToString() ?? "";
                    string period = row["ArtifactPeriod"]?.ToString() ?? "";
                    string material = row["ArtifactMaterial"]?.ToString() ?? "";
                    string origin = row["ArtifactOrigin"]?.ToString() ?? "";
                    string colDesc = row["CollectionDesc"]?.ToString() ?? "";

                    lblArtifactMeta.Text = $"Bộ sưu tập: {colTitle} ({colTheme})\nThời kỳ: {period} | Chất liệu: {material}\nXuất xứ: {origin}";
                    lblCollectionDesc.Text = string.IsNullOrEmpty(colDesc) ? "" : $"Mô tả: {colDesc}";
                }
                else
                {
                    lblArtifactHeader.Text = "GIỚI THIỆU TỔNG QUAN";
                    lblArtifactMeta.Text = "Mời bạn cùng chiêm ngưỡng vẻ đẹp của lịch sử.";
                    lblCollectionDesc.Text = "";
                }

                if (!string.IsNullOrWhiteSpace(mediaUrl))
                {
                    GenerateQRCode(mediaUrl);
                }
                else
                {
                    ClearQRCode();
                }

                picMedia.Image = null;
                picMedia.Controls.Clear();
                pnlMediaContainer.Visible = false;
                picMedia.Visible = true;

                if (mediaType.Equals("Video", StringComparison.OrdinalIgnoreCase) ||
                    mediaType.Equals("Audio", StringComparison.OrdinalIgnoreCase))
                {
                    if (File.Exists(fileName) && dynamicMediaPlayer != null)
                    {
                        picMedia.Visible = false;
                        pnlMediaContainer.Visible = true;
                        dynamicMediaPlayer.URL = fileName;
                        dynamicMediaPlayer.Ctlcontrols.play();
                    }
                    else
                    {
                        SetMediaFallbackTag(mediaType, fileName);
                    }
                }
                else if (mediaType.Equals("Image", StringComparison.OrdinalIgnoreCase))
                {
                    if (File.Exists(fileName))
                    {
                        try { picMedia.Image = Image.FromFile(fileName); }
                        catch { SetMediaFallbackTag(mediaType, fileName); }
                    }
                    else
                    {
                        SetMediaFallbackTag(mediaType, fileName);
                    }
                }
                else
                {
                    SetMediaFallbackTag(mediaType, fileName);
                }
            }
            else
            {
                grpArtifact.Visible = false;
                ClearQRCode();
                picMedia.Image = null;
                picMedia.Controls.Clear();
                pnlMediaContainer.Visible = false;
            }

            AdjustLayoutForArtifact();

            btnPrevNode.Enabled = (index > 0);
            btnNextNode.Enabled = (index < dtRouteNodes.Rows.Count - 1);
            lblStepCounter.Text = $"{index + 1} / {dtRouteNodes.Rows.Count}";

            if (ScreenReaderHelper.IsEnabled)
            {
                string speechText = $"Đã mở {lblNodeTitle.Text}. ";
                if (!string.IsNullOrEmpty(storyTitle))
                {
                    speechText += $"{lblStoryHeader.Text}. {lblStepTitle.Text}. ";
                }
                ScreenReaderHelper.Speak(speechText);
            }
        }

        private void picMedia_Click(object sender, EventArgs e)
        {
            if (picMedia.Image == null) return;

            Form fullScreenViewer = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                BackColor = Color.Black,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false
            };

            PictureBox picFull = new PictureBox
            {
                Image = picMedia.Image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                Cursor = Cursors.Hand
            };

            Label lblCloseHint = new Label
            {
                Text = "Nhấn ESC hoặc click bất kỳ đâu để đóng",
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                AutoSize = true,
                Location = new Point(15, 15)
            };

            picFull.Controls.Add(lblCloseHint);

            picFull.Click += (s, args) => fullScreenViewer.Close();
            fullScreenViewer.KeyDown += (s, args) =>
            {
                if (args.KeyCode == Keys.Escape || args.KeyCode == Keys.Enter || args.KeyCode == Keys.Space)
                {
                    fullScreenViewer.Close();
                }
            };

            fullScreenViewer.Controls.Add(picFull);
            fullScreenViewer.ShowDialog(this);
        }

        private void GenerateQRCode(string url)
        {
            try
            {
                ClearQRCode();

                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(5);
                        picQRCode.Image = qrCodeImage;
                        picQRCode.Visible = true;

                        lblArtifactHeader.Width = 230;
                        lblArtifactMeta.Width = 230;
                    }
                }
            }
            catch
            {
                ClearQRCode();
            }
        }

        private void ClearQRCode()
        {
            if (picQRCode.Image != null)
            {
                picQRCode.Image.Dispose();
                picQRCode.Image = null;
            }
            picQRCode.Visible = false;

            lblArtifactHeader.Width = 314;
            lblArtifactMeta.Width = 314;
        }

        private void AdjustLayoutForArtifact()
        {
            int totalWidth = pnlContentBody.ClientSize.Width;
            int padding = 10;

            if (grpArtifact.Visible)
            {
                int artifactWidth = 330;
                grpArtifact.Width = artifactWidth;
                grpArtifact.Left = totalWidth - artifactWidth - padding;
                grpArtifact.Height = pnlContentBody.ClientSize.Height - padding;

                txtStepContent.Width = grpArtifact.Left - txtStepContent.Left - padding;
            }
            else
            {
                txtStepContent.Width = totalWidth - txtStepContent.Left - padding;
            }
            txtStepContent.Height = pnlContentBody.ClientSize.Height - txtStepContent.Top - padding;
        }

        private void pnlContentBody_Resize(object sender, EventArgs e)
        {
            AdjustLayoutForArtifact();
        }

        private void SetMediaFallbackTag(string mediaType, string fileName)
        {
            picMedia.Visible = true;
            pnlMediaContainer.Visible = false;
            Label lblTag = new Label
            {
                Text = string.IsNullOrEmpty(mediaType) ? "Chưa chọn tệp Media" : $"[{mediaType.ToUpper()}]\n{fileName}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.DimGray
            };
            picMedia.Controls.Add(lblTag);
        }

        private void ClearJourneyDisplay()
        {
            if (dynamicMediaPlayer != null && dynamicMediaPlayer.URL != null)
            {
                try { dynamicMediaPlayer.Ctlcontrols.stop(); } catch { }
            }
            pnlMediaContainer.Visible = false;
            picMedia.Visible = true;

            lblNodeTitle.Text = "Chưa có điểm dừng";
            lblStoryHeader.Text = "";
            lblStorySynopsis.Text = "";
            lblStepTitle.Text = "";
            txtStepContent.Clear();

            grpArtifact.Visible = false;
            ClearQRCode();
            lblArtifactHeader.Text = "";
            lblArtifactMeta.Text = "";
            lblCollectionDesc.Text = "";
            picMedia.Image = null;
            picMedia.Controls.Clear();

            btnPrevNode.Enabled = false;
            btnNextNode.Enabled = false;
            lblStepCounter.Text = "0 / 0";
        }

        private void btnPrevNode_Click(object sender, EventArgs e)
        {
            if (currentStepIndex > 0)
            {
                currentStepIndex--;
                lstTimeline.SelectedIndex = currentStepIndex;
            }
        }

        private void btnNextNode_Click(object sender, EventArgs e)
        {
            if (dtRouteNodes != null && currentStepIndex < dtRouteNodes.Rows.Count - 1)
            {
                currentStepIndex++;
                lstTimeline.SelectedIndex = currentStepIndex;
            }
        }
    }
}