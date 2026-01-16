using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyPhongTro_1.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyPhongTro_1
{
    public partial class FormContract : Form
    {
        string conStr = DbHelper.ConnectionString;
        public FormContract()
        {
            InitializeComponent();
            OverrideDesignBeautiful();
            intoCbRoom();
            // ===== ADD FILTER ITEMS =====
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Tất cả hợp đồng");
            comboBox1.Items.Add("Hợp đồng còn hạn");
            comboBox1.Items.Add("Hợp đồng sắp hết hạn");
            comboBox1.Items.Add("Hợp đồng đã hết hạn");
            comboBox1.SelectedIndex = 0;
            contractLoad();
        }
        private void OverrideDesignBeautiful()
        {
            // Xóa hết control cũ
            this.Controls.Clear();

            // Fonts
            Font fontTitle = new Font("Segoe UI Semibold", 18F);
            Font fontSection = new Font("Segoe UI Semibold", 14F);
            Font fontLabel = new Font("Segoe UI", 11F);
            Font fontInput = new Font("Segoe UI", 11F);

            // ===== Main TableLayoutPanel =====
            TableLayoutPanel mainLayout = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(10)
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.Controls.Add(mainLayout);

            // ===== LEFT PANEL =====
            Panel leftPanelScroll = new Panel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            mainLayout.Controls.Add(leftPanelScroll, 0, 0);

            TableLayoutPanel leftPanel = new TableLayoutPanel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                RowCount = 2
            };
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftPanelScroll.Controls.Add(leftPanel);

            // --- GroupBox Thông tin hợp đồng ---
            GroupBox gbDetail = new GroupBox()
            {
                Text = "Thông tin hợp đồng",
                Font = fontSection,
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(10)
            };

            TableLayoutPanel tblDetail = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 9,
                AutoSize = true
            };
            tblDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));

            void AddDetailRow(string labelText, Control control, int rowIndex)
            {
                Label lbl = new Label()
                {
                    Text = labelText,
                    Font = fontLabel,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(3)
                };
                control.Font = fontInput;
                control.Dock = DockStyle.Fill;
                control.Margin = new Padding(3);
                tblDetail.Controls.Add(lbl, 0, rowIndex);
                tblDetail.Controls.Add(control, 1, rowIndex);
            }

            AddDetailRow("Họ và tên", txtFullName, 0);
            AddDetailRow("SĐT", txtSDT, 1);
            AddDetailRow("CCCD", txtCCCD, 2);
            AddDetailRow("Địa chỉ", txtAddress, 3);
            AddDetailRow("Phòng thuê", cbRoom, 4);
            AddDetailRow("Giá phòng", txtPrice, 5);
            AddDetailRow("Ngày bắt đầu", TimeStart, 6);
            AddDetailRow("Ngày kết thúc", TimeEnd, 7);
            AddDetailRow("Tiền cọc", txtDeposit, 8);

            gbDetail.Controls.Add(tblDetail);
            leftPanel.Controls.Add(gbDetail, 0, 0);

            // --- GroupBox Thông tin tài khoản ---
            GroupBox gbUser = new GroupBox()
            {
                Text = "Thông tin tài khoản",
                Font = fontSection,
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(10)
            };

            TableLayoutPanel tblUser = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5,
                AutoSize = true
            };
            tblUser.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblUser.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));

            void AddUserRow(string labelText, Control control, int rowIndex)
            {
                Label lbl = new Label()
                {
                    Text = labelText,
                    Font = fontLabel,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(3)
                };
                control.Font = fontInput;
                control.Dock = DockStyle.Fill;
                control.Margin = new Padding(3);
                tblUser.Controls.Add(lbl, 0, rowIndex);
                tblUser.Controls.Add(control, 1, rowIndex);
            }

            AddUserRow("Tài khoản", txtUserName, 0);
            AddUserRow("Mật khẩu", txtPassWord, 1);
            AddUserRow("Nhập lại MK", txtNhapLai, 2);
            AddUserRow("Email", txtEmail, 3);

            // --- FlowLayoutPanel nút ---
            FlowLayoutPanel flButtons = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false, // tránh xuống dòng
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 5, 0, 0)
            };

            // Nút tự động mở rộng đủ chữ
            btnAdd.AutoSize = true;
            btnUpdate.AutoSize = true;
            btnDelete.AutoSize = true;

            btnAdd.Font = new Font("Segoe UI", 11F);
            btnUpdate.Font = new Font("Segoe UI", 11F);
            btnDelete.Font = new Font("Segoe UI", 11F);

            flButtons.Controls.Add(btnAdd);
            flButtons.Controls.Add(btnUpdate);
            flButtons.Controls.Add(btnDelete);

            tblUser.Controls.Add(flButtons, 0, 4);
            tblUser.SetColumnSpan(flButtons, 2);

            gbUser.Controls.Add(tblUser);
            leftPanel.Controls.Add(gbUser, 0, 1);

            // ===== RIGHT PANEL =====
            TableLayoutPanel rightPanel = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            rightPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F)); // search + filter
            rightPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // DGV
            mainLayout.Controls.Add(rightPanel, 1, 0);

            // --- Panel tìm kiếm + lọc ---
            Panel topPanel = new Panel() { Dock = DockStyle.Fill };
            rightPanel.Controls.Add(topPanel, 0, 0);

            FlowLayoutPanel searchPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 40,
                Padding = new Padding(0, 0, 0, 5),
                WrapContents = false
            };
            button1.Height = 30;
            textBox9.Width = 300;
            searchPanel.Controls.Add(button1);
            searchPanel.Controls.Add(textBox9);
            topPanel.Controls.Add(searchPanel);

            FlowLayoutPanel filterPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 35,
                Padding = new Padding(0),
                WrapContents = false
            };
            button2.Height = 30;
            comboBox1.Width = 200;
            filterPanel.Controls.Add(button2);
            filterPanel.Controls.Add(comboBox1);
            topPanel.Controls.Add(filterPanel);

            // --- GroupBox DGV ---
            GroupBox gbDGV = new GroupBox()
            {
                Text = "Danh sách hợp đồng",
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                Font = new Font("Segoe UI Semibold", 14F)
            };
            rightPanel.Controls.Add(gbDGV, 0, 1);

            Panel dgvPanel = new Panel() { Dock = DockStyle.Fill, Padding = new Padding(0) };
            gbDGV.Controls.Add(dgvPanel);

            dgvlistViewContract.Dock = DockStyle.Fill;
            dgvlistViewContract.Font = new Font("Segoe UI", 10F);
            dgvlistViewContract.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F);
            dgvlistViewContract.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvlistViewContract.EnableHeadersVisualStyles = false;
            dgvlistViewContract.RowTemplate.Height = 28;
            dgvlistViewContract.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvlistViewContract.MultiSelect = false;
            dgvlistViewContract.ScrollBars = ScrollBars.Both;
            dgvlistViewContract.AllowUserToAddRows = false;
            dgvlistViewContract.AllowUserToDeleteRows = false;
            dgvlistViewContract.AllowUserToResizeRows = false;

            // ===== DGV scroll ngang và cột rộng hợp lý =====
            dgvlistViewContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvlistViewContract.DataBindingComplete += (s, e) =>
            {
                // set width cột sau khi có dữ liệu
                foreach (DataGridViewColumn col in dgvlistViewContract.Columns)
                {
                    col.Width = 150;
                    col.MinimumWidth = 100;
                }
            };

            dgvPanel.Controls.Add(dgvlistViewContract);
        }


        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            return System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );
        }

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Trả về dạng: base64(hash) + ":" + base64(salt)
            return Convert.ToBase64String(hash) + ":" + Convert.ToBase64String(salt);
        }
        private bool validateData()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }


            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return false;
            }


            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
            {
                MessageBox.Show("CCCD không hợp lệ!");
                return false;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!");
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        private void intoCbRoom(string currentRoomName = null)
        {
            cbRoom.Items.Clear(); // xóa cũ

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();

                    // 1. Lấy tất cả phòng trống
                    string query = "SELECT id, room_name FROM Room WHERE status = 'Trống'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<string> roomNamesAdded = new List<string>();
                    while (reader.Read())
                    {
                        int roomId = reader.GetInt32("id");
                        string roomName = reader.GetString("room_name");
                        cbRoom.Items.Add(new ListRoom(roomName, roomId)); // lưu roomId vào Value
                        roomNamesAdded.Add(roomName);
                    }
                    reader.Close();

                    // 2. Nếu phòng khách đang thuê chưa có trong combobox
                    if (!string.IsNullOrEmpty(currentRoomName) && !roomNamesAdded.Contains(currentRoomName))
                    {
                        string queryRoom = "SELECT id, room_name FROM Room WHERE room_name = @name";
                        MySqlCommand cmdRoom = new MySqlCommand(queryRoom, conn);
                        cmdRoom.Parameters.AddWithValue("@name", currentRoomName);
                        MySqlDataReader readerRoom = cmdRoom.ExecuteReader();
                        if (readerRoom.Read())
                        {
                            int roomId = readerRoom.GetInt32("id");
                            string roomName = readerRoom.GetString("room_name");
                            cbRoom.Items.Add(new ListRoom(roomName, roomId)); // lưu roomId luôn
                        }
                        readerRoom.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void AutoEndExpiredContracts()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // ===== LẤY DANH SÁCH HỢP ĐỒNG QUÁ HẠN =====
                    string getExpiredSql = @"
                SELECT c.id, c.room_id
                FROM Contract c
                WHERE c.is_active = 1
                  AND c.end_date < CURDATE()
                  AND NOT EXISTS (
                      SELECT 1 FROM Invoice i
                      WHERE i.contract_id = c.id AND i.is_paid = 0
                  )
            ";

                    MySqlCommand cmdGet = new MySqlCommand(getExpiredSql, conn, trans);

                    using (var reader = cmdGet.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int contractId = reader.GetInt32("id");
                            int roomId = reader.GetInt32("room_id");

                            // Kết thúc hợp đồng
                            string endContractSql =
                                "UPDATE Contract SET is_active = 0 WHERE id = @cid";
                            MySqlCommand cmdEnd =
                                new MySqlCommand(endContractSql, conn, trans);
                            cmdEnd.Parameters.AddWithValue("@cid", contractId);
                            cmdEnd.ExecuteNonQuery();

                            // Trả phòng
                            string updateRoomSql =
                                "UPDATE Room SET status = 'Trống', is_active = 1 WHERE id = @room";
                            MySqlCommand cmdRoom =
                                new MySqlCommand(updateRoomSql, conn, trans);
                            cmdRoom.Parameters.AddWithValue("@room", roomId);
                            cmdRoom.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }


        private void contractLoad()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("SELECT \r\n    c.id AS contract_id,\r\n    t.id AS tenant_id,\r\n    r.room_name AS room_name,\r\n    c.start_date,\r\n    c.end_date,\r\n    c.price AS contract_price,\r\n    c.deposit,\r\n    t.full_name  AS tenant_name,\r\n    t.id_card AS tenant_id_card,\r\n    t.phone AS tenant_phone,\r\n    t.address AS tenant_address,\r\n    ct.is_primary AS is_primary_tenant\r\nFROM Contract c\r\nJOIN Room r ON c.room_id = r.id\r\nJOIN Contract_Tenant ct ON c.id = ct.contract_id\r\nJOIN Tenant t ON ct.tenant_id = t.id\r\nWHERE c.is_active = 1\r\nORDER BY c.id, ct.is_primary DESC;\r\n", conn);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgvlistViewContract.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!validateData()) return;

            if (cbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            if (!decimal.TryParse(txtDeposit.Text, out decimal deposit) ||
                !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá hoặc tiền cọc không hợp lệ!");
                return;
            }

            if (TimeEnd.Value <= TimeStart.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    long tenantId = -1;
                    long userId = -1;

                    // ================== CHECK TENANT BẰNG ID ==================
                    if (selectTenantID != -1)
                    {
                        string checkTenantSql =
                            "SELECT id, user_id FROM Tenant WHERE id = @tid AND is_active = 1";

                        MySqlCommand cmdCheckTenant =
                            new MySqlCommand(checkTenantSql, conn, trans);
                        cmdCheckTenant.Parameters.AddWithValue("@tid", selectTenantID);

                        using (var reader = cmdCheckTenant.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tenantId = reader.GetInt64("id");
                                userId = reader.GetInt64("user_id");
                            }
                        }
                    }


                    // ================== NẾU KHÁCH CHƯA TỒN TẠI ==================
                    if (tenantId == -1)
                    {
                        // ---- check username ----
                        string checkUserSql = "SELECT 1 FROM `User` WHERE username = @user";
                        MySqlCommand cmdCheckUser = new MySqlCommand(checkUserSql, conn, trans);
                        cmdCheckUser.Parameters.AddWithValue("@user", txtUserName.Text);

                        if (cmdCheckUser.ExecuteScalar() != null)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại!");
                            trans.Rollback();
                            return;
                        }

                        if (txtUserName.Text == "" || txtPassWord.Text == "" ||
                            txtNhapLai.Text == "" || txtEmail.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!");
                            trans.Rollback();
                            return;
                        }

                        if (txtPassWord.Text != txtNhapLai.Text)
                        {
                            MessageBox.Show("Mật khẩu nhập lại không khớp!");
                            trans.Rollback();
                            return;
                        }

                        // ---- insert User ----
                        string insertUser = @"
                    INSERT INTO `User` (username, password_hash, role, is_active, created_at, email)
                    VALUES (@user, @pass, 'TENANT', 1, NOW(), @email)
                ";

                        MySqlCommand cmdUser = new MySqlCommand(insertUser, conn, trans);
                        cmdUser.Parameters.AddWithValue("@user", txtUserName.Text);
                        cmdUser.Parameters.AddWithValue("@pass", HashPassword(txtPassWord.Text));
                        cmdUser.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmdUser.ExecuteNonQuery();

                        userId = cmdUser.LastInsertedId;

                        // ---- insert Tenant ----
                        string insertTenant = @"
                    INSERT INTO Tenant (full_name, phone, id_card, address, user_id, is_active)
                    VALUES (@name, @phone, @cccd, @address, @user_id, 1)
                ";

                        MySqlCommand cmdTenant = new MySqlCommand(insertTenant, conn, trans);
                        cmdTenant.Parameters.AddWithValue("@name", txtFullName.Text);
                        cmdTenant.Parameters.AddWithValue("@phone", txtSDT.Text);
                        cmdTenant.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                        cmdTenant.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmdTenant.Parameters.AddWithValue("@user_id", userId);
                        cmdTenant.ExecuteNonQuery();

                        tenantId = cmdTenant.LastInsertedId;
                    }

                    // ================== INSERT CONTRACT ==================
                    string insertContract = @"
                INSERT INTO Contract (room_id, start_date, end_date, deposit, price, is_active)
                VALUES (@room_id, @start, @end, @deposit, @price, 1)
            ";

                    MySqlCommand cmdContract = new MySqlCommand(insertContract, conn, trans);
                    cmdContract.Parameters.AddWithValue("@room_id", ((ListRoom)cbRoom.SelectedItem).Value);
                    cmdContract.Parameters.AddWithValue("@start", TimeStart.Value);
                    cmdContract.Parameters.AddWithValue("@end", TimeEnd.Value);
                    cmdContract.Parameters.AddWithValue("@deposit", deposit);
                    cmdContract.Parameters.AddWithValue("@price", price);
                    cmdContract.ExecuteNonQuery();

                    long contractId = cmdContract.LastInsertedId;

                    // ================== LINK CONTRACT - TENANT ==================
                    string insertCT =
                        "INSERT INTO Contract_Tenant (contract_id, tenant_id, is_primary) VALUES (@c, @t, 1)";

                    MySqlCommand cmdCT = new MySqlCommand(insertCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@c", contractId);
                    cmdCT.Parameters.AddWithValue("@t", tenantId);
                    cmdCT.ExecuteNonQuery();

                    // ================== UPDATE ROOM ==================
                    string updateRoom =
                        "UPDATE Room SET status = 'Đang thuê', is_active = 1 WHERE id = @room";

                    MySqlCommand cmdRoom = new MySqlCommand(updateRoom, conn, trans);
                    cmdRoom.Parameters.AddWithValue("@room", ((ListRoom)cbRoom.SelectedItem).Value);
                    cmdRoom.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Thêm hợp đồng thành công!");
                    contractLoad();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


        private void FormContract_Load(object sender, EventArgs e)
        {
            AutoEndExpiredContracts();
        }
        int oldRoomID = -1;
        int selectContractID = -1;
        int selectTenantID = -1;
        private void dgvlistViewContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvlistViewContract.Rows[e.RowIndex];
                string roomNameOfCustomer = row.Cells["room_name"].Value.ToString();

                // Load combobox (phòng trống + phòng đang thuê)
                intoCbRoom(roomNameOfCustomer);

                // Chọn phòng dựa trên Text nhưng Value vẫn giữ room_id
                foreach (ListRoom item in cbRoom.Items)
                {
                    if (item.Text == roomNameOfCustomer)
                    {
                        cbRoom.SelectedItem = item;
                        break;
                    }
                }


                // Load thông tin khách
                selectContractID = Convert.ToInt32(row.Cells["contract_id"].Value);
                selectTenantID = Convert.ToInt32(row.Cells["tenant_id"].Value);
                oldRoomID = ((ListRoom)cbRoom.SelectedItem).Value;
                txtFullName.Text = row.Cells["tenant_name"].Value.ToString();
                txtSDT.Text = row.Cells["tenant_phone"].Value.ToString();
                txtCCCD.Text = row.Cells["tenant_id_card"].Value.ToString();
                txtAddress.Text = row.Cells["tenant_address"].Value.ToString();
                txtPrice.Text = row.Cells["contract_price"].Value.ToString();
                txtDeposit.Text = row.Cells["deposit"].Value.ToString();
                TimeStart.Value = Convert.ToDateTime(row.Cells["start_date"].Value);
                TimeEnd.Value = Convert.ToDateTime(row.Cells["end_date"].Value);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectContractID == -1)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần cập nhật!");
                return;
            }

            if (!validateData()) return;

            if (cbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            if (!decimal.TryParse(txtDeposit.Text, out decimal deposit) ||
                !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá hoặc tiền cọc không hợp lệ!");
                return;
            }

            if (TimeEnd.Value <= TimeStart.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có muốn cập nhật không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rs != DialogResult.Yes) return;

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Update Contract
                        string updateContract = @"
                    UPDATE Contract 
                    SET 
                        room_id = @roomid,
                        start_date = @startdate,
                        end_date = @enddate,
                        deposit = @deposit,
                        price = @price
                    WHERE id = @contractid";

                        MySqlCommand cmdContract = new MySqlCommand(updateContract, conn, trans);
                        cmdContract.Parameters.AddWithValue("@roomid", ((ListRoom)cbRoom.SelectedItem).Value);
                        cmdContract.Parameters.AddWithValue("@startdate", TimeStart.Value);
                        cmdContract.Parameters.AddWithValue("@enddate", TimeEnd.Value);
                        cmdContract.Parameters.AddWithValue("@deposit", deposit);
                        cmdContract.Parameters.AddWithValue("@price", price);
                        cmdContract.Parameters.AddWithValue("@contractid", selectContractID);
                        cmdContract.ExecuteNonQuery();

                        // 2️⃣ Update Tenant (CHỈ tenant chính – giữ nguyên logic)
                        string updateTenant = @"
                    UPDATE Tenant t
                    JOIN Contract_Tenant ct ON t.id = ct.tenant_id
                    SET 
                        t.full_name = @name,
                        t.phone = @phone,
                        t.id_card = @cccd,
                        t.address = @address
                    WHERE 
                        ct.contract_id = @contractid
                        AND ct.is_primary = 1";

                        MySqlCommand cmdTenant = new MySqlCommand(updateTenant, conn, trans);
                        cmdTenant.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                        cmdTenant.Parameters.AddWithValue("@phone", txtSDT.Text.Trim());
                        cmdTenant.Parameters.AddWithValue("@cccd", txtCCCD.Text.Trim());
                        cmdTenant.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        cmdTenant.Parameters.AddWithValue("@contractid", selectContractID);

                        int tenantRows = cmdTenant.ExecuteNonQuery();
                        if (tenantRows == 0)
                        {
                            throw new Exception("Không tìm thấy tenant chính để cập nhật!");
                        }

                        // 3️⃣ Update phòng (GIỮ LOGIC: phòng cũ → trống, phòng mới → đang thuê)
                        int newRoomID = ((ListRoom)cbRoom.SelectedItem).Value;

                        if (oldRoomID != newRoomID)
                        {
                            string updateOldRoom = "UPDATE Room SET status = 'Trống', is_active = 1 WHERE id = @oldroom";
                            MySqlCommand cmdOldRoom = new MySqlCommand(updateOldRoom, conn, trans);
                            cmdOldRoom.Parameters.AddWithValue("@oldroom", oldRoomID);
                            cmdOldRoom.ExecuteNonQuery();

                            string updateRoom = "UPDATE Room SET status = 'Đang thuê', is_active = 1 WHERE id = @room";
                            MySqlCommand cmdRoom = new MySqlCommand(updateRoom, conn, trans);
                            cmdRoom.Parameters.AddWithValue("@room", newRoomID);
                            cmdRoom.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Cập nhật hợp đồng thành công!");
                        contractLoad();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();

                string sql = @"
            SELECT 
                c.id AS contract_id,
                t.id AS tenant_id,
                r.room_name AS room_name,
                c.start_date,
                c.end_date,
                c.price AS contract_price,
                c.deposit,
                t.full_name AS tenant_name,
                t.id_card AS tenant_id_card,
                t.phone AS tenant_phone,
                t.address AS tenant_address,
                ct.is_primary AS is_primary_tenant
            FROM Contract c
            JOIN Room r ON c.room_id = r.id
            JOIN Contract_Tenant ct ON c.id = ct.contract_id
            JOIN Tenant t ON ct.tenant_id = t.id
            WHERE 
                c.is_active = 1
                AND t.is_active = 1
                AND (
                    t.full_name LIKE @search
                    OR t.phone LIKE @search
                    OR t.id_card LIKE @search
                )
            ORDER BY c.id, ct.is_primary DESC
        ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@search", "%" + textBox9.Text.Trim() + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvlistViewContract.DataSource = dt;
            }
        }


private void btnDelete_Click(object sender, EventArgs e)
{
    if (selectContractID == -1)
    {
        MessageBox.Show("Vui lòng chọn hợp đồng cần kết thúc!");
        return;
    }

    DialogResult rs = MessageBox.Show(
        "Bạn có chắc chắn muốn kết thúc hợp đồng này?",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

    if (rs != DialogResult.Yes) return;

    using (MySqlConnection conn = new MySqlConnection(conStr))
    {
        conn.Open();
        MySqlTransaction trans = conn.BeginTransaction();

        try
        {
            // ===== 1. CHECK HÓA ĐƠN CHƯA THANH TOÁN =====
            string checkInvoiceSql = @"
                SELECT COUNT(*) 
                FROM Invoice 
                WHERE contract_id = @cid
                  AND status IN ('Mới', 'Chờ thanh toán', 'Quá hạn')
            ";

            MySqlCommand cmdCheckInvoice =
                new MySqlCommand(checkInvoiceSql, conn, trans);
            cmdCheckInvoice.Parameters.AddWithValue("@cid", selectContractID);

            int unpaidCount = Convert.ToInt32(cmdCheckInvoice.ExecuteScalar());

            if (unpaidCount > 0)
            {
                MessageBox.Show(
                    "Không thể kết thúc hợp đồng!\nHợp đồng vẫn còn hóa đơn chưa thanh toán.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                trans.Rollback();
                return;
            }

            // ===== 2. LẤY ROOM ID =====
            string getRoomSql =
                "SELECT room_id FROM Contract WHERE id = @cid AND is_active = 1";

            MySqlCommand cmdGetRoom =
                new MySqlCommand(getRoomSql, conn, trans);
            cmdGetRoom.Parameters.AddWithValue("@cid", selectContractID);

            object roomObj = cmdGetRoom.ExecuteScalar();
            if (roomObj == null)
            {
                MessageBox.Show("Hợp đồng không tồn tại hoặc đã kết thúc!");
                trans.Rollback();
                return;
            }

            int roomId = Convert.ToInt32(roomObj);

            // ===== 3. XÓA LIÊN KẾT CONTRACT - TENANT =====
            string deleteCTSql =
                "DELETE FROM Contract_Tenant WHERE contract_id = @cid";

            MySqlCommand cmdDeleteCT =
                new MySqlCommand(deleteCTSql, conn, trans);
            cmdDeleteCT.Parameters.AddWithValue("@cid", selectContractID);
            cmdDeleteCT.ExecuteNonQuery();

            // ===== 4. KẾT THÚC HỢP ĐỒNG =====
            string endContractSql =
                "UPDATE Contract SET is_active = 0 WHERE id = @cid";

            MySqlCommand cmdEndContract =
                new MySqlCommand(endContractSql, conn, trans);
            cmdEndContract.Parameters.AddWithValue("@cid", selectContractID);
            cmdEndContract.ExecuteNonQuery();

            // ===== 5. TRẢ PHÒNG =====
            string updateRoomSql =
                "UPDATE Room SET status = 'Trống', is_active = 1 WHERE id = @room";

            MySqlCommand cmdUpdateRoom =
                new MySqlCommand(updateRoomSql, conn, trans);
            cmdUpdateRoom.Parameters.AddWithValue("@room", roomId);
            cmdUpdateRoom.ExecuteNonQuery();

            trans.Commit();

            MessageBox.Show("Kết thúc hợp đồng thành công!");
            selectContractID = -1;
            selectTenantID = -1;
            oldRoomID = -1;

            contractLoad();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            MessageBox.Show("Lỗi: " + ex.Message);
        }
    }
}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn điều kiện lọc!");
                return;
            }

            string filter = comboBox1.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();

                string where = "";

                if (filter == "Hợp đồng còn hạn")
                {
                    where = "AND c.is_active = 1 AND c.end_date >= CURDATE()";
                }
                else if (filter == "Hợp đồng sắp hết hạn")
                {
                    where = @"AND c.is_active = 1 
                      AND c.end_date BETWEEN CURDATE() 
                      AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)";
                }
                else if (filter == "Hợp đồng đã hết hạn")
                {
                    where = "AND c.is_active = 0";
                }
                // Tất cả hợp đồng → KHÔNG where thêm gì

                string sql = $@"
        SELECT 
            c.id AS contract_id,
            t.id AS tenant_id,
            r.room_name,
            c.start_date,
            c.end_date,
            c.price AS contract_price,
            c.deposit,
            t.full_name AS tenant_name,
            t.id_card AS tenant_id_card,
            t.phone AS tenant_phone,
            t.address AS tenant_address,
            ct.is_primary
        FROM Contract c
        JOIN Room r ON c.room_id = r.id
        JOIN Contract_Tenant ct ON c.id = ct.contract_id
        JOIN Tenant t ON ct.tenant_id = t.id
        WHERE 
            t.is_active = 1
            {where}
        ORDER BY c.end_date DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvlistViewContract.DataSource = dt;
            }
        }
    }
}
