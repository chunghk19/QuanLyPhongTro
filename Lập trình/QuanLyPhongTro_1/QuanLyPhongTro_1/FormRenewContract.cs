using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuanLyPhongTro_1
{
    public partial class FormRenewContract : Form
    {
        int oldContractId;
        int roomId;

        DateTimePicker dtStart;
        DateTimePicker dtEnd;
        ComboBox cboMonths;
        NumericUpDown nudPrice;
        Button btnSave, btnCancel;

        string conStr = "Server=localhost;Port=3306;Database=Room_Management;Uid=root;Pwd=157359";

        public FormRenewContract(int contractId)
        {
            oldContractId = contractId;
            BuildUI();
            LoadOldContract();
        }

        private void BuildUI()
        {
            this.Text = "Gia hạn hợp đồng";
            this.Size = new Size(410, 280);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            TableLayoutPanel tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(15)
            };

            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            for (int i = 0; i < 5; i++)
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            dtStart = new DateTimePicker { Dock = DockStyle.Fill };
            dtEnd = new DateTimePicker { Dock = DockStyle.Fill };

            cboMonths = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboMonths.Items.AddRange(new object[] { 1, 3, 6, 12 });
            cboMonths.SelectedIndexChanged += (s, e) =>
            {
                if (cboMonths.SelectedItem != null)
                    dtEnd.Value = dtStart.Value.AddMonths(Convert.ToInt32(cboMonths.SelectedItem));
            };

            nudPrice = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Maximum = 100_000_000,
                Increment = 100_000,
                ThousandsSeparator = true
            };

            btnSave = new Button { Text = "Lưu", Dock = DockStyle.Fill };
            btnCancel = new Button { Text = "Hủy", Dock = DockStyle.Fill };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();

            tlp.Controls.Add(new Label { Text = "Ngày bắt đầu", TextAlign = ContentAlignment.MiddleLeft }, 0, 0);
            tlp.Controls.Add(dtStart, 1, 0);

            tlp.Controls.Add(new Label { Text = "Thời hạn (tháng)", TextAlign = ContentAlignment.MiddleLeft }, 0, 1);
            tlp.Controls.Add(cboMonths, 1, 1);

            tlp.Controls.Add(new Label { Text = "Ngày kết thúc", TextAlign = ContentAlignment.MiddleLeft }, 0, 2);
            tlp.Controls.Add(dtEnd, 1, 2);

            tlp.Controls.Add(new Label { Text = "Giá thuê", TextAlign = ContentAlignment.MiddleLeft }, 0, 3);
            tlp.Controls.Add(nudPrice, 1, 3);

            tlp.Controls.Add(btnSave, 0, 4);
            tlp.Controls.Add(btnCancel, 1, 4);

            this.Controls.Add(tlp);
        }

        private void LoadOldContract()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"
                    SELECT room_id, end_date, price
                    FROM Contract
                    WHERE id = @id
                ", conn);

                cmd.Parameters.AddWithValue("@id", oldContractId);

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        roomId = rd.GetInt32("room_id");
                        dtStart.Value = rd.GetDateTime("end_date").AddDays(1);
                        nudPrice.Value = rd.GetDecimal("price");
                        cboMonths.SelectedIndex = 0;
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();

                try
                {
                    new MySqlCommand(
                        "UPDATE Contract SET is_active = 0 WHERE id = @id",
                        conn, tran)
                    {
                        Parameters = { new MySqlParameter("@id", oldContractId) }
                    }.ExecuteNonQuery();

                    var cmdNew = new MySqlCommand(@"
                        INSERT INTO Contract (room_id, start_date, end_date, price, is_active)
                        VALUES (@room, @start, @end, @price, 1)
                    ", conn, tran);

                    cmdNew.Parameters.AddWithValue("@room", roomId);
                    cmdNew.Parameters.AddWithValue("@start", dtStart.Value);
                    cmdNew.Parameters.AddWithValue("@end", dtEnd.Value);
                    cmdNew.Parameters.AddWithValue("@price", nudPrice.Value);
                    cmdNew.ExecuteNonQuery();

                    int newContractId = (int)cmdNew.LastInsertedId;

                    var cmdTenant = new MySqlCommand(@"
                        INSERT INTO Contract_Tenant (contract_id, tenant_id)
                        SELECT @newId, tenant_id
                        FROM Contract_Tenant
                        WHERE contract_id = @oldId
                    ", conn, tran);

                    cmdTenant.Parameters.AddWithValue("@newId", newContractId);
                    cmdTenant.Parameters.AddWithValue("@oldId", oldContractId);
                    cmdTenant.ExecuteNonQuery();

                    tran.Commit();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
