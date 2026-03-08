using System;
using System.Collections.Generic;
using System.Data;
using BenhVienOffline.Data;
using BenhVienOffline.Models;

namespace BenhVienOffline.Services
{
    public static class ThuNganService
    {
        public static long InsertTamUng(HoaDonTamUng hd)
        {
            if (string.IsNullOrWhiteSpace(hd.MaHoaDon))
            {
                hd.MaHoaDon = Utils.IdGenerator.GenerateMaHoaDonTamUng(hd.TenBenhNhan);
            }

        public static void ExportTamUngToCsv(string filePath)
        {
            var lines = new List<string>();
            lines.Add("MaHoaDon,Khoa,TenBenhNhan,NamSinh,DoiTuong,NgayGio,SoTien,DaIn");
            var dt = SQLiteHelper.ExecuteQuery("SELECT MaHoaDon, Khoa, TenBenhNhan, NamSinh, DoiTuong, NgayGio, SoTien, DaIn FROM HoaDonTamUng ORDER BY NgayGio");
            foreach (DataRow r in dt.Rows)
            {
                var ma = r["MaHoaDon"] != DBNull.Value ? r["MaHoaDon"].ToString() : string.Empty;
                var khoa = r["Khoa"] != DBNull.Value ? r["Khoa"].ToString() : string.Empty;
                var ten = r["TenBenhNhan"] != DBNull.Value ? r["TenBenhNhan"].ToString() : string.Empty;
                var ns = r["NamSinh"] != DBNull.Value ? r["NamSinh"].ToString() : string.Empty;
                var dtg = r["DoiTuong"] != DBNull.Value ? r["DoiTuong"].ToString() : string.Empty;
                var ng = r["NgayGio"] != DBNull.Value ? r["NgayGio"].ToString() : string.Empty;
                var st = r["SoTien"] != DBNull.Value ? r["SoTien"].ToString() : "0";
                var di = r["DaIn"] != DBNull.Value ? r["DaIn"].ToString() : "0";
                lines.Add($"{Utils.ExportCsvHelper.Escape(ma)},{Utils.ExportCsvHelper.Escape(khoa)},{Utils.ExportCsvHelper.Escape(ten)},{Utils.ExportCsvHelper.Escape(ns)},{Utils.ExportCsvHelper.Escape(dtg)},{Utils.ExportCsvHelper.Escape(ng)},{Utils.ExportCsvHelper.Escape(st)},{Utils.ExportCsvHelper.Escape(di)}");
            }

            Utils.ExportCsvHelper.WriteLines(filePath, lines);
        }

        public static void ExportThanhToanToCsv(string invoiceFilePath, string linesFilePath)
        {
            var linesInv = new List<string>();
            linesInv.Add("MaHoaDon,Khoa,TenBenhNhan,NamSinh,DoiTuong,TyLeBaoHiem,TienGiuong,SoTienTamUng,NgayGio,DaIn");
            var dt = SQLiteHelper.ExecuteQuery("SELECT Id, MaHoaDon, Khoa, TenBenhNhan, NamSinh, DoiTuong, TyLeBaoHiem, TienGiuong, SoTienTamUng, NgayGio, DaIn FROM HoaDonThanhToan ORDER BY NgayGio");
            var invIds = new List<long>();
            foreach (DataRow r in dt.Rows)
            {
                var id = r["Id"] != DBNull.Value ? Convert.ToInt64(r["Id"]) : 0L;
                invIds.Add(id);
                var ma = r["MaHoaDon"] != DBNull.Value ? r["MaHoaDon"].ToString() : string.Empty;
                var khoa = r["Khoa"] != DBNull.Value ? r["Khoa"].ToString() : string.Empty;
                var ten = r["TenBenhNhan"] != DBNull.Value ? r["TenBenhNhan"].ToString() : string.Empty;
                var ns = r["NamSinh"] != DBNull.Value ? r["NamSinh"].ToString() : string.Empty;
                var dtg = r["DoiTuong"] != DBNull.Value ? r["DoiTuong"].ToString() : string.Empty;
                var ty = r["TyLeBaoHiem"] != DBNull.Value ? r["TyLeBaoHiem"].ToString() : string.Empty;
                var tg = r["TienGiuong"] != DBNull.Value ? r["TienGiuong"].ToString() : "0";
                var st = r["SoTienTamUng"] != DBNull.Value ? r["SoTienTamUng"].ToString() : "0";
                var ng = r["NgayGio"] != DBNull.Value ? r["NgayGio"].ToString() : string.Empty;
                var di = r["DaIn"] != DBNull.Value ? r["DaIn"].ToString() : "0";
                linesInv.Add($"{Utils.ExportCsvHelper.Escape(ma)},{Utils.ExportCsvHelper.Escape(khoa)},{Utils.ExportCsvHelper.Escape(ten)},{Utils.ExportCsvHelper.Escape(ns)},{Utils.ExportCsvHelper.Escape(dtg)},{Utils.ExportCsvHelper.Escape(ty)},{Utils.ExportCsvHelper.Escape(tg)},{Utils.ExportCsvHelper.Escape(st)},{Utils.ExportCsvHelper.Escape(ng)},{Utils.ExportCsvHelper.Escape(di)}");
            }

            Utils.ExportCsvHelper.WriteLines(invoiceFilePath, linesInv);

            // export lines
            var lines = new List<string>();
            lines.Add("HoaDonThanhToanId,MaHoaDon,MaDichVu,TenDichVu,SoLuong,DonGia");
            var sqlLines = "SELECT dc.HoaDonThanhToanId, ht.MaHoaDon, dc.MaDichVu, dc.TenDichVu, dc.SoLuong, dc.DonGia FROM DichVuChon dc LEFT JOIN HoaDonThanhToan ht ON dc.HoaDonThanhToanId = ht.Id ORDER BY dc.Id";
            var dtLines = SQLiteHelper.ExecuteQuery(sqlLines);
            foreach (DataRow r in dtLines.Rows)
            {
                var hid = r["HoaDonThanhToanId"] != DBNull.Value ? r["HoaDonThanhToanId"].ToString() : "";
                var mahd = r["MaHoaDon"] != DBNull.Value ? r["MaHoaDon"].ToString() : "";
                var ma = r["MaDichVu"] != DBNull.Value ? r["MaDichVu"].ToString() : "";
                var ten = r["TenDichVu"] != DBNull.Value ? r["TenDichVu"].ToString() : "";
                var sl = r["SoLuong"] != DBNull.Value ? r["SoLuong"].ToString() : "0";
                var dg = r["DonGia"] != DBNull.Value ? r["DonGia"].ToString() : "0";
                lines.Add($"{Utils.ExportCsvHelper.Escape(hid)},{Utils.ExportCsvHelper.Escape(mahd)},{Utils.ExportCsvHelper.Escape(ma)},{Utils.ExportCsvHelper.Escape(ten)},{Utils.ExportCsvHelper.Escape(sl)},{Utils.ExportCsvHelper.Escape(dg)}");
            }

            Utils.ExportCsvHelper.WriteLines(linesFilePath, lines);
        }

            var sql = "INSERT INTO HoaDonTamUng (MaHoaDon, Khoa, TenBenhNhan, NamSinh, DoiTuong, NgayGio, SoTien, DaIn) VALUES (@ma, @k, @ten, @ns, @dt, @ng, @st, @di)";

            var ng = hd.NgayGio;

            return SQLiteHelper.ExecuteInsertAndGetId(sql,
                SQLiteHelper.CreateParam("@ma", DbType.String, hd.MaHoaDon),
                SQLiteHelper.CreateParam("@k", DbType.String, hd.Khoa),
                SQLiteHelper.CreateParam("@ten", DbType.String, hd.TenBenhNhan),
                SQLiteHelper.CreateParam("@ns", DbType.Int32, hd.NamSinh),
                SQLiteHelper.CreateParam("@dt", DbType.String, hd.DoiTuong),
                SQLiteHelper.CreateParam("@ng", DbType.String, ng.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                SQLiteHelper.CreateParam("@st", DbType.Decimal, hd.SoTien),
                SQLiteHelper.CreateParam("@di", DbType.Int32, hd.DaIn ? 1 : 0)
            );
        }

        public static long InsertThanhToan(HoaDonThanhToan hd)
        {
            if (string.IsNullOrWhiteSpace(hd.MaHoaDon))
            {
                hd.MaHoaDon = Utils.IdGenerator.GenerateMaHoaDonThanhToan(hd.TenBenhNhan);
            }

            var sql = "INSERT INTO HoaDonThanhToan (MaHoaDon, Khoa, TenBenhNhan, NamSinh, DoiTuong, TyLeBaoHiem, TienGiuong, SoTienTamUng, NgayGio, DaIn) VALUES (@ma, @k, @ten, @ns, @dt, @ty, @tg, @st, @ng, @di)";

            var ng = hd.NgayGio;

            var id = SQLiteHelper.ExecuteInsertAndGetId(sql,
                SQLiteHelper.CreateParam("@ma", DbType.String, hd.MaHoaDon),
                SQLiteHelper.CreateParam("@k", DbType.String, hd.Khoa),
                SQLiteHelper.CreateParam("@ten", DbType.String, hd.TenBenhNhan),
                SQLiteHelper.CreateParam("@ns", DbType.Int32, hd.NamSinh),
                SQLiteHelper.CreateParam("@dt", DbType.String, hd.DoiTuong),
                SQLiteHelper.CreateParam("@ty", DbType.Int32, hd.TyLeBaoHiem),
                SQLiteHelper.CreateParam("@tg", DbType.Decimal, hd.TienGiuong),
                SQLiteHelper.CreateParam("@st", DbType.Decimal, hd.SoTienTamUng),
                SQLiteHelper.CreateParam("@ng", DbType.String, ng.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                SQLiteHelper.CreateParam("@di", DbType.Int32, hd.DaIn ? 1 : 0)
            );

            // insert dich vu chon
            if (hd.DichVuChons != null && hd.DichVuChons.Count > 0 && id > 0)
            {
                foreach (var dv in hd.DichVuChons)
                {
                    SQLiteHelper.ExecuteNonQuery(
                        "INSERT INTO DichVuChon (HoaDonThanhToanId, MaDichVu, TenDichVu, SoLuong, DonGia) VALUES (@hid, @ma, @ten, @sl, @dg)",
                        SQLiteHelper.CreateParam("@hid", DbType.Int64, id),
                        SQLiteHelper.CreateParam("@ma", DbType.String, dv.MaDichVu),
                        SQLiteHelper.CreateParam("@ten", DbType.String, dv.TenDichVu),
                        SQLiteHelper.CreateParam("@sl", DbType.Int32, dv.SoLuong),
                        SQLiteHelper.CreateParam("@dg", DbType.Decimal, dv.DonGia)
                    );
                }
            }

            return id;
        }

        public static decimal GetSumTamUng(string khoa, string ten, int? nam)
        {
            var sql = "SELECT SUM(SoTien) FROM HoaDonTamUng WHERE Khoa = @k AND TenBenhNhan = @ten" + (nam.HasValue ? " AND NamSinh = @ns" : "");
            var parameters = new List<System.Data.SQLite.SQLiteParameter>
            {
                SQLiteHelper.CreateParam("@k", DbType.String, khoa),
                SQLiteHelper.CreateParam("@ten", DbType.String, ten)
            };
            if (nam.HasValue)
                parameters.Add(SQLiteHelper.CreateParam("@ns", DbType.Int32, nam.Value));

            var val = SQLiteHelper.ExecuteScalar(sql, parameters.ToArray());
            if (val == null || val == DBNull.Value) return 0m;
            return Convert.ToDecimal(val);
        }
    }
}
