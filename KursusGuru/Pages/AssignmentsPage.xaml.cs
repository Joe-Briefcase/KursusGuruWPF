using KursusGuru.Data_Layer;
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

namespace KursusGuru.Pages
{
    /// <summary>
    /// Interaction logic for AssignmentsPage.xaml
    /// </summary>
    public partial class AssignmentsPage : Page
    {
        public ObservableCollection<Course> Courses { get; set; }
        public AssignmentsPage()
        {
            InitializeComponent();
            PopulateForTesting();
        }

        private void PopulateForTesting()
        {
            Courses = new ObservableCollection<Course>()
            {
                new Course(
                    1, "Swedish 101", new List<Assignment>(){
                        new Assignment(1, "Learn some Swedish", new DateTime())
                    }
                ),
                new Course(
                    2, "General Insanity", new List<Assignment>(){
                        new Assignment(2, "Smash That Interview", new DateTime()),
                        new Assignment(3, "Break it Down. Now.", new DateTime())
                    }
                ),
                new Course(
                    3, "Advanced Yelling", new List<Assignment>(){
                        new Assignment(4, "Yell at Some Birds", new DateTime()),
                        new Assignment(5, "Yell at Some Kinds", new DateTime()),
                        new Assignment(6, "Yell at the Elderly", new DateTime())
                    }
                )
            };
        }
    }
}
