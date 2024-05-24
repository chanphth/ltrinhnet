namespace qlybanhang
{
    partial class frmmain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnudanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuchatlieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnunhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnukhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhanghoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimkiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnufindhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnufindhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnufindkhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnubaocao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnubchangton = new System.Windows.Forms.ToolStripMenuItem();
            this.mnubcdoanhthu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutrogiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuthoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnudanhmuc,
            this.mnuhoadon,
            this.mnutimkiem,
            this.mnubaocao,
            this.mnutrogiup,
            this.mnuthoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnudanhmuc
            // 
            this.mnudanhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuchatlieu,
            this.mnunhanvien,
            this.mnukhachhang,
            this.mnuhanghoa});
            this.mnudanhmuc.Name = "mnudanhmuc";
            this.mnudanhmuc.Size = new System.Drawing.Size(74, 20);
            this.mnudanhmuc.Text = "Danh mục";
            // 
            // mnuchatlieu
            // 
            this.mnuchatlieu.Name = "mnuchatlieu";
            this.mnuchatlieu.Size = new System.Drawing.Size(180, 22);
            this.mnuchatlieu.Text = "Chất liệu";
            this.mnuchatlieu.Click += new System.EventHandler(this.mnuchatlieu_Click);
            // 
            // mnunhanvien
            // 
            this.mnunhanvien.Name = "mnunhanvien";
            this.mnunhanvien.Size = new System.Drawing.Size(180, 22);
            this.mnunhanvien.Text = "Nhân viên";
            this.mnunhanvien.Click += new System.EventHandler(this.mnunhanvien_Click);
            // 
            // mnukhachhang
            // 
            this.mnukhachhang.Name = "mnukhachhang";
            this.mnukhachhang.Size = new System.Drawing.Size(180, 22);
            this.mnukhachhang.Text = "Khách hàng";
            this.mnukhachhang.Click += new System.EventHandler(this.mnukhachhang_Click);
            // 
            // mnuhanghoa
            // 
            this.mnuhanghoa.Name = "mnuhanghoa";
            this.mnuhanghoa.Size = new System.Drawing.Size(180, 22);
            this.mnuhanghoa.Text = "Hàng hóa";
            this.mnuhanghoa.Click += new System.EventHandler(this.mnuhanghoa_Click);
            // 
            // mnuhoadon
            // 
            this.mnuhoadon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuhoadonban});
            this.mnuhoadon.Name = "mnuhoadon";
            this.mnuhoadon.Size = new System.Drawing.Size(65, 20);
            this.mnuhoadon.Text = "Hóa đơn";
            // 
            // mnuhoadonban
            // 
            this.mnuhoadonban.Name = "mnuhoadonban";
            this.mnuhoadonban.Size = new System.Drawing.Size(143, 22);
            this.mnuhoadonban.Text = "Hóa đơn bán";
            // 
            // mnutimkiem
            // 
            this.mnutimkiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnufindhoadon,
            this.mnufindhang,
            this.mnufindkhachhang});
            this.mnutimkiem.Name = "mnutimkiem";
            this.mnutimkiem.Size = new System.Drawing.Size(68, 20);
            this.mnutimkiem.Text = "Tìm kiếm";
            // 
            // mnufindhoadon
            // 
            this.mnufindhoadon.Name = "mnufindhoadon";
            this.mnufindhoadon.Size = new System.Drawing.Size(137, 22);
            this.mnufindhoadon.Text = "Hóa đơn";
            // 
            // mnufindhang
            // 
            this.mnufindhang.Name = "mnufindhang";
            this.mnufindhang.Size = new System.Drawing.Size(137, 22);
            this.mnufindhang.Text = "Hàng";
            // 
            // mnufindkhachhang
            // 
            this.mnufindkhachhang.Name = "mnufindkhachhang";
            this.mnufindkhachhang.Size = new System.Drawing.Size(137, 22);
            this.mnufindkhachhang.Text = "Khách hàng";
            // 
            // mnubaocao
            // 
            this.mnubaocao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnubchangton,
            this.mnubcdoanhthu});
            this.mnubaocao.Name = "mnubaocao";
            this.mnubaocao.Size = new System.Drawing.Size(61, 20);
            this.mnubaocao.Text = "Báo cáo";
            // 
            // mnubchangton
            // 
            this.mnubchangton.Name = "mnubchangton";
            this.mnubchangton.Size = new System.Drawing.Size(130, 22);
            this.mnubchangton.Text = "Hàng tồn";
            // 
            // mnubcdoanhthu
            // 
            this.mnubcdoanhthu.Name = "mnubcdoanhthu";
            this.mnubcdoanhthu.Size = new System.Drawing.Size(130, 22);
            this.mnubcdoanhthu.Text = "Doanh thu";
            // 
            // mnutrogiup
            // 
            this.mnutrogiup.Name = "mnutrogiup";
            this.mnutrogiup.Size = new System.Drawing.Size(62, 20);
            this.mnutrogiup.Text = "Trợ giúp";
            // 
            // mnuthoat
            // 
            this.mnuthoat.Name = "mnuthoat";
            this.mnuthoat.Size = new System.Drawing.Size(49, 20);
            this.mnuthoat.Text = "Thoát";
            this.mnuthoat.Click += new System.EventHandler(this.mnuthoat_Click);
            // 
            // frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmmain";
            this.Text = "Chương trình quản lý bán hàng";
            this.Load += new System.EventHandler(this.frmmain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnudanhmuc;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadon;
        private System.Windows.Forms.ToolStripMenuItem mnutimkiem;
        private System.Windows.Forms.ToolStripMenuItem mnubaocao;
        private System.Windows.Forms.ToolStripMenuItem mnutrogiup;
        private System.Windows.Forms.ToolStripMenuItem mnuthoat;
        private System.Windows.Forms.ToolStripMenuItem mnuchatlieu;
        private System.Windows.Forms.ToolStripMenuItem mnunhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnukhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnuhanghoa;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadonban;
        private System.Windows.Forms.ToolStripMenuItem mnufindhoadon;
        private System.Windows.Forms.ToolStripMenuItem mnufindhang;
        private System.Windows.Forms.ToolStripMenuItem mnufindkhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnubchangton;
        private System.Windows.Forms.ToolStripMenuItem mnubcdoanhthu;
    }
}

