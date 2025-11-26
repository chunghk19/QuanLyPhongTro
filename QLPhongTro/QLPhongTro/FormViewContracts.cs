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
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace QLPhongTro
{
    public partial class FormViewContracts : Form

    {
        string str = "Server=localhost;Port=3306;Database=room_management;Uid=root;Pwd=";
        public FormViewContracts()
        {
            InitializeComponent();
            LoadContracts(); // Tự động load danh sách hợp đồng khi form mở
        }
        // Hàm load danh sách hợp đồng từ database vào DataGridView
        private void LoadContracts()
        {
            // SQL lấy danh sách hợp đồng, gom tên tất cả khách thuê trong 1 hợp đồng
            string sql = @"
            SELECT c.id AS ContractID,  -- Mã hợp đồng
                   GROUP_CONCAT(t.full_name SEPARATOR ', ') AS TenantNames,  -- Gom tên khách thuê
                   r.room_name AS RoomName,   -- Tên phòng
                   c.start_date,              -- Ngày bắt đầu hợp đồng
                   c.end_date,                -- Ngày kết thúc hợp đồng
                   c.price                    -- Giá thuê
            FROM Contract c
            INNER JOIN Contract_Tenant ct ON c.id = ct.contract_id  -- Liên kết hợp đồng ↔ khách thuê
            INNER JOIN Tenant t ON ct.tenant_id = t.id             -- Lấy thông tin khách thuê
            INNER JOIN Room r ON c.room_id = r.id                 -- Lấy thông tin phòng
            WHERE c.is_active = TRUE                               -- Chỉ hiển thị hợp đồng còn hiệu lực
            GROUP BY c.id;                                        -- Gom tất cả khách trong cùng hợp đồng
            ";

            // Tạo kết nối tới MySQL
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open(); // Mở kết nối

                // Tạo command để thực hiện SQL
                using (var cmd = new MySqlCommand(sql, conn))
                // Adapter giúp đổ dữ liệu từ database vào DataTable
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();  // Tạo bảng dữ liệu tạm thời
                    adapter.Fill(dt);                // Điền dữ liệu từ query vào DataTable
                    dgvContracts.DataSource = dt;    // Gán DataTable cho DataGridView hiển thị
                }
            }

            // Đặt tiêu đề cột hiển thị trong DataGridView
            dgvContracts.Columns["ContractID"].HeaderText = "Mã Hợp Đồng";
            dgvContracts.Columns["TenantNames"].HeaderText = "Khách Thuê";
            dgvContracts.Columns["RoomName"].HeaderText = "Phòng";
            dgvContracts.Columns["start_date"].HeaderText = "Ngày Bắt Đầu";
            dgvContracts.Columns["end_date"].HeaderText = "Ngày Kết Thúc";
            dgvContracts.Columns["price"].HeaderText = "Giá Thuê";

            // Format hiển thị các cột ngày và giá
            dgvContracts.Columns["start_date"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Ngày bắt đầu
            dgvContracts.Columns["end_date"].DefaultCellStyle.Format = "dd/MM/yyyy";   // Ngày kết thúc
            dgvContracts.Columns["price"].DefaultCellStyle.Format = "C2";              // Giá tiền, định dạng currency
        }

        // Sự kiện khi bấm nút Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadContracts();  // Load lại danh sách hợp đồng mới nhất
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormViewContracts_Load(object sender, EventArgs e)
        {

        }
    }
}
