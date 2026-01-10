using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FastReport;
using FastReport.Export.PdfSimple;
using QuanLyPhongTro_1.Common;

namespace QuanLyPhongTro_1
{
    public partial class FormReportListTenant : Form
    {
        private DataGridView dgvTenantRoom;
        private ComboBox cbFilterRoom;
        private ComboBox cbFilterStatus;
        private Button btnExportPDF;
        DataTable data;
        private string connStr = DbHelper.ConnectionString;

        public FormReportListTenant()
        {
            this.Text = "Danh sách khách thuê - phòng thuê";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeControls();
            LoadFilterOptions();
            LoadTenantRoomData();
        }

        private void InitializeControls()
        {
            cbFilterRoom = new ComboBox
            {
                Location = new Point(20, 20),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbFilterRoom.SelectedIndexChanged += (s, e) => LoadTenantRoomData();
            this.Controls.Add(cbFilterRoom);

            cbFilterStatus = new ComboBox
            {
                Location = new Point(290, 20),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbFilterStatus.SelectedIndexChanged += (s, e) => LoadTenantRoomData();
            this.Controls.Add(cbFilterStatus);

            btnExportPDF = new Button
            {
                Text = "Xuất PDF",
                Location = new Point(460, 20),
                Size = new Size(100, 25)
            };
            btnExportPDF.Click += BtnExportPDF_Click;
            this.Controls.Add(btnExportPDF);

            dgvTenantRoom = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(940, 480),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            this.Controls.Add(dgvTenantRoom);
        }

        private void LoadFilterOptions()
        {
            cbFilterRoom.Items.Clear();
            cbFilterRoom.Items.Add("Tất cả");

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT room_name FROM Room WHERE is_active = 1", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    cbFilterRoom.Items.Add(reader.GetString("room_name"));
            }
            cbFilterRoom.SelectedIndex = 0;

            cbFilterStatus.Items.Clear();
            cbFilterStatus.Items.Add("Tất cả");
            cbFilterStatus.Items.Add("Còn hiệu lực");
            cbFilterStatus.Items.Add("Đã kết thúc");
            cbFilterStatus.SelectedIndex = 0;
        }

        private DataTable GetTenantRoomData()
        {
            data = new DataTable();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT t.full_name, t.phone, t.id_card, t.address,
                           r.room_name, r.price, c.is_active AS contract_active
                    FROM Tenant t
                    INNER JOIN Contract_Tenant ct ON t.id = ct.tenant_id
                    INNER JOIN Contract c ON ct.contract_id = c.id
                    INNER JOIN Room r ON c.room_id = r.id
                    WHERE t.is_active = 1 AND r.is_active = 1";

                if (cbFilterRoom.SelectedIndex > 0)
                    sql += " AND r.room_name = @roomName";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (cbFilterRoom.SelectedIndex > 0)
                    cmd.Parameters.AddWithValue("@roomName", cbFilterRoom.SelectedItem.ToString());

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(data);
            }

            // Filter theo trạng thái hợp đồng
            DataRow[] filteredRows;
            if (cbFilterStatus.SelectedIndex == 1)
                filteredRows = data.Select("contract_active = true");
            else if (cbFilterStatus.SelectedIndex == 2)
                filteredRows = data.Select("contract_active = false");
            else
                filteredRows = data.Select();

            data = filteredRows.Length > 0 ? filteredRows.CopyToDataTable() : data.Clone();

            // Thêm cột string hiển thị trạng thái hợp đồng
            if (!data.Columns.Contains("contract_status"))
            {
                data.Columns.Add("contract_status", typeof(string));
                foreach (DataRow row in data.Rows)
                    row["contract_status"] = (bool)row["contract_active"] ? "Còn" : "Đã";
            }
            data.TableName = "TenantRoom";
            return data;
        }

        private void LoadTenantRoomData()
        {
            data = GetTenantRoomData();
            dgvTenantRoom.DataSource = data;

            if (data.Columns.Contains("full_name")) dgvTenantRoom.Columns["full_name"].HeaderText = "Tên khách";
            if (data.Columns.Contains("phone")) dgvTenantRoom.Columns["phone"].HeaderText = "SĐT";
            if (data.Columns.Contains("id_card")) dgvTenantRoom.Columns["id_card"].HeaderText = "CCCD";
            if (data.Columns.Contains("address")) dgvTenantRoom.Columns["address"].HeaderText = "Địa chỉ";
            if (data.Columns.Contains("room_name")) dgvTenantRoom.Columns["room_name"].HeaderText = "Phòng thuê";
            if (data.Columns.Contains("price")) dgvTenantRoom.Columns["price"].HeaderText = "Giá thuê";
            if (data.Columns.Contains("contract_status")) dgvTenantRoom.Columns["contract_status"].HeaderText = "HĐ còn hiệu lực";
            data.TableName = "TenantRoom";
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            data = GetTenantRoomData();
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất PDF!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "DanhSachKhachHang.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Report report = new Report();
                string reportPath = Path.Combine(Application.StartupPath, "ReportListTenant.frx");

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file ReportListTenant.frx");
                    return;
                }

                report.Load(reportPath);

                // Quan trọng: true = đăng ký tất cả Table bên trong DataSet
                report.RegisterData(data, "TenantRoom");
                // Bật DataSource đúng tên Table
                report.GetDataSource("TenantRoom").Enabled = true;

                report.Prepare();

                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    PDFSimpleExport pdf = new PDFSimpleExport();
                    report.Export(pdf, fs);
                }

                MessageBox.Show("Xuất PDF thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF:\n" + ex.Message);
            }
        }
    }
}
