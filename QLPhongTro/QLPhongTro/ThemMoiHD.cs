using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro
{
    public partial class ThemMoiHD : Form
    {
        string str = "Server=localhost;Database=Room_Management;Uid=root;Pwd=157359";
        private int selectedTenantId = -1;
        public ThemMoiHD()
        {
            InitializeComponent();
            LoadAvailableRooms();
        
        }

        private void LoadRooms()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    string query = "SELECT id, room_name, price FROM Room WHERE status <> 'Đang thuê'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbRoom.DataSource = dt;
                    cbRoom.DisplayMember = "room_name";
                    cbRoom.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách phòng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAvailableRooms()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    string query = @"
                        SELECT r.id, r.room_name, r.price
                        FROM Room r
                        WHERE r.is_active = true
                        AND r.id NOT IN (
                            SELECT room_id 
                            FROM Contract 
                            WHERE is_active = true
                        )";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbRoom.DataSource = dt;
                    cbRoom.DisplayMember = "room_name";
                    cbRoom.ValueMember = "id";

                    if (dt.Rows.Count > 0)
                        txtPrice.Text = dt.Rows[0]["price"].ToString();
                    else
                        txtPrice.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phòng: " + ex.Message);
            }
        }



        private void ThemMoiHD_Load(object sender, EventArgs e)
        {
            
            LoadAvailableRooms();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTenantId == -1)
                {
                    MessageBox.Show("Chưa chọn khách thuê!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    // ========================
                    // INSERT HỢP ĐỒNG
                    // ========================
                    string queryContract = @"INSERT INTO Contract 
                                             (room_id, start_date, end_date, deposit, price, is_active) 
                                             VALUES 
                                             (@room_id, @start_date, @end_date, @deposit, @price, true)";

                    MySqlCommand cmdContract = new MySqlCommand(queryContract, conn);
                    cmdContract.Parameters.AddWithValue("@room_id", cbRoom.SelectedValue);
                    cmdContract.Parameters.AddWithValue("@start_date", dpStartDay.Value);
                    cmdContract.Parameters.AddWithValue("@end_date", dpEndDay.Value);
                    cmdContract.Parameters.AddWithValue("@deposit", decimal.Parse(txtDeposit.Text.Trim()));
                    cmdContract.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text.Trim()));

                    cmdContract.ExecuteNonQuery();

                    // Lấy ID hợp đồng vừa thêm
                    long contractId = cmdContract.LastInsertedId;

                    // ========================
                    // INSERT VÀO Contract_Tenant
                    // ========================
                    string queryTenant = @"INSERT INTO Contract_Tenant 
                                           (contract_id, tenant_id, is_primary) 
                                           VALUES (@contract_id, @tenant_id, true)";
                    MySqlCommand cmdTenant = new MySqlCommand(queryTenant, conn);
                    cmdTenant.Parameters.AddWithValue("@contract_id", contractId);
                    cmdTenant.Parameters.AddWithValue("@tenant_id", selectedTenantId);
                    cmdTenant.ExecuteNonQuery();

                    // ========================
                    // CẬP NHẬT TRẠNG THÁI PHÒNG
                    // ========================
                    string updateRoom = "UPDATE Room SET status = 'Đang thuê' WHERE id = @id";
                    MySqlCommand cmd2 = new MySqlCommand(updateRoom, conn);
                    cmd2.Parameters.AddWithValue("@id", cbRoom.SelectedValue);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Thêm hợp đồng thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload lại danh sách phòng
                    LoadAvailableRooms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hợp đồng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    string query = "SELECT id, full_name, phone, address FROM Tenant WHERE id_card = @cccd AND is_active = true";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text.Trim());

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        selectedTenantId = reader.GetInt32("id");
                        txtFullName.Text = reader.GetString("full_name");
                        txtPhone.Text = reader.GetString("phone");
                        txtAddress.Text = reader.GetString("address");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy CCCD/CMND này. Vui lòng thêm khách thuê mới!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        selectedTenantId = -1;
                        txtFullName.Clear();
                        txtPhone.Clear();
                        txtAddress.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách thuê: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRoom.SelectedValue == null) return;

                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    string query = "SELECT price FROM Room WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", cbRoom.SelectedValue);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        txtPrice.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load giá phòng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
