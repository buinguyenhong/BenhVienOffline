namespace BenhVienOffline.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBenhAn;
        private System.Windows.Forms.Button btnThuNgan;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExportBenhAn;
        private System.Windows.Forms.Button btnExportThuNgan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBenhAn = new System.Windows.Forms.Button();
            this.btnThuNgan = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExportBenhAn = new System.Windows.Forms.Button();
            this.btnExportThuNgan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBenhAn
            // 
            this.btnBenhAn.Location = new System.Drawing.Point(30, 30);
            this.btnBenhAn.Name = "btnBenhAn";
            this.btnBenhAn.Size = new System.Drawing.Size(150, 40);
            this.btnBenhAn.TabIndex = 0;
            this.btnBenhAn.Text = "Bệnh án";
            this.btnBenhAn.UseVisualStyleBackColor = true;
            this.btnBenhAn.Click += new System.EventHandler(this.btnBenhAn_Click);
            // 
            // btnThuNgan
            // 
            this.btnThuNgan.Location = new System.Drawing.Point(200, 30);
            this.btnThuNgan.Name = "btnThuNgan";
            this.btnThuNgan.Size = new System.Drawing.Size(150, 40);
            this.btnThuNgan.TabIndex = 1;
            this.btnThuNgan.Text = "Thu ngân";
            this.btnThuNgan.UseVisualStyleBackColor = true;
            this.btnThuNgan.Click += new System.EventHandler(this.btnThuNgan_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(370, 30);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExportBenhAn
            // 
            this.btnExportBenhAn.Location = new System.Drawing.Point(30, 80);
            this.btnExportBenhAn.Name = "btnExportBenhAn";
            this.btnExportBenhAn.Size = new System.Drawing.Size(150, 30);
            this.btnExportBenhAn.TabIndex = 3;
            this.btnExportBenhAn.Text = "Export bệnh án";
            this.btnExportBenhAn.UseVisualStyleBackColor = true;
            this.btnExportBenhAn.Click += new System.EventHandler(this.btnExportBenhAn_Click);
            // 
            // btnExportThuNgan
            // 
            this.btnExportThuNgan.Location = new System.Drawing.Point(200, 80);
            this.btnExportThuNgan.Name = "btnExportThuNgan";
            this.btnExportThuNgan.Size = new System.Drawing.Size(150, 30);
            this.btnExportThuNgan.TabIndex = 4;
            this.btnExportThuNgan.Text = "Export thu ngân";
            this.btnExportThuNgan.UseVisualStyleBackColor = true;
            this.btnExportThuNgan.Click += new System.EventHandler(this.btnExportThuNgan_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 170);
            this.Controls.Add(this.btnBenhAn);
            this.Controls.Add(this.btnThuNgan);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExportBenhAn);
            this.Controls.Add(this.btnExportThuNgan);
            this.Name = "FrmMain";
            this.Text = "BenhVienOffline - Main";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
        }
    }
}
