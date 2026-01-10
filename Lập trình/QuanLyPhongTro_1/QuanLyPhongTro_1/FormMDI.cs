using System.Net;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using QLPhongTro;
using QuanLyPhongTro_1.Common;
namespace QuanLyPhongTro_1
{
    public partial class FormMDI : Form
    {
        string str = DbHelper.ConnectionString;
        public FormMDI()
        {
            InitializeComponent();
            FormLogin formDangNhap = new FormLogin();
            TaikhoanLoad();
            formDangNhap.ShowDialog();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            FormDashboard dash = new FormDashboard();
            dash.MdiParent = this;
            dash.Show();
            MessageBox.Show("Xin chào " + Authorization1.Username + " (" + Authorization1.Role + ")");
            ApplyRolePermission();

        }

        private void ApplyRolePermission()
        {
            if (Authorization1.Role == "TENANT")
            {
                //thốngKêToolStripMenuItem.Visible = false;
                //đăngKýTàiKhoảnMớiToolStripMenuItem.Visible = false;
                //danhSáchTàiKhoảnToolStripMenuItem.Visible = false;
                //danhSáchKháchThuêToolStripMenuItem.Visible = false;
                //danhSáchPhòngTrọToolStripMenuItem.Visible = false;
                //thêmMớiHợpĐồngToolStripMenuItem.Visible = false;
                //danhSáchHợpĐồngToolStripMenuItem.Visible = false;
            }
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
        private void PhanQuyenMenu()
        {
            if (AppSession.Role == "ADMIN")
            {
                // ADMIN: thấy hết
                mnQuanLy.Visible = true;
                mnHoaDon.Visible = true;
                mnBaoCao.Visible = true;
            }
            else if (AppSession.Role == "TENANT")
            {
                // TENANT: chỉ xem hóa đơn, thông tin cá nhân
                mnQuanLy.Visible = false;
                mnBaoCao.Visible = false;

                mnHoaDon.Visible = true;
            }
        }
        private void HienThiThongTinNguoiDung()
        {
            if (AppSession.Username != null)
            {
                lblUserInfo.Text = $"Xin chào: {AppSession.Username} ({AppSession.Role})";
            }
            else
            {
                lblUserInfo.Text = "Chưa đăng nhập";
            }
        }

        private void thôngTinNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserProfile form = new FormUserProfile();
            form.MdiParent = this;
            form.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword form = new FormChangePassword();
            form.MdiParent = this;
            form.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Bạn có chắc muốn đăng xuất không?",
           "Đăng xuất",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                // 1. Xóa session
                AppSession.Clear();

                // 2. Mở lại form đăng nhập
                FormLogin login = new FormLogin();
                login.Show();

                // 3. Đóng form chính (MDI)
                this.Close();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Bạn có chắc muốn đăng xuất không?",
           "Đăng xuất",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // 1. Xóa session
                AppSession.Clear();

                // 2. Mở lại form đăng nhập
                FormLogin login = new FormLogin();
                login.Show();

                // 3. Đóng form chính (MDI)
                this.Close();
            }
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoom fr = new FormRoom();
            fr.MdiParent = this;
            fr.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void kháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTenant fr = new FormTenant();
            fr.MdiParent = this;
            fr.Show();
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContract fr = new FormContract();
            fr.MdiParent = this;
            fr.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormService fr = new FormService();
            fr.MdiParent = this;
            fr.Show();
        }

        private void ghiĐiệnNướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsumption fr = new FormConsumption();
            fr.MdiParent = this;
            fr.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPayment fr = new FormPayment();
            fr.MdiParent = this;
            fr.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInvoice fr = new FormInvoice();
            fr.MdiParent = this;
            fr.Show();
        }

        private void dsroomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoomReport fr = new FormRoomReport();
            fr.MdiParent = this;
            fr.Show();
        }

        private void danhSáchKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportListTenant fr = new FormReportListTenant();
            fr.MdiParent = this;
            fr.Show();
        }

        private void hợpĐồngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormReportContract fr = new FormReportContract();
            fr.MdiParent = this;
            fr.Show();
        }

        private void dịchVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormReportService fr = new FormReportService();
            fr.MdiParent = this;
            fr.Show();
        }
    }
}
