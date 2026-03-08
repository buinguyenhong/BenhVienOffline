using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using BenhVienOffline.Data;
using BenhVienOffline.Models;
using BenhVienOffline.Utils;

namespace BenhVienOffline.Services
{
    public static class DichVuService
    {
        // Import CSV with header: MaDichVu,TenDichVu,GiaVienPhi,GiaBaoHiem
        public static int ImportFromCsv(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) return 0;
            int imported = 0;
            bool first = true;
            foreach (var row in CsvHelper.ReadAll(filePath))
            {
                if (first)
                {
                    first = false; // skip header
                    continue;
                }

                if (row.Length < 4) continue;
                var ma = row[0]?.Trim();
                var ten = row[1]?.Trim();
                if (string.IsNullOrWhiteSpace(ma)) continue;

                if (!decimal.TryParse(row[2]?.Trim(), out var giaVP)) giaVP = 0m;
                if (!decimal.TryParse(row[3]?.Trim(), out var giaBH)) giaBH = 0m;

                // insert or update
                var exists = SQLiteHelper.ExecuteScalar("SELECT COUNT(1) FROM DichVu WHERE MaDichVu = @ma",
                    SQLiteHelper.CreateParam("@ma", DbType.String, ma));

                if (exists != null && Convert.ToInt32(exists) > 0)
                {
                    SQLiteHelper.ExecuteNonQuery(
                        "UPDATE DichVu SET TenDichVu = @ten, GiaVienPhi = @vp, GiaBaoHiem = @bh WHERE MaDichVu = @ma",
                        SQLiteHelper.CreateParam("@ten", DbType.String, ten),
                        SQLiteHelper.CreateParam("@vp", DbType.Decimal, giaVP),
                        SQLiteHelper.CreateParam("@bh", DbType.Decimal, giaBH),
                        SQLiteHelper.CreateParam("@ma", DbType.String, ma)
                    );
                }
                else
                {
                    SQLiteHelper.ExecuteNonQuery(
                        "INSERT INTO DichVu (MaDichVu, TenDichVu, GiaVienPhi, GiaBaoHiem) VALUES (@ma, @ten, @vp, @bh)",
                        SQLiteHelper.CreateParam("@ma", DbType.String, ma),
                        SQLiteHelper.CreateParam("@ten", DbType.String, ten),
                        SQLiteHelper.CreateParam("@vp", DbType.Decimal, giaVP),
                        SQLiteHelper.CreateParam("@bh", DbType.Decimal, giaBH)
                    );
                }

                imported++;
            }

            return imported;
        }

        public static List<DichVu> GetAll()
        {
            var list = new List<DichVu>();
            var dt = SQLiteHelper.ExecuteQuery("SELECT Id, MaDichVu, TenDichVu, GiaVienPhi, GiaBaoHiem FROM DichVu ORDER BY TenDichVu");
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new DichVu
                {
                    Id = Convert.ToInt32(r["Id"]),
                    MaDichVu = r["MaDichVu"]?.ToString(),
                    TenDichVu = r["TenDichVu"]?.ToString(),
                    GiaVienPhi = r["GiaVienPhi"] != DBNull.Value ? Convert.ToDecimal(r["GiaVienPhi"]) : 0m,
                    GiaBaoHiem = r["GiaBaoHiem"] != DBNull.Value ? Convert.ToDecimal(r["GiaBaoHiem"]) : 0m
                });
            }
            return list;
        }
    }
}
