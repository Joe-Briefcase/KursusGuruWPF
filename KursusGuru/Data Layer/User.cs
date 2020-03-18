using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Data_Layer
{
    class User
    {
        public Calender calender { set; get; }
        public string userName { set; get; }
        public int id { set; get; }
        public Assignment[] assignments { set; get; }
        public Book[] books { set; get; }
    }
    class Calender { }
    class Assignment { }
    class Book { }
}
