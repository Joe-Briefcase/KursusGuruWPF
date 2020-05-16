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
    /// Interaction logic for BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public ObservableCollection<Course> Courses { get; set; }
        public BooksPage()
        {
            InitializeComponent();
            // In production this method shouldn't be called (obviously :/)
            PopulateForTesting();
        }

        private void PopulateForTesting() {
            Courses = new ObservableCollection<Course>() {
                new Course(
                    1, "Swedish 101", new List<Book>(){
                        new Book(1, "Böök", "John Bork", "501-6-20-501863-1")
                    }
                ),
                new Course(
                    2, "General Insanity", new List<Book>(){
                        new Book(2, "Freestyle Your Way Trough Job Interviews", "Lil John", "385-6-11-123456-9"),
                        new Book(3, "Learn Computer Architecture Through Breakdance", "Ole Wedel", "978-3-16-148410-0")
                    }
                ),
                new Course(
                    3, "Advanced Yelling", new List<Book>(){
                        new Book(4, "AAAAAAAAAAARGH", "Ang Rey Gai", "483-9-13-405912-7"),
                        new Book(5, "More AAAAAAAAAAARGH", "Ang Rey Gai", "607-1-22-530629-4"),
                        new Book(6, "AAAAAAAAAAARGH Revisited", "Ang Rey Gai Jr.", "058-7-04-406919-6")
                    }
                )
            };
        }
    }
}
