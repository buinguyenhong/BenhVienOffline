using BenhVienOffline.Models;

namespace BenhVienOffline.Session
{
    public static class CurrentSession
    {
        public static User CurrentUser { get; private set; }

        public static void SetUser(User user)
        {
            CurrentUser = user;
        }

        public static void Clear()
        {
            CurrentUser = null;
        }

        public static string CurrentKhoa => CurrentUser != null ? CurrentUser.Username : null;
        public static bool IsThuNgan => CurrentUser != null && CurrentUser.Role == "ThuNgan";
    }
}
