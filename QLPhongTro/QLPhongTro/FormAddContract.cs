using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLPhongTro
{
    public partial class FormAddContract : Form
    {
        string str = "Server=localhost;Port=3306;Database=room_management;Uid=root;Pwd=";
        public FormAddContract()
        {
            InitializeComponent();
            LoadRooms();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadRooms()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    string sql = "SELECT id, room_name FROM Room WHERE status='Trống'";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            cbSellectRoom.DisplayMember = "room_name"; // tên hiển thị
                            cbSellectRoom.ValueMember = "id";          // giá trị thực sự
                            cbSellectRoom.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phòng: " + ex.Message);
            }
        }


        private void btnAddContract_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    // 1. Kiểm tra tenant theo số điện thoại
                    int? tenantId = null;
                    string checkSql = "SELECT id FROM Tenant WHERE phone = @phone";

                    using (var cmd = new MySqlCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", txtSDT.Text);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            tenantId = Convert.ToInt32(result);
                    }
                    if (tenantId == null)
                    {
                        string insertTenant = @"
                        INSERT INTO Tenant(full_name, phone, id_card, address, is_active)
                        VALUES(@name, @phone, @idcard, @address, TRUE);
                        SELECT LAST_INSERT_ID();
                           ";

                        using (var cmd = new MySqlCommand(insertTenant, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@phone", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@idcard", "unknown");
                            cmd.Parameters.AddWithValue("@address", txtAdd.Text);

                            tenantId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    // 3. Lấy giá phòng
                    decimal roomPrice = 0;
                    string roomPriceSql = "SELECT price FROM Room WHERE id = @rid";
                    using (var cmd = new MySqlCommand(roomPriceSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", (int)cbSellectRoom.SelectedValue);
                        roomPrice = Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                    // 4. Tạo hợp đồng
                    int contractId = 0;
                    string insertContract = @"
                    INSERT INTO Contract(room_id, start_date, end_date, deposit, price, is_active)
                    VALUES(@room, @start, @end, @deposit, @price, TRUE);
                    SELECT LAST_INSERT_ID();
                    ";
                    using (var cmd = new MySqlCommand(insertContract, conn))
                    {
                        cmd.Parameters.AddWithValue("@room", (int)cbSellectRoom.SelectedValue);
                        cmd.Parameters.AddWithValue("@start", dtpStartDay.Value.Date);
                        cmd.Parameters.AddWithValue("@end", dtpEndDay.Checked ? (object)dtpEndDay.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@deposit", 0);
                        cmd.Parameters.AddWithValue("@price", roomPrice);

                        contractId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // 5. Thêm khách thuê vào hợp đồng
                    string ctSql = @"
                    INSERT INTO Contract_Tenant(contract_id, tenant_id, is_primary)
                    VALUES(@cid, @tid, TRUE);
                    ";
                    using (var cmd = new MySqlCommand(ctSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", contractId);
                        cmd.Parameters.AddWithValue("@tid", tenantId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tạo hợp đồng thành công!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
