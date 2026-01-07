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
    public partial class FormRoom : Form
    {
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
        public FormRoom()
        {
            InitializeComponent();
            FillCheckedListBox(clService, "SELECT id, service_name FROM Service WHERE is_active = 1");
            loadData();
        }
        // Hien thi danh sach phong len DataGridView
        void loadData()
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("SELECT \r\n    r.*,\r\n    t.full_name AS tenant_name,\r\n    t.id_card\r\nFROM Room r\r\nLEFT JOIN Contract c \r\n    ON r.id = c.room_id \r\n    AND c.is_active = true\r\nLEFT JOIN Contract_Tenant ct \r\n    ON c.id = ct.contract_id\r\nLEFT JOIN Tenant t \r\n    ON ct.tenant_id = t.id \r\n    AND t.is_active = true;\r\n", conn);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgRoomLists.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
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

                string query = " INSERT INTO Room (room_name, price, area, status, is_active)VALUES(@room_name, @price, @area, @status,@is_active);SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room_name", txtRoomName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtRoomRate.Text));
                    cmd.Parameters.AddWithValue("@area", Convert.ToInt32(txtArea.Text));
                    cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@is_active", cbIsActive.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();
                    newRoomId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                List<int> selectedServiceIds = new List<int>();

                foreach (var item in clService.CheckedItems)
                {
                    ListItem li = item as ListItem;
                    selectedServiceIds.Add(li.Value); // lấy service_id
                }

                string insertMapping = "INSERT INTO Room_Service (room_id, service_id) VALUES (@roomId, @serviceId)";
                using (MySqlCommand cmdMap = new MySqlCommand(insertMapping, conn))
                {
                    cmdMap.Parameters.Add("@roomId", MySqlDbType.Int32);
                    cmdMap.Parameters.Add("@serviceId", MySqlDbType.Int32);

                    foreach (int serviceId in selectedServiceIds)
                    {
                        cmdMap.Parameters["@roomId"].Value = newRoomId;
                        cmdMap.Parameters["@serviceId"].Value = serviceId;
                        cmdMap.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm phòng và dịch vụ thành công!");
                txtArea.Clear();
                txtRoomRate.Clear();
                txtRoomName.Clear();
                cbIsActive.Checked = false;
                //txtTenPhong.Clear();
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
            DialogResult rs = MessageBox.Show("bạn muốn xóa dữ liệu của sách có mã id là " + selectID,
            "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand("delete from Room where id = " + selectID, conn);
                    sqlCommand.ExecuteNonQuery();
                    string deleteMapping = "DELETE FROM Room_Service WHERE room_id=@roomId";
                    using (MySqlCommand cmdDelete = new MySqlCommand(deleteMapping, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@roomId", selectID);
                        cmdDelete.ExecuteNonQuery();
                    }
                    MessageBox.Show("xóa thành công");
                    txtArea.Clear();
                    txtRoomRate.Clear();
                    txtRoomName.Clear();
                    cbIsActive.Checked = false;
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
