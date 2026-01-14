using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuanLyPhongTro_1.Common
{
    internal class DbHelper
    {
        public static string ConnectionString =
            "Server=localhost;Database=Room_Management;Uid=root;Pwd=";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
