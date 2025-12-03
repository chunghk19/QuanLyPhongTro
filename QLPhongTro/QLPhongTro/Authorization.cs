using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro
{
    public static class Authorization
    {
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }   // ADMIN | TENANT
        public static bool IsActive { get; set; }
    }
}
