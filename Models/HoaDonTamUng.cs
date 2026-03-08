using System;

namespace BenhVienOffline.Models
{
    public class HoaDonTamUng
    {
        public int Id { get; set; }
        public string MaHoaDon { get; set; } // TU_{tenbenhnhankhongdau}_{yyyyMMddHHmmssfff}
        public string Khoa { get; set; }
        public string TenBenhNhan { get; set; }
        public int? NamSinh { get; set; }
        public string DoiTuong { get; set; } // "VienPhi" or "BaoHiem"
        public DateTime NgayGio { get; set; }
        public decimal SoTien { get; set; }
        public bool DaIn { get; set; }
    }
}