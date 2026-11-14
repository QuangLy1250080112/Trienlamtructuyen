using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using NAudio.Wave;
using Vosk;

namespace Trienlamtructuyen
{
    public static class VoiceRecognitionHelper
    {
        public static bool IsListening { get; private set; } = false;
        public static event Action<string>? OnCommandRecognized;

        private static Model? model;
        private static VoskRecognizer? recognizer;
        private static WaveInEvent? waveIn;

        private static string lastHandledCommand = "";
        private static DateTime lastHandledTime = DateTime.MinValue;

        static VoiceRecognitionHelper()
        {
            try
            {
                string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "model-vn");
                if (Directory.Exists(modelPath))
                {
                    Vosk.Vosk.SetLogLevel(-1);
                    model = new Model(modelPath);

                    // 1. Mở rộng bộ Từ điển Grammar chứa thêm các biến thể âm tiết bị Vosk đoán nhầm cho lệnh TẮT MEDIA
                    List<string> expandedGrammar = new List<string>
                    {
                        // 1. Khám phá triển lãm
                        "khám phá triển lãm", "kham pha trien lam", "khám phá", "triển lãm", "kham pha", "trien lam",
                        "triển lãm ảnh", "triển lảm", "triển lâm", "lãm", "lảm", "lâm", "lặng", "lẽ", "lệ", "làm",
                        "hôm ra tỷ lệ", "đầm ra triển lãm ảnh", "đêm hoa kỳ lạ lẫm", "đồng thời thì làm",
                        "hà nam khoa biển lặng", "em trai chị lặng", "rèm khai quật nữa hình", "âm phối khí lạnh",

                        // 2. Điểm dừng
                        "điểm dừng", "diem dung", "điểm", "dừng", "diem", "đểm", "điễm",

                        // 3. Tên câu chuyện
                        "tên câu chuyện", "ten cau chuyen", "câu chuyện", "cau chuyen", "câu truyện", "tên chuyện", "chuyện", "truyện",

                        // 4. Nội dung
                        "nội dung", "noi dung", "nỗi dung", "thuyết minh", "thuyet minh", "nội",

                        // 5. Tuyến tham quan
                        "tuyến tham quan", "tuyen tham quan", "tuyến", "tham quan", "tuyen",

                        // 6. Mở / Phát media
                        "mở media", "chơi media", "phát media", "bật media", "mở video", "phát video", "mở nhạc", "chơi nhạc", "mở", "chơi", "phát", "bật",

                        // 7. Tắt / Dừng media (Bổ sung tất cả các chuỗi thu âm biến dạng từ log)
                        "tắt media", "dừng media", "ngưng media", "tắt video", "dừng video", "tắt nhạc", "dừng nhạc", "tắt", "ngưng",
                        "đất này đe", "đợt này đe", "đất này đi ăn", "đất này đi hoặc", "đất lý đê", "đất này", "đợt này", "đê", "đây", "tất",

                        "[unk]"
                    };

                    string grammarJson = JsonSerializer.Serialize(expandedGrammar);
                    recognizer = new VoskRecognizer(model, 16000.0f, grammarJson);
                    Debug.WriteLine("[VoiceRecognition] Đã nạp bộ ngữ pháp mở rộng siêu nhạy.");
                }
                else
                {
                    Debug.WriteLine("[VoiceRecognition Warning] Chưa tìm thấy thư mục model-vn!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[VoiceRecognition Init Error] {ex.Message}");
            }
        }

        public static void ToggleListening()
        {
            if (IsListening) Stop();
            else Start();
        }

        public static void Start()
        {
            if (model == null || recognizer == null)
            {
                ScreenReaderHelper.Speak("Chưa nạp được bộ dữ liệu giọng nói tiếng Việt.");
                return;
            }

            try
            {
                waveIn = new WaveInEvent
                {
                    DeviceNumber = 0,
                    WaveFormat = new WaveFormat(16000, 1) // 16kHz Mono
                };

                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.StartRecording();
                IsListening = true;

                ScreenReaderHelper.Speak("Đã bật nhận diện giọng nói. Mời bạn nói câu lệnh.");
                Debug.WriteLine("[VoiceRecognition] Đang lắng nghe micrô...");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[VoiceRecognition Start Error] {ex.Message}");
                ScreenReaderHelper.Speak("Không thể kết nối micrô.");
            }
        }

        private static void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            if (recognizer == null) return;

            // Bỏ qua thu mic khi ScreenReader đang phát loa để tránh thu vòng
            if (ScreenReaderHelper.IsSpeaking) return;

