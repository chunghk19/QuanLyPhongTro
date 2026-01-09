using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyPhongTro_1.Common;
using Timer = System.Windows.Forms.Timer;

namespace QuanLyPhongTro_1
{
    public partial class FormDashboard : Form
    {
        FlowLayoutPanel flpTop;
        Panel pnlBottom;
        DataGridView dgvExpire;

        Label lblTotalRoom;
        Label lblEmptyRoom;
        Label lblRentedRoom;
        Label lblTenant;
        Label lblRevenue;

        Timer refreshTimer;

        string conStr = DbHelper.ConnectionString;

        public FormDashboard()
        {
            InitializeComponent();
            BuildUI();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;

            LoadDashboard();

            refreshTimer = new Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += (s, ev) => LoadDashboard();
            refreshTimer.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            refreshTimer?.Stop();
            base.OnFormClosing(e);
        }

        private void BuildUI()
        {
            this.BackColor = Color.White;

            flpTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 160,
                Padding = new Padding(15),
                WrapContents = false
            };

            flpTop.Controls.Add(CreateCard("Tổng phòng", out lblTotalRoom, Color.LightSteelBlue));
            flpTop.Controls.Add(CreateCard("Phòng trống", out lblEmptyRoom, Color.LightGreen));
            flpTop.Controls.Add(CreateCard("Đang thuê", out lblRentedRoom, Color.LightSalmon));
            flpTop.Controls.Add(CreateCard("Khách đang ở", out lblTenant, Color.LightSkyBlue));
            flpTop.Controls.Add(CreateCard("Doanh thu tháng", out lblRevenue, Color.Khaki));

            pnlBottom = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15)
            };

            GroupBox gb = new GroupBox
            {
                Text = "⚠ Hợp đồng sắp hết hạn (30 ngày)",
                Dock = DockStyle.Fill
            };

            dgvExpire = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvExpire.CellContentClick += dgvExpire_CellContentClick;

            gb.Controls.Add(dgvExpire);
            pnlBottom.Controls.Add(gb);

            this.Controls.Add(pnlBottom);
            this.Controls.Add(flpTop);
        }

        private Panel CreateCard(string title, out Label lblValue, Color color)
        {
            Panel card = new Panel
            {
                Size = new Size(190, 110),
                BackColor = color,
                Margin = new Padding(10)
            };

            lblValue = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(15, 25),
                AutoSize = true
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 75),
                AutoSize = true
            };

            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);
            return card;
        }

        private void LoadDashboard()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();

                lblTotalRoom.Text = ExecuteScalar(conn,
                    "SELECT COUNT(*) FROM Room WHERE is_active = 1");

                lblEmptyRoom.Text = ExecuteScalar(conn,
                    "SELECT COUNT(*) FROM Room WHERE status='Trống' AND is_active=1");

                lblRentedRoom.Text = ExecuteScalar(conn,
                    "SELECT COUNT(*) FROM Room WHERE status='Đang thuê' AND is_active=1");

                lblTenant.Text = ExecuteScalar(conn, @"
                    SELECT COUNT(DISTINCT t.id)
                    FROM Tenant t
                    JOIN Contract_Tenant ct ON t.id = ct.tenant_id
                    JOIN Contract c ON ct.contract_id = c.id
                    WHERE t.is_active = 1 AND c.is_active = 1
                ");

                lblRevenue.Text = string.Format("{0:N0} ₫", ExecuteScalar(conn, @"
                    SELECT IFNULL(SUM(total_cost),0)
                    FROM Invoice
                    WHERE month = MONTH(CURDATE())
                      AND year = YEAR(CURDATE())
                      AND status = 'Đã thanh toán'
                "));

                MySqlDataAdapter da = new MySqlDataAdapter(@"
                    SELECT 
                        c.id AS contract_id,
                        r.room_name AS 'Phòng',
                        c.end_date AS 'Ngày hết hạn',
                        DATEDIFF(c.end_date, CURDATE()) AS 'Còn lại (ngày)'
                    FROM Contract c
                    JOIN Room r ON c.room_id = r.id
                    WHERE c.is_active = 1
                      AND c.end_date IS NOT NULL
                      AND DATEDIFF(c.end_date, CURDATE()) BETWEEN 0 AND 30
                    ORDER BY c.end_date
                ", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvExpire.DataSource = dt;

                dgvExpire.Columns["contract_id"].Visible = false;

                if (!dgvExpire.Columns.Contains("btnRenew"))
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                    {
                        Name = "btnRenew",
                        HeaderText = "Hành động",
                        Text = "Gia hạn",
                        UseColumnTextForButtonValue = true
                    };
                    dgvExpire.Columns.Add(btn);
                }
            }
        }

        private void dgvExpire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvExpire.Columns[e.ColumnIndex].Name != "btnRenew") return;

            int contractId = Convert.ToInt32(
                dgvExpire.Rows[e.RowIndex].Cells["contract_id"].Value
            );

            using (FormRenewContract f = new FormRenewContract (contractId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDashboard();
                }
            }
        }


        private string ExecuteScalar(MySqlConnection conn, string sql)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                object result = cmd.ExecuteScalar();
                return result == null ? "0" : result.ToString();
            }
        }
    }
}
