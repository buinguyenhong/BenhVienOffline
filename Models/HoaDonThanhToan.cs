using System;
using System.Collections.Generic;
using System.Linq;

namespace BenhVienOffline.Models
{
    public class HoaDonThanhToan
    {
        public int Id { get; set; }
        public string MaHoaDon { get; set; } // TT_{tenbenhnhankhongdau}_{yyyyMMddHHmmssfff}
        public string Khoa { get; set; }
        public string TenBenhNhan { get; set; }
        public int? NamSinh { get; set; }
        public string DoiTuong { get; set; } // "VienPhi" or "BaoHiem"
        public int? TyLeBaoHiem { get; set; } // 80, 95, 100
        public decimal TienGiuong { get; set; }
        public List<DichVuChon> DichVuChons { get; set; } = new List<DichVuChon>();
        public decimal SoTienTamUng { get; set; }
        public DateTime NgayGio { get; set; }
        public bool DaIn { get; set; }

        public decimal TongDichVu => DichVuChons?.Sum(d => d.ThanhTien) ?? 0m;

        public decimal ThanhToanThanhTien
        {
            get
            {
                decimal totalDichVu = TongDichVu;
                decimal applyPrice = totalDichVu; // price already chosen per service line

                if (DoiTuong == "BaoHiem" && TyLeBaoHiem.HasValue)
                {
                    decimal tyLe = TyLeBaoHiem.Value / 100m;
                    applyPrice = applyPrice * tyLe; // apply insurance coverage
                }

                decimal total = TienGiuong + applyPrice - SoTienTamUng;
                return total >= 0 ? total : 0;
            }
        }
    }
}