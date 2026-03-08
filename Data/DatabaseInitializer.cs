using System;
using BenhVienOffline.Data;

namespace BenhVienOffline.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            SQLiteHelper.EnsureDatabaseFile();

            var script = @"
PRAGMA journal_mode = WAL;
PRAGMA synchronous = NORMAL;

CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    DisplayName TEXT,
    Role TEXT
);

CREATE TABLE IF NOT EXISTS BenhAn (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaBenhAn TEXT NOT NULL UNIQUE,
    Khoa TEXT,
    TenBenhNhan TEXT,
    NamSinh INTEGER,
    NgayVaoVien TEXT,
    NgayRaVien TEXT
);

CREATE TABLE IF NOT EXISTS DichVu (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaDichVu TEXT NOT NULL UNIQUE,
    TenDichVu TEXT,
    GiaVienPhi REAL,
    GiaBaoHiem REAL
);

CREATE TABLE IF NOT EXISTS HoaDonTamUng (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaHoaDon TEXT NOT NULL UNIQUE,
    Khoa TEXT,
    TenBenhNhan TEXT,
    NamSinh INTEGER,
    DoiTuong TEXT,
    NgayGio TEXT,
    SoTien REAL,
    DaIn INTEGER DEFAULT 0
);

CREATE TABLE IF NOT EXISTS HoaDonThanhToan (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaHoaDon TEXT NOT NULL UNIQUE,
    Khoa TEXT,
    TenBenhNhan TEXT,
    NamSinh INTEGER,
    DoiTuong TEXT,
    TyLeBaoHiem INTEGER,
    TienGiuong REAL,
    SoTienTamUng REAL,
    NgayGio TEXT,
    DaIn INTEGER DEFAULT 0
);

CREATE TABLE IF NOT EXISTS DichVuChon (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    HoaDonThanhToanId INTEGER,
    MaDichVu TEXT,
    TenDichVu TEXT,
    SoLuong INTEGER,
    DonGia REAL
);
";

            SQLiteHelper.ExecuteScript(script);
        }
    }
}
