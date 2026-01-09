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
using QuanLyPhongTro_1.Common;

namespace QuanLyPhongTro_1
{

    public partial class FormTenant : Form
    {
        string str = DbHelper.ConnectionString;
        public FormTenant()
        {
            InitializeComponent();
            OverrideDesignBeautiful();
            loadForm();
        }

        private void OverrideDesignBeautiful()
        {
            // ===== XÓA GIAO DIỆN CŨ =====
            this.Controls.Clear();

            // ===== FONT =====
            Font fontTitle = new Font("Segoe UI Semibold", 18F);
            Font fontSection = new Font("Segoe UI Semibold", 14F);
            Font fontLabel = new Font("Segoe UI", 11F);
            Font fontInput = new Font("Segoe UI", 11F);
            Font fontButton = new Font("Segoe UI Semibold", 11F);
            Font fontGrid = new Font("Segoe UI", 11F);

            // ===== FORM =====
            this.Text = "Quản Lý Khách Thuê";
            this.MinimumSize = new Size(1000, 600);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // ===== MAIN LAYOUT =====
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                BackColor = Color.White
            };
            mainLayout.RowStyles.Clear();
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));  // title
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));   // detail
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));   // grid

            // ===== TITLE =====
            var lblTitle = new Label
            {
                Text = "QUẢN LÝ KHÁCH THUÊ",
                Dock = DockStyle.Fill,
                Font = fontTitle,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            mainLayout.Controls.Add(lblTitle, 0, 0);

            // ===== FORM INPUT (Detail) =====
            var formLayout = new TableLayoutPanel
            {
                Padding = new Padding(20),
                ColumnCount = 4,
                AutoSize = true
            };

            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

            // ===== STYLE =====
            void StyleInput(Control c)
            {
                c.Font = fontInput;
                c.Dock = DockStyle.Fill;
                c.Margin = new Padding(6);
                c.MinimumSize = new Size(100, 30);
            }

            void StyleRoundButton(Button b, Color color)
            {
                b.Font = fontButton;
                b.Height = 42;
                b.Width = 160;
                b.BackColor = color;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.MinimumSize = new Size(80, 35);
            }

            // ===== INPUT =====
            txtSearch.PlaceholderText = "🔍 Nhập tên hoặc số điện thoại...";
            StyleInput(txtSearch);
            StyleInput(txtFullName);
            StyleInput(txtCCCD);
            StyleInput(txtAddress);
            StyleInput(txtPhoneNumber);

            StyleRoundButton(btnSearch, Color.Gainsboro);
            StyleRoundButton(btnAdd, Color.LightSkyBlue);
            StyleRoundButton(btnUpdate, Color.Gold);
            StyleRoundButton(btnDelete, Color.Salmon);

            // ===== ADD INPUT =====
            formLayout.Controls.Add(btnSearch, 0, 0);
            formLayout.Controls.Add(txtSearch, 1, 0);
            formLayout.SetColumnSpan(txtSearch, 3);

            formLayout.Controls.Add(new Label { Text = "Họ và tên", Font = fontLabel }, 0, 1);
            formLayout.Controls.Add(txtFullName, 1, 1);
            formLayout.SetColumnSpan(txtFullName, 3);

            formLayout.Controls.Add(new Label { Text = "CCCD", Font = fontLabel }, 0, 2);
            formLayout.Controls.Add(txtCCCD, 1, 2);
            formLayout.SetColumnSpan(txtCCCD, 3);

            formLayout.Controls.Add(new Label { Text = "Địa chỉ", Font = fontLabel }, 0, 3);
            formLayout.Controls.Add(txtAddress, 1, 3);
            formLayout.SetColumnSpan(txtAddress, 3);

            formLayout.Controls.Add(new Label { Text = "SĐT", Font = fontLabel }, 0, 4);
            formLayout.Controls.Add(txtPhoneNumber, 1, 4);
            formLayout.SetColumnSpan(txtPhoneNumber, 2);

            // ===== BUTTON PANEL =====
            var buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = false,
                Height = 50,
                WrapContents = false,
                AutoScroll = true, // scroll ngang nếu cần
                Dock = DockStyle.Fill
            };
            buttonPanel.Controls.Add(btnAdd);
            buttonPanel.Controls.Add(btnUpdate);
            buttonPanel.Controls.Add(btnDelete);
            formLayout.Controls.Add(buttonPanel, 1, 5);
            formLayout.SetColumnSpan(buttonPanel, 3);

            // ===== SEPARATOR =====
            var separator = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 2,
                BackColor = Color.LightGray,
                Margin = new Padding(0, 10, 0, 10)
            };
            formLayout.Controls.Add(separator);
            formLayout.SetColumnSpan(separator, 4);

            // ===== Bọc formLayout vào panel có AutoScroll =====
            var scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White
            };
            formLayout.Dock = DockStyle.Top; // ❌ không Dock Fill để scroll dọc xuất hiện
            scrollPanel.Controls.Add(formLayout);

            // ===== GRID SECTION =====
            var gridContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            var lblGridTitle = new Label
            {
                Text = "Danh sách khách thuê",
                Dock = DockStyle.Top,
                Height = 40,
                Font = fontSection,
                TextAlign = ContentAlignment.MiddleLeft
            };

            dgTenants.Dock = DockStyle.Fill;
            dgTenants.Font = fontGrid;
            dgTenants.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F);
            dgTenants.RowTemplate.Height = 36;
            dgTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgTenants.BorderStyle = BorderStyle.None;
            dgTenants.BackgroundColor = Color.White;
            dgTenants.RowHeadersVisible = false;

            var dgvWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.White
            };

            dgvWrapper.Paint += (s, e) =>
            {
                var rect = dgvWrapper.ClientRectangle;
                rect.Inflate(-1, -1);
                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                int r = 20;
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();
                dgvWrapper.Region = new Region(path);
                e.Graphics.DrawPath(new Pen(Color.LightGray, 1), path);
            };

            dgvWrapper.Controls.Add(dgTenants);
            gridContainer.Controls.Add(dgvWrapper);
            gridContainer.Controls.Add(lblGridTitle);

            // ===== GHÉP =====
            mainLayout.Controls.Add(scrollPanel, 0, 1); // scroll dọc cho detail
            mainLayout.Controls.Add(gridContainer, 0, 2);
            this.Controls.Add(mainLayout);
        }



        private void loadForm()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(str))
            {
                try
                {
                    mySqlConnection.Open();
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from Tenant", str);
                    DataTable dt = new DataTable();
                    mySqlDataAdapter.Fill(dt);
                    dgTenants.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int selectID = 0;
        private void dgTenants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    object cellID = dgTenants.Rows[e.RowIndex].Cells["id"].Value;
                    if (cellID != null)
                    {
                        //txtID.Text = cellID.ToString();
                        selectID = int.Parse(cellID.ToString());
                    }
                    object cellTenKH = dgTenants.Rows[e.RowIndex].Cells["full_name"].Value;
                    if (cellTenKH != null)
                    {
                        txtFullName.Text = cellTenKH.ToString();
                    }
                    object phone = dgTenants.Rows[e.RowIndex].Cells["phone"].Value;
                    if (phone != null)
                    {
                        txtPhoneNumber.Text = phone.ToString();
                    }
                    object CCCD = dgTenants.Rows[e.RowIndex].Cells["id_card"].Value;
                    if (CCCD != null)
                    {
                        txtCCCD.Text = CCCD.ToString();
                    }
                    object address = dgTenants.Rows[e.RowIndex].Cells["address"].Value;
                    if (address != null)
                    {
                        txtAddress.Text = address.ToString();
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
            DialogResult rs = MessageBox.Show("bạn có muốn cập nhật không", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    try
                    {
                        conn.Open();
                        string update = "update Tenant set full_name = @name, phone = @phone, id_card = @id_card, address = @address where id = @id";
                        MySqlCommand mySqlCommand = new MySqlCommand(update, conn);
                        mySqlCommand.Parameters.AddWithValue("@name", txtFullName.Text);
                        mySqlCommand.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);
                        mySqlCommand.Parameters.AddWithValue("@id_card", txtCCCD.Text);
                        mySqlCommand.Parameters.AddWithValue("@address", txtAddress.Text);
                        mySqlCommand.Parameters.AddWithValue("@id", selectID);
                        mySqlCommand.ExecuteNonQuery();
                        MessageBox.Show("cập nhật thành công");
                        loadForm();
                        txtAddress.Clear();
                        txtCCCD.Clear();
                        txtFullName.Clear();
                        txtPhoneNumber.Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand("select * from Tenant where full_name like @search or phone like @search;", conn);
                    sqlCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text.Trim() + "%");
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    mySqlDataAdapter.Fill(dt);
                    dgTenants.DataSource = dt;
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
