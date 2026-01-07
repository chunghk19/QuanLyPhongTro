using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPhongTro;

namespace QuanLyPhongTro_1
{
    public partial class FormUserProfile : Form
    {
        public FormUserProfile()
        {
            InitializeComponent();
        }

        private void FormUserProfile_Load(object sender, EventArgs e)
        {
            txtEmail.Text = Authorization1.email;
            txtTenDangNhap.Text = Authorization1.Username;
            txtVaiTro.Text = Authorization1.Role;
        }
    }
}
