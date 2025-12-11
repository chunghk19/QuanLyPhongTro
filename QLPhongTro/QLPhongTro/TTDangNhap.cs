using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace QLPhongTro
{
    public partial class TTDangNhap : Form
    {
        private string userName;
        private string email;
        private string role;
        public TTDangNhap()
        {
            InitializeComponent();
        }
        public TTDangNhap(string username, string email, string role)
        {
            InitializeComponent();
            this.userName = username;
            this.email = email;
            this.role = role;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TTDangNhap_Load(object sender, EventArgs e)
        {
            txtEmail.Text = email;
            txtUserName.Text = userName;
            txtQuyen.Text = role;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau(userName);
            doiMatKhau.ShowDialog();
            
        }
    }
}
