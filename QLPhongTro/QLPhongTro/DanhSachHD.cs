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
    public partial class dgDSHD : Form
    {
        string str = "Server=localhost;Database=Room_Management;Uid=root;Pwd=";
        public dgDSHD()
        {
            InitializeComponent();
            LoadContracts();
        }

        private void DanhSachHD_Load(object sender, EventArgs e)
        {

        }
        // =========================
        // Load tất cả hợp đồng
        // =========================
        private void LoadContracts()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        c.id AS contract_id,
                        r.room_name,
                        c.price,
                        c.start_date,
                        c.end_date,
                        c.deposit,
                        c.is_active,
                        GROUP_CONCAT(t.full_name SEPARATOR ', ') AS tenants
                    FROM Contract c
                    INNER JOIN Room r ON c.room_id = r.id
                    INNER JOIN Contract_Tenant ct ON c.id = ct.contract_id
                    INNER JOIN Tenant t ON ct.tenant_id = t.id
                    GROUP BY c.id
                    ORDER BY c.id DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm cột trạng thái hiển thị
                    dt.Columns.Add("Trạng thái", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Trạng thái"] = Convert.ToBoolean(row["is_active"]) ? "Còn hiệu lực" : "Đã kết thúc";
                    }

                    dgvDanhSachHD.DataSource = dt;

                    // Đổi tên các cột sang tiếng Việt
                    dgvDanhSachHD.Columns["room_name"].HeaderText = "Tên phòng";
                    dgvDanhSachHD.Columns["price"].HeaderText = "Giá phòng";
                    dgvDanhSachHD.Columns["start_date"].HeaderText = "Ngày bắt đầu";
                    dgvDanhSachHD.Columns["end_date"].HeaderText = "Ngày kết thúc";
                    dgvDanhSachHD.Columns["deposit"].HeaderText = "Tiền đặt cọc";
                    dgvDanhSachHD.Columns["tenants"].HeaderText = "Khách thuê";

                    // Ẩn các cột không cần hiển thị
                    dgvDanhSachHD.Columns["contract_id"].Visible = false;
                    dgvDanhSachHD.Columns["is_active"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách hợp đồng: " + ex.Message);
            }
        }

        // =========================
        // Tìm CCCD
        // =========================
        private void btnSeach_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD!");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        c.id AS contract_id,
                        r.room_name,
                        c.price,
                        c.start_date,
                        c.end_date,
                        c.deposit,
                        c.is_active,
                        GROUP_CONCAT(t2.full_name SEPARATOR ', ') AS tenants
                    FROM Contract c
                    INNER JOIN Room r ON c.room_id = r.id
                    INNER JOIN Contract_Tenant ct ON c.id = ct.contract_id
                    INNER JOIN Tenant t ON ct.tenant_id = t.id
                    INNER JOIN Contract_Tenant ct2 ON c.id = ct2.contract_id
                    INNER JOIN Tenant t2 ON ct2.tenant_id = t2.id
                    WHERE t.id_card = @cccd
                    GROUP BY c.id
                    ORDER BY c.id DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cccd", cccd);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách thuê với CCCD này!");
                    }
                    else
                    {
                        // Tự động xóa chữ trong ô tìm kiếm
                        txtCCCD.Clear();
                        dgvDanhSachHD.DataSource = dt;

                        dt.Columns.Add("status_text", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["status_text"] = Convert.ToBoolean(row["is_active"]) ? "Còn hiệu lực" : "Đã kết thúc";
                        }

                        dgvDanhSachHD.Columns["contract_id"].Visible = false;
                        dgvDanhSachHD.Columns["is_active"].Visible = false;
                        dgvDanhSachHD.Columns["status_text"].HeaderText = "Trạng thái";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm CCCD: " + ex.Message);
            }
        }
        // =========================
        // Nút Thêm mới
        // =========================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemMoiHD themMoiHD = new ThemMoiHD();
            themMoiHD.ShowDialog();
            LoadContracts(); // reload danh sách sau khi thêm
        }
        // =========================
        // Nút Sửa
        // =========================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng để sửa!");
                return;
            }

            int contractId = Convert.ToInt32(dgvDanhSachHD.SelectedRows[0].Cells["contract_id"].Value);
            ThemMoiHD themMoiHD = new ThemMoiHD();
            themMoiHD.ShowDialog();
            LoadContracts(); // reload danh sách sau khi sửa
        }
    }
}
