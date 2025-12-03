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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace QLPhongTro
{
    public partial class Form1 : Form
    {
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=157359";
        public Form1()
        {
            InitializeComponent();

            FormDangNhap formDangNhap = new FormDangNhap();
            TaikhoanLoad();
            formDangNhap.ShowDialog();

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
        private void TaikhoanLoad()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    string query = "SELECT * FROM `User` WHERE username = @username LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", "admin");

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.Read())
                        {
                            rdr.Close(); // MUST CLOSE READER before INSERT

                            string insertQuery =
                            "INSERT INTO `User` (username, password_hash, email, role, is_active, created_at) " +
                            "VALUES (@username, @pass, @mail, 'ADMIN', '1', NOW())";

                            MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@username", "admin");
                            insertCmd.Parameters.AddWithValue("@pass", HashPassword("admin"));
                            insertCmd.Parameters.AddWithValue("@mail", "khongcoemail@gmail.com");

                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("ADMIN created!");
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
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
