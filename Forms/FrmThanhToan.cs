using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BenhVienOffline.Models;
using BenhVienOffline.Services;
using BenhVienOffline.Utils;

namespace BenhVienOffline.Forms
{
    public partial class FrmThanhToan : Form
    {
        private readonly string _khoa;
        private readonly string _ten;
        private readonly int? _nam;
        private readonly string _doiTuong;
        private readonly int? _tyLe;

        private DataTable _dtServices;

        public FrmThanhToan(string khoa, string ten, int? nam, string doiTuong, int? tyLe)
        {
            _khoa = khoa;
            _ten = ten;
            _nam = nam;
            _doiTuong = doiTuong;
            _tyLe = tyLe;
            InitializeComponent();
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            txtKhoa.Text = _khoa;
            txtTen.Text = _ten;
            txtNam.Text = _nam.HasValue ? _nam.Value.ToString() : string.Empty;
            txtDoiTuong.Text = _doiTuong;
            txtTyLe.Text = _tyLe.HasValue ? _tyLe.Value.ToString() + "%" : string.Empty;

            lblMa.Text = "Mã hóa đơn: " + IdGenerator.GenerateMaHoaDonThanhToan(_ten);

            numTienGiuong.Value = 0;
            LoadSoTienTamUng();
            LoadServices();

            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void LoadSoTienTamUng()
        {
            try
            {
                var sum = ThuNganService.GetSumTamUng(_khoa, _ten, _nam);
                txtSoTienTamUng.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc tạm ứng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServices()
        {
            var list = DichVuService.GetAll();
            _dtServices = new DataTable();
            _dtServices.Columns.Add("Selected", typeof(bool));
            _dtServices.Columns.Add("MaDichVu", typeof(string));
            _dtServices.Columns.Add("TenDichVu", typeof(string));
            _dtServices.Columns.Add("SoLuong", typeof(int));
            _dtServices.Columns.Add("DonGia", typeof(decimal));
            _dtServices.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");

            foreach (var d in list)
            {
                var price = _doiTuong == "BaoHiem" ? d.GiaBaoHiem : d.GiaVienPhi;
                var row = _dtServices.NewRow();
                row["Selected"] = false;
                row["MaDichVu"] = d.MaDichVu;
                row["TenDichVu"] = d.TenDichVu;
                row["SoLuong"] = 1;
                row["DonGia"] = price;
                _dtServices.Rows.Add(row);
            }

            dgvServices.DataSource = _dtServices;
            // set column order and widths
            dgvServices.Columns["Selected"].Width = 60;
            dgvServices.Columns["MaDichVu"].Width = 120;
            dgvServices.Columns["TenDichVu"].Width = 300;
            dgvServices.Columns["SoLuong"].Width = 80;
            dgvServices.Columns["DonGia"].Width = 100;
            dgvServices.Columns["ThanhTien"].Width = 120;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var s = txtSearch.Text.Replace("'", "''");
            if (_dtServices == null) return;
            if (string.IsNullOrWhiteSpace(s))
            {
                _dtServices.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                _dtServices.DefaultView.RowFilter = $"TenDichVu LIKE '%{s}%' OR MaDichVu LIKE '%{s}%'";
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            decimal totalDichVu = 0m;
            foreach (DataRow r in _dtServices.Rows)
            {
                if (r.Field<bool>("Selected"))
                {
                    totalDichVu += Convert.ToDecimal(r["ThanhTien"]);
                }
            }

            var tienGiuong = numTienGiuong.Value;
            var tamUng = decimal.TryParse(txtSoTienTamUng.Text, out var t) ? t : 0m;

            decimal applyDichVu = totalDichVu;
            if (_doiTuong == "BaoHiem" && _tyLe.HasValue)
            {
                applyDichVu = applyDichVu * (_tyLe.Value / 100m);
            }

            var tong = tienGiuong + applyDichVu - tamUng;
            MessageBox.Show($"Tổng dịch vụ: {totalDichVu}\nÁp dụng: {applyDichVu}\nTiền giường: {tienGiuong}\nTạm ứng: {tamUng}\nTổng thanh toán: {tong}", "Tính toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(false);
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void Save(bool print)
        {
            try
            {
                var hd = new HoaDonThanhToan
                {
                    MaHoaDon = IdGenerator.GenerateMaHoaDonThanhToan(_ten),
                    Khoa = _khoa,
                    TenBenhNhan = _ten,
                    NamSinh = _nam,
                    DoiTuong = _doiTuong,
                    TyLeBaoHiem = _tyLe,
                    TienGiuong = Convert.ToDecimal(numTienGiuong.Value),
                    SoTienTamUng = decimal.TryParse(txtSoTienTamUng.Text, out var t) ? t : 0m,
                    NgayGio = DateTime.Now,
                    DaIn = print
                };

                foreach (DataRow r in _dtServices.Rows)
                {
                    if (!r.Field<bool>("Selected")) continue;
                    var dv = new DichVuChon
                    {
                        MaDichVu = r.Field<string>("MaDichVu"),
                        TenDichVu = r.Field<string>("TenDichVu"),
                        SoLuong = Convert.ToInt32(r["SoLuong"]),
                        DonGia = Convert.ToDecimal(r["DonGia"])
                    };
                    hd.DichVuChons.Add(dv);
                }

                var id = ThuNganService.InsertThanhToan(hd);
                if (id > 0)
                {
                    MessageBox.Show("Đã lưu thanh toán.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (print)
                    {
                        MessageBox.Show("(In) - chức năng in chưa hiện thực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
