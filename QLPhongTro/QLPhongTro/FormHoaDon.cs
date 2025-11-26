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

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
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
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvHoaDon.DataSource = dt;
            }
        }
    }
}
