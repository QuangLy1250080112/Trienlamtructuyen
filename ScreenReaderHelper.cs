using System;
using System.Diagnostics;
using System.Speech.Synthesis;

namespace Trienlamtructuyen
{
    public static class ScreenReaderHelper
    {
        public static bool IsEnabled { get; set; } = false;
        private static readonly SpeechSynthesizer synth = new SpeechSynthesizer();

        // Thuộc tính kiểm tra xem Screen Reader có đang phát tiếng đọc ra loa hay không
        public static bool IsSpeaking => synth.State == SynthesizerState.Speaking;

        static ScreenReaderHelper()
        {
            try
            {
                synth.Volume = 100;
                synth.Rate = 1;

                bool selected = false;

                // 1. Duyệt danh sách các giọng đã cài
                foreach (var voice in synth.GetInstalledVoices())
                {
                    if (!voice.Enabled) continue;

                    var info = voice.VoiceInfo;
                    Debug.WriteLine($"[ScreenReader Voice] Tên: {info.Name} | Ngôn ngữ: {info.Culture.Name}");

                    // 2. Tìm giọng theo mã ngôn ngữ tiếng Việt (vi-VN)
                    if (info.Culture.Name.Equals("vi-VN", StringComparison.OrdinalIgnoreCase) ||
                        info.Culture.TwoLetterISOLanguageName.Equals("vi", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            synth.SelectVoice(info.Name);
                            selected = true;
                            Debug.WriteLine($"[ScreenReader Selected Voice] Đã chọn giọng tiếng Việt thành công: {info.Name}");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"[ScreenReader Voice Select Error] {info.Name}: {ex.Message}");
                        }
                    }
                }

                // 3. Phương án dự phòng chọn giọng theo Prompt/Culture nếu SelectVoice theo tên bị SAPI5 chặn
                if (!selected)
                {
                    try
                    {
                        synth.SelectVoiceByHints(VoiceGender.NotSet, VoiceAge.NotSet, 0, new System.Globalization.CultureInfo("vi-VN"));
                        Debug.WriteLine("[ScreenReader Selected Voice] Đã chọn giọng tiếng Việt qua SelectVoiceByHints (vi-VN)");
                    }
                    catch
                    {
                        Debug.WriteLine("[ScreenReader Warning] Không thể kích hoạt giọng tiếng Việt qua SAPI5, chuyển sang giọng mặc định.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ScreenReader Init Error] {ex.Message}");
            }
        }

        public static void Speak(string text)
        {
            if (!IsEnabled || string.IsNullOrWhiteSpace(text)) return;

            Debug.WriteLine($"[ScreenReader] Đang đọc: {text}");

            try
            {
                // Ngắt câu đọc cũ ngay lập tức để phản hồi phím Tab 0ms
                synth.SpeakAsyncCancelAll();

                // Đọc ngay lập tức câu mới
                synth.SpeakAsync(text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ScreenReader Error] {ex.Message}");
            }
        }

        public static void Stop()
        {
            try
            {
                synth.SpeakAsyncCancelAll();
            }
            catch { }
        }
    }
}