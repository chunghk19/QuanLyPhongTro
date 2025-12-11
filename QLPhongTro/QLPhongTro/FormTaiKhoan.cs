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
    public partial class FormTaiKhoan : Form
    {
        string conStr = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
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
                    MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter("SELECT * FROM User ", conn);
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

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                txtID.Text = row.Cells["id"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtMatKhau.Text = row.Cells["password_hash"].Value.ToString();
                cbQuyen.SelectedItem = row.Cells["role"].Value.ToString();
                chkHoatDong.Checked = Convert.ToBoolean(row.Cells["is_active"].Value);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để cập nhật thông tin");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin tài khoản?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(conStr))
                    try
                    {
                        conn.Open();
                        string update = "UPDATE User SET email=@email, password_hash = @pass, role = @role, is_active = @is_active WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(update, conn);
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@pass", HashPassword(txtMatKhau.Text));
                        cmd.Parameters.AddWithValue("@role", cbQuyen.Text);
                        cmd.Parameters.AddWithValue("@is_active",chkHoatDong.Checked ? 1:0);

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Cập nhật thông tin tài khoản thành công");
                        txtEmail.Clear();
                        txtMatKhau.Clear();
                        txtID.Clear();
                        cbQuyen.SelectedIndex = -1;
                        chkHoatDong.Checked = false;
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        string delete = "DELETE FROM User WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(delete, conn);
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa khách hàng thành công");
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM User WHERE username LIKE @username";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", "%" + txtTimKiem.Text.Trim() + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTaiKhoan.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }
    }
}
