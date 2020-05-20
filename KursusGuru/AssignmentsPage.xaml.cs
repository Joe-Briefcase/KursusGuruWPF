using KursusGuru.Data_Layer;
using static KursusGuru.Data_Layer.User;
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
using KursusGuru.Logic_Layer;

namespace KursusGuru
{
    /// <summary>
    /// Interaction logic for AssignmentsPage.xaml
    /// </summary>
    public partial class AssignmentsPage : Page
    {
        private User User { get; }
        public AssignmentsPage()
        {
            InitializeComponent();
            User = LogicController.CurrentUser();
            //InitializeData();
            mainGrid.DataContext = User.User_Courses;
            userName.DataContext = User;
        }
        /*
        private void InitializeData()
        {
            ObservableCollection<Courses> userCourses = new ObservableCollection<Courses>();
            ObservableCollection<Assignment> userAssignments = new ObservableCollection<Assignment>();
            Courses = new ObservableCollection<User_Course>();
            foreach (Assignment a in User.assignments)
            {
                userAssignments.Add(a);
            }
            // User API does not provide any foreign key linking courses to assignment/books
            // Until they do the User_Course objects cannot be created correctly.
            // Therefore all courses contain all assignments/books
            foreach (Courses c in User.courses)
            {
                Courses.Add(new User_Course(c.name, c.courseSummary, c.id, c.courseWeight, userAssignments));
            }
        }
        */
    }
}
