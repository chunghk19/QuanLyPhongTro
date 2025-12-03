using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLPhongTro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
      
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Xin chào " + Authorization.Username + " (" + Authorization.Role + ")");

            ApplyRolePermission();
        }
        private void ApplyRolePermission()
        {
            if (Authorization.Role == "TENANT")
            {
                thốngKêToolStripMenuItem.Visible = false;
                đăngKýTàiKhoảnMớiToolStripMenuItem.Visible = false;
                danhSáchTàiKhoảnToolStripMenuItem.Visible = false;
                danhSáchKháchThuêToolStripMenuItem.Visible = false;
                danhSáchPhòngTrọToolStripMenuItem.Visible = false;
            }
        }
        private void đăngKýKháchThuêMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void quảnLýKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDon formHoaDon = new FormHoaDon();
            formHoaDon.MdiParent = this;
            formHoaDon.Show();
        }

        private void quảnLíPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngKýTàiKhoảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.MdiParent = this;
            formRegister.Show();
        }

        private void danhSáchTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTaiKhoan formTaiKhoan = new FormTaiKhoan();
            formTaiKhoan.MdiParent = this;
            formTaiKhoan.Show();
        }

        private void danhSáchKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenantForm tenantForm = new TenantForm();
            tenantForm.MdiParent = this;
            tenantForm.Show();
        }

        private void danhSáchPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomForm roomForm = new RoomForm();
            roomForm.MdiParent = this;
            roomForm.Show();
        }
    }
}
