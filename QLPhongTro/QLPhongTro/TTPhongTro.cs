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
        private void loadDichVu()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            s.service_name AS 'Tên dịch vụ',
                            FORMAT(s.price, 0) AS 'Giá (VNĐ)'
                        FROM User u
                        JOIN Tenant t ON t.user_id = u.id
                        JOIN Contract_Tenant ct ON ct.tenant_id = t.id
                        JOIN Contract c ON c.id = ct.contract_id
                        JOIN Room r ON r.id = c.room_id
                        JOIN Room_Service rs ON rs.room_id = r.id
                        JOIN Service s ON s.id = rs.service_id
                        WHERE u.username = @user
                          AND c.is_active = TRUE
                          AND s.is_active = TRUE;
                    ";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@user", username);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDichVu.DataSource = dt;

                    // Tùy chọn giao diện (khuyên dùng)
                    dgvDichVu.DataSource = dt;
                    dgvDichVu.ReadOnly = true;
                    dgvDichVu.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dịch vụ: " + ex.Message);
            }
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
                        " WHERE u.username = @user  AND c.is_active = TRUE";
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
                loadDichVu();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
