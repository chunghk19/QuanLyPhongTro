using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro_1
{
    public partial class FormDashboard : Form
    {
        FlowLayoutPanel flpTop;
        Panel pnlBottom;
        DataGridView dgvExpire;

        public FormDashboard()
        {
            InitializeComponent();
            BuildUI();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // QUAN TRỌNG NHẤT – FILL MDI
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
        }

        private void BuildUI()
        {
            this.BackColor = Color.White;

            // ===== FLOWLAYOUT TOP =====
            flpTop = new FlowLayoutPanel();
            flpTop.Dock = DockStyle.Top;
            flpTop.Height = 160;
            flpTop.Padding = new Padding(15);
            flpTop.WrapContents = false;

            flpTop.Controls.Add(CreateCard("Tổng phòng", "0", Color.LightSteelBlue));
            flpTop.Controls.Add(CreateCard("Phòng trống", "0", Color.LightGreen));
            flpTop.Controls.Add(CreateCard("Đang thuê", "0", Color.LightSalmon));
            flpTop.Controls.Add(CreateCard("Khách đang ở", "0", Color.LightSkyBlue));
            flpTop.Controls.Add(CreateCard("Doanh thu tháng", "0 ₫", Color.Khaki));

            // ===== PANEL BOTTOM =====
            pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Padding = new Padding(15);

            GroupBox gb = new GroupBox();
            gb.Text = "⚠ Phòng sắp hết hạn hợp đồng";
            gb.Dock = DockStyle.Fill;

            dgvExpire = new DataGridView();
            dgvExpire.Dock = DockStyle.Fill;
            dgvExpire.ReadOnly = true;
            dgvExpire.AllowUserToAddRows = false;
            dgvExpire.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gb.Controls.Add(dgvExpire);
            pnlBottom.Controls.Add(gb);

            // ===== ADD TO FORM =====
            this.Controls.Add(pnlBottom);
            this.Controls.Add(flpTop);
        }

        private Panel CreateCard(string title, string value, Color color)
        {
            Panel card = new Panel();
            card.Size = new Size(190, 110);
            card.BackColor = color;
            card.Margin = new Padding(10);

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblValue.Location = new Point(15, 25);
            lblValue.AutoSize = true;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 9);
            lblTitle.Location = new Point(15, 75);
            lblTitle.AutoSize = true;

            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);

            return card;
        }
    }
}