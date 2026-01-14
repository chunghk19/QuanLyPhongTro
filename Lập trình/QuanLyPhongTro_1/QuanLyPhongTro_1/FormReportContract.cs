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
    public partial class FormReportContract : Form
    {
        private ComboBox cbTenant;
        private DataGridView dgvContracts;
        private Button btnExportPDF;
        private DataTable contractData;
        private string connStr = DbHelper.ConnectionString;

        public FormReportContract()
        {
            this.Text = "Quản lý hợp đồng";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeControls();
            LoadTenantFilter();
            LoadContractData();
        }

        private void InitializeControls()
        {
            cbTenant = new ComboBox
            {
                Location = new Point(20, 20),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbTenant.SelectedIndexChanged += (s, e) => LoadContractData();
            this.Controls.Add(cbTenant);

            btnExportPDF = new Button
            {
                Text = "Xuất PDF",
                Location = new Point(290, 20),
                Size = new Size(100, 25)
            };
            btnExportPDF.Click += BtnExportPDF_Click;
            this.Controls.Add(btnExportPDF);

            dgvContracts = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(940, 480),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            this.Controls.Add(dgvContracts);
        }

        private void LoadTenantFilter()
        {
            cbTenant.Items.Clear();
            cbTenant.Items.Add("Tất cả");

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT id, full_name FROM Tenant WHERE is_active = 1", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbTenant.Items.Add(new { Id = reader.GetInt32("id"), Name = reader.GetString("full_name") });
                }
            }

            cbTenant.DisplayMember = "Name";
            cbTenant.ValueMember = "Id";
            cbTenant.SelectedIndex = 0;
        }

        private DataTable GetContractData()
        {
            contractData = new DataTable();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT c.id AS contract_id, t.full_name, t.phone, t.id_card, t.address,
                           r.room_name, c.start_date, c.end_date, c.deposit, c.price AS room_price
                    FROM Contract c
                    INNER JOIN Contract_Tenant ct ON c.id = ct.contract_id
                    INNER JOIN Tenant t ON ct.tenant_id = t.id
                    INNER JOIN Room r ON c.room_id = r.id
                    WHERE c.is_active = 1";

                if (cbTenant.SelectedIndex > 0)
                    sql += " AND t.id = @tenantId";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (cbTenant.SelectedIndex > 0)
                {
                    dynamic selected = cbTenant.SelectedItem;
                    cmd.Parameters.AddWithValue("@tenantId", selected.Id);
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(contractData);
            }

            contractData.TableName = "Contracts";
            return contractData;
        }

        private void LoadContractData()
        {
            contractData = GetContractData();
            dgvContracts.DataSource = contractData;
            if (contractData.Columns.Contains("contract_id")) dgvContracts.Columns["contract_id"].HeaderText = "Mã hợp đồng";
            if (contractData.Columns.Contains("full_name")) dgvContracts.Columns["full_name"].HeaderText = "Tên khách";
            if (contractData.Columns.Contains("phone")) dgvContracts.Columns["phone"].HeaderText = "SĐT";
            if (contractData.Columns.Contains("id_card")) dgvContracts.Columns["id_card"].HeaderText = "CCCD";
            if (contractData.Columns.Contains("address")) dgvContracts.Columns["address"].HeaderText = "Địa chỉ";
            if (contractData.Columns.Contains("room_name")) dgvContracts.Columns["room_name"].HeaderText = "Phòng thuê";
            if (contractData.Columns.Contains("start_date")) dgvContracts.Columns["start_date"].HeaderText = "Ngày bắt đầu";
            if (contractData.Columns.Contains("end_date")) dgvContracts.Columns["end_date"].HeaderText = "Ngày kết thúc";
            if (contractData.Columns.Contains("deposit")) dgvContracts.Columns["deposit"].HeaderText = "Tiền đặt cọc";
            if (contractData.Columns.Contains("room_price")) dgvContracts.Columns["room_price"].HeaderText = "Giá phòng";
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            contractData = GetContractData();
            if (contractData.Rows.Count == 0)
            {
                MessageBox.Show("Không có hợp đồng để xuất PDF!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "HopDong.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Report report = new Report();
                string reportPath = Path.Combine(Application.StartupPath, "ReportContract.frx");

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file ReportContract.frx");
                    return;
                }

                report.Load(reportPath);
                report.RegisterData(contractData, "Contracts");
                report.GetDataSource("Contracts").Enabled = true;

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
