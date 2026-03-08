namespace BenhVienOffline.Forms
{
    partial class FrmBenhAn
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstPatients;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label lblVao;
        private System.Windows.Forms.DateTimePicker dtpVao;
        private System.Windows.Forms.Label lblRa;
        private System.Windows.Forms.DateTimePicker dtpRa;
        private System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;

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
            this.lstPatients = new System.Windows.Forms.ListBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.lblVao = new System.Windows.Forms.Label();
            this.dtpVao = new System.Windows.Forms.DateTimePicker();
            this.lblRa = new System.Windows.Forms.Label();
            this.dtpRa = new System.Windows.Forms.DateTimePicker();
            this.btnNow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPatients
            // 
            this.lstPatients.FormattingEnabled = true;
            this.lstPatients.ItemHeight = 16;
            this.lstPatients.Location = new System.Drawing.Point(12, 12);
            this.lstPatients.Name = "lstPatients";
            this.lstPatients.Size = new System.Drawing.Size(300, 420);
            this.lstPatients.TabIndex = 0;
            this.lstPatients.SelectedIndexChanged += new System.EventHandler(this.lstPatients_SelectedIndexChanged);
            // 
            // lblKhoa
            // 
            this.lblKhoa.Location = new System.Drawing.Point(330, 12);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(80, 23);
            this.lblKhoa.Text = "Khoa:";
            // 
            // txtKhoa
            // 
            this.txtKhoa.Location = new System.Drawing.Point(420, 12);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.ReadOnly = true;
            this.txtKhoa.Size = new System.Drawing.Size(300, 22);
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(330, 44);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(400, 23);
            this.lblMa.Text = "Mã bệnh án: ";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(330, 80);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(80, 23);
            this.lblTen.Text = "Tên BN:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(420, 80);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(300, 22);
            // 
            // lblNam
            // 
            this.lblNam.Location = new System.Drawing.Point(330, 112);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(80, 23);
            this.lblNam.Text = "Năm sinh:";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(420, 112);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(120, 22);
            // 
            // lblVao
            // 
            this.lblVao.Location = new System.Drawing.Point(330, 144);
            this.lblVao.Name = "lblVao";
            this.lblVao.Size = new System.Drawing.Size(80, 23);
            this.lblVao.Text = "Ngày giờ vào:";
            // 
            // dtpVao
            // 
            this.dtpVao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVao.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpVao.ShowUpDown = true;
            this.dtpVao.Location = new System.Drawing.Point(420, 144);
            this.dtpVao.Name = "dtpVao";
            this.dtpVao.Size = new System.Drawing.Size(200, 22);
            // 
            // lblRa
            // 
            this.lblRa.Location = new System.Drawing.Point(330, 176);
            this.lblRa.Name = "lblRa";
            this.lblRa.Size = new System.Drawing.Size(80, 23);
            this.lblRa.Text = "Ngày giờ ra:";
            // 
            // dtpRa
            // 
            this.dtpRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRa.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpRa.ShowCheckBox = true;
            this.dtpRa.ShowUpDown = true;
            this.dtpRa.Location = new System.Drawing.Point(420, 176);
            this.dtpRa.Name = "dtpRa";
            this.dtpRa.Size = new System.Drawing.Size(200, 22);
            // 
            // btnNow
            // 
            this.btnNow.Location = new System.Drawing.Point(630, 144);
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(90, 26);
            this.btnNow.Text = "Lấy giờ";
            this.btnNow.UseVisualStyleBackColor = true;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(420, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(560, 220);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 36);
            this.btnNew.Text = "Mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FrmBenhAn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.lstPatients);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.txtKhoa);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.lblVao);
            this.Controls.Add(this.dtpVao);
            this.Controls.Add(this.lblRa);
            this.Controls.Add(this.dtpRa);
            this.Controls.Add(this.btnNow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Name = "FrmBenhAn";
            this.Text = "Bệnh án";
            this.Load += new System.EventHandler(this.FrmBenhAn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
