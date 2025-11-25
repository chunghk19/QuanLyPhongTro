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

        }

        private void đăngKýKháchThuêMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.MdiParent = this;
            formRegister.Show();
        }

        private void quảnLýKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
