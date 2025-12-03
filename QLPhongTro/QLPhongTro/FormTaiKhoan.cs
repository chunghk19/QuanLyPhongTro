using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLPhongTro
{
    public partial class FormTaiKhoan : Form
    {
        string conStr = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=157359";
        public FormTaiKhoan()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
                try
                {
                    conn.Open();
                    MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter("SELECT * FROM USER ", conn);
                    DataTable dt = new DataTable();
                    mysqlDataAdapter.Fill(dt);
                    dgvTaiKhoan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
