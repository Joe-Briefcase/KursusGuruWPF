using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Data_Layer
{
    class User
    {
        public static ObservableCollection<User_Course> User_Courses { get; set; }
        public string userName { set; get; }
        public int id { set; get; }
        public string password { set; get; }
        public Assignment[] assignments { set; get; }
        public Book[] books { set; get; }
        public Courses[] courses { set; get; }

        public User()
        {
            this.courses = new Courses[5];
            this.books = new Book[10];
            this.assignments = new Assignment[10];
        }


        public class Assignment
        {
            public string name { set; get; }
            public string course { set; get; }
            public DateTime deadline { set; get; }
        }
        public class Book
        {
            public string name { set; get; }
            public string author { set; get; }
        }
        public class Courses
        {
            public string name { set; get; }
            public string courseSummary { set; get; }
            public int id { set; get; }
            public int courseWeight { set; get; }
            public string time { set; get; }
        }
        public class User_Course
        {
            // This class represents a single course with a list of corresponding book objects
            public string Name { set; get; }
            public string CourseSummary { set; get; }
            public int Id { set; get; }
            public int CourseWeight { set; get; }
            
            public IList<Assignment> Assignments { get; set; }
            public IList<Book> Books { get; set; }

            public User_Course(string name, string courseSummary, int id, int courseWeight, ObservableCollection<Assignment> assignments, ObservableCollection<Book> books)
            {
                this.Name = name;
                this.CourseSummary = courseSummary;
                this.Id = id;
                this.CourseWeight = courseWeight;
                this.Books = books;
                this.Assignments = assignments;
            }
        }
        public void InitializeUserCoursesData()
        {
            ObservableCollection<Assignment> userAssignments = new ObservableCollection<Assignment>();
            ObservableCollection<Book> userBooks = new ObservableCollection<Book>();
            User_Courses = new ObservableCollection<User_Course>();
            foreach (Assignment a in assignments)
            {
                userAssignments.Add(a);
            }
            foreach (Book b in books)
            {
                userBooks.Add(b);
            }
            foreach (Courses c in courses)
            {
                User_Courses.Add(new User_Course(c.name, c.courseSummary, c.id, c.courseWeight, userAssignments, userBooks));
            }
        }
    }
}
