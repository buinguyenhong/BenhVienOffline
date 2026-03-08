using System;
using System.Linq;
using System.Windows.Forms;
using BenhVienOffline.Models;
using BenhVienOffline.Session;
using BenhVienOffline.Services;

namespace BenhVienOffline.Forms
{
    public partial class FrmBenhAn : Form
    {
        private BenhAn current;

        public FrmBenhAn()
        {
            InitializeComponent();
        }

        private void FrmBenhAn_Load(object sender, EventArgs e)
        {
            txtKhoa.Text = CurrentSession.CurrentKhoa ?? string.Empty;
            ClearForm();
            LoadList();
        }

        private void LoadList()
        {
            lstPatients.Items.Clear();
            try
            {
                var khoa = CurrentSession.CurrentKhoa;
                var list = BenhAnService.GetActiveByKhoa(khoa);
                foreach (var b in list)
                {
                    var display = $"{b.MaBenhAn} - {b.TenBenhNhan} ({(b.NamSinh.HasValue ? b.NamSinh.ToString() : "n/a")})";
                    var item = new ListViewItemPlaceholder { Text = display, Tag = b };
                    lstPatients.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bệnh án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPatients.SelectedItem == null) return;
            var item = lstPatients.SelectedItem as ListViewItemPlaceholder;
            if (item == null) return;
            var b = item.Tag as BenhAn;
            if (b == null) return;
            LoadBenhAnToForm(b);
        }

        private void LoadBenhAnToForm(BenhAn b)
        {
            current = b;
            txtKhoa.Text = b.Khoa;
            lblMa.Text = "Mã bệnh án: " + b.MaBenhAn;
            txtTen.Text = b.TenBenhNhan;
            txtNam.Text = b.NamSinh.HasValue ? b.NamSinh.Value.ToString() : string.Empty;
            if (b.NgayVaoVien.HasValue)
                dtpVao.Value = b.NgayVaoVien.Value;
            if (b.NgayRaVien.HasValue)
            {
                dtpRa.Value = b.NgayRaVien.Value;
                dtpRa.Checked = true;
            }
            else
            {
                dtpRa.Checked = false;
            }
        }

        private void ClearForm()
        {
            current = null;
            lblMa.Text = "Mã bệnh án: ";
            txtTen.Text = string.Empty;
            txtNam.Text = string.Empty;
            dtpVao.Value = DateTime.Now;
            dtpRa.Checked = false;
            lstPatients.ClearSelected();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            dtpVao.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var ten = txtTen.Text.Trim();
                int? nam = null;
                if (int.TryParse(txtNam.Text.Trim(), out var n)) nam = n;
                DateTime vao = dtpVao.Value;
                DateTime? ra = dtpRa.Checked ? (DateTime?)dtpRa.Value : null;

                if (string.IsNullOrWhiteSpace(ten))
                {
                    MessageBox.Show("Vui lòng nhập tên bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (current == null)
                {
                    var ba = new BenhAn
                    {
                        MaBenhAn = GenerateMaBenhAn(CurrentSession.CurrentKhoa),
                        Khoa = CurrentSession.CurrentKhoa,
                        TenBenhNhan = ten,
                        NamSinh = nam,
                        NgayVaoVien = vao,
                        NgayRaVien = ra
                    };
                    BenhAnService.Insert(ba);
                    MessageBox.Show("Đã lưu bệnh án.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    current.TenBenhNhan = ten;
                    current.NamSinh = nam;
                    current.NgayVaoVien = vao;
                    current.NgayRaVien = ra;
                    BenhAnService.Update(current);
                    MessageBox.Show("Đã cập nhật bệnh án.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadList();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu bệnh án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateMaBenhAn(string khoa)
        {
            var k = string.IsNullOrWhiteSpace(khoa) ? "unk" : khoa;
            return $"{k}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
        }

        // Simple helper class to hold items in ListBox with Tag support
        private class ListViewItemPlaceholder
        {
            public string Text { get; set; }
            public object Tag { get; set; }
            public override string ToString() => Text;
        }
    }
}
