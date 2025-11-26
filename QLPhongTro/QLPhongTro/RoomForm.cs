using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.MonthCalendar;

namespace QLPhongTro
{
    public partial class RoomForm : Form
    {
        string str = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=157359";
        public RoomForm()
        {
            InitializeComponent();
            FillCheckedListBox(chkListBoxService, "SELECT id, service_name FROM Service WHERE is_active = 1");
            loadData();
        }

        void loadData()
        {
            using (MySqlConnection conn = new MySqlConnection(str))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("select * from Room" , conn);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgvRoom.DataSource = dt;
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            using(MySqlConnection conn = new MySqlConnection(str))
            {
                conn.Open();

                string query = " INSERT INTO Room (room_name, price, area, status, is_active)VALUES(@room_name, @price, @area, @status, @is_active);SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room_name", txtTenPhong.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtGia.Text));
                    cmd.Parameters.AddWithValue("@area", Convert.ToInt32(txtDienTichThue.Text));
                    cmd.Parameters.AddWithValue("@status", cbTrangThai.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@is_active", chkActive.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();
                    newRoomId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                List<int> selectedServiceIds = new List<int>();

                foreach (var item in chkListBoxService.CheckedItems)
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
            }
            
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LoadServicesForRoom(int roomId)
        {
            // Bỏ hết check trước
            for (int i = 0; i < chkListBoxService.Items.Count; i++)
            {
                chkListBoxService.SetItemChecked(i, false);
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
                        for (int i = 0; i < chkListBoxService.Items.Count; i++)
                        {
                            ListItem li = chkListBoxService.Items[i] as ListItem;
                            if (serviceIds.Contains(li.Value))
                            {
                                chkListBoxService.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
        }

        int selectID = 0;
        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    object cellID = dgvRoom.Rows[e.RowIndex].Cells["id"].Value;
                    if (cellID != null)
                    {
                        txtID.Text = cellID.ToString();
                        selectID = int.Parse(cellID.ToString());
                    }
                    object cellTenPhong = dgvRoom.Rows[e.RowIndex].Cells["room_name"].Value;
                    if (cellTenPhong != null)
                    {
                        txtTenPhong.Text = cellTenPhong.ToString();
                    }
                    object cellGia = dgvRoom.Rows[e.RowIndex].Cells["price"].Value;
                    if (cellGia != null)
                    {
                        txtGia.Text = cellGia.ToString();
                    }
                    object cellDienTichThue = dgvRoom.Rows[e.RowIndex].Cells["area"].Value;
                    if (cellDienTichThue != null)
                    {
                        txtDienTichThue.Text = cellDienTichThue.ToString();
                    }
                    object cellTrangThai = dgvRoom.Rows[e.RowIndex].Cells["status"].Value;
                    if (cellTrangThai != null)
                    {
                        cbTrangThai.Text = cellTrangThai.ToString();
                    }
                    object cellIsActive = dgvRoom.Rows[e.RowIndex].Cells["is_active"].Value;
                    if (cellIsActive != null)
                    {
                        if (cellIsActive.ToString() == "1")
                            chkActive.Checked = true;
                        else chkActive.Checked = false;
                    }
                }
                if (selectID > 0)
                {
                    LoadServicesForRoom(selectID);
                }
            }
            catch (Exception ex) { MessageBox.Show("bạn chọn vào một ô trống"); }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn có muốn cập nhật dữ liêu?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(str))
                {
                    try
                    {

                        conn.Open();
                        string insert = "update Room set " + "room_name = @name, price = @price, area = @area, status = @status, is_active = @is_active where id = " + selectID;
                        MySqlParameter[] p =
                        {
                            new MySqlParameter("@name", txtTenPhong.Text),
                            new MySqlParameter("@price",Convert.ToDecimal(txtGia.Text)),
                            new MySqlParameter("@area", Convert.ToInt32(txtDienTichThue.Text)),
                            new MySqlParameter("@status", cbTrangThai.Text),
                            new MySqlParameter("@is_active",chkActive.Checked ? 1 : 0)
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
                    foreach (var item in chkListBoxService.CheckedItems)
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
                    txtDienTichThue.Clear();
                    txtGia.Clear();
                    txtID.Clear();
                    txtTenPhong.Clear();
                    loadData();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn muốn xóa dữ liệu của sách có mã id là " + selectID,
           "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                using(MySqlConnection conn = new MySqlConnection(str))
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
                        cmd.Parameters.AddWithValue("@room_name", "%" + txtTimKiem.Text.Trim() + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvRoom.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SearchRoomByName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
