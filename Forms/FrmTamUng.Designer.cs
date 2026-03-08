namespace BenhVienOffline.Forms
{
    partial class FrmTamUng
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label lblDoiTuong;
        private System.Windows.Forms.TextBox txtDoiTuong;
        private System.Windows.Forms.Label lblNgayGio;
        private System.Windows.Forms.DateTimePicker dtpNgayGio;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.NumericUpDown numSoTien;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSavePrint;

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
            this.lblMa = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.lblDoiTuong = new System.Windows.Forms.Label();
            this.txtDoiTuong = new System.Windows.Forms.TextBox();
            this.lblNgayGio = new System.Windows.Forms.Label();
            this.dtpNgayGio = new System.Windows.Forms.DateTimePicker();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.numSoTien = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSavePrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(12, 9);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(420, 23);
            this.lblMa.Text = "Mã hóa đơn: ";
            // 
            // lblKhoa
            // 
            this.lblKhoa.Location = new System.Drawing.Point(12, 40);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(80, 23);
            this.lblKhoa.Text = "Khoa:";
            // 
            // txtKhoa
            // 
            this.txtKhoa.Location = new System.Drawing.Point(100, 40);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.ReadOnly = true;
            this.txtKhoa.Size = new System.Drawing.Size(320, 22);
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(12, 72);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(80, 23);
            this.lblTen.Text = "Tên BN:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(100, 72);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(320, 22);
            // 
            // lblNam
            // 
            this.lblNam.Location = new System.Drawing.Point(12, 104);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(80, 23);
            this.lblNam.Text = "Năm sinh:";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(100, 104);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(120, 22);
            // 
            // lblDoiTuong
            // 
            this.lblDoiTuong.Location = new System.Drawing.Point(12, 136);
            this.lblDoiTuong.Name = "lblDoiTuong";
            this.lblDoiTuong.Size = new System.Drawing.Size(80, 23);
            this.lblDoiTuong.Text = "Đối tượng:";
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.Location = new System.Drawing.Point(100, 136);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.ReadOnly = true;
            this.txtDoiTuong.Size = new System.Drawing.Size(120, 22);
            // 
            // lblNgayGio
            // 
            this.lblNgayGio.Location = new System.Drawing.Point(12, 168);
            this.lblNgayGio.Name = "lblNgayGio";
            this.lblNgayGio.Size = new System.Drawing.Size(80, 23);
            this.lblNgayGio.Text = "Ngày giờ:";
            // 
            // dtpNgayGio
            // 
            this.dtpNgayGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayGio.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpNgayGio.ShowUpDown = true;
            this.dtpNgayGio.Location = new System.Drawing.Point(100, 168);
            this.dtpNgayGio.Name = "dtpNgayGio";
            this.dtpNgayGio.Size = new System.Drawing.Size(200, 22);
            // 
            // lblSoTien
            // 
            this.lblSoTien.Location = new System.Drawing.Point(12, 200);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(80, 23);
            this.lblSoTien.Text = "Số tiền:";
            // 
            // numSoTien
            // 
            this.numSoTien.Location = new System.Drawing.Point(100, 200);
            this.numSoTien.Name = "numSoTien";
            this.numSoTien.Size = new System.Drawing.Size(160, 22);
            this.numSoTien.Maximum = new decimal(new int[] {1000000000,0,0,0});
            this.numSoTien.DecimalPlaces = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Location = new System.Drawing.Point(240, 240);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(120, 36);
            this.btnSavePrint.Text = "Lưu và in";
            this.btnSavePrint.UseVisualStyleBackColor = true;
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // FrmTamUng
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 300);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.txtKhoa);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.lblDoiTuong);
            this.Controls.Add(this.txtDoiTuong);
            this.Controls.Add(this.lblNgayGio);
            this.Controls.Add(this.dtpNgayGio);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.numSoTien);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSavePrint);
            this.Name = "FrmTamUng";
            this.Text = "Tạm ứng";
            this.Load += new System.EventHandler(this.FrmTamUng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
