using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLPhongTro
{
    public partial class TenantForm : Form
    {
        string conStr = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=157359";
        public TenantForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TenantForm_Load(object sender, EventArgs e)
        {
            loadData();
            LoadUserComboBox();
        }
        void LoadUserComboBox(int? currentUserId = null)
        {
            var list = new List<UserTenant>();
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT u.id, u.username FROM User u " +
                        "LEFT JOIN Tenant t ON u.id = t.user_id " +
                        "WHERE u.role = 'TENANT'" +
                        " AND u.is_active = true" +
                        " AND ( t.user_id IS NULL OR u.id = @currentUserId )";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@currentUserId", currentUserId.HasValue ? currentUserId.Value : -1);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        list.Add(new UserTenant(0, "-- Chưa có tài khoản --"));
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string username = reader.GetString("username");
                            list.Add(new UserTenant(id, username));
                        }
                        reader.Close();

                        CbDanhSachUser.DataSource = list;
                        CbDanhSachUser.DisplayMember = "userName";
                        CbDanhSachUser.ValueMember = "id";
                        CbDanhSachUser.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private bool validateData()
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

           
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return false;
            }

            
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
            {
                MessageBox.Show("CCCD không hợp lệ!");
                return false;
            }

            return true;
        }

        public void loadData()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))  
            try
            {
                conn.Open();
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter("SELECT id, full_name, phone, id_card, address, user_id FROM Tenant", conn);
                DataTable dt = new DataTable();
                mysqlDataAdapter.Fill(dt);
                dgvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

            private void btnTimKiem_Click(object sender, EventArgs e)
            {
                string keyword = txtTimKiem.Text.Trim();
                using (MySqlConnection conn = new MySqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT id, full_name, phone, id_card, address" +
                                        " FROM Tenant " +
                                        " WHERE full_name " +
                                        " LIKE @keyword " +
                                        " OR phone LIKE @keyword " +
                                        " OR id_card LIKE @keyword " +
                                        " OR address LIKE @keyword";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        mysqlDataAdapter.Fill(dt);
                        dgvKhachHang.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!validateData()) return;
            using (MySqlConnection conn = new MySqlConnection(conStr))
            try
            {
                conn.Open();
                string insert = "INSERT INTO Tenant (full_name, phone, id_card, address, user_id) " +
                        "VALUES (@name, @phone, @cccd, @diachi, @user_id)";
                    object selectedValue = CbDanhSachUser.SelectedValue;
                    MySqlParameter[] p =
                {
                    new MySqlParameter("@name", txtTenKH.Text),
                    new MySqlParameter("@phone", txtSDT.Text),
                    new MySqlParameter("@cccd", txtCCCD.Text),
                    new MySqlParameter("@diachi", txtDiaChi.Text),
                    new MySqlParameter("@user_id", Convert.ToInt32(CbDanhSachUser.SelectedValue))
                };
                MySqlCommand cmd = new MySqlCommand(insert, conn);
                cmd.Parameters.AddRange(p);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới khách hàng thành công");
                txtCCCD.Clear();
                txtDiaChi.Clear();
                txtID.Clear();
                txtSDT.Clear();
                txtTenKH.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            loadData();
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                txtID.Text = row.Cells["id"].Value.ToString();
                txtTenKH.Text = row.Cells["full_name"].Value.ToString();
                txtSDT.Text = row.Cells["phone"].Value.ToString();
                txtCCCD.Text = row.Cells["id_card"].Value.ToString();
                txtDiaChi.Text = row.Cells["address"].Value.ToString();
                // 🔥 LẤY USER ID (CÓ THỂ NULL)
                int? userId = row.Cells["user_id"].Value == DBNull.Value ? (int?)null : Convert.ToInt32(row.Cells["user_id"].Value);
                // 🔥 LUÔN LOAD COMBOBOX
                LoadUserComboBox(userId);

                // 🔥 SET GIÁ TRỊ HIỂN THỊ
                if (userId.HasValue)
                    CbDanhSachUser.SelectedValue = userId.Value;
                else
                    CbDanhSachUser.SelectedIndex = 0; // "-- Chưa có tài khoản --"
            }
        }
        private void btnSuaTT_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cập nhật thông tin");
                return;
            }
            if (!validateData()) return;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin khách hàng?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(conStr))
                try
                {
                    conn.Open();
                    string update = "UPDATE Tenant SET full_name=@name, phone=@phone, address=@diachi, id_card=@cccd, user_id = @user_id WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(update, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@name", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("@phone", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(CbDanhSachUser.SelectedValue));
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                        txtCCCD.Clear();
                        txtDiaChi.Clear();
                        txtID.Clear();
                        txtSDT.Clear();
                        txtTenKH.Clear();
                        CbDanhSachUser.SelectedIndex = 0;
                        loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }

            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        string delete = "DELETE FROM Tenant WHERE id=@id";
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

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
