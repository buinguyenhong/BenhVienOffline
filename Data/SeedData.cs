using System;
using System.Data.SQLite;
using BenhVienOffline.Data;

namespace BenhVienOffline.Data
{
    public static class SeedData
    {
        public static void EnsureSeedUsers()
        {
            // Sample users: khoanoi, khoangoaitonghop, khoangoaithankinh, thungan
            InsertIfNotExists("khoanoi", "Khoa Noi", "Khoa");
            InsertIfNotExists("khoangoaitonghop", "Khoa Ngoai Tong Hop", "Khoa");
            InsertIfNotExists("khoangoaithankinh", "Khoa Ngoai Than Kinh", "Khoa");
            InsertIfNotExists("thungan", "Thu Ngan", "ThuNgan");
        }

        private static void InsertIfNotExists(string username, string displayName, string role)
        {
            var exists = SQLiteHelper.ExecuteScalar("SELECT COUNT(1) FROM Users WHERE Username = @u",
                SQLiteHelper.CreateParam("@u", System.Data.DbType.String, username));

            if (exists == null || Convert.ToInt32(exists) == 0)
            {
                SQLiteHelper.ExecuteNonQuery(
                    "INSERT INTO Users (Username, DisplayName, Role) VALUES (@u, @d, @r)",
                    SQLiteHelper.CreateParam("@u", System.Data.DbType.String, username),
                    SQLiteHelper.CreateParam("@d", System.Data.DbType.String, displayName),
                    SQLiteHelper.CreateParam("@r", System.Data.DbType.String, role)
                );
            }
        }
    }
}
