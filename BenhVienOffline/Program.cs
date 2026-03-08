using System;
using System.Windows.Forms;
using BenhVienOffline.Data;
using BenhVienOffline.Forms;

namespace BenhVienOffline
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseInitializer.Initialize();
                SeedData.EnsureSeedUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new FrmLogin());
        }
    }
}
