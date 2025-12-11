using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLPhongTro
{
    public partial class FormRegister : Form
    {
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
        public FormRegister()
        {
            InitializeComponent();
        }

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Trả về dạng: base64(hash) + ":" + base64(salt)
            return Convert.ToBase64String(hash) + ":" + Convert.ToBase64String(salt);
        }


        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text;
                string password = txtPassWord.Text;
                string passRe = txtNhapLai.Text;
                string email = txtEmail.Text;

                if (username == "" || password == "" || email == "" || passRe == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                if (passRe != password)
                {
                    MessageBox.Show("Mật khẩu nhập lại không trung khớp");
                }
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    var passHash = HashPassword(password);
                    string checkQuery = "SELECT * FROM `User` WHERE username = @user";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@user", username);

                    MySqlDataReader rdr = checkCmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Close();
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                        return;
                    }
                    rdr.Close();
                    string insertQuery =
                        "INSERT INTO `User` (username, password_hash, email, role, is_active, created_at) " +
                        "VALUES (@user, @pass, @email, 'TENANT', '1', NOW())";

                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@user", username);
                    insertCmd.Parameters.AddWithValue("@pass", passHash);
                    insertCmd.Parameters.AddWithValue("@email", email);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công!");

                }
            }

             catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
