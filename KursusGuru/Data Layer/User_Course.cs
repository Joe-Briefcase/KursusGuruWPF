using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KursusGuru.Data_Layer.User;
namespace KursusGuru.Data_Layer
{
    public class User_Course
    {
        // This class represents a single course with a list of corresponding book objects
        public string Name { set; get; }
        public string CourseSummary { set; get; }
        public int Id { set; get; }
        public int CourseWeight { set; get; }
        /*
        public IList<Assignment> Assignments { get; set; }
        public IList<Book> Books { get; set; }
        
        public User_Course(string name, string courseSummary, int id, int courseWeight, ObservableCollection<Assignment> assignments)
        {
            this.Name = name;
            this.CourseSummary = courseSummary;
            this.Id = id;
            this.CourseWeight = courseWeight;
            this.Assignments = assignments;
        }
        public User_Course(string name, string courseSummary, int id, int courseWeight, ObservableCollection<Book> books)
        {
            this.Name = name;
            this.CourseSummary = courseSummary;
            this.Id = id;
            this.CourseWeight = courseWeight;
            this.Books = books;
        }
        */
    }
}
