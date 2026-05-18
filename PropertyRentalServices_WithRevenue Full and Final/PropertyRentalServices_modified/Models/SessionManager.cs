namespace PropertyRentalServices.Models
{
    public static class SessionManager
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserRole { get; set; }

        public static bool IsLoggedIn => UserId > 0;

        public static void Clear()
        {
            UserId = 0;
            UserName = string.Empty;
            UserEmail = string.Empty;
            UserRole = string.Empty;
        }
    }
}
