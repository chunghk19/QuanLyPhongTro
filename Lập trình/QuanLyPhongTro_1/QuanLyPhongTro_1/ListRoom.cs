using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro_1
{
    internal class ListRoom
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ListRoom(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text; // CheckedListBox sẽ hiển thị text
        }
    }
}
