using System;
using System.Data;
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
            LoadRooms(txtRoomSearch.Text.Trim());
        }

        private DataRow GetLastConsumption(int roomId)
        {
            string sql = @"
                SELECT *
                FROM consumption
                WHERE room_id = @roomId
                ORDER BY created_at DESC
                LIMIT 1
            ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        private void cbRoomSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoomSearch.SelectedValue == null) return;
            if (!int.TryParse(cbRoomSearch.SelectedValue.ToString(), out int roomId)) return;

            DataRow last = GetLastConsumption(roomId);

            if (last != null)
            {
                txtElectricOld.Text = last["electric_new"].ToString();
                txtWaterOld.Text = last["water_new"].ToString();
                txtElectricOld.ReadOnly = true;
                txtWaterOld.ReadOnly = true;
            }
            else
            {
                txtElectricOld.Text = "0";
                txtWaterOld.Text = "0";
                txtElectricOld.ReadOnly = false;
                txtWaterOld.ReadOnly = false;
            }

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

            // ===== Validate trống =====
            if (string.IsNullOrWhiteSpace(txtElectricNew.Text) || string.IsNullOrWhiteSpace(txtWaterNew.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện và số nước mới");
                return;
            }

            // ===== Validate kiểu số =====
            if (!int.TryParse(txtElectricNew.Text, out int electricNew))
            {
                MessageBox.Show("Chỉ số điện mới phải là số nguyên hợp lệ");
                return;
            }

            if (!int.TryParse(txtWaterNew.Text, out int waterNew))
            {
                MessageBox.Show("Chỉ số nước mới phải là số nguyên hợp lệ");
                return;
            }

            if (!int.TryParse(txtElectricOld.Text, out int electricOld))
            {
                MessageBox.Show("Chỉ số điện cũ không hợp lệ");
                return;
            }

            if (!int.TryParse(txtWaterOld.Text, out int waterOld))
            {
                MessageBox.Show("Chỉ số nước cũ không hợp lệ");
                return;
            }

            // ===== Validate số âm =====
            if (electricNew < 0 || waterNew < 0)
            {
                MessageBox.Show("Chỉ số điện và nước không được âm");
                return;
            }

            if (electricOld < 0 || waterOld < 0)
            {
                MessageBox.Show("Chỉ số cũ không hợp lệ");
                return;
            }

            // ===== Validate lớn hơn cũ =====
            if (electricNew < electricOld || waterNew < waterOld)
            {
                MessageBox.Show("Chỉ số mới không được nhỏ hơn chỉ số cũ");
                return;
            }

            // ===== Validate ngày =====
            DateTime selectedDate = dpStartDay.Value.Date;
            DataRow last = GetLastConsumption(Convert.ToInt32(cbRoomSearch.SelectedValue));
            if (last != null)
            {
                DateTime lastDate = Convert.ToDateTime(last["created_at"]);
                if (selectedDate <= lastDate)
                {
                    MessageBox.Show("Ngày chốt phải lớn hơn lần chốt gần nhất");
                    return;
                }
            }

            int month = selectedDate.Month;
            int year = selectedDate.Year;

            // ===== Validate đã chốt tháng =====
            if (IsConsumptionExists(Convert.ToInt32(cbRoomSearch.SelectedValue), month, year))
            {
                MessageBox.Show($"Phòng này đã chốt điện nước tháng {month}/{year}");
                return;
            }

            // ===== Thực hiện lưu =====
            string sql = @"
        INSERT INTO consumption (
            room_id, month, year,
            electric_old, electric_new, electric_price_per_kwh,
            water_old, water_new, water_price_per_m3,
            created_at
        )
        VALUES (
            @roomId, @month, @year,
            @eOld, @eNew, @ePrice,
            @wOld, @wNew, @wPrice,
            @createdAt
        )
    ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", Convert.ToInt32(cbRoomSearch.SelectedValue));
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                cmd.Parameters.AddWithValue("@eOld", electricOld);
                cmd.Parameters.AddWithValue("@eNew", electricNew);
                cmd.Parameters.AddWithValue("@ePrice", Convert.ToDecimal(txtDonGiaDien.Text));

                cmd.Parameters.AddWithValue("@wOld", waterOld);
                cmd.Parameters.AddWithValue("@wNew", waterNew);
                cmd.Parameters.AddWithValue("@wPrice", Convert.ToDecimal(TxtDonGiaNuoc.Text));

                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Lưu chỉ số điện nước thành công!");

            txtElectricNew.Text = "";
            txtWaterNew.Text = "";
            txtElectricCost.Text = "0";
            txtWaterCost.Text = "0";
        }


        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