            if (recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded))
            {
                string text = ExtractTextFromJson(recognizer.Result()).ToLower().Trim();

                if (!string.IsNullOrWhiteSpace(text) && text != "[unk]")
                {
                    Debug.WriteLine($"[VoiceRecognition RAW] Thu được từ mic: '{text}'");
                    CheckAndExecuteCommand(text);
                }
            }
        }

        private static void CheckAndExecuteCommand(string text)
        {
            string matchedCommand = MatchUserCommand(text);

            if (!string.IsNullOrEmpty(matchedCommand))
            {
                // Chống lặp câu lệnh trùng trong vòng 1.2 giây
                if (matchedCommand == lastHandledCommand && (DateTime.Now - lastHandledTime).TotalSeconds < 1.2)
                {
                    return;
                }

                lastHandledCommand = matchedCommand;
                lastHandledTime = DateTime.Now;

                // Reset bộ đệm nhận diện
                recognizer?.Reset();

                Debug.WriteLine($"[VoiceRecognition SUCCESS] >>> KHỚP LỆNH: '{matchedCommand}' (Gốc: '{text}')");
                OnCommandRecognized?.Invoke(matchedCommand);
            }
        }

        /// <summary>
        /// Phân tích câu lệnh rộng hơn cho các từ Vosk hay luận nhầm
        /// </summary>
        private static string MatchUserCommand(string input)
        {
            string norm = RemoveDiacritics(input).ToLower();

            // 1. TẮT / DỪNG MEDIA (Đưa lên kiểm tra sớm và bắt luôn các âm tiết biến dạng Vosk đoán nhầm)
            if (norm.Contains("tat media") || norm.Contains("dung media") || norm.Contains("ngung media") ||
                norm.Contains("tat video") || norm.Contains("dung video") || norm.Contains("tat nhac") || norm.Contains("dung nhac") ||
                norm.Contains("tat") || norm.Contains("ngung") || norm.Contains("dat nay") || norm.Contains("dot nay") ||
                norm.Contains("dat ly") || norm.Contains("nay de") || norm.Contains("di an"))
            {
                return "tắt media";
            }

            // 2. KHÁM PHÁ TRIỂN LÃM
            if (norm.Contains("kham pha") || norm.Contains("trien lam") || norm.Contains("trien") ||
                norm.Contains("lam") || norm.Contains("lang") || norm.Contains("ty le") || norm.Contains("thi lam"))
            {
                return "khám phá triển lãm";
            }

            // 3. NỘI DUNG
            if (norm.Contains("noi dung") || norm.Contains("thuyet minh") || norm.Contains("noi dun") || norm.Contains("noi"))
                return "nội dung";

            // 4. TÊN CÂU CHUYỆN
            if (norm.Contains("cau chuyen") || norm.Contains("cau truyen") || norm.Contains("ten cau") || norm.Contains("ten chuyen") || norm.Contains("chuyen") || norm.Contains("truyen"))
                return "tên câu chuyện";

            // 5. TUYẾN THAM QUAN
            if (norm.Contains("tuyen tham quan") || norm.Contains("tuyen tham") || norm.Contains("tuyen quan") || norm.Contains("tuyen") || norm.Contains("tham quan"))
                return "tuyến tham quan";

            // 6. MỞ / CHƠI / PHÁT MEDIA
            if (norm.Contains("mo media") || norm.Contains("choi media") || norm.Contains("phat media") || norm.Contains("bat media") ||
                norm.Contains("mo video") || norm.Contains("phat video") || norm.Contains("mo nhac") || norm.Contains("phat nhac") ||
                norm.Contains("mo") || norm.Contains("choi") || norm.Contains("phat") || norm.Contains("bat"))
            {
                return "mở media";
            }

            // 7. ĐIỂM DỪNG
            if (norm.Contains("diem dung") || norm.Contains("diem") || norm.Contains("dung"))
            {
                return "điểm dừng";
            }

            return string.Empty;
        }

        private static string RemoveDiacritics(string text)
        {
            string regex = @"[áàảãạâấầẩẫậăắằẳẵặ]";
            text = Regex.Replace(text, regex, "a");
            regex = @"[éèẻẽẹêếềểễệ]";
            text = Regex.Replace(text, regex, "e");
            regex = @"[iíìỉĩị]";
            text = Regex.Replace(text, regex, "i");
            regex = @"[óòỏõọôốồổỗộơớờởỡợ]";
            text = Regex.Replace(text, regex, "o");
            regex = @"[úùủũụưứừửữự]";
            text = Regex.Replace(text, regex, "u");
            regex = @"[ýỳỷỹỵ]";
            text = Regex.Replace(text, regex, "y");
            regex = @"[đ]";
            text = Regex.Replace(text, regex, "d");
            return text;
        }

        public static void Stop()
        {
            try
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                    waveIn.Dispose();
                    waveIn = null;
                }
                IsListening = false;
                ScreenReaderHelper.Speak("Đã tắt nhận diện giọng nói.");
                Debug.WriteLine("[VoiceRecognition] Đã dừng lắng nghe.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[VoiceRecognition Stop Error] {ex.Message}");
            }
        }

        private static string ExtractTextFromJson(string json)
        {
            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("text", out JsonElement textElement))
                {
                    return textElement.GetString() ?? "";
                }
            }
            catch { }
            return "";
        }
    }
}