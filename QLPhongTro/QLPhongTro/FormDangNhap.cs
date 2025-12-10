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
using Org.BouncyCastle.Asn1.X500;

namespace QLPhongTro
{
    public partial class FormDangNhap : Form
    {
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
        public FormDangNhap()
        {
            InitializeComponent();

        }


        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            byte[] hash = Convert.FromBase64String(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hashToCheck = pbkdf2.GetBytes(32);

            return hashToCheck.SequenceEqual(hash);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    string query = "SELECT * FROM `User` WHERE username=@user LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtTenDangNhap.Text);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.Read())
                        {
                            MessageBox.Show("Tài khoản không tồn tại!");
                            return;
                        }
                        Authorization.Id = rdr.GetInt32("id");
                        Authorization.Role = rdr.GetString("role");
                        Authorization.Username = rdr.GetString("username");
                        Authorization.IsActive = rdr.GetBoolean("is_active");
                        string storedHash = rdr["password_hash"].ToString();
                        if (!VerifyPassword(txtMatKhau.Text, storedHash))
                        {
                            MessageBox.Show("Sai mật khẩu!");
                            return;
                        }
                        MessageBox.Show("Đăng nhập thành công!");
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }


        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
