using System;
using System.Collections.Generic;
using System.Data;
using BenhVienOffline.Data;
using BenhVienOffline.Models;

namespace BenhVienOffline.Services
{
    public static class BenhAnService
    {
        public static List<BenhAn> GetActiveByKhoa(string khoa)
        {
            var list = new List<BenhAn>();
            var dt = SQLiteHelper.ExecuteQuery(
                "SELECT Id, MaBenhAn, Khoa, TenBenhNhan, NamSinh, NgayVaoVien, NgayRaVien FROM BenhAn WHERE Khoa = @k AND (NgayRaVien IS NULL OR NgayRaVien = '') ORDER BY NgayVaoVien DESC",
                SQLiteHelper.CreateParam("@k", DbType.String, khoa)
            );

            foreach (DataRow r in dt.Rows)
            {
                list.Add(RowToBenhAn(r));
            }

            return list;
        }

        public static BenhAn GetById(int id)
        {
            var dt = SQLiteHelper.ExecuteQuery(
                "SELECT Id, MaBenhAn, Khoa, TenBenhNhan, NamSinh, NgayVaoVien, NgayRaVien FROM BenhAn WHERE Id = @id",
                SQLiteHelper.CreateParam("@id", DbType.Int32, id)
            );

            if (dt.Rows.Count == 0) return null;
            return RowToBenhAn(dt.Rows[0]);
        }

        public static long Insert(BenhAn ba)
        {
            if (string.IsNullOrWhiteSpace(ba.MaBenhAn))
            {
                // Fallback if not set
                ba.MaBenhAn = GenerateMaBenhAn(ba.Khoa);
            }

            var sql = "INSERT INTO BenhAn (MaBenhAn, Khoa, TenBenhNhan, NamSinh, NgayVaoVien, NgayRaVien) VALUES (@ma, @k, @ten, @ns, @vao, @ra)";

            var vao = ba.NgayVaoVien.HasValue ? (object)ba.NgayVaoVien.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") : DBNull.Value;
            var ra = ba.NgayRaVien.HasValue ? (object)ba.NgayRaVien.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") : DBNull.Value;

            return SQLiteHelper.ExecuteInsertAndGetId(sql,
                SQLiteHelper.CreateParam("@ma", DbType.String, ba.MaBenhAn),
                SQLiteHelper.CreateParam("@k", DbType.String, ba.Khoa),
                SQLiteHelper.CreateParam("@ten", DbType.String, ba.TenBenhNhan),
                SQLiteHelper.CreateParam("@ns", DbType.Int32, ba.NamSinh),
                SQLiteHelper.CreateParam("@vao", DbType.String, vao),
                SQLiteHelper.CreateParam("@ra", DbType.String, ra)
            );
        }

        public static int Update(BenhAn ba)
        {
            var sql = "UPDATE BenhAn SET TenBenhNhan = @ten, NamSinh = @ns, NgayVaoVien = @vao, NgayRaVien = @ra WHERE Id = @id";
            var vao = ba.NgayVaoVien.HasValue ? (object)ba.NgayVaoVien.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") : DBNull.Value;
            var ra = ba.NgayRaVien.HasValue ? (object)ba.NgayRaVien.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") : DBNull.Value;

            return SQLiteHelper.ExecuteNonQuery(sql,
                SQLiteHelper.CreateParam("@ten", DbType.String, ba.TenBenhNhan),
                SQLiteHelper.CreateParam("@ns", DbType.Int32, ba.NamSinh),
                SQLiteHelper.CreateParam("@vao", DbType.String, vao),
                SQLiteHelper.CreateParam("@ra", DbType.String, ra),
                SQLiteHelper.CreateParam("@id", DbType.Int32, ba.Id)
            );
        }

        private static BenhAn RowToBenhAn(DataRow r)
        {
            DateTime? ParseDate(object o)
            {
                if (o == null || o == DBNull.Value) return null;
                var s = o.ToString();
                if (string.IsNullOrWhiteSpace(s)) return null;
                if (DateTime.TryParse(s, out var dt)) return dt;
                return null;
            }

            return new BenhAn
            {
                Id = Convert.ToInt32(r["Id"]),
                MaBenhAn = r["MaBenhAn"] != DBNull.Value ? r["MaBenhAn"].ToString() : null,
                Khoa = r["Khoa"] != DBNull.Value ? r["Khoa"].ToString() : null,
                TenBenhNhan = r["TenBenhNhan"] != DBNull.Value ? r["TenBenhNhan"].ToString() : null,
                NamSinh = r["NamSinh"] != DBNull.Value ? (int?)Convert.ToInt32(r["NamSinh"]) : null,
                NgayVaoVien = ParseDate(r["NgayVaoVien"]),
                NgayRaVien = ParseDate(r["NgayRaVien"]) 
            };
        }

        private static string GenerateMaBenhAn(string khoa)
        {
            var k = string.IsNullOrWhiteSpace(khoa) ? "unk" : khoa;
            return $"{k}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
        }

        public static void ExportToCsv(string filePath)
        {
            var lines = new List<string>();
            lines.Add("MaBenhAn,Khoa,TenBenhNhan,NamSinh,NgayVaoVien,NgayRaVien");
            var dt = SQLiteHelper.ExecuteQuery("SELECT MaBenhAn, Khoa, TenBenhNhan, NamSinh, NgayVaoVien, NgayRaVien FROM BenhAn ORDER BY NgayVaoVien");
            foreach (DataRow r in dt.Rows)
            {
                var ma = r["MaBenhAn"] != DBNull.Value ? r["MaBenhAn"].ToString() : string.Empty;
                var khoa = r["Khoa"] != DBNull.Value ? r["Khoa"].ToString() : string.Empty;
                var ten = r["TenBenhNhan"] != DBNull.Value ? r["TenBenhNhan"].ToString() : string.Empty;
                var ns = r["NamSinh"] != DBNull.Value ? r["NamSinh"].ToString() : string.Empty;
                var vao = r["NgayVaoVien"] != DBNull.Value ? r["NgayVaoVien"].ToString() : string.Empty;
                var ra = r["NgayRaVien"] != DBNull.Value ? r["NgayRaVien"].ToString() : string.Empty;
                lines.Add($"{Utils.ExportCsvHelper.Escape(ma)},{Utils.ExportCsvHelper.Escape(khoa)},{Utils.ExportCsvHelper.Escape(ten)},{Utils.ExportCsvHelper.Escape(ns)},{Utils.ExportCsvHelper.Escape(vao)},{Utils.ExportCsvHelper.Escape(ra)}");
            }

            Utils.ExportCsvHelper.WriteLines(filePath, lines);
        }
    }

}
