using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyPhongTro_1.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            numMonth.Minimum = 1;
            numMonth.Maximum = 12;

            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
        }

        // ================= LOAD ROOM =================
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

        // ================= CONTRACT =================
        private DateTime? GetContractStartDate(int roomId)
        {
            string sql = @"
                SELECT start_date
                FROM contract
                WHERE room_id = @roomId
                AND status = 'Đang hiệu lực'
                ORDER BY start_date DESC
                LIMIT 1
            ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);
                conn.Open();
                object rs = cmd.ExecuteScalar();
                return rs != null ? Convert.ToDateTime(rs) : (DateTime?)null;
            }
        }

        // ================= CONSUMPTION =================
        private DataRow GetLastConsumption(int roomId)
        {
            string sql = @"
                SELECT *
                FROM consumption
                WHERE room_id = @roomId
                ORDER BY year DESC, month DESC
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

        // ================= ROOM CHANGE =================
        private void cbRoomSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoomSearch.SelectedValue == null) return;
            if (!int.TryParse(cbRoomSearch.SelectedValue.ToString(), out int roomId)) return;

            DateTime? contractStart = GetContractStartDate(roomId);
            if (contractStart == null)
            {
                MessageBox.Show("Phòng này chưa có hợp đồng hiệu lực");
                return;
            }

            DataRow last = GetLastConsumption(roomId);

            if (last != null)
            {
                // ===== Đã từng chốt =====
                txtElectricOld.Text = last["electric_new"].ToString();
                txtWaterOld.Text = last["water_new"].ToString();
                txtElectricOld.ReadOnly = true;
                txtWaterOld.ReadOnly = true;

                int lastMonth = Convert.ToInt32(last["month"]);
                int lastYear = Convert.ToInt32(last["year"]);
                DateTime next = new DateTime(lastYear, lastMonth, 1).AddMonths(1);

                numMonth.Value = next.Month;
                numYear.Value = next.Year;
            }
            else
            {
                // ===== Hợp đồng mới =====
                txtElectricOld.Text = "0";
                txtWaterOld.Text = "0";
                txtElectricOld.ReadOnly = false;
                txtWaterOld.ReadOnly = false;

                numMonth.Value = contractStart.Value.Month;
                numYear.Value = contractStart.Value.Year;
            }

            txtElectricNew.Text = "";
            txtWaterNew.Text = "";
            txtElectricCost.Text = "0";
            txtWaterCost.Text = "0";
        }

        // ================= SAVE =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbRoomSearch.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng");
                return;
            }

            int roomId = Convert.ToInt32(cbRoomSearch.SelectedValue);
            int month = (int)numMonth.Value;
            int year = (int)numYear.Value;

            DateTime? contractStart = GetContractStartDate(roomId);
            if (contractStart == null)
            {
                MessageBox.Show("Phòng chưa có hợp đồng hiệu lực");
                return;
            }

            // ===== Không trước tháng hợp đồng =====
            DateTime selected = new DateTime(year, month, 1);
            DateTime contractMonth = new DateTime(contractStart.Value.Year, contractStart.Value.Month, 1);
            if (selected < contractMonth)
            {
                MessageBox.Show("Không được lập trước tháng bắt đầu hợp đồng");
                return;
            }

            DataRow last = GetLastConsumption(roomId);
            if (last != null)
            {
                DateTime lastMonth = new DateTime(
                    Convert.ToInt32(last["year"]),
                    Convert.ToInt32(last["month"]),
                    1
                );

                if (selected <= lastMonth)
                {
                    MessageBox.Show("Phải lập tháng sau lần chốt gần nhất");
                    return;
                }
            }

            if (IsConsumptionExists(roomId, month, year))
            {
                MessageBox.Show($"Phòng đã chốt điện nước tháng {month}/{year}");
                return;
            }

            // ===== Validate số =====
            if (!int.TryParse(txtElectricNew.Text, out int electricNew) ||
                !int.TryParse(txtWaterNew.Text, out int waterNew) ||
                !int.TryParse(txtElectricOld.Text, out int electricOld) ||
                !int.TryParse(txtWaterOld.Text, out int waterOld))
            {
                MessageBox.Show("Chỉ số điện nước không hợp lệ");
                return;
            }

            if (electricNew < electricOld || waterNew < waterOld)
            {
                MessageBox.Show("Chỉ số mới không được nhỏ hơn chỉ số cũ");
                return;
            }

            // ===== INSERT =====
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
                cmd.Parameters.AddWithValue("@roomId", roomId);
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
        }


        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
