using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FastReport.Export.PdfSimple;
using FastReport;
using MySql.Data.MySqlClient;
using QuanLyPhongTro_1.Common;
using System.IO;

namespace QuanLyPhongTro_1
{
    public partial class FormInvoice : Form
    {
        ComboBox cbRoom, cbFilter;
        DateTimePicker dpMonth;
        TextBox txtRoomPrice, txtElectric, txtWater, txtService, txtOther, txtTotal;
        Button btnCreate, btnExportPDF;
        DataGridView dgvInvoices;
        TableLayoutPanel tlpMain;

        // ---------- Biến lưu hóa đơn hiện tại ----------
        DataTable currentInvoiceData;

        public FormInvoice()
        {
            InitializeComponent();
            InitUI();
            LoadRooms();
            LoadInvoiceList();
        }

        TextBox AddRowDetail(TableLayoutPanel tlp, string label, int row)
        {
            Label lbl = new Label()
            {
                Text = label,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Anchor = AnchorStyles.Left
            };

            TextBox txt = new TextBox()
            {
                ReadOnly = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Margin = new Padding(0, 0, 0, 5)
            };

            tlp.Controls.Add(lbl, 0, row);
            tlp.Controls.Add(txt, 1, row);
            return txt;
        }

        void InitUI()
        {
            this.Text = "LẬP HÓA ĐƠN";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(900, 600);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // TableLayoutPanel chính
            tlpMain = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(10),
            };
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.Controls.Add(tlpMain);

