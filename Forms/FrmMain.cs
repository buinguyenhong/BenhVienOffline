using System;
using System.Windows.Forms;
using BenhVienOffline.Session;
using BenhVienOffline.Services;
using System.IO;

namespace BenhVienOffline.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var user = CurrentSession.CurrentUser;
            if (user == null)
            {
                MessageBox.Show("Người dùng chưa đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = $"BenhVienOffline - {user.DisplayName} ({user.Username})";

            if (CurrentSession.IsThuNgan)
            {
                btnBenhAn.Enabled = false;
                btnThuNgan.Enabled = true;
            }
            else
            {
                btnBenhAn.Enabled = true;
                btnThuNgan.Enabled = false;
            }
        }

        private void btnBenhAn_Click(object sender, EventArgs e)
        {
            var f = new FrmBenhAn();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }

        private void btnExportBenhAn_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exports");
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var file = Path.Combine(dir, $"benh_an_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
                BenhAnService.ExportToCsv(file);
                MessageBox.Show($"Đã xuất bệnh án ra: {file}", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất bệnh án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportThuNgan_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exports");
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var t = DateTime.Now.ToString("yyyyMMddHHmmss");
                var fileTam = Path.Combine(dir, $"tam_ung_{t}.csv");
                var fileTT = Path.Combine(dir, $"thanh_toan_{t}.csv");
                var fileTTLines = Path.Combine(dir, $"thanh_toan_lines_{t}.csv");

                ThuNganService.ExportTamUngToCsv(fileTam);
                ThuNganService.ExportThanhToanToCsv(fileTT, fileTTLines);

                MessageBox.Show($"Đã xuất tạm ứng: {fileTam}\nĐã xuất thanh toán: {fileTT} và {fileTTLines}", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất thu ngân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThuNgan_Click(object sender, EventArgs e)
        {
            var f = new FrmThuNganChonLoai();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentSession.Clear();
            // Return to login
            var login = new FrmLogin();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.Show();
            this.Close();
        }
    }
}
