using System;
using System.Windows.Forms;
using BenhVienOffline.Models;
using BenhVienOffline.Services;
using BenhVienOffline.Session;
using BenhVienOffline.Utils;

namespace BenhVienOffline.Forms
{
    public partial class FrmTamUng : Form
    {
        private readonly string _khoa;
        private readonly string _ten;
        private readonly int? _nam;
        private readonly string _doiTuong;

        public FrmTamUng(string khoa, string ten, int? nam, string doiTuong)
        {
            _khoa = khoa;
            _ten = ten;
            _nam = nam;
            _doiTuong = doiTuong;
            InitializeComponent();
        }

        private void FrmTamUng_Load(object sender, EventArgs e)
        {
            txtKhoa.Text = _khoa;
            txtTen.Text = _ten;
            txtNam.Text = _nam.HasValue ? _nam.Value.ToString() : string.Empty;
            txtDoiTuong.Text = _doiTuong;
            dtpNgayGio.Value = DateTime.Now;

            GenerateNewMa();
        }

        private void GenerateNewMa()
        {
            lblMa.Text = "Mã hóa đơn: " + IdGenerator.GenerateMaHoaDonTamUng(txtTen.Text);
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
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    MessageBox.Show("Nhập tên bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var hd = new HoaDonTamUng
                {
                    MaHoaDon = IdGenerator.GenerateMaHoaDonTamUng(txtTen.Text),
                    Khoa = txtKhoa.Text,
                    TenBenhNhan = txtTen.Text.Trim(),
                    NamSinh = int.TryParse(txtNam.Text.Trim(), out var n) ? (int?)n : null,
                    DoiTuong = txtDoiTuong.Text,
                    NgayGio = dtpNgayGio.Value,
                    SoTien = Convert.ToDecimal(numSoTien.Value),
                    DaIn = print
                };

                var id = ThuNganService.InsertTamUng(hd);
                if (id > 0)
                {
                    MessageBox.Show("Đã lưu tạm ứng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (print)
                    {
                        // TODO: implement printing
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
                MessageBox.Show("Lỗi lưu tạm ứng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
