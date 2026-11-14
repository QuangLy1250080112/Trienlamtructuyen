namespace Trienlamtructuyen
{
    public static class UserSession
    {
        public static string UserID { get; set; } = string.Empty; // Khớp VARCHAR(50) USR-001
        public static string Username { get; set; } = string.Empty; // Khớp VARCHAR(50)
        public static string FullName { get; set; } = string.Empty; // Khớp NVARCHAR(100)
        public static string Email { get; set; } = string.Empty; // Khớp VARCHAR(100)
        public static string Role { get; set; } = string.Empty; // Khớp VARCHAR(20): Admin, Curator, Visitor
    }
}