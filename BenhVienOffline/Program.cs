using System;
using System.Windows.Forms;

// Program entry. Uses lightweight stubs for DatabaseInitializer/SeedData/FrmLogin when
// the real implementations are not yet included in the project.
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
                BenhVienOffline.Data.DatabaseInitializer.Initialize();
                BenhVienOffline.Data.SeedData.EnsureSeedUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new BenhVienOffline.Forms.FrmLogin());
        }
    }
}

// Lightweight stubs in case Data/Forms real implementations are not compiled yet.
namespace BenhVienOffline.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            // no-op; real initializer will replace this when included
        }
    }

    public static class SeedData
    {
        public static void EnsureSeedUsers()
        {
            // no-op; real seeding will replace this when included
        }
    }
}

namespace BenhVienOffline.Forms
{
    using System.Windows.Forms;

    public class FrmLogin : Form
    {
        public FrmLogin()
        {
            this.Text = "Đăng nhập - (placeholder)";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 360;
            this.Height = 160;

            var lbl = new Label()
            {
                Left = 12,
                Top = 20,
                Width = 320,
                Text = "(Placeholder login) - include real FrmLogin.cs to enable full login."
            };

            var btn = new Button() { Left = 120, Top = 80, Width = 100, Text = "OK" };
            btn.Click += (s, e) => this.Close();

            this.Controls.Add(lbl);
            this.Controls.Add(btn);
        }
    }
}
