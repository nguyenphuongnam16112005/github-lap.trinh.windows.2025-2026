namespace KiemTraGiuaKy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.cbxTrangThai = new System.Windows.Forms.ComboBox();
            this.txtSCN = new System.Windows.Forms.TextBox();
            this.txtTDP = new System.Windows.Forms.TextBox();
            this.txtMDP = new System.Windows.Forms.TextBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblSoCaNhiemMoi = new System.Windows.Forms.Label();
            this.lblTenDiaPhuong = new System.Windows.Forms.Label();
            this.lblMaDiaPhuong = new System.Windows.Forms.Label();
            this.lblTieuDe2 = new System.Windows.Forms.Label();
            this.dgvTinhHinhDiaPhuong = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.xuấtBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhHinhDiaPhuong)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.cbxTrangThai);
            this.grbThongTin.Controls.Add(this.txtSCN);
            this.grbThongTin.Controls.Add(this.txtTDP);
            this.grbThongTin.Controls.Add(this.txtMDP);
            this.grbThongTin.Controls.Add(this.btnCapNhat);
            this.grbThongTin.Controls.Add(this.btnThem);
            this.grbThongTin.Controls.Add(this.lblTrangThai);
            this.grbThongTin.Controls.Add(this.lblSoCaNhiemMoi);
            this.grbThongTin.Controls.Add(this.lblTenDiaPhuong);
            this.grbThongTin.Controls.Add(this.lblMaDiaPhuong);
            this.grbThongTin.Location = new System.Drawing.Point(15, 71);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(332, 250);
            this.grbThongTin.TabIndex = 1;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin địa phương";
            // 
            // cbxTrangThai
            // 
            this.cbxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTrangThai.FormattingEnabled = true;
            this.cbxTrangThai.Location = new System.Drawing.Point(151, 175);
            this.cbxTrangThai.Name = "cbxTrangThai";
            this.cbxTrangThai.Size = new System.Drawing.Size(175, 24);
            this.cbxTrangThai.TabIndex = 4;
            // 
            // txtSCN
            // 
            this.txtSCN.Location = new System.Drawing.Point(151, 127);
            this.txtSCN.Name = "txtSCN";
            this.txtSCN.Size = new System.Drawing.Size(100, 22);
            this.txtSCN.TabIndex = 3;
            this.txtSCN.Text = "0";
            // 
            // txtTDP
            // 
            this.txtTDP.Location = new System.Drawing.Point(151, 81);
            this.txtTDP.Name = "txtTDP";
            this.txtTDP.Size = new System.Drawing.Size(175, 22);
            this.txtTDP.TabIndex = 3;
            this.txtTDP.Text = "Hà Nội";
            // 
            // txtMDP
            // 
            this.txtMDP.Location = new System.Drawing.Point(151, 39);
            this.txtMDP.Name = "txtMDP";
            this.txtMDP.Size = new System.Drawing.Size(71, 22);
            this.txtMDP.TabIndex = 3;
            this.txtMDP.Text = "HNO";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.AllowDrop = true;
            this.btnCapNhat.Location = new System.Drawing.Point(251, 214);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.AllowDrop = true;
            this.btnThem.Location = new System.Drawing.Point(147, 214);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(6, 175);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(79, 16);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Trạng Thái: ";
            // 
            // lblSoCaNhiemMoi
            // 
            this.lblSoCaNhiemMoi.AutoSize = true;
            this.lblSoCaNhiemMoi.Location = new System.Drawing.Point(6, 130);
            this.lblSoCaNhiemMoi.Name = "lblSoCaNhiemMoi";
            this.lblSoCaNhiemMoi.Size = new System.Drawing.Size(117, 16);
            this.lblSoCaNhiemMoi.TabIndex = 0;
            this.lblSoCaNhiemMoi.Text = "Số Ca Nhiễm Mới: ";
            // 
            // lblTenDiaPhuong
            // 
            this.lblTenDiaPhuong.AutoSize = true;
            this.lblTenDiaPhuong.Location = new System.Drawing.Point(6, 84);
            this.lblTenDiaPhuong.Name = "lblTenDiaPhuong";
            this.lblTenDiaPhuong.Size = new System.Drawing.Size(109, 16);
            this.lblTenDiaPhuong.TabIndex = 0;
            this.lblTenDiaPhuong.Text = "Tên Địa Phương: ";
            // 
            // lblMaDiaPhuong
            // 
            this.lblMaDiaPhuong.AutoSize = true;
            this.lblMaDiaPhuong.Location = new System.Drawing.Point(6, 39);
            this.lblMaDiaPhuong.Name = "lblMaDiaPhuong";
            this.lblMaDiaPhuong.Size = new System.Drawing.Size(104, 16);
            this.lblMaDiaPhuong.TabIndex = 0;
            this.lblMaDiaPhuong.Text = "Mã Địa Phương: ";
            // 
            // lblTieuDe2
            // 
            this.lblTieuDe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe2.ForeColor = System.Drawing.Color.Blue;
            this.lblTieuDe2.Location = new System.Drawing.Point(346, 22);
            this.lblTieuDe2.Name = "lblTieuDe2";
            this.lblTieuDe2.Size = new System.Drawing.Size(381, 46);
            this.lblTieuDe2.TabIndex = 0;
            this.lblTieuDe2.Text = "Tình hình dịch Covid 19";
            // 
            // dgvTinhHinhDiaPhuong
            // 
            this.dgvTinhHinhDiaPhuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTinhHinhDiaPhuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTinhHinhDiaPhuong.Location = new System.Drawing.Point(353, 71);
            this.dgvTinhHinhDiaPhuong.Name = "dgvTinhHinhDiaPhuong";
            this.dgvTinhHinhDiaPhuong.RowHeadersWidth = 51;
            this.dgvTinhHinhDiaPhuong.RowTemplate.Height = 24;
            this.dgvTinhHinhDiaPhuong.Size = new System.Drawing.Size(674, 377);
            this.dgvTinhHinhDiaPhuong.TabIndex = 2;
            this.dgvTinhHinhDiaPhuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTinhHinhDiaPhuong_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem,
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem,
            this.toolStripSeparator1,
            this.xuấtBáoCáoToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // sắpXếpTheoSốCaNhiễmToolStripMenuItem
            // 
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Name = "sắpXếpTheoSốCaNhiễmToolStripMenuItem";
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Text = "Sắp xếp theo số ca nhiễm";
            this.sắpXếpTheoSốCaNhiễmToolStripMenuItem.Click += new System.EventHandler(this.sắpXếpTheoSốCaNhiễmToolStripMenuItem_Click);
            // 
            // cácĐịaPhươngNhómNguyCơToolStripMenuItem
            // 
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Name = "cácĐịaPhươngNhómNguyCơToolStripMenuItem";
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Text = "Các địa phương nhóm nguy cơ";
            this.cácĐịaPhươngNhómNguyCơToolStripMenuItem.Click += new System.EventHandler(this.cácĐịaPhươngNhómNguyCơToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(316, 6);
            // 
            // xuấtBáoCáoToolStripMenuItem
            // 
            this.xuấtBáoCáoToolStripMenuItem.Name = "xuấtBáoCáoToolStripMenuItem";
            this.xuấtBáoCáoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.xuấtBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.xuấtBáoCáoToolStripMenuItem.Text = "Xuất báo cáo";
            this.xuấtBáoCáoToolStripMenuItem.Click += new System.EventHandler(this.xuấtBáoCáoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 454);
            this.Controls.Add(this.dgvTinhHinhDiaPhuong);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.lblTieuDe2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin địa phương";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhHinhDiaPhuong)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblSoCaNhiemMoi;
        private System.Windows.Forms.Label lblTenDiaPhuong;
        private System.Windows.Forms.Label lblMaDiaPhuong;
        private System.Windows.Forms.Label lblTieuDe2;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbxTrangThai;
        private System.Windows.Forms.TextBox txtSCN;
        private System.Windows.Forms.TextBox txtTDP;
        private System.Windows.Forms.TextBox txtMDP;
        private System.Windows.Forms.DataGridView dgvTinhHinhDiaPhuong;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sắpXếpTheoSốCaNhiễmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cácĐịaPhươngNhómNguyCơToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem xuấtBáoCáoToolStripMenuItem;
    }
}

