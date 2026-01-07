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

namespace QuanLyPhongTro_1
{
    public partial class FormContract : Form
    {
        string conStr = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
        public FormContract()
        {
            InitializeComponent();
            intoCbRoom();
            contractLoad();
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
        private bool validateData()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
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
        private void intoCbRoom()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, room_name FROM Room WHERE status = 'Trống'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int roomId = reader.GetInt32("id");
                        string roomName = reader.GetString("room_name");
                        cbRoom.Items.Add(new ListRoom(roomName, roomId));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void contractLoad()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("SELECT \r\n    c.id AS contract_id,\r\n    r.room_name AS room_name,\r\n    c.start_date,\r\n    c.end_date,\r\n    c.price AS contract_price,\r\n    c.deposit,\r\n    t.full_name  AS tenant_name,\r\n    t.id_card AS tenant_id_card,\r\n    ct.is_primary AS is_primary_tenant\r\nFROM Contract c\r\nJOIN Room r \r\n    ON c.room_id = r.id\r\nJOIN Contract_Tenant ct \r\n    ON c.id = ct.contract_id\r\nJOIN Tenant t \r\n    ON ct.tenant_id = t.id\r\nWHERE \r\n    c.is_active = true\r\n    AND r.is_active = true\r\n    AND t.is_active = true\r\nORDER BY \r\n    c.id, ct.is_primary DESC;\r\n", conn);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgvlistViewContract.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!validateData()) return;

            if (cbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            if (!decimal.TryParse(txtDeposit.Text, out decimal deposit) ||
                !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá hoặc tiền cọc không hợp lệ!");
                return;
            }

            if (TimeEnd.Value <= TimeStart.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Check username
                    string checkQuery = "SELECT 1 FROM `User` WHERE username = @user";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, trans);
                    checkCmd.Parameters.AddWithValue("@user", txtUserName.Text);

                    if (checkCmd.ExecuteScalar() != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                        trans.Rollback();
                        return;
                    }

                    // 2. Insert User
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
                    string insertUser =
                        "INSERT INTO `User` (username, password_hash, role, is_active, created_at, email) " +
                        "VALUES (@user, @pass, 'TENANT', 1, NOW(), @email)";

                    MySqlCommand cmdUser = new MySqlCommand(insertUser, conn, trans);
                    cmdUser.Parameters.AddWithValue("@user", txtUserName.Text);
                    cmdUser.Parameters.AddWithValue("@pass", HashPassword(txtPassWord.Text));
                    cmdUser.ExecuteNonQuery();
                    long userId = cmdUser.LastInsertedId;

                    // 3. Insert Tenant
                    string insertTenant =
                        "INSERT INTO Tenant (full_name, phone, id_card, address, user_id, is_active) " +
                        "VALUES (@name, @phone, @cccd, @address, @user_id, 1)";

                    MySqlCommand cmdTenant = new MySqlCommand(insertTenant, conn, trans);
                    cmdTenant.Parameters.AddWithValue("@name", txtFullName.Text);
                    cmdTenant.Parameters.AddWithValue("@phone", txtSDT.Text);
                    cmdTenant.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmdTenant.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmdTenant.Parameters.AddWithValue("@user_id", userId);
                    cmdTenant.ExecuteNonQuery();
                    long tenantId = cmdTenant.LastInsertedId;

                    // 4. Insert Contract
                    string insertContract =
                        "INSERT INTO Contract (room_id, start_date, end_date, deposit, price, is_active) " +
                        "VALUES (@room_id, @start, @end, @deposit, @price, 1)";

                    MySqlCommand cmdContract = new MySqlCommand(insertContract, conn, trans);
                    cmdContract.Parameters.AddWithValue("@room_id", ((ListRoom)cbRoom.SelectedItem).Value);
                    cmdContract.Parameters.AddWithValue("@start", TimeStart.Value);
                    cmdContract.Parameters.AddWithValue("@end", TimeEnd.Value);
                    cmdContract.Parameters.AddWithValue("@deposit", deposit);
                    cmdContract.Parameters.AddWithValue("@price", price);
                    cmdContract.ExecuteNonQuery();
                    long contractId = cmdContract.LastInsertedId;

                    // 5. Link Contract - Tenant
                    string insertCT =
                        "INSERT INTO Contract_Tenant (contract_id, tenant_id, is_primary) VALUES (@c, @t, 1)";
                    MySqlCommand cmdCT = new MySqlCommand(insertCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@c", contractId);
                    cmdCT.Parameters.AddWithValue("@t", tenantId);
                    cmdCT.ExecuteNonQuery();

                    // 6. Update Room status
                    string updateRoom =
                        "UPDATE Room SET status = 'Đang thuê' WHERE id = @room";
                    MySqlCommand cmdRoom = new MySqlCommand(updateRoom, conn, trans);
                    cmdRoom.Parameters.AddWithValue("@room", ((ListRoom)cbRoom.SelectedItem).Value);
                    cmdRoom.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Thêm hợp đồng thành công!");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

    }
}
