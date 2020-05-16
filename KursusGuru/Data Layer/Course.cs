using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Data_Layer
{
    public class Course
    {
        // This class represents a single course with a list of corresponding book objects
        int Id { get; set; }
        string Name { get; set; }
        IList<Book> Books { get; set; }
        IList<Assignment> Assignments { get; set; }
        public Course(int Id, string Name, IList<Book> Books)
        {
            this.Id = Id;
            this.Name = Name;
            this.Books = Books;
        }
        public Course(int Id, string Name, IList<Assignment> Assignments)
        {
            this.Id = Id;
            this.Name = Name;
            this.Assignments = Assignments;
        }
    }
}
