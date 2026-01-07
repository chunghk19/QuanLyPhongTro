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

namespace QuanLyPhongTro_1
{
    public partial class FormService : Form
    {
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
        public FormService()
        {
            InitializeComponent();
            BuildResponsiveLayout();
            loadform();
        }

        private void BuildResponsiveLayout()
        {
            // ==== FORM ====
            this.Controls.Clear();
            this.WindowState = FormWindowState.Maximized;
            this.Font = new Font("Segoe UI", 10F);
            this.AutoScaleMode = AutoScaleMode.Font;

            // ===== TABLE MAIN =====
            TableLayoutPanel tableMain = new TableLayoutPanel();
            tableMain.Dock = DockStyle.Fill;
            tableMain.ColumnCount = 1;
            tableMain.RowCount = 2;
            tableMain.Padding = new Padding(15);

            tableMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));     // Chi tiết
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Danh sách

            // ================= GROUPBOX CHI TIẾT =================
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Padding = new Padding(10);

            // ---- TABLE DETAIL ----
            TableLayoutPanel tableDetail = new TableLayoutPanel();
            tableDetail.Dock = DockStyle.Fill;
            tableDetail.ColumnCount = 2;
            tableDetail.RowCount = 3;

            tableDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            tableDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 45));

            // Label
            label1.Text = "Tên dịch vụ";
            label2.Text = "Giá dịch vụ";

            label1.TextAlign = ContentAlignment.MiddleLeft;
            label2.TextAlign = ContentAlignment.MiddleLeft;

            // TextBox
            txtServiceName.Dock = DockStyle.Fill;
            txtPrice.Dock = DockStyle.Fill;

            txtServiceName.AutoSize = false;
            txtPrice.AutoSize = false;
            txtServiceName.Height = 30;
            txtPrice.Height = 30;

            // ---- BUTTON PANEL ----
            FlowLayoutPanel panelButton = new FlowLayoutPanel();
            panelButton.AutoSize = true;
            panelButton.Dock = DockStyle.Left;
            panelButton.FlowDirection = FlowDirection.LeftToRight;
            panelButton.WrapContents = false;
            panelButton.Padding = new Padding(0, 5, 0, 5);

            btnAdd.Size = new Size(90, 32);
            btnUpdate.Size = new Size(90, 32);
            btnDelete.Size = new Size(90, 32);

            btnAdd.Margin = new Padding(0, 0, 10, 0);
            btnUpdate.Margin = new Padding(0, 0, 10, 0);
            btnDelete.Margin = new Padding(0);

            panelButton.Controls.Add(btnAdd);
            panelButton.Controls.Add(btnUpdate);
            panelButton.Controls.Add(btnDelete);

            // Add to detail table
            tableDetail.Controls.Add(label1, 0, 0);
            tableDetail.Controls.Add(txtServiceName, 1, 0);
            tableDetail.Controls.Add(label2, 0, 1);
            tableDetail.Controls.Add(txtPrice, 1, 1);
            tableDetail.Controls.Add(panelButton, 1, 2);

            groupBox1.Controls.Add(tableDetail);

            // ================= GROUPBOX DANH SÁCH =================
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Padding = new Padding(10);

            dgvService.Dock = DockStyle.Fill;
            dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvService.RowTemplate.Height = 32;
            dgvService.AllowUserToAddRows = false;
            dgvService.ReadOnly = true;

            groupBox2.Controls.Add(dgvService);

            // ===== ADD TO MAIN =====
            tableMain.Controls.Add(groupBox1, 0, 0);
            tableMain.Controls.Add(groupBox2, 0, 1);

            this.Controls.Add(tableMain);
        }


        private void loadform()
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from Service", conn);
                    DataTable dt = new DataTable();
                    mySqlDataAdapter.Fill(dt);
                    dgvService.DataSource = dt;
                    dgvService.Columns["id"].HeaderText = "Mã dịch vụ";
                    dgvService.Columns["service_name"].HeaderText = "Tên dịch vụ";
                    dgvService.Columns["price"].HeaderText = "Giá dịch vụ";
                    dgvService.Columns["is_active"].HeaderText = "Đang hoạt động";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string insert = "insert into Service (service_name, price) values (@service_name, @price)";
                    MySqlCommand mySqlCommand = new MySqlCommand(insert, conn);
                    mySqlCommand.Parameters.AddWithValue("@service_name", txtServiceName.Text);
                    mySqlCommand.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                    mySqlCommand.ExecuteNonQuery();
                    loadform();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int selectID = 0;
        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    object cellID = dgvService.Rows[e.RowIndex].Cells["id"].Value;
                    if (cellID != null)
                    {
                        //txtID.Text = cellID.ToString();
                        selectID = int.Parse(cellID.ToString());
                    }
                    object cellTenDV = dgvService.Rows[e.RowIndex].Cells["service_name"].Value;
                    if (cellTenDV != null)
                    {
                        txtServiceName.Text = cellTenDV.ToString();
                    }
                    object price = dgvService.Rows[e.RowIndex].Cells["price"].Value;
                    if (price != null)
                    {
                        txtPrice.Text = price.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("bạn chọn vào ô trống");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn có muốn cập nhật dữ liêu?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    try
                    {
                        conn.Open();
                        string update = "update Service set service_name = @name, price = @price where id = @id";
                        MySqlCommand mySqlCommand = new MySqlCommand(update, conn);
                        mySqlCommand.Parameters.AddWithValue("@name", txtServiceName.Text);
                        mySqlCommand.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                        mySqlCommand.Parameters.AddWithValue("@id", selectID);
                        mySqlCommand.ExecuteNonQuery();
                        loadform();
                        txtPrice.Clear();
                        txtServiceName.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }
    }
}
