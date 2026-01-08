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
using QuanLyPhongTro_1.Common;

namespace QuanLyPhongTro_1
{
    public partial class FormConsumption : Form
    {
        public FormConsumption()
        {
            InitializeComponent();
            this.Load += FormConsumption_Load;
            LoadRooms();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormConsumption_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
        }
        private void LoadRooms(string keyword = "")
        {
            cbRoomSearch.DataSource = null;

            string sql = @"
                            SELECT id, room_name
                            FROM Room
                            WHERE is_active = 1
                            AND status = 'Đang thuê'
                            AND room_name LIKE @keyword
                        ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbRoomSearch.DisplayMember = "room_name";
                cbRoomSearch.ValueMember = "id";
                cbRoomSearch.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string keyword = txtRoomSearch.Text.Trim();
            LoadRooms(keyword);
        }

        private bool HasPreviousConsumption(int roomId, int month, int year)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM consumption
        WHERE room_id = @roomId
          AND (year < @year OR (year = @year AND month < @month))
    ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void LoadPreviousConsumption(int roomId, int month, int year)
        {
            string sql = @"
                        SELECT electric_new, water_new
                        FROM consumption
                        WHERE room_id = @roomId
                        AND (year < @year OR (year = @year AND month < @month))
                        ORDER BY year DESC, month DESC
                        LIMIT 1
                    ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtElectricOld.Text = reader["electric_new"].ToString();
                        txtWaterOld.Text = reader["water_new"].ToString();
                    }
                }
            }
        }

        private void cbRoomSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = dpStartDay.Value.Month;
            int year = dpStartDay.Value.Year;
            if (cbRoomSearch.SelectedValue == null) return;
            if (!int.TryParse(cbRoomSearch.SelectedValue.ToString(), out int roomId)) return;

            if (HasPreviousConsumption(roomId, month, year))
            {
                LoadPreviousConsumption(roomId, month, year);
                txtElectricOld.ReadOnly = true;
                txtWaterOld.ReadOnly = true;
            }
            else
            {
                // Tháng đầu → nhập tay
                txtElectricOld.ReadOnly = false;
                txtWaterOld.ReadOnly = false;

                txtElectricOld.Text = "0";
                txtWaterOld.Text = "0";
            }

            // Clear số mới mỗi lần đổi phòng
            txtElectricNew.Text = "";
            txtWaterNew.Text = "";
            txtElectricCost.Text = "0";
            txtWaterCost.Text = "0";
        }


        private bool IsConsumptionExists(int roomId, int month, int year)
        {
            string sql = @"
                        SELECT COUNT(*)
                        FROM consumption
                        WHERE room_id = @roomId
                        AND month = @month
                        AND year = @year
                    ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbRoomSearch.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng");
                return;
            }

            // 2. Validate số mới
            if (string.IsNullOrEmpty(txtElectricNew.Text) || string.IsNullOrEmpty(txtWaterNew.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện và số nước mới");
                return;
            }

            int roomId = Convert.ToInt32(cbRoomSearch.SelectedValue);
            int month = dpStartDay.Value.Month;
            int year = dpStartDay.Value.Year;

            int electricOld = int.Parse(txtElectricOld.Text);
            int electricNew = int.Parse(txtElectricNew.Text);
            int waterOld = int.Parse(txtWaterOld.Text);
            int waterNew = int.Parse(txtWaterNew.Text);

            // 3. Validate logic
            if (electricNew < electricOld || waterNew < waterOld)
            {
                MessageBox.Show("Chỉ số mới không được nhỏ hơn chỉ số cũ");
                return;
            }

            // 4. Check trùng tháng
            if (IsConsumptionExists(roomId, month, year))
            {
                MessageBox.Show("Phòng này đã chốt điện nước cho tháng này");
                return;
            }

            // 5. INSERT vào bảng consumption
            string sql = @"
                        INSERT INTO consumption (
                            room_id, month, year,
                            electric_old, electric_new, electric_price_per_kwh,
                            water_old, water_new, water_price_per_m3
                        )
                        VALUES (
                            @roomId, @month, @year,
                            @eOld, @eNew, @ePrice,
                            @wOld, @wNew, @wPrice
                        )
                    ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                cmd.Parameters.AddWithValue("@eOld", electricOld);
                cmd.Parameters.AddWithValue("@eNew", electricNew);
                cmd.Parameters.AddWithValue("@ePrice", Convert.ToInt32(txtDonGiaDien.Text));

                cmd.Parameters.AddWithValue("@wOld", waterOld);
                cmd.Parameters.AddWithValue("@wNew", waterNew);
                cmd.Parameters.AddWithValue("@wPrice",Convert.ToInt32(TxtDonGiaNuoc.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Lưu chỉ số điện nước thành công!");

            // 6. Reset form (optional)
            txtElectricNew.Text = "";
            txtWaterNew.Text = "";
            txtElectricCost.Text = "0";
            txtWaterCost.Text = "0";
        }
    }
}
