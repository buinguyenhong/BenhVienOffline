using System;

namespace BenhVienOffline.Models
{
    public class DichVu
    {
        public int Id { get; set; }
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal GiaVienPhi { get; set; }
        public decimal GiaBaoHiem { get; set; }
    }
}