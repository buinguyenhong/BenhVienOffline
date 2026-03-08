namespace BenhVienOffline.Forms
{
    partial class FrmThanhToan
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
        private System.Windows.Forms.Label lblTyLe;
        private System.Windows.Forms.TextBox txtTyLe;
        private System.Windows.Forms.Label lblTienGiuong;
        private System.Windows.Forms.NumericUpDown numTienGiuong;
        private System.Windows.Forms.Label lblSoTienTamUng;
        private System.Windows.Forms.TextBox txtSoTienTamUng;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Button btnView;
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
            this.lblTyLe = new System.Windows.Forms.Label();
            this.txtTyLe = new System.Windows.Forms.TextBox();
            this.lblTienGiuong = new System.Windows.Forms.Label();
            this.numTienGiuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoTienTamUng = new System.Windows.Forms.Label();
            this.txtSoTienTamUng = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSavePrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTienGiuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(12, 9);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(760, 23);
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
            this.txtKhoa.Size = new System.Drawing.Size(300, 22);
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(420, 40);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(80, 23);
            this.lblTen.Text = "Tên BN:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(500, 40);
            this.txtTen.Name = "txtTen";
            this.txtTen.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(260, 22);
            // 
            // lblNam
            // 
            this.lblNam.Location = new System.Drawing.Point(12, 72);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(80, 23);
            this.lblNam.Text = "Năm sinh:";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(100, 72);
            this.txtNam.Name = "txtNam";
            this.txtNam.ReadOnly = true;
            this.txtNam.Size = new System.Drawing.Size(120, 22);
            // 
            // lblDoiTuong
            // 
            this.lblDoiTuong.Location = new System.Drawing.Point(240, 72);
            this.lblDoiTuong.Name = "lblDoiTuong";
            this.lblDoiTuong.Size = new System.Drawing.Size(80, 23);
            this.lblDoiTuong.Text = "Đối tượng:";
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.Location = new System.Drawing.Point(330, 72);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.ReadOnly = true;
            this.txtDoiTuong.Size = new System.Drawing.Size(120, 22);
            // 
            // lblTyLe
            // 
            this.lblTyLe.Location = new System.Drawing.Point(470, 72);
            this.lblTyLe.Name = "lblTyLe";
            this.lblTyLe.Size = new System.Drawing.Size(60, 23);
            this.lblTyLe.Text = "Tỷ lệ:";
            // 
            // txtTyLe
            // 
            this.txtTyLe.Location = new System.Drawing.Point(540, 72);
            this.txtTyLe.Name = "txtTyLe";
            this.txtTyLe.ReadOnly = true;
            this.txtTyLe.Size = new System.Drawing.Size(80, 22);
            // 
            // lblTienGiuong
            // 
            this.lblTienGiuong.Location = new System.Drawing.Point(12, 104);
            this.lblTienGiuong.Name = "lblTienGiuong";
            this.lblTienGiuong.Size = new System.Drawing.Size(100, 23);
            this.lblTienGiuong.Text = "Tiền giường:";
            // 
            // numTienGiuong
            // 
            this.numTienGiuong.Location = new System.Drawing.Point(120, 104);
            this.numTienGiuong.Name = "numTienGiuong";
            this.numTienGiuong.Size = new System.Drawing.Size(160, 22);
            this.numTienGiuong.Maximum = new decimal(new int[] {1000000000,0,0,0});
            this.numTienGiuong.DecimalPlaces = 0;
            // 
            // lblSoTienTamUng
            // 
            this.lblSoTienTamUng.Location = new System.Drawing.Point(300, 104);
            this.lblSoTienTamUng.Name = "lblSoTienTamUng";
            this.lblSoTienTamUng.Size = new System.Drawing.Size(140, 23);
            this.lblSoTienTamUng.Text = "Số tiền đã tạm ứng:";
            // 
            // txtSoTienTamUng
            // 
            this.txtSoTienTamUng.Location = new System.Drawing.Point(450, 104);
            this.txtSoTienTamUng.Name = "txtSoTienTamUng";
            this.txtSoTienTamUng.ReadOnly = true;
            this.txtSoTienTamUng.Size = new System.Drawing.Size(160, 22);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(100, 140);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(420, 22);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(12, 140);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(80, 23);
            this.lblSearch.Text = "Tìm dịch vụ:";
            // 
            // dgvServices
            // 
            this.dgvServices.Location = new System.Drawing.Point(12, 172);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.Size = new System.Drawing.Size(760, 360);
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(12, 540);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(120, 36);
            this.btnView.Text = "Xem tổng";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 540);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Location = new System.Drawing.Point(290, 540);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(120, 36);
            this.btnSavePrint.Text = "Lưu và in";
            this.btnSavePrint.UseVisualStyleBackColor = true;
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // FrmThanhToan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 590);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.txtKhoa);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.lblDoiTuong);
            this.Controls.Add(this.txtDoiTuong);
            this.Controls.Add(this.lblTyLe);
            this.Controls.Add(this.txtTyLe);
            this.Controls.Add(this.lblTienGiuong);
            this.Controls.Add(this.numTienGiuong);
            this.Controls.Add(this.lblSoTienTamUng);
            this.Controls.Add(this.txtSoTienTamUng);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSavePrint);
            this.Name = "FrmThanhToan";
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.FrmThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTienGiuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}