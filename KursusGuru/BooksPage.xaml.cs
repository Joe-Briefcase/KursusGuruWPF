using KursusGuru.Data_Layer;
using KursusGuru.Logic_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static KursusGuru.Data_Layer.User;

namespace KursusGuru
{
    /// <summary>
    /// Interaction logic for BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        
        private User User { get; }
        public BooksPage()
        {
            InitializeComponent();
            User = LogicController.CurrentUser();
            mainGrid.DataContext = User.User_Courses;
            userName.DataContext = User;
        }
        /*
        private void InitializeData()
        {
            ObservableCollection<Courses> userCourses = new ObservableCollection<Courses>();
            ObservableCollection<Book> userBooks = new ObservableCollection<Book>();
            Courses = new ObservableCollection<User_Course>();
            foreach (Book b in User.books)
            {
                userBooks.Add(b);
            }
            // User API does not provide any foreign key linking courses to assignment/books
            // Until they do the User_Course objects cannot be created correctly.
            // Therefore all courses contain all assignments/books
            foreach (Courses c in User.courses)
            {
                Courses.Add(new User_Course(c.name, c.courseSummary, c.id, c.courseWeight, userBooks));
            }
        }
        */
    }
}
