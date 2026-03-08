using System;

namespace BenhVienOffline.Models
{
    public class DichVuChon
    {
        public int Id { get; set; }
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public decimal ThanhTien => SoLuong * DonGia;
    }
}