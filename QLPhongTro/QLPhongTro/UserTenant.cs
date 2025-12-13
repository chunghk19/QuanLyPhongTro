using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro
{
    internal class UserTenant
    {
        public int id { get; set; }
        public string userName { get; set; }
        public UserTenant(int id, string userName)
        {
            this.id = id;
            this.userName = userName;
        }
        public override string ToString()
        {
            return userName; // CheckedListBox sẽ hiển thị text
        }
    }
}
