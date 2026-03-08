using System;
using BenhVienOffline.Utils;

namespace BenhVienOffline.Utils
{
    public static class IdGenerator
    {
        public static string GenerateMaBenhAn(string khoa)
        {
            var k = string.IsNullOrWhiteSpace(khoa) ? "unk" : khoa;
            return $"{k}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
        }

        public static string GenerateMaHoaDonTamUng(string tenBenhNhan)
        {
            var idName = StringUtils.ToIdentifier(tenBenhNhan);
            if (string.IsNullOrWhiteSpace(idName)) idName = "unk";
            return $"TU_{idName}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
        }

        public static string GenerateMaHoaDonThanhToan(string tenBenhNhan)
        {
            var idName = StringUtils.ToIdentifier(tenBenhNhan);
            if (string.IsNullOrWhiteSpace(idName)) idName = "unk";
            return $"TT_{idName}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
        }
    }
}
