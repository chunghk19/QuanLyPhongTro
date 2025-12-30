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
using QuanLyPhongTro_1.Common;

namespace QuanLyPhongTro_1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT id, username, password_hash, role
                    FROM User
                    WHERE username = @u AND is_active = true
        ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", username);

                MySqlDataReader rd = cmd.ExecuteReader();

                if (!rd.Read())
                {
                    MessageBox.Show("Tài khoản không tồn tại hoặc bị khóa!");
                    return;
                }

                string hash = rd["password_hash"].ToString();

                // ⚠️ TẠM THỜI so sánh plain-text (đồ án)
                if (hash != password)
                {
                    MessageBox.Show("Sai mật khẩu!");
                    return;
                }

                // Lưu session
                AppSession.UserId = Convert.ToInt32(rd["id"]);
                AppSession.Username = rd["username"].ToString();
                AppSession.Role = rd["role"].ToString();
            }

            // Mở Form Main
            FormMDI mdi = new FormMDI();
            mdi.Show();
            this.Hide();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
               "Bạn có chắc muốn đăng xuất?",
               "Xác nhận",
               MessageBoxButtons.YesNo
   );

            if (confirm == DialogResult.Yes)
            {
                AppSession.Clear();

                FormLogin login = new FormLogin();
                login.Show();

                this.Close(); // đóng MDI
            }
        }
    }
}