            // GroupBox Chi tiết
            GroupBox gbDetail = new GroupBox() { Text = "Chi tiết hóa đơn", Dock = DockStyle.Fill };
            TableLayoutPanel tlpDetail = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 9,
                Padding = new Padding(10),
            };
            tlpDetail.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < tlpDetail.RowCount; i++)
                tlpDetail.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Labels + Controls
            Label lblRoom = new Label() { Text = "Phòng - Khách thuê", AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Anchor = AnchorStyles.Left };
            cbRoom = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Left | AnchorStyles.Right, Margin = new Padding(0, 0, 0, 5) };
            cbRoom.SelectedIndexChanged += (s, e) => LoadCosts();
            tlpDetail.Controls.Add(lblRoom, 0, 0);
            tlpDetail.Controls.Add(cbRoom, 1, 0);

            Label lblMonth = new Label() { Text = "Tháng", AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Anchor = AnchorStyles.Left };
            dpMonth = new DateTimePicker() { Format = DateTimePickerFormat.Custom, CustomFormat = "MM/yyyy", Anchor = AnchorStyles.Left | AnchorStyles.Right, Margin = new Padding(0, 0, 0, 5) };
            dpMonth.ValueChanged += (s, e) => LoadCosts();
            tlpDetail.Controls.Add(lblMonth, 0, 1);
            tlpDetail.Controls.Add(dpMonth, 1, 1);

            txtRoomPrice = AddRowDetail(tlpDetail, "Tiền phòng", 2);
            txtElectric = AddRowDetail(tlpDetail, "Tiền điện", 3);
            txtWater = AddRowDetail(tlpDetail, "Tiền nước", 4);
            txtService = AddRowDetail(tlpDetail, "Dịch vụ", 5);

            Label lblOther = new Label() { Text = "Chi phí khác", AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Anchor = AnchorStyles.Left };
            txtOther = new TextBox() { Text = "0", Anchor = AnchorStyles.Left | AnchorStyles.Right, Margin = new Padding(0, 0, 0, 5) };
            txtOther.TextChanged += (s, e) => CalcTotal();
            tlpDetail.Controls.Add(lblOther, 0, 6);
            tlpDetail.Controls.Add(txtOther, 1, 6);

            txtTotal = AddRowDetail(tlpDetail, "TỔNG TIỀN", 7);
            txtTotal.Font = new Font(txtTotal.Font.FontFamily, 10, FontStyle.Regular);

            // Buttons căn trái
            FlowLayoutPanel pnlButtons = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Padding = new Padding(0),
            };

            btnCreate = new Button()
            {
                Text = "LẬP HÓA ĐƠN",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Margin = new Padding(0, 0, 10, 0)
            };
            btnCreate.Click += BtnCreate_Click;

            btnExportPDF = new Button()
            {
                Text = "XUẤT PDF",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Margin = new Padding(0)
            };
            btnExportPDF.Click += BtnExportPDF_Click;

            pnlButtons.Controls.Add(btnCreate);
            pnlButtons.Controls.Add(btnExportPDF);

            tlpDetail.Controls.Add(pnlButtons, 1, 8);
            tlpDetail.RowStyles[8] = new RowStyle(SizeType.AutoSize);

            gbDetail.Controls.Add(tlpDetail);
            tlpMain.Controls.Add(gbDetail, 0, 0);

            // GroupBox Danh sách
            GroupBox gbInvoice = new GroupBox() { Text = "Danh sách hóa đơn", Dock = DockStyle.Fill };
            TableLayoutPanel tlpInvoice = new TableLayoutPanel() { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
            tlpInvoice.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpInvoice.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            FlowLayoutPanel pnlFilter = new FlowLayoutPanel() { Dock = DockStyle.Top, AutoSize = true };
            Label lblFilter = new Label() { Text = "Lọc hóa đơn", AutoSize = true, Anchor = AnchorStyles.Left };
            cbFilter = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
            cbFilter.Items.AddRange(new string[] { "Tất cả", "Người thuê hiện tại", "Người thuê cũ" });
            cbFilter.SelectedIndex = 0;
            cbFilter.SelectedIndexChanged += (s, e) => LoadInvoiceList();
            pnlFilter.Controls.Add(lblFilter);
            pnlFilter.Controls.Add(cbFilter);

            dgvInvoices = new DataGridView()
            {
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ScrollBars = ScrollBars.Both
            };
            dgvInvoices.CellClick += DgvInvoices_CellClick;

            tlpInvoice.Controls.Add(pnlFilter, 0, 0);
            tlpInvoice.Controls.Add(dgvInvoices, 0, 1);
            gbInvoice.Controls.Add(tlpInvoice);
            tlpMain.Controls.Add(gbInvoice, 1, 0);
        }

        void LoadRooms()
        {
            string sql = @"
                SELECT r.id, CONCAT(r.room_name, ' - ', t.full_name) AS room_tenant
                FROM Room r
                JOIN Contract c ON r.id = c.room_id AND c.is_active = 1
                JOIN Contract_Tenant ct ON ct.contract_id = c.id AND ct.is_primary = 1
                JOIN Tenant t ON ct.tenant_id = t.id AND t.is_active = 1
                WHERE r.is_active = 1
                ORDER BY r.room_name";
            using (var conn = DbHelper.GetConnection())
            using (var da = new MySqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbRoom.DataSource = dt;
                cbRoom.DisplayMember = "room_tenant";
                cbRoom.ValueMember = "id";
            }
        }

        private bool TryGetSelectedRoomId(out int roomId)
        {
            roomId = 0;
            if (cbRoom.SelectedItem == null) return false;
            if (!(cbRoom.SelectedItem is DataRowView row)) return false;
            if (row["id"] == DBNull.Value) return false;
            roomId = Convert.ToInt32(row["id"]);
            return true;
        }

        void LoadCosts()
        {
            if (!TryGetSelectedRoomId(out int roomId)) return;
            int month = dpMonth.Value.Month;
            int year = dpMonth.Value.Year;
            DataRow contract = GetActiveContract(roomId);
            if (contract == null) return;
            txtRoomPrice.Text = contract["price"].ToString();
            DataRow c = GetConsumption(roomId, month, year);
            if (c == null)
            {
                txtElectric.Text = "0";
                txtWater.Text = "0";
            }
            else
            {
                decimal elec = (Convert.ToInt32(c["electric_new"]) - Convert.ToInt32(c["electric_old"]))
                               * Convert.ToDecimal(c["electric_price_per_kwh"]);
                decimal water = (Convert.ToInt32(c["water_new"]) - Convert.ToInt32(c["water_old"]))
                                * Convert.ToDecimal(c["water_price_per_m3"]);
                txtElectric.Text = elec.ToString("N0");
                txtWater.Text = water.ToString("N0");
            }
            txtService.Text = GetServiceCost(roomId).ToString("N0");
            CalcTotal();
        }

        void CalcTotal()
        {
            decimal total = ToDec(txtRoomPrice) + ToDec(txtElectric) + ToDec(txtWater) + ToDec(txtService) + ToDec(txtOther);
            txtTotal.Text = total.ToString("N0");
        }

        decimal ToDec(TextBox t)
        {
            decimal.TryParse(t.Text.Replace(",", ""), out decimal v);
            return v;
        }

        DataRow GetActiveContract(int roomId)
        {
            string sql = @"SELECT * FROM Contract WHERE room_id=@r AND is_active=1 LIMIT 1";
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@r", roomId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        DataRow GetConsumption(int roomId, int m, int y)
        {
            string sql = @"SELECT * FROM consumption WHERE room_id=@r AND month=@m AND year=@y";
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@r", roomId);
                cmd.Parameters.AddWithValue("@m", m);
                cmd.Parameters.AddWithValue("@y", y);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        decimal GetServiceCost(int roomId)
        {
            string sql = @"SELECT IFNULL(SUM(s.price),0)
                           FROM Room_Service rs
                           JOIN Service s ON rs.service_id = s.id
                           WHERE rs.room_id=@r AND s.is_active=1";
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@r", roomId);
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedRoomId(out int roomId))
            {
                MessageBox.Show("Vui lòng chọn phòng hợp lệ");
                return;
            }
            int month = dpMonth.Value.Month;
            int year = dpMonth.Value.Year;
            DataRow contract = GetActiveContract(roomId);
            if (contract == null)
            {
                MessageBox.Show("Phòng chưa có hợp đồng");
                return;
            }
            int contractId = Convert.ToInt32(contract["id"]);
            string checkSql = @"SELECT COUNT(*) FROM Invoice WHERE contract_id=@c AND month=@m AND year=@y";
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(checkSql, conn))
            {
                cmd.Parameters.AddWithValue("@c", contractId);
                cmd.Parameters.AddWithValue("@m", month);
                cmd.Parameters.AddWithValue("@y", year);
                conn.Open();
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("Hóa đơn đã tồn tại");
                    return;
                }
            }
            string insert = @"
                INSERT INTO Invoice
                (contract_id, month, year, room_price, electric_cost, water_cost,
                 service_cost, other_cost, total_cost, status)
                VALUES
                (@c,@m,@y,@r,@e,@w,@s,@o,@t,'Chờ thanh toán')";
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@c", contractId);
                cmd.Parameters.AddWithValue("@m", month);
                cmd.Parameters.AddWithValue("@y", year);
                cmd.Parameters.AddWithValue("@r", ToDec(txtRoomPrice));
                cmd.Parameters.AddWithValue("@e", ToDec(txtElectric));
                cmd.Parameters.AddWithValue("@w", ToDec(txtWater));
                cmd.Parameters.AddWithValue("@s", ToDec(txtService));
                cmd.Parameters.AddWithValue("@o", ToDec(txtOther));
                cmd.Parameters.AddWithValue("@t", ToDec(txtTotal));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Lập hóa đơn thành công");
            LoadInvoiceList();
        }

        void LoadInvoiceList()
        {
            string sql = @"
                SELECT i.id, r.room_name AS 'Phòng', t.full_name AS 'Người thuê',
                       i.month AS 'Tháng', i.year AS 'Năm', i.room_price AS 'Tiền phòng',
                       i.electric_cost AS 'Tiền điện', i.water_cost AS 'Tiền nước',
                       i.service_cost AS 'Dịch vụ', i.other_cost AS 'Chi phí khác',
                       i.total_cost AS 'Tổng tiền', i.paid_amount AS 'Đã thanh toán',
                       i.status AS 'Trạng thái',
                       c.is_active AS 'contract_active'
                FROM Invoice i
                JOIN Contract c ON i.contract_id = c.id
                JOIN Room r ON c.room_id = r.id
                JOIN Contract_Tenant ct ON ct.contract_id = c.id AND ct.is_primary=1
                JOIN Tenant t ON ct.tenant_id = t.id";

            if (cbFilter.SelectedItem != null)
            {
                string filter = cbFilter.SelectedItem.ToString();
                if (filter == "Người thuê hiện tại")
                    sql += " WHERE c.is_active = 1 ";
                else if (filter == "Người thuê cũ")
                    sql += " WHERE c.is_active = 0 ";
            }

            sql += " ORDER BY i.year DESC, i.month DESC, r.room_name";

            using (var conn = DbHelper.GetConnection())
            using (var da = new MySqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (!dt.Columns.Contains("Người thuê - Trạng thái"))
                    dt.Columns.Add("Người thuê - Trạng thái", typeof(string));

                foreach (DataRow row in dt.Rows)
                    row["Người thuê - Trạng thái"] = Convert.ToBoolean(row["contract_active"]) ? "Hiện tại" : "Cũ";

                dgvInvoices.DataSource = dt;

                if (dgvInvoices.Columns.Contains("contract_active"))
                    dgvInvoices.Columns["contract_active"].Visible = false;

                dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvInvoices.ScrollBars = ScrollBars.Both;

                foreach (DataGridViewColumn col in dgvInvoices.Columns)
                {
                    col.MinimumWidth = 100;
                    if (col.Name == "Phòng") col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                string[] moneyCols = { "Tiền phòng", "Tiền điện", "Tiền nước", "Dịch vụ", "Chi phí khác", "Tổng tiền", "Đã thanh toán" };
                foreach (DataGridViewColumn col in dgvInvoices.Columns)
                {
                    if (moneyCols.Contains(col.Name))
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    else
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (moneyCols.Contains(col.Name))
                        col.DefaultCellStyle.Format = "N0";
                }

                dgvInvoices.Dock = DockStyle.Fill;
            }
        }

        private void DgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvInvoices.Rows[e.RowIndex];

            int invoiceId = Convert.ToInt32(row.Cells["id"].Value);

            // Lấy dữ liệu hóa đơn từ DB
            string sql = @"
                SELECT i.id, r.room_name, t.full_name AS tenant_name,
                       i.month, i.year, i.room_price, i.electric_cost, i.water_cost,
                       i.service_cost, i.other_cost, i.total_cost, i.paid_amount, i.status
                FROM Invoice i
                JOIN Contract c ON i.contract_id = c.id
                JOIN Room r ON c.room_id = r.id
                JOIN Contract_Tenant ct ON ct.contract_id = c.id AND ct.is_primary=1
                JOIN Tenant t ON ct.tenant_id = t.id
                WHERE i.id=@id";

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", invoiceId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                currentInvoiceData = new DataTable();
                da.Fill(currentInvoiceData);
            }

            int roomId = GetRoomIdByName(row.Cells["Phòng"].Value.ToString());
            if (roomId > 0)
            {
                cbRoom.SelectedValue = roomId;
                dpMonth.Value = new DateTime(
                    Convert.ToInt32(row.Cells["Năm"].Value),
                    Convert.ToInt32(row.Cells["Tháng"].Value),
                    1
                );
                txtOther.Text = row.Cells["Chi phí khác"].Value?.ToString() ?? "0";
                DataRow contract = GetActiveContract(roomId);
                if (contract != null)
                {
                    txtRoomPrice.Text = contract["price"].ToString();
                    DataRow c = GetConsumption(roomId, dpMonth.Value.Month, dpMonth.Value.Year);
                    if (c != null)
                    {
                        decimal elec = (Convert.ToInt32(c["electric_new"]) - Convert.ToInt32(c["electric_old"]))
                                       * Convert.ToDecimal(c["electric_price_per_kwh"]);
                        decimal water = (Convert.ToInt32(c["water_new"]) - Convert.ToInt32(c["water_old"]))
                                        * Convert.ToDecimal(c["water_price_per_m3"]);
                        txtElectric.Text = elec.ToString("N0");
                        txtWater.Text = water.ToString("N0");
                    }
                    else
                    {
                        txtElectric.Text = "0";
                        txtWater.Text = "0";
                    }
                    txtService.Text = GetServiceCost(roomId).ToString("N0");
                }
                CalcTotal();
            }
        }

        private int GetRoomIdByName(string roomName)
        {
            foreach (DataRowView drv in cbRoom.Items)
            {
                if (drv["room_tenant"].ToString().StartsWith(roomName))
                    return Convert.ToInt32(drv["id"]);
            }
            return 0;
        }

        // ---------- Xuất PDF / mở FormReport ----------
        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (currentInvoiceData == null || currentInvoiceData.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trong danh sách trước khi xuất PDF");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF File (*.pdf)|*.pdf",
                FileName = "HoaDon.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Report report = new Report();

                // Đường dẫn file frx
                string reportPath = Path.Combine(Application.StartupPath, "ReportInvoice.frx");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file ReportInvoice.frx");
                    return;
                }

                // Load report
                report.Load(reportPath);

                // Đổ DataTable vào report
                report.RegisterData(currentInvoiceData, "Invoice");
                report.GetDataSource("Invoice").Enabled = true;

                // BẮT BUỘC
                report.Prepare();

                // Xuất PDF
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
