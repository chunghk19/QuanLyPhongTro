using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClosedXML;
using ClosedXML.Excel;


namespace QLPhongTro
{
    public partial class FormHoaDon : Form
    {
        string conStr = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=";
<<<<<<< HEAD
=======

>>>>>>> 7488c9686e6c26571b0e4b0696c0a5541001b3ac
        public FormHoaDon()
        {


            InitializeComponent();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            loadRoomList();
        }

        private void loadRoomList()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, room_name FROM Room WHERE is_active = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbPhong.DataSource = dt;
                    cbPhong.DisplayMember = "room_name";
                    cbPhong.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load phòng: " + ex.Message);
                }
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                string query = @"
                SELECT 
                    r.room_name AS 'Phòng',
                    i.month AS 'Tháng',
                    i.year AS 'Năm',
                    i.electric_cost AS 'Tiền điện',
                    i.water_cost AS 'Tiền nước',
                    i.service_cost AS 'Dịch vụ',
                    i.other_cost AS 'Khác',
                    i.total_cost AS 'Tổng tiền',
                    i.status AS 'Trạng thái'
                FROM Invoice i
                JOIN Contract c ON i.contract_id = c.id
                JOIN Room r ON c.room_id = r.id
                ORDER BY i.year DESC, i.month DESC, r.room_name ASC
            ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvHoaDon.DataSource = dt;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private int GetContractId(int roomId)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT id FROM contract WHERE room_id=@roomId AND is_active=1 LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private decimal GetRoomPrice(int roomId)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT price FROM contract WHERE room_id=@roomId AND is_active=1 LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        private decimal GetServiceCost(int roomId)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(@"
                SELECT COALESCE(SUM(s.price), 0)
                FROM room_service rs
                JOIN service s ON rs.service_id = s.id
                WHERE rs.room_id = @roomId AND s.is_active = 1
            ", conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            int roomId = Convert.ToInt32(cbPhong.SelectedValue);
            int month = dtTime.Value.Month;
            int year = dtTime.Value.Year;

            int elecOld = int.Parse(txtSoDienCu.Text);
            int elecNew = int.Parse(txtSoDienMoi.Text);
            decimal elecPrice = decimal.Parse(txtGiaDien.Text);

            int waterOld = int.Parse(txtSoNuocCu.Text);
            int waterNew = int.Parse(txtSoNuocMoi.Text);
            decimal waterPrice = decimal.Parse(txtGiaNuoc.Text);

            decimal electricCost = (elecNew - elecOld) * elecPrice;
            decimal waterCost = (waterNew - waterOld) * waterPrice;

            // Lấy giá phòng + dịch vụ
            decimal roomPrice = GetRoomPrice(roomId);
            decimal serviceCost = GetServiceCost(roomId);

            decimal total = roomPrice + electricCost + waterCost + serviceCost;

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        int usageId = 0;
                        using (MySqlCommand cmd = new MySqlCommand(@"
                        INSERT INTO consumption
                        (room_id, month, year,
                        electric_old, electric_new, electric_price_per_kwh,
                        water_old, water_new, water_price_per_m3)
                        VALUES
                        (@room_id, @month, @year,
                        @elec_old, @elec_new, @elec_price,
                        @water_old, @water_new, @water_price);
                        SELECT LAST_INSERT_ID();
                    ", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@room_id", roomId);
                            cmd.Parameters.AddWithValue("@month", month);
                            cmd.Parameters.AddWithValue("@year", year);

                            cmd.Parameters.AddWithValue("@elec_old", elecOld);
                            cmd.Parameters.AddWithValue("@elec_new", elecNew);
                            cmd.Parameters.AddWithValue("@elec_price", elecPrice);

                            cmd.Parameters.AddWithValue("@water_old", waterOld);
                            cmd.Parameters.AddWithValue("@water_new", waterNew);
                            cmd.Parameters.AddWithValue("@water_price", waterPrice);

                            usageId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        int contractId = GetContractId(roomId);

                        using (MySqlCommand cmd = new MySqlCommand(@"
                        INSERT INTO invoice
                        (contract_id, usage_id, month, year,
                         room_price, electric_cost, water_cost, service_cost, other_cost, total_cost)
                        VALUES
                        (@contract_id, @usage_id, @month, @year,
                         @room_price, @electric_cost, @water_cost, @service_cost, 0, @total_cost)
                    ", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@contract_id", contractId);
                            cmd.Parameters.AddWithValue("@usage_id", usageId);
                            cmd.Parameters.AddWithValue("@month", month);
                            cmd.Parameters.AddWithValue("@year", year);

                            cmd.Parameters.AddWithValue("@room_price", roomPrice);
                            cmd.Parameters.AddWithValue("@electric_cost", electricCost);
                            cmd.Parameters.AddWithValue("@water_cost", waterCost);
                            cmd.Parameters.AddWithValue("@service_cost", serviceCost);
                            cmd.Parameters.AddWithValue("@total_cost", total);

                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Tính và lưu hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message);
                    }
                }
            }
        }

        private DataRowView GetSelectedInvoice()
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trong bảng!");
                return null;
            }

            return dgvHoaDon.CurrentRow.DataBoundItem as DataRowView;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedInvoice();
            if (selected == null) return;

            string room = selected["Phòng"].ToString();
            string month = selected["Tháng"].ToString();
            string year = selected["Năm"].ToString();
            string electric = selected["Tiền điện"].ToString();
            string water = selected["Tiền nước"].ToString();
            string service = selected["Dịch vụ"].ToString();
            string other = selected["Khác"].ToString();
            string total = selected["Tổng tiền"].ToString();

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel File|*.xlsx";
            save.FileName = $"HoaDon_{room}_{month}_{year}.xlsx";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            // ClosedXML
            using (var wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Hóa đơn");

                // Tiêu đề
                ws.Cell("A1").Value = "HÓA ĐƠN PHÒNG TRỌ";
                ws.Range("A1:D1").Merge();
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Cell("A1").Style.Font.FontSize = 18;
                ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Thông tin phòng và tháng/năm
                ws.Cell("A3").Value = "Phòng:";
                ws.Cell("B3").Value = room;
                ws.Cell("B3").Style.Font.Bold = true;
                ws.Cell("B3").Style.Font.FontColor = XLColor.White;
                ws.Cell("B3").Style.Fill.BackgroundColor = XLColor.DarkBlue;
                ws.Cell("B3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell("A4").Value = "Tháng/Năm:";
                ws.Cell("B4").Value = $"{month}/{year}";

                // Header bảng chi phí
                ws.Cell("A6").Value = "Mục";
                ws.Cell("B6").Value = "Số tiền";
                ws.Range("A6:B6").Style.Font.Bold = true;
                ws.Range("A6:B6").Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Range("A6:B6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Dữ liệu chi phí
                ws.Cell("A7").Value = "Tiền điện"; ws.Cell("B7").Value = electric;
                ws.Cell("A8").Value = "Tiền nước"; ws.Cell("B8").Value = water;
                ws.Cell("A9").Value = "Dịch vụ"; ws.Cell("B9").Value = service;
                ws.Cell("A10").Value = "Chi phí khác"; ws.Cell("B10").Value = other;

                // Tổng cộng
                ws.Cell("A12").Value = "TỔNG CỘNG";
                ws.Cell("B12").Value = total;
                ws.Range("A12:B12").Style.Font.Bold = true;
                ws.Range("A12:B12").Style.Fill.BackgroundColor = XLColor.LightYellow;

                // Định dạng tiền
                ws.Range("B7:B12").Style.NumberFormat.Format = "#,##0";

                // Border
                ws.Range("A6:B10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ws.Range("A6:B10").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                ws.Range("A12:B12").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // Auto-fit cột
                ws.Columns().AdjustToContents();

                // Lưu file
                wb.SaveAs(save.FileName);
            }

            MessageBox.Show("Xuất Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
