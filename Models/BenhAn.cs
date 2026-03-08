using System;

namespace BenhVienOffline.Models
{
    public class BenhAn
    {
        public int Id { get; set; }
        public string MaBenhAn { get; set; } // e.g. khoanoi_20260308101530125
        public string Khoa { get; set; }
        public string TenBenhNhan { get; set; }
        public int? NamSinh { get; set; }
        public DateTime? NgayVaoVien { get; set; }
        public DateTime? NgayRaVien { get; set; }

        public bool IsDaRaVien => NgayRaVien.HasValue;
    }
}