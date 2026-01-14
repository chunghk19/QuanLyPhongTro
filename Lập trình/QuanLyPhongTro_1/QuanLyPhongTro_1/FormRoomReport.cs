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
    public partial class FormRoomReport : Form
    {
        private string connStr = DbHelper.ConnectionString;

        private DataGridView dgvRoom;
        private Button btnExport;
        DataTable data;
        public FormRoomReport()
        {
            InitializeComponent();
            InitUI();
            LoadRoom();
        }

        private void InitUI()
        {
            this.Text = "BÁO CÁO DANH SÁCH PHÒNG";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 600);

            dgvRoom = new DataGridView()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };

            btnExport = new Button()
            {
                Text = "Xuất PDF",
                Height = 40,
                Dock = DockStyle.Bottom
            };
            btnExport.Click += BtnExport_Click;

            this.Controls.Add(dgvRoom);
            this.Controls.Add(btnExport);
        }

        private void LoadRoom()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connStr);
                string sql = @"
                    SELECT 
                        id,
                        room_name,
                        price,
                        area,
                        status
                    FROM Room
                    ORDER BY room_name";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                data = new DataTable();
                da.Fill(data);

                // Quan trọng: tên Table phải trùng với ReferenceName trong .frx
                data.TableName = "Room";

                dgvRoom.DataSource = data;
                dgvRoom.Columns["id"].HeaderText = "Mã phòng";
                dgvRoom.Columns["room_name"].HeaderText = "Tên phòng";
                dgvRoom.Columns["price"].HeaderText = "Giá phòng";
                dgvRoom.Columns["area"].HeaderText = "Diện tích (m²)";
                dgvRoom.Columns["status"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu:\n" + ex.Message);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dgvRoom.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "DanhSachPhong.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Report report = new Report();
                string reportPath = Path.Combine(Application.StartupPath, "ReportListRoom.frx");

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file ReportListRoom.frx");
                    return;
                }

                report.Load(reportPath);

                // Quan trọng: true = đăng ký tất cả Table bên trong DataSet
                report.RegisterData(data, "Room");
                // Bật DataSource đúng tên Table
                report.GetDataSource("Room").Enabled = true;

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
