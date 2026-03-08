using System;

namespace BenhVienOffline.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } // e.g. khoanoi, thungan
        public string DisplayName { get; set; }
        public string Role { get; set; } // "Khoa" or "ThuNgan"
    }
}