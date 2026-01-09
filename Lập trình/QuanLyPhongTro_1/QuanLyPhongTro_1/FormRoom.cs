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
    public partial class FormRoom : Form
    {
        string str = DbHelper.ConnectionString;
        public FormRoom()
        {
            InitializeComponent();
            BuildRoomLayout();
            FillCheckedListBox(clService, "SELECT id, service_name FROM Service WHERE is_active = 1");
            loadData();
        }

        private void BuildRoomLayout()
        {
            this.SuspendLayout();

            // ===== FORM =====
            this.Controls.Clear();
            this.WindowState = FormWindowState.Maximized;
            this.Font = new Font("Segoe UI", 10F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.MinimumSize = new Size(1100, 650);

            // ================== TABLE MAIN ==================
            TableLayoutPanel main = new TableLayoutPanel();
            main.Dock = DockStyle.Fill;
            main.RowCount = 2;
            main.ColumnCount = 1;
            main.Padding = new Padding(15);

            // ⭐ DETAIL LỚN HƠN – LIST NHỎ LẠI
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 55)); // DETAIL
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 45)); // LIST

            // ================== GROUPBOX DETAIL ==================
            GroupBox gbDetail = new GroupBox();
            gbDetail.Text = "Thông tin phòng";
            gbDetail.Dock = DockStyle.Fill;
            gbDetail.Padding = new Padding(8);

            // ===== DETAIL WRAP =====
            TableLayoutPanel detailWrap = new TableLayoutPanel();
            detailWrap.Dock = DockStyle.Fill;
            detailWrap.RowCount = 2;
            detailWrap.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            detailWrap.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));

            // ===== TABLE DETAIL =====
            TableLayoutPanel tbl = new TableLayoutPanel();
            tbl.Dock = DockStyle.Fill;
            tbl.ColumnCount = 2;
            tbl.RowCount = 5;

            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 36)); // tên
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 36)); // giá
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 36)); // diện tích
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 36)); // trạng thái
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // ⭐ DỊCH VỤ

            // ===== DOCK CONTROL =====
            txtRoomName.Dock = DockStyle.Fill;
            txtRoomRate.Dock = DockStyle.Fill;
            txtArea.Dock = DockStyle.Fill;
            cbStatus.Dock = DockStyle.Fill;

            clService.Dock = DockStyle.Fill;
            clService.IntegralHeight = false;
            clService.ScrollAlwaysVisible = true;

            // ===== ADD FIELD =====
            tbl.Controls.Add(new Label { Text = "Tên phòng", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 0);
            tbl.Controls.Add(txtRoomName, 1, 0);

            tbl.Controls.Add(new Label { Text = "Giá phòng", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 1);
            tbl.Controls.Add(txtRoomRate, 1, 1);

            tbl.Controls.Add(new Label { Text = "Diện tích", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 2);
            tbl.Controls.Add(txtArea, 1, 2);

            tbl.Controls.Add(new Label { Text = "Trạng thái", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 3);
            tbl.Controls.Add(cbStatus, 1, 3);

            // ⭐ LABEL + CHECKLIST CÙNG ROW → CĂN GIỮA ĐẸP
            Label lblService = new Label
            {
                Text = "Dịch vụ",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            tbl.Controls.Add(lblService, 0, 4);
            tbl.Controls.Add(clService, 1, 4);

            // ===== BUTTON PANEL =====
            FlowLayoutPanel pnlBtn = new FlowLayoutPanel();
            pnlBtn.Dock = DockStyle.Fill;
            pnlBtn.Padding = new Padding(5);

            btnAdd.Size = btnUpdate.Size = btnDelete.Size = new Size(100, 32);
            pnlBtn.Controls.AddRange(new Control[] { btnAdd, btnUpdate, btnDelete });

            detailWrap.Controls.Add(tbl, 0, 0);
            detailWrap.Controls.Add(pnlBtn, 0, 1);
            gbDetail.Controls.Add(detailWrap);

            // ================== GROUPBOX LIST ==================
            GroupBox gbList = new GroupBox();
            gbList.Text = "Danh sách phòng";
            gbList.Dock = DockStyle.Fill;
            gbList.Padding = new Padding(8);

            dgRoomLists.Dock = DockStyle.Fill;
            dgRoomLists.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgRoomLists.RowTemplate.Height = 28;

            gbList.Controls.Add(dgRoomLists);

            // ===== ADD MAIN =====
            main.Controls.Add(gbDetail, 0, 0);
            main.Controls.Add(gbList, 0, 1);

            this.Controls.Add(main);
            this.ResumeLayout();
        }


        // Hien thi danh sach phong len DataGridView
        void loadData()
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();

                string sql = @"
            SELECT 
                r.id,
                r.room_name,
                r.price,
                r.area,
                r.status,
                r.is_active,
                t.full_name AS tenant_name,
                t.id_card
            FROM Room r
            LEFT JOIN Contract c 
                ON r.id = c.room_id 
                AND c.is_active = 1
            LEFT JOIN Contract_Tenant ct 
                ON c.id = ct.contract_id 
                AND ct.is_primary = 1
            LEFT JOIN Tenant t 
                ON ct.tenant_id = t.id 
                AND t.is_active = 1
            ORDER BY r.room_name
        ";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgRoomLists.DataSource = dt;
            }
        }


        public void FillCheckedListBox(CheckedListBox listBox, string query)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                listBox.Items.Clear();

                while (rdr.Read())
                {
                    // Item hiển thị + gắn ID trong Tag
                    string displayText = rdr[1].ToString(); // cột thứ 2
                    int id = Convert.ToInt32(rdr[0]);       // cột thứ 1 (id)

                    listBox.Items.Add(new ListItem(displayText, id));
                }

                rdr.Close();
            }
        }
        int newRoomId = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();

                string query = @"
            INSERT INTO Room (room_name, price, area, status, is_active)
            VALUES (@room_name, @price, @area, @status, 1);
            SELECT LAST_INSERT_ID();
        ";

                int newRoomId;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room_name", txtRoomName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtRoomRate.Text));
                    cmd.Parameters.AddWithValue("@area", Convert.ToInt32(txtArea.Text));
                    cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());

                    // ❗ CHỈ GỌI 1 LẦN
                    newRoomId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // ===== INSERT ROOM_SERVICE =====
                string insertMapping = "INSERT INTO Room_Service (room_id, service_id) VALUES (@roomId, @serviceId)";
                using (MySqlCommand cmdMap = new MySqlCommand(insertMapping, conn))
                {
                    cmdMap.Parameters.Add("@roomId", MySqlDbType.Int32);
                    cmdMap.Parameters.Add("@serviceId", MySqlDbType.Int32);

                    foreach (ListItem item in clService.CheckedItems)
                    {
                        cmdMap.Parameters["@roomId"].Value = newRoomId;
                        cmdMap.Parameters["@serviceId"].Value = item.Value;
                        cmdMap.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm phòng thành công!");

                txtRoomName.Clear();
                txtRoomRate.Clear();
                txtArea.Clear();
                cbIsActive.Checked = false;

                loadData();
            }
        }


        private void LoadServicesForRoom(int roomId)
        {
            // Bỏ hết check trước
            for (int i = 0; i < clService.Items.Count; i++)
            {
                clService.SetItemChecked(i, false);
            }

            using (MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();
                string query = "SELECT service_id FROM Room_Service WHERE room_id = @roomId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        List<int> serviceIds = new List<int>();
                        while (rdr.Read())
                        {
                            serviceIds.Add(rdr.GetInt32("service_id"));
                        }

                        // Check các dịch vụ trong CheckedListBox
                        for (int i = 0; i < clService.Items.Count; i++)
                        {
                            ListItem li = clService.Items[i] as ListItem;
                            if (serviceIds.Contains(li.Value))
                            {
                                clService.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
        }
        int selectID = 0;

        private void dgRoomLists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    object cellID = dgRoomLists.Rows[e.RowIndex].Cells["id"].Value;
                    if (cellID != null)
                    {
                        //txtID.Text = cellID.ToString();
                        selectID = int.Parse(cellID.ToString());
                    }
                    object cellTenPhong = dgRoomLists.Rows[e.RowIndex].Cells["room_name"].Value;
                    if (cellTenPhong != null)
                    {
                        txtRoomName.Text = cellTenPhong.ToString();
                    }
                    object cellGia = dgRoomLists.Rows[e.RowIndex].Cells["price"].Value;
                    if (cellGia != null)
                    {
                        txtRoomRate.Text = cellGia.ToString();
                    }
                    object cellDienTichThue = dgRoomLists.Rows[e.RowIndex].Cells["area"].Value;
                    if (cellDienTichThue != null)
                    {
                        txtArea.Text = cellDienTichThue.ToString();
                    }
                    object cellTrangThai = dgRoomLists.Rows[e.RowIndex].Cells["status"].Value;
                    if (cellTrangThai != null)
                    {
                        cbStatus.Text = cellTrangThai.ToString();
                    }
                    object cellIsActive = dgRoomLists.Rows[e.RowIndex].Cells["is_active"].Value;
                    if (cellIsActive != null)
                    {
                        if (cellIsActive.ToString() == "True")
                            cbIsActive.Checked = true;
                        else cbIsActive.Checked = false;
                    }
                }
                if (selectID > 0)
                {
                    LoadServicesForRoom(selectID);
                }
            }
            catch (Exception ex) { MessageBox.Show("bạn chọn vào một ô trống"); }
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
                        string insert = "update Room set " + "room_name = @name, price = @price, area = @area, status = @status,is_active = @is_active where id = " + selectID;

                        MySqlParameter[] p =
                        {
                            new MySqlParameter("@name", txtRoomName.Text),
                            new MySqlParameter("@price",Convert.ToDecimal(txtRoomRate.Text)),
                            new MySqlParameter("@area", Convert.ToInt32(txtArea.Text)),
                            new MySqlParameter("@status", cbStatus.Text),
                            new MySqlParameter("@is_active",cbIsActive.Checked ? 1 : 0)
                        };
                        MySqlCommand cmd = new MySqlCommand(insert, conn);
                        cmd.Parameters.AddRange(p);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { MessageBox.Show("vui lòng nhập hết trường dữ liệu!!", ex.Message); }

                    // 1. Xóa mapping cũ
                    string deleteMapping = "DELETE FROM Room_Service WHERE room_id=@roomId";
                    using (MySqlCommand cmdDelete = new MySqlCommand(deleteMapping, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@roomId", selectID);
                        cmdDelete.ExecuteNonQuery();
                    }

                    // 2. Thêm mapping mới từ CheckedListBox
                    List<int> selectedServiceIds = new List<int>();
                    foreach (var item in clService.CheckedItems)
                    {
                        ListItem li = item as ListItem;
                        selectedServiceIds.Add(li.Value);
                    }

                    string insertMapping = "INSERT INTO Room_Service (room_id, service_id) VALUES (@roomId, @serviceId)";
                    using (MySqlCommand cmdMap = new MySqlCommand(insertMapping, conn))
                    {
                        cmdMap.Parameters.Add("@roomId", MySqlDbType.Int32);
                        cmdMap.Parameters.Add("@serviceId", MySqlDbType.Int32);

                        foreach (int serviceId in selectedServiceIds)
                        {
                            cmdMap.Parameters["@roomId"].Value = selectID;
                            cmdMap.Parameters["@serviceId"].Value = serviceId;
                            cmdMap.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("cập nhật thành công");
                    txtArea.Clear();
                    txtRoomRate.Clear();
                    txtRoomName.Clear();
                    cbIsActive.Checked = false;
                    loadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectID <= 0) return;

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn ngưng sử dụng phòng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rs == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();

                    string sql = "UPDATE Room SET is_active = 0 WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đã ngưng sử dụng phòng!");
                    loadData();
                }
            }
        }


        private void SearchRoomByName()
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM Room WHERE room_name LIKE @room_name";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@room_name", "%" + txtSearch.Text.Trim() + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgRoomLists.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRoomByName();
        }

        private void FormRoom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtArea.Clear();
                txtRoomRate.Clear();
                txtRoomName.Clear();
                cbIsActive.Checked = false;
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormRoom_Load(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }

}
