# Triển lãm trực tuyến

Ứng dụng máy tính hỗ trợ tổ chức và trải nghiệm triển lãm số. Hệ thống quản lý bộ sưu tập, hiện vật, nội dung thuyết minh và tuyến tham quan trên cùng một cơ sở dữ liệu; khách tham quan có thể khám phá nội dung, xem tư liệu đa phương tiện và gửi đánh giá.

## Nghiệp vụ chính

- **Quản lý bộ sưu tập và hiện vật:** tổ chức hiện vật theo chủ đề, lưu thông tin xuất xứ, thời kỳ và chất liệu.
- **Biên tập câu chuyện:** xây dựng nội dung theo từng bước, liên kết bước thuyết minh với hiện vật và kiểm tra tình trạng đính kèm media.
- **Quản lý media:** lưu thông tin tệp, định dạng, dung lượng và liên kết media với hiện vật hoặc bước câu chuyện.
- **Thiết kế tuyến tham quan:** tạo tuyến và các điểm dừng dựa trên nội dung câu chuyện.
- **Khám phá triển lãm:** xem các tuyến và nội dung được trình bày theo điểm dừng, bao gồm tư liệu media liên quan.
- **Phản hồi và thống kê:** tiếp nhận đánh giá, xem số liệu về hiện vật, điểm dừng, media và phản hồi; xuất dữ liệu báo cáo dạng CSV.
- **Quản lý người dùng:** quản lý tài khoản và vai trò sử dụng hệ thống.
- **Hỗ trợ tiếp cận:** hỗ trợ đọc nội dung trên giao diện và nhận lệnh giọng nói tiếng Việt trong khu vực khám phá triển lãm.

## Vai trò sử dụng

| Vai trò | Phạm vi nghiệp vụ |
| --- | --- |
| `Admin` | Quản lý người dùng, bộ sưu tập, câu chuyện, tuyến tham quan, media và thống kê. |
| `Curator` | Quản lý nội dung triển lãm, tuyến tham quan, media và thống kê; không quản lý người dùng. |
| `Visitor` | Khám phá triển lãm và gửi phản hồi. |

## Yêu cầu hệ thống

- Windows có hỗ trợ ứng dụng Windows Forms.
- .NET 9 SDK để khôi phục gói, biên dịch và chạy từ mã nguồn.
- SQL Server có thể truy cập từ máy chạy ứng dụng.
- Cơ sở dữ liệu `Trienlamtructuyen` cùng dữ liệu mẫu đã được tạo (thư mục assets/Trienlamtructuyen.sql), có cấu trúc bảng và dữ liệu tài khoản phù hợp với ứng dụng.
- Micro và thư mục mô hình `model-vn` đặt cạnh tệp chạy ứng dụng nếu cần sử dụng nhận diện giọng nói. Đây là chức năng tùy chọn.

## Cài đặt và cấu hình

### 1. Chuẩn bị cơ sở dữ liệu

Mã nguồn hiện không kèm tệp SQL để tạo cơ sở dữ liệu hoặc dữ liệu khởi tạo. Trước khi chạy, cần chuẩn bị cơ sở dữ liệu `Trienlamtructuyen` với cấu trúc mà ứng dụng sử dụng, bao gồm các bảng người dùng, bộ sưu tập, hiện vật, câu chuyện, bước câu chuyện, media, tuyến tham quan, điểm dừng và phản hồi. Cần có tài khoản người dùng với vai trò phù hợp để sử dụng các nghiệp vụ.

Ứng dụng hiện cấu hình kết nối mặc định trong `Database.cs`:

```text
Data Source=localhost;Initial Catalog=Trienlamtructuyen;Integrated Security=True;TrustServerCertificate=True;
```

Nếu SQL Server không chạy tại `localhost` hoặc cần phương thức xác thực khác, hãy điều chỉnh chuỗi kết nối trong `Database.cs` cho phù hợp với môi trường triển khai. Tài khoản Windows chạy ứng dụng cần có quyền truy cập cơ sở dữ liệu.

### 2. Khôi phục và biên dịch

Mở PowerShell tại thư mục dự án, sau đó chạy:

```powershell
dotnet restore .\Trienlamtructuyen.csproj
dotnet build .\Trienlamtructuyen.csproj
```

### 3. Khởi chạy ứng dụng

```powershell
dotnet run --project .\Trienlamtructuyen.csproj
```

Ứng dụng mở giao diện khám phá triển lãm. Các chức năng quản trị sẽ được hiển thị tùy theo vai trò của phiên làm việc. Nếu không kết nối được cơ sở dữ liệu, hãy kiểm tra dịch vụ SQL Server, tên cơ sở dữ liệu, quyền truy cập và chuỗi kết nối.

## Hỗ trợ tiếp cận

- Nhấn `Ctrl` + `Shift` + `Tab` để bật hoặc tắt đọc màn hình.
- Khi đọc màn hình đang bật, nhấn `Ctrl` + `Shift` + `Space` để bật hoặc tắt nhận diện giọng nói.
- Nhận diện giọng nói cần có micro và mô hình tiếng Việt trong thư mục `model-vn` cạnh tệp chạy ứng dụng. Thiếu mô hình không ảnh hưởng đến các chức năng sử dụng chuột và bàn phím.

## Cấu trúc dự án

- `FrmMain.cs`: giao diện chính, điều hướng và phân quyền chức năng.
- Các tệp `Frm*.cs`: màn hình nghiệp vụ quản lý, khám phá, phản hồi và thống kê.
- `Database.cs`: cấu hình và các thao tác truy cập dữ liệu.
- `UserSession.cs`: thông tin phiên người dùng hiện tại.
- `ScreenReaderHelper.cs`, `VoiceRecognitionHelper.cs`: hỗ trợ đọc màn hình và nhận diện lệnh giọng nói.
