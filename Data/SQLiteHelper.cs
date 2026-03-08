using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BenhVienOffline.Data
{
    /// <summary>
    /// Nhỏ gọn wrapper cho SQLite. Dùng System.Data.SQLite (thêm NuGet nếu cần).
    /// - Tạo file DB trong folder "Data" dưới base directory
    /// - Cung cấp các hàm ExecuteQuery/ExecuteNonQuery/ExecuteScalar
    /// </summary>
    public static class SQLiteHelper
    {
        private static string DbFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "benhvien.db");

        private static string ConnectionString => $"Data Source={DbFilePath};Version=3;Pooling=True;Max Pool Size=100;";

        public static void EnsureDatabaseFile()
        {
            var dir = Path.GetDirectoryName(DbFilePath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists(DbFilePath))
            {
                try
                {
                    SQLiteConnection.CreateFile(DbFilePath);
                }
                catch
                {
                    // Fallback: create empty file
                    File.WriteAllBytes(DbFilePath, new byte[0]);
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            EnsureDatabaseFile();
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        public static long ExecuteInsertAndGetId(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var tran = conn.BeginTransaction())
            using (var cmd = new SQLiteCommand(sql, conn, tran))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT last_insert_rowid();";
                var val = cmd.ExecuteScalar();
                tran.Commit();
                return (val != null && val != DBNull.Value) ? Convert.ToInt64(val) : 0L;
            }
        }

        public static DataTable ExecuteQuery(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static SQLiteParameter CreateParam(string name, DbType type, object value)
        {
            var p = new SQLiteParameter(name, value ?? DBNull.Value);
            p.DbType = type;
            return p;
        }

        public static void ExecuteScript(string sqlScript)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = sqlScript;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
