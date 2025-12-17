using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace QLPhongTro
{
    public partial class FormViewReport: Form
    {
        string str = "Server=localhost;Database=Room_Management;Uid=root;Pwd=";
        int _invoiceId;

        public FormViewReport(int invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;

        }

        private void FormViewReport_Load(object sender, EventArgs e)
        {


            LoadReport();   
        }
        private void LoadReport()
        {
            string sqlInvoice = @"
        SELECT
            i.id AS InvoiceId,
            i.month AS Month,
            i.year AS Year,
            i.status AS Status,
            i.total_cost AS TotalCost,
            r.room_name AS RoomName
        FROM Invoice i
        JOIN Contract c ON i.contract_id = c.id
        JOIN Room r ON c.room_id = r.id
        WHERE i.id = @invoiceId";

            string sqlConsumption = @"
        SELECT
            c.electric_old AS ElectricOld,
            c.electric_new AS ElectricNew,
            (c.electric_new - c.electric_old) AS ElectricUsed,
            c.electric_price_per_kwh AS ElectricPrice,
            (c.electric_new - c.electric_old) * c.electric_price_per_kwh AS ElectricCost,
            c.water_old AS WaterOld,
            c.water_new AS WaterNew,
            (c.water_new - c.water_old) AS WaterUsed,
            c.water_price_per_m3 AS WaterPrice,
            (c.water_new - c.water_old) * c.water_price_per_m3 AS WaterCost
        FROM Invoice i
        JOIN consumption c ON i.usage_id = c.id
        WHERE i.id = @invoiceId";

            string sqlService = @"
        SELECT
            s.service_name AS ServiceName,
            s.price AS Price
        FROM Invoice i
        JOIN Contract c ON i.contract_id = c.id
        JOIN Room_Service rs ON c.room_id = rs.room_id
        JOIN Service s ON rs.service_id = s.id
        WHERE i.id = @invoiceId";

            string sqlTenant = @"
        SELECT
            t.full_name AS FullName,
            ct.is_primary AS IsPrimary
        FROM Invoice i
        JOIN Contract c ON i.contract_id = c.id
        JOIN Contract_Tenant ct ON ct.contract_id = c.id
        JOIN Tenant t ON ct.tenant_id = t.id
        WHERE i.id = @invoiceId";


            DataTable dtInvoice = GetData(sqlInvoice);
            DataTable dtConsumption = GetData(sqlConsumption);
            DataTable dtService = GetData(sqlService);
            DataTable dtTenant = GetData(sqlTenant);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource =
                "QLPhongTro.ReportHoaDon.rdlc";

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("InvoiceInfo", dtInvoice));
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("ConsumptionInfo", dtConsumption));
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("ServiceDetail", dtService));
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("TenantInfo", dtTenant));

            reportViewer1.RefreshReport();
        }

        private DataTable GetData(string sql)
        {

            using (MySqlConnection conn = new MySqlConnection(str))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@invoiceId", _invoiceId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }


    }
}
