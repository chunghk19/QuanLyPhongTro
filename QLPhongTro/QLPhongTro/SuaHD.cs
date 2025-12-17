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
    public partial class SuaHD : Form
    {
        string str = "Server=localhost;Database=Room_Management;Uid=root;Pwd=";
        private int contractId;
        private int currentRoomId;
        public SuaHD()
        {
            InitializeComponent();
        }
        public SuaHD(int _contractId)
        {
            InitializeComponent();
            contractId = _contractId;

            // Không cho sửa thông tin khách
            txtCCCD.ReadOnly = true;
            txtFullName.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAddress.ReadOnly = true;

            LoadContractData();
        }
        private void LoadContractData()
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        c.room_id, c.price, c.deposit, c.start_date, c.end_date,
                        t.id_card, t.full_name, t.phone, t.address
                    FROM Contract c
                    INNER JOIN Contract_Tenant ct ON c.id = ct.contract_id AND ct.is_primary = true
                    INNER JOIN Tenant t ON ct.tenant_id = t.id
                    WHERE c.id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", contractId);

                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    currentRoomId = rd.GetInt32("room_id");

                    txtCCCD.Text = rd["id_card"].ToString();
                    txtFullName.Text = rd["full_name"].ToString();
                    txtPhone.Text = rd["phone"].ToString();
                    txtAddress.Text = rd["address"].ToString();

                    txtPrice.Text = rd["price"].ToString();
                    txtDeposit.Text = rd["deposit"].ToString();
                    dpStartDay.Value = Convert.ToDateTime(rd["start_date"]);
                    dpEndDay.Value = rd["end_date"] == DBNull.Value
                                    ? DateTime.Now
                                    : Convert.ToDateTime(rd["end_date"]);
                }
                rd.Close();
            }

            LoadRoomsForEdit();
        }
        private void LoadRoomsForEdit()
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();

                        string query = @"
                SELECT id, room_name
                FROM Room
                WHERE is_active = true
                AND (
                    id = @currentRoom
                    OR id NOT IN (
                        SELECT room_id FROM Contract WHERE is_active = true
                    )
                )";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@currentRoom", currentRoomId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbRoom.DataSource = dt;
                cbRoom.DisplayMember = "room_name";
                cbRoom.ValueMember = "id";
                cbRoom.SelectedValue = currentRoomId;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
               "Bạn có chắc muốn lưu thay đổi không?",
               "Xác nhận",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question);

            if (r != DialogResult.OK) return;

            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();

                string query = @"
                    UPDATE Contract
                    SET room_id = @room,
                        price = @price,
                        deposit = @deposit,
                        start_date = @start,
                        end_date = @end
                    WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@room", cbRoom.SelectedValue);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@deposit", txtDeposit.Text);
                cmd.Parameters.AddWithValue("@start", dpStartDay.Value);
                cmd.Parameters.AddWithValue("@end", dpEndDay.Value);
                cmd.Parameters.AddWithValue("@id", contractId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật hợp đồng thành công!");
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

