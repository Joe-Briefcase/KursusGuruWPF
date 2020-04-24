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
        public string password { set; get; }
        public Assignment[] assignments { set; get; }
        public Book[] books { set; get; }
        public Courses[] courses { set; get; }

        public class Calender
        {

        }
        public class Assignment
        {
            public string name { set; get; }
            public string description { set; get; }
            public DateTime deadline { set; get; }
        }
        public class Book
        {
            public string name { set; get; }
            public int length { set; get; }
        }
        public class Courses
        {
            public string name { set; get; }
            public string courseSummary { set; get; }
            public int id { set; get; }
            public int courseWeight { set; get; }
        }
    }
}
