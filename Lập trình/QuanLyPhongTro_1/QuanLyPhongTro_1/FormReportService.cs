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
    public partial class FormReportService : Form
    {
        private ComboBox cbRoom;
        private DataGridView dgvServices;
        private Button btnExportPDF;
        private DataTable serviceData;
        private string connStr = DbHelper.ConnectionString;

        public FormReportService()
        {
            this.Text = "Báo cáo dịch vụ";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeControls();
            LoadRoomFilter();
            LoadServiceData();
        }

        private void InitializeControls()
        {
            cbRoom = new ComboBox
            {
                Location = new Point(20, 20),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbRoom.SelectedIndexChanged += (s, e) => LoadServiceData();
            this.Controls.Add(cbRoom);

            btnExportPDF = new Button
            {
                Text = "Xuất PDF",
                Location = new Point(290, 20),
                Size = new Size(100, 25)
            };
            btnExportPDF.Click += BtnExportPDF_Click;
            this.Controls.Add(btnExportPDF);

            dgvServices = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(740, 380),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            this.Controls.Add(dgvServices);
        }

        private void LoadRoomFilter()
        {
            cbRoom.Items.Clear();
            cbRoom.Items.Add("Tất cả");

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT id, room_name FROM Room WHERE is_active = 1", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbRoom.Items.Add(new { Id = reader.GetInt32("id"), Name = reader.GetString("room_name") });
                }
            }

            cbRoom.DisplayMember = "Name";
            cbRoom.ValueMember = "Id";
            cbRoom.SelectedIndex = 0;
        }

        private DataTable GetServiceData()
        {
            serviceData = new DataTable();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT s.service_name, s.price
                    FROM Service s
                    WHERE s.is_active = 1";

                // Lọc theo phòng nếu chọn
                if (cbRoom.SelectedIndex > 0)
                {
                    sql = @"
                        SELECT s.service_name, s.price
                        FROM Service s
                        INNER JOIN Room_Service rs ON s.id = rs.service_id
                        WHERE rs.room_id = @roomId AND s.is_active = 1";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (cbRoom.SelectedIndex > 0)
                {
                    dynamic selected = cbRoom.SelectedItem;
                    cmd.Parameters.AddWithValue("@roomId", selected.Id);
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(serviceData);
            }

            serviceData.TableName = "Services";
            return serviceData;
        }

        private void LoadServiceData()
        {
            serviceData = GetServiceData();
            dgvServices.DataSource = serviceData;

            if (serviceData.Columns.Contains("service_name")) dgvServices.Columns["service_name"].HeaderText = "Tên dịch vụ";
            if (serviceData.Columns.Contains("price")) dgvServices.Columns["price"].HeaderText = "Đơn giá";
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            serviceData = GetServiceData();
            if (serviceData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất PDF!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "DanhSachDichVu.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            //try
            //{
                Report report = new Report();
                string reportPath = Path.Combine(Application.StartupPath, "ReportService.frx");

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file ReportService.frx");
                    return;
                }

                report.Load(reportPath);
                report.RegisterData(serviceData, "Services");
                report.GetDataSource("Services").Enabled = true;

                // Truyền tên phòng vào parameter
                report.SetParameterValue("RoomName", cbRoom.SelectedIndex == 0 ? "" : ((dynamic)cbRoom.SelectedItem).Name);

                report.Prepare();

                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    PDFSimpleExport pdf = new PDFSimpleExport();
                    report.Export(pdf, fs);
                }

                MessageBox.Show("Xuất PDF thành công!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi xuất PDF:\n" + ex.Message);
            //}
        }
    }
}
