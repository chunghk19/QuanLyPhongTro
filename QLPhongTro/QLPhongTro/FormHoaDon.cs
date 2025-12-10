using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLPhongTro
{
    public partial class FormHoaDon: Form
    {
        string conStr = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
        public FormHoaDon()
        {
            InitializeComponent();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            loadRoomList();
        }
        private void loadRoomList()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, room_name FROM Room WHERE is_active = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbPhong.DataSource = dt;
                    cbPhong.DisplayMember = "room_name";
                    cbPhong.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load phòng: " + ex.Message);
                }
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
            int roomId = Convert.ToInt32(cbPhong.SelectedValue);
            int month = dtTime.Value.Month;
            int year = dtTime.Value.Year;
            decimal electricOld = decimal.Parse(txtSoDienCu.Text);
            decimal electricNew = decimal.Parse(txtSoDienMoi.Text);
            decimal electricPrice = decimal.Parse(txtGiaDien.Text);
            decimal waterOld = decimal.Parse(txtSoNuocCu.Text);
            decimal waterNew = decimal.Parse(txtSoNuocMoi.Text);
            decimal waterPrice = decimal.Parse(txtGiaNuoc.Text);


            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();

                // 1. Lấy hợp đồng của phòng
                string getContract = @"SELECT id, price FROM Contract 
                               WHERE room_id = @roomId AND is_active = 1";
                MySqlCommand cmd1 = new MySqlCommand(getContract, conn);
                cmd1.Parameters.AddWithValue("@roomId", roomId);

                int contractId = 0;
                decimal roomPrice = 0;

                using (var reader = cmd1.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("Phòng này chưa có hợp đồng đang hiệu lực!");
                        return;
                    }
                    contractId = reader.GetInt32("id");
                    roomPrice = reader.GetDecimal("price");
                }

                // 2. Kiểm tra xem hóa đơn đã tồn tại chưa
                string checkInvoice = @"SELECT id FROM Invoice 
                                WHERE contract_id=@cid AND month=@m AND year=@y";

                MySqlCommand cmd2 = new MySqlCommand(checkInvoice, conn);
                cmd2.Parameters.AddWithValue("@cid", contractId);
                cmd2.Parameters.AddWithValue("@m", month);
                cmd2.Parameters.AddWithValue("@y", year);

                object existingInvoice = cmd2.ExecuteScalar();

                if (existingInvoice == null)
                {
                    string insertUsage = @"
                INSERT INTO consumption (
                    room_id, month, year,
                    electric_old, electric_new, electric_price_per_kwh,
                    water_old, water_new, water_price_per_m3
                ) VALUES (
                    @room, @m, @y,
                    @eOld, @eNew, @ePrice,
                    @wOld, @wNew, @wPrice
                );
                SELECT LAST_INSERT_ID();
            ";

                    MySqlCommand cmd3 = new MySqlCommand(insertUsage, conn);
                    cmd3.Parameters.AddWithValue("@room", roomId);
                    cmd3.Parameters.AddWithValue("@m", month);
                    cmd3.Parameters.AddWithValue("@y", year);
                    cmd3.Parameters.AddWithValue("@eOld", electricOld);
                    cmd3.Parameters.AddWithValue("@eNew", electricNew);
                    cmd3.Parameters.AddWithValue("@ePrice", electricPrice);
                    cmd3.Parameters.AddWithValue("@wOld", waterOld);
                    cmd3.Parameters.AddWithValue("@wNew", waterNew);
                    cmd3.Parameters.AddWithValue("@wPrice", waterPrice);

                    long usageId = Convert.ToInt64(cmd3.ExecuteScalar());

                    // 4. Tính chi phí điện,nước
                    decimal electricCost = (electricNew - electricOld) * electricPrice;
                    decimal waterCost = (waterOld - waterNew) * waterPrice;

                    // 5. Lấy giá dịch vụ
                    string getServiceCost = @"
                SELECT SUM(s.price)
                FROM Room_Service rs
                JOIN Service s ON s.id = rs.service_id AND s.is_active=1
                WHERE rs.room_id = @room;
            ";

                    MySqlCommand cmd4 = new MySqlCommand(getServiceCost, conn);
                    cmd4.Parameters.AddWithValue("@room", roomId);

                    decimal serviceCost = Convert.ToDecimal(cmd4.ExecuteScalar() ?? 0);
                    decimal otherCost = 0;
                    decimal total = roomPrice + electricCost + waterCost + serviceCost;

                    // 6. Insert hoá đơn
                    string insertInvoice = @"
                INSERT INTO Invoice (
                    contract_id, usage_id, month, year,
                    room_price, electric_cost, water_cost, service_cost, other_cost,
                    total_cost, status
                ) VALUES (
                    @cid, @uid, @m, @y,
                    @rPrice, @ele, @water, @service, @other,
                    @total, 'Chờ thanh toán'
                );
            ";

                    MySqlCommand cmd5 = new MySqlCommand(insertInvoice, conn);
                    cmd5.Parameters.AddWithValue("@cid", contractId);
                    cmd5.Parameters.AddWithValue("@uid", usageId);
                    cmd5.Parameters.AddWithValue("@m", month);
                    cmd5.Parameters.AddWithValue("@y", year);
                    cmd5.Parameters.AddWithValue("@rPrice", roomPrice);
                    cmd5.Parameters.AddWithValue("@ele", electricCost);
                    cmd5.Parameters.AddWithValue("@water", waterCost);
                    cmd5.Parameters.AddWithValue("@service", serviceCost);
                    cmd5.Parameters.AddWithValue("@other", otherCost);
                    cmd5.Parameters.AddWithValue("@total", total);

                    cmd5.ExecuteNonQuery();
                }

                // Load hóa đơn ra DataGridView
                string query = @"
            SELECT 
                r.id,
                r.room_name,
                i.room_price,
                i.electric_cost,
                i.water_cost,
                i.service_cost,
                i.other_cost,
                i.total_cost,
                i.paid_amount,
                i.status
            FROM Invoice i
            JOIN Contract c ON i.contract_id = c.id
            JOIN Room r ON c.room_id = r.id
            WHERE r.id = @roomId AND i.month = @month AND i.year = @year
        ";

                MySqlCommand cmdDisplay = new MySqlCommand(query, conn);
                cmdDisplay.Parameters.AddWithValue("@roomId", roomId);
                cmdDisplay.Parameters.AddWithValue("@month", month);
                cmdDisplay.Parameters.AddWithValue("@year", year);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdDisplay);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvHoaDon.DataSource = dt;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
