namespace BenhVienOffline.Forms
{
    partial class FrmThuNganChonLoai
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label lblDoiTuong;
        private System.Windows.Forms.ComboBox cmbDoiTuong;
        private System.Windows.Forms.Label lblTyLe;
        private System.Windows.Forms.ComboBox cmbTyLe;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.lblDoiTuong = new System.Windows.Forms.Label();
            this.cmbDoiTuong = new System.Windows.Forms.ComboBox();
            this.lblTyLe = new System.Windows.Forms.Label();
            this.cmbTyLe = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblKhoa
            // 
            this.lblKhoa.Location = new System.Drawing.Point(12, 15);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(80, 23);
            this.lblKhoa.Text = "Khoa:";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.Location = new System.Drawing.Point(100, 12);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(300, 24);
            this.cmbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(12, 50);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(80, 23);
            this.lblTen.Text = "Tên BN:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(100, 48);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(300, 22);
            // 
            // lblNam
            // 
            this.lblNam.Location = new System.Drawing.Point(12, 82);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(80, 23);
            this.lblNam.Text = "Năm sinh:";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(100, 80);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(120, 22);
            // 
            // lblDoiTuong
            // 
            this.lblDoiTuong.Location = new System.Drawing.Point(12, 114);
            this.lblDoiTuong.Name = "lblDoiTuong";
            this.lblDoiTuong.Size = new System.Drawing.Size(80, 23);
            this.lblDoiTuong.Text = "Đối tượng:";
            // 
            // cmbDoiTuong
            // 
            this.cmbDoiTuong.Location = new System.Drawing.Point(100, 112);
            this.cmbDoiTuong.Name = "cmbDoiTuong";
            this.cmbDoiTuong.Size = new System.Drawing.Size(150, 24);
            this.cmbDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblTyLe
            // 
            this.lblTyLe.Location = new System.Drawing.Point(270, 114);
            this.lblTyLe.Name = "lblTyLe";
            this.lblTyLe.Size = new System.Drawing.Size(60, 23);
            this.lblTyLe.Text = "Tỷ lệ:";
            // 
            // cmbTyLe
            // 
            this.cmbTyLe.Location = new System.Drawing.Point(330, 112);
            this.cmbTyLe.Name = "cmbTyLe";
            this.cmbTyLe.Size = new System.Drawing.Size(70, 24);
            this.cmbTyLe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblLoai
            // 
            this.lblLoai.Location = new System.Drawing.Point(12, 150);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(80, 23);
            this.lblLoai.Text = "Loại phiếu:";
            // 
            // cmbLoai
            // 
            this.cmbLoai.Location = new System.Drawing.Point(100, 148);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(150, 24);
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(100, 190);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 34);
            this.btnNext.Text = "Tiếp theo";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmThuNganChonLoai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 240);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.lblDoiTuong);
            this.Controls.Add(this.cmbDoiTuong);
            this.Controls.Add(this.lblTyLe);
            this.Controls.Add(this.cmbTyLe);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.cmbLoai);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmThuNganChonLoai";
            this.Text = "Thu ngân - Chọn loại";
            this.Load += new System.EventHandler(this.FrmThuNganChonLoai_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
