using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BenhVienOffline.Data;
using BenhVienOffline.Models;
using BenhVienOffline.Session;
using BenhVienOffline.Forms;

namespace BenhVienOffline.Forms
{
    public partial class FrmLogin : Form
    {
        private ComboBox cmbUsers;
        private Button btnLogin;
        private Button btnExit;
        private Label lblUser;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng nhập - BenhVienOffline";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Width = 360;
            this.Height = 160;

            lblUser = new Label() { Left = 12, Top = 20, Width = 80, Text = "Người dùng:" };
            cmbUsers = new ComboBox() { Left = 100, Top = 16, Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };

            btnLogin = new Button() { Left = 100, Top = 56, Width = 100, Text = "Đăng nhập" };
            btnExit = new Button() { Left = 220, Top = 56, Width = 100, Text = "Thoát" };

            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += (s, e) => Application.Exit();

            this.Controls.Add(lblUser);
            this.Controls.Add(cmbUsers);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnExit);

            this.Load += FrmLogin_Load;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var dt = SQLiteHelper.ExecuteQuery("SELECT Id, Username, DisplayName, Role FROM Users ORDER BY DisplayName");
                cmbUsers.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    var display = r["DisplayName"] != DBNull.Value ? r["DisplayName"].ToString() : r["Username"].ToString();
                    var username = r["Username"].ToString();
                    cmbUsers.Items.Add(new ComboboxItem { Text = display + " (" + username + ")", Value = username });
                }

                if (cmbUsers.Items.Count > 0)
                    cmbUsers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc danh sách người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = cmbUsers.SelectedItem as ComboboxItem;
            var username = item.Value;

            try
            {
                var dt = SQLiteHelper.ExecuteQuery("SELECT Id, Username, DisplayName, Role FROM Users WHERE Username = @u",
                    SQLiteHelper.CreateParam("@u", System.Data.DbType.String, username));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Người dùng không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var row = dt.Rows[0];
                var user = new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Username = row["Username"].ToString(),
                    DisplayName = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : row["Username"].ToString(),
                    Role = row["Role"] != DBNull.Value ? row["Role"].ToString() : "Khoa"
                };

                CurrentSession.SetUser(user);

                // Open main form (Form1) and close login when main closes
                var main = new FrmMain();
                main.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
                main.FormClosed += (s, ev) => this.Close();
                main.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
