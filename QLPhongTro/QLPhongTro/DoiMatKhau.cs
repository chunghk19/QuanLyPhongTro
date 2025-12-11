using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLPhongTro
{
    public partial class DoiMatKhau : Form
    {
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=157359";
        private string username;
        public DoiMatKhau(string username   )
        {
            InitializeComponent();
            this.username = username;
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

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            byte[] hash = Convert.FromBase64String(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hashToCheck = pbkdf2.GetBytes(32);

            return hashToCheck.SequenceEqual(hash);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string tendangnhap = username;
                string MatKhauCu = txtMatKhauCu.Text;
                string MatKhauMoi = txtMatKhauMoi.Text;
                string XacNhanMatKhauMoi = txtNhapLai.Text;

                if ( MatKhauCu == "" || MatKhauMoi == "" || XacNhanMatKhauMoi == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    string query = "SELECT password_hash FROM `User` WHERE username=@user LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", tendangnhap);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.Read())
                        {
                            MessageBox.Show("Tài khoản không tồn tại!");
                            return;
                        }
                        string storedHash = rdr["password_hash"].ToString();
                        if (!VerifyPassword(MatKhauCu, storedHash))
                        {
                            MessageBox.Show("Mật khẩu cũ không đúng!");
                            return;
                        }
                    }
                }
                if (MatKhauMoi != XacNhanMatKhauMoi)
                {
                    MessageBox.Show("Mật khẩu mới nhập lại không trung khớp");
                }
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    var passHash = HashPassword(XacNhanMatKhauMoi);
                    string update = "UPDATE User SET  password_hash = @pass WHERE username=@username";
                    MySqlCommand cmd = new MySqlCommand(update, conn);
                    cmd.Parameters.AddWithValue("@username", tendangnhap);
                    cmd.Parameters.AddWithValue("@pass", passHash);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đổi mật khẩu thành công");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
        }
    }
}
