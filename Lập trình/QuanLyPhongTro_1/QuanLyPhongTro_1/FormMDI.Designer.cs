namespace QuanLyPhongTro_1
{
    partial class FormMDI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnHeThong = new ToolStripMenuItem();
            thôngTinNgườiDùngToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            mnQuanLy = new ToolStripMenuItem();
            phòngToolStripMenuItem = new ToolStripMenuItem();
            kháchThuêToolStripMenuItem = new ToolStripMenuItem();
            hợpĐồngToolStripMenuItem = new ToolStripMenuItem();
            dịchVụToolStripMenuItem = new ToolStripMenuItem();
            mnHoaDon = new ToolStripMenuItem();
            ghiĐiệnNướcToolStripMenuItem = new ToolStripMenuItem();
            lậpHóaĐơnToolStripMenuItem = new ToolStripMenuItem();
            thanhToánToolStripMenuItem = new ToolStripMenuItem();
            mnBaoCao = new ToolStripMenuItem();
            danhSáchPhòngToolStripMenuItem = new ToolStripMenuItem();
            danhSáchKháchThuêToolStripMenuItem = new ToolStripMenuItem();
            hợpĐồngToolStripMenuItem1 = new ToolStripMenuItem();
            dịchVụToolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblUserInfo = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnHeThong, mnQuanLy, mnHoaDon, mnBaoCao });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(741, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnHeThong
            // 
            mnHeThong.DropDownItems.AddRange(new ToolStripItem[] { thôngTinNgườiDùngToolStripMenuItem, đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem, thoátToolStripMenuItem });
            mnHeThong.Image = Properties.Resources.icons8_cog_50;
            mnHeThong.Name = "mnHeThong";
            mnHeThong.Size = new Size(96, 28);
            mnHeThong.Text = "Hệ Thống";
            // 
            // thôngTinNgườiDùngToolStripMenuItem
            // 
            thôngTinNgườiDùngToolStripMenuItem.Name = "thôngTinNgườiDùngToolStripMenuItem";
            thôngTinNgườiDùngToolStripMenuItem.Size = new Size(191, 22);
            thôngTinNgườiDùngToolStripMenuItem.Text = "Thông tin người dùng";
            thôngTinNgườiDùngToolStripMenuItem.Click += thôngTinNgườiDùngToolStripMenuItem_Click;
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(191, 22);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            đổiMậtKhẩuToolStripMenuItem.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(191, 22);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(191, 22);
            thoátToolStripMenuItem.Text = "Thoát";
            thoátToolStripMenuItem.Click += thoátToolStripMenuItem_Click;
            // 
            // mnQuanLy
            // 
            mnQuanLy.DropDownItems.AddRange(new ToolStripItem[] { phòngToolStripMenuItem, kháchThuêToolStripMenuItem, hợpĐồngToolStripMenuItem, dịchVụToolStripMenuItem });
            mnQuanLy.Image = Properties.Resources.icons8_service_50;
            mnQuanLy.Name = "mnQuanLy";
            mnQuanLy.Size = new Size(86, 28);
            mnQuanLy.Text = "Quản Lý";
            // 
            // phòngToolStripMenuItem
            // 
            phòngToolStripMenuItem.Name = "phòngToolStripMenuItem";
            phòngToolStripMenuItem.Size = new Size(134, 22);
            phòngToolStripMenuItem.Text = "Phòng";
            phòngToolStripMenuItem.Click += phòngToolStripMenuItem_Click;
            // 
            // kháchThuêToolStripMenuItem
            // 
            kháchThuêToolStripMenuItem.Name = "kháchThuêToolStripMenuItem";
            kháchThuêToolStripMenuItem.Size = new Size(134, 22);
            kháchThuêToolStripMenuItem.Text = "Khách thuê";
            kháchThuêToolStripMenuItem.Click += kháchThuêToolStripMenuItem_Click;
            // 
            // hợpĐồngToolStripMenuItem
            // 
            hợpĐồngToolStripMenuItem.Name = "hợpĐồngToolStripMenuItem";
            hợpĐồngToolStripMenuItem.Size = new Size(134, 22);
            hợpĐồngToolStripMenuItem.Text = "Hợp đồng";
            hợpĐồngToolStripMenuItem.Click += hợpĐồngToolStripMenuItem_Click;
            // 
            // dịchVụToolStripMenuItem
            // 
            dịchVụToolStripMenuItem.Name = "dịchVụToolStripMenuItem";
            dịchVụToolStripMenuItem.Size = new Size(134, 22);
            dịchVụToolStripMenuItem.Text = "Dịch vụ";
            dịchVụToolStripMenuItem.Click += dịchVụToolStripMenuItem_Click;
            // 
            // mnHoaDon
            // 
            mnHoaDon.DropDownItems.AddRange(new ToolStripItem[] { ghiĐiệnNướcToolStripMenuItem, lậpHóaĐơnToolStripMenuItem, thanhToánToolStripMenuItem });
            mnHoaDon.Image = Properties.Resources.icons8_file_invoice_dollar_50;
            mnHoaDon.Name = "mnHoaDon";
            mnHoaDon.Size = new Size(90, 28);
            mnHoaDon.Text = "Hóa Đơn";
            // 
            // ghiĐiệnNướcToolStripMenuItem
            // 
            ghiĐiệnNướcToolStripMenuItem.Name = "ghiĐiệnNướcToolStripMenuItem";
            ghiĐiệnNướcToolStripMenuItem.Size = new Size(148, 22);
            ghiĐiệnNướcToolStripMenuItem.Text = "Ghi điện nước";
            ghiĐiệnNướcToolStripMenuItem.Click += ghiĐiệnNướcToolStripMenuItem_Click;
            // 
            // lậpHóaĐơnToolStripMenuItem
            // 
            lậpHóaĐơnToolStripMenuItem.Name = "lậpHóaĐơnToolStripMenuItem";
            lậpHóaĐơnToolStripMenuItem.Size = new Size(148, 22);
            lậpHóaĐơnToolStripMenuItem.Text = "Lập hóa đơn";
            lậpHóaĐơnToolStripMenuItem.Click += lậpHóaĐơnToolStripMenuItem_Click;
            // 
            // thanhToánToolStripMenuItem
            // 
            thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            thanhToánToolStripMenuItem.Size = new Size(148, 22);
            thanhToánToolStripMenuItem.Text = "Thanh toán";
            thanhToánToolStripMenuItem.Click += thanhToánToolStripMenuItem_Click;
            // 
            // mnBaoCao
            // 
            mnBaoCao.DropDownItems.AddRange(new ToolStripItem[] { danhSáchPhòngToolStripMenuItem, danhSáchKháchThuêToolStripMenuItem, hợpĐồngToolStripMenuItem1, dịchVụToolStripMenuItem1 });
            mnBaoCao.Image = Properties.Resources.icons8_bar_chart_50;
            mnBaoCao.Name = "mnBaoCao";
            mnBaoCao.Size = new Size(87, 28);
            mnBaoCao.Text = "Báo Cáo";
            // 
            // danhSáchPhòngToolStripMenuItem
            // 
            danhSáchPhòngToolStripMenuItem.Name = "danhSáchPhòngToolStripMenuItem";
            danhSáchPhòngToolStripMenuItem.Size = new Size(191, 22);
            danhSáchPhòngToolStripMenuItem.Text = "Danh sách phòng";
            danhSáchPhòngToolStripMenuItem.Click += danhSáchPhòngToolStripMenuItem_Click;
            // 
            // danhSáchKháchThuêToolStripMenuItem
            // 
            danhSáchKháchThuêToolStripMenuItem.Name = "danhSáchKháchThuêToolStripMenuItem";
            danhSáchKháchThuêToolStripMenuItem.Size = new Size(191, 22);
            danhSáchKháchThuêToolStripMenuItem.Text = "Danh sách khách thuê";
            danhSáchKháchThuêToolStripMenuItem.Click += danhSáchKháchThuêToolStripMenuItem_Click;
            // 
            // hợpĐồngToolStripMenuItem1
            // 
            hợpĐồngToolStripMenuItem1.Name = "hợpĐồngToolStripMenuItem1";
            hợpĐồngToolStripMenuItem1.Size = new Size(191, 22);
            hợpĐồngToolStripMenuItem1.Text = "Hợp đồng";
            hợpĐồngToolStripMenuItem1.Click += hợpĐồngToolStripMenuItem1_Click;
            // 
            // dịchVụToolStripMenuItem1
            // 
            dịchVụToolStripMenuItem1.Name = "dịchVụToolStripMenuItem1";
            dịchVụToolStripMenuItem1.Size = new Size(191, 22);
            dịchVụToolStripMenuItem1.Text = "Dịch vụ";
            dịchVụToolStripMenuItem1.Click += dịchVụToolStripMenuItem1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblUserInfo });
            statusStrip1.Location = new Point(0, 454);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 10, 0);
            statusStrip1.Size = new Size(741, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblUserInfo
            // 
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(95, 17);
            lblUserInfo.Text = "Chưa đăng nhập";
            // 
            // FormMDI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(741, 476);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "FormMDI";
            Text = "Quản Lý Phòng Trọ_Nhóm 1 Lớp UDPM1-K15";
            WindowState = FormWindowState.Maximized;
            Load += FormMDI_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnHeThong;
        private ToolStripMenuItem thôngTinNgườiDùngToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem mnQuanLy;
        private ToolStripMenuItem phòngToolStripMenuItem;
        private ToolStripMenuItem kháchThuêToolStripMenuItem;
        private ToolStripMenuItem hợpĐồngToolStripMenuItem;
        private ToolStripMenuItem dịchVụToolStripMenuItem;
        private ToolStripMenuItem mnHoaDon;
        private ToolStripMenuItem ghiĐiệnNướcToolStripMenuItem;
        private ToolStripMenuItem lậpHóaĐơnToolStripMenuItem;
        private ToolStripMenuItem thanhToánToolStripMenuItem;
        private ToolStripMenuItem mnBaoCao;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblUserInfo;
        private ToolStripMenuItem danhSáchPhòngToolStripMenuItem;
        private ToolStripMenuItem danhSáchKháchThuêToolStripMenuItem;
        private ToolStripMenuItem hợpĐồngToolStripMenuItem1;
        private ToolStripMenuItem dịchVụToolStripMenuItem1;
    }
}
