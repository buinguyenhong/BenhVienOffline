using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BenhVienOffline.Data;
using BenhVienOffline.Session;

namespace BenhVienOffline.Forms
{
    public partial class FrmThuNganChonLoai : Form
    {
        public FrmThuNganChonLoai()
        {
            InitializeComponent();
        }

        private void FrmThuNganChonLoai_Load(object sender, EventArgs e)
        {
            LoadKhoas();
            cmbDoiTuong.Items.Clear();
            cmbDoiTuong.Items.Add("VienPhi");
            cmbDoiTuong.Items.Add("BaoHiem");
            cmbDoiTuong.SelectedIndex = 0;

            cmbTyLe.Items.Clear();
            cmbTyLe.Items.Add("80");
            cmbTyLe.Items.Add("95");
            cmbTyLe.Items.Add("100");
            cmbTyLe.SelectedIndex = 0;
            cmbTyLe.Enabled = false;

            cmbLoai.Items.Clear();
            cmbLoai.Items.Add("TamUng");
            cmbLoai.Items.Add("ThanhToan");
            cmbLoai.SelectedIndex = 0;

            cmbDoiTuong.SelectedIndexChanged += CmbDoiTuong_SelectedIndexChanged;
        }

        private void LoadKhoas()
        {
            try
            {
                var dt = SQLiteHelper.ExecuteQuery("SELECT Username, DisplayName FROM Users WHERE Role = 'Khoa' ORDER BY DisplayName");
                cmbKhoa.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    var uname = r["Username"].ToString();
                    var disp = r["DisplayName"] != DBNull.Value ? r["DisplayName"].ToString() : uname;
                    cmbKhoa.Items.Add(new ComboItem { Text = disp + " (" + uname + ")", Value = uname });
                }

                if (cmbKhoa.Items.Count > 0) cmbKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = cmbDoiTuong.SelectedItem?.ToString();
            if (sel == "BaoHiem") cmbTyLe.Enabled = true;
            else cmbTyLe.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedItem == null)
            {
                MessageBox.Show("Chọn khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var khoa = (cmbKhoa.SelectedItem as ComboItem).Value;
            var ten = txtTen.Text.Trim();
            int? nam = null;
            if (int.TryParse(txtNam.Text.Trim(), out var n)) nam = n;
            var doiTuong = cmbDoiTuong.SelectedItem?.ToString() ?? "VienPhi";
            int? tyLe = null;
            if (doiTuong == "BaoHiem")
            {
                if (int.TryParse(cmbTyLe.SelectedItem?.ToString(), out var t)) tyLe = t;
            }

            var loai = cmbLoai.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Nhập tên bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (loai == "TamUng")
            {
                var f = new FrmTamUng(khoa, ten, nam, doiTuong);
                f.StartPosition = FormStartPosition.CenterParent;
                this.Hide();
                f.FormClosed += (s, ev) => this.Show();
                f.ShowDialog(this);
            }
            else if (loai == "ThanhToan")
            {
                var f = new FrmThanhToan(khoa, ten, nam, doiTuong, tyLe);
                f.StartPosition = FormStartPosition.CenterParent;
                this.Hide();
                f.FormClosed += (s, ev) => this.Show();
                f.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Chọn loại phiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private class ComboItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
