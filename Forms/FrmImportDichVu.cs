using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BenhVienOffline.Services;

namespace BenhVienOffline.Forms
{
    public partial class FrmImportDichVu : Form
    {
        public FrmImportDichVu()
        {
            InitializeComponent();
        }

        private void FrmImportDichVu_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            var list = DichVuService.GetAll();
            dgv.DataSource = list;
            lblStatus.Text = $"Số dịch vụ: {list?.Count ?? 0}";
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = ofd.FileName;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var path = txtFile.Text;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                MessageBox.Show("Chọn file CSV trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var cnt = DichVuService.ImportFromCsv(path);
                MessageBox.Show($"Đã import: {cnt} dòng.", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
