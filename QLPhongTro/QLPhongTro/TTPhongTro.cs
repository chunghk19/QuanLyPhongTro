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
using static System.Windows.Forms.MonthCalendar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLPhongTro
{
    public partial class TTPhongTro : Form
    {
        private string username;
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=157359";
        public TTPhongTro(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TTPhongTro_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    string query = "SELECT r.id AS room_id, r.room_name, r.price,  r.area,  r.status" +
                        " FROM User u  JOIN Tenant t ON t.user_id = u.id" +
                        " JOIN Contract_Tenant ct ON ct.tenant_id = t.id" +
                        " JOIN Contract c ON c.id = ct.contract_id" +
                        " JOIN Room r ON r.id = c.room_id" +
                        " WHERE u.username = ?  AND c.is_active = TRUE";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", username);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtTenPhong.Text = rdr["room_name"].ToString();
                            txtGia.Text = rdr["price"].ToString();
                            txtDienTichThue.Text = rdr["area"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin phòng!");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
