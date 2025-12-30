using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro_1.Common
{
    //Lưu giữ thông tin người đang đăng nhập trong lúc chương trình đang chạy
    public static class AppSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; } // ADMIN / TENANT
        public static bool IsLoggedIn { get; set; }

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
            IsLoggedIn = false;
        }
    }
}
