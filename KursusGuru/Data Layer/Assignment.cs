using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Data_Layer
{
    // This class represents a single course with a list of corresponding assignment objects
    public class Assignment
    {
        int Id { get; set; }
        string Title { get; set; }
        DateTime DueDate { get; set; }
        public Assignment(int Id, string Title, DateTime DueDate)
        {
            this.Id = Id;
            this.Title = Title;
            this.DueDate = DueDate;
        }
    }
}
