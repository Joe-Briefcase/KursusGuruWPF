using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using KursusGuru.Data_Layer;
using KursusGuru.Logic_Layer;
using KursusGuru.Properties;

namespace KursusGuru
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Subscribe til events
            Settings.Default.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(WhenUserLogsInEvent);
            
            // Tjekker om brugeren er logget ind og hvis de er gemmes login skærmen
            if (Properties.Settings.Default.IsUserLoggedIn)
            {
                loginFrame.Visibility = Visibility.Hidden;
            } else
            {
                loginFrame.Visibility = Visibility.Visible;
            }

            afleveringerFrame.Visibility = Visibility.Hidden;
            booksFrame.Visibility = Visibility.Hidden;
            skemaFrame.Visibility = Visibility.Hidden;

            // Admin bruger
            User userAdmin = new User();
            userAdmin.userName = "Admin";
            userAdmin.id = 185143;
            DataController.SaveUserData(userAdmin);

            // Test bruger
            User testUser = new User();
            testUser.userName = "Test";
            testUser.id = 123456;
            testUser.courses[0] = new User.Courses();
            testUser.courses[0].name = "Indledende Programmering";
            testUser.courses[0].time = "earlytuesday";
            testUser.courses[1] = new User.Courses();
            testUser.courses[1].name = "Datakommunikation";
            testUser.courses[1].time = "latetuesday";
            testUser.courses[2] = new User.Courses();
            testUser.courses[2].name = "Test Metoder";
            testUser.courses[2].time = "earlyfriday";
            testUser.courses[3] = new User.Courses();
            testUser.courses[3].name = "Diskret Matematik";
            testUser.courses[3].time = "earlywednesday";
            testUser.courses[4] = new User.Courses();
            testUser.courses[4].name = "Udviklingsmetoder";
            testUser.courses[4].time = "latemonday";
            testUser.books[0] = new User.Book();
            testUser.books[0].name = "Applying UML and Patterns";
            testUser.books[0].author = "Larman";
            testUser.books[1] = new User.Book();
            testUser.books[1].name = "Professional C# and .NET Core 2.0";
            testUser.books[1].author = "Nagel";
            testUser.books[2] = new User.Book();
            testUser.books[2].name = "Diskret Mat Kursusnoter";
            testUser.books[2].author = "Ukendt";
            testUser.assignments[0] = new User.Assignment();
            testUser.assignments[0].name = "Første Aflevering";
            testUser.assignments[0].course = "Indledende Programmering";
            testUser.assignments[0].deadline = new DateTime(2020, 6, 2);
            testUser.assignments[1] = new User.Assignment();
            testUser.assignments[1].name = "Ugentlig Aflevering";
            testUser.assignments[1].course = "Diskret Mat";
            testUser.assignments[1].deadline = new DateTime(2020, 6, 12);
            DataController.SaveUserData(testUser);
            testUser.InitializeUserCoursesData();
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonPopUpLogou_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        // Når brugeren logger ind gemmes login skærmen
        private void WhenUserLogsInEvent(object sender, PropertyChangedEventArgs e)
        {
            if (Properties.Settings.Default.IsUserLoggedIn)
            {
                loginFrame.Visibility = Visibility.Hidden;
            }
            else
            {
                loginFrame.Visibility = Visibility.Visible;
            }

            UserId.Text = "s" + LogicController.CurrentUser().id.ToString();
            if (LogicController.CurrentUser().id != 123456)
            {
                LoadCourses(LogicController.CurrentUser());
            }
        }

        private void Skema_Selected(object sender, RoutedEventArgs e)
        {
            afleveringerFrame.Visibility = Visibility.Hidden;
            booksFrame.Visibility = Visibility.Hidden;
            skemaFrame.Visibility = Visibility.Visible;
        }

        private void AfleveringerButton_Selected(object sender, RoutedEventArgs e)
        {
            afleveringerFrame.Visibility = Visibility.Visible;
            booksFrame.Visibility = Visibility.Hidden;
            skemaFrame.Visibility = Visibility.Hidden;
        }

        private void BooksButton_Selected(object sender, RoutedEventArgs e)
        {
            afleveringerFrame.Visibility = Visibility.Hidden;
            booksFrame.Visibility = Visibility.Visible;
            skemaFrame.Visibility = Visibility.Hidden;
        }

        private void OversigtButton_Selected(object sender, RoutedEventArgs e)
        {
            afleveringerFrame.Visibility = Visibility.Hidden;
            booksFrame.Visibility = Visibility.Hidden;
            skemaFrame.Visibility = Visibility.Hidden;
        }

        // Selenium
        private void LoadCourses(User user)
        {
            int i = 0;
            SeleniumLogin.SeleniumLoginInside("s" + LogicController.CurrentUser().id, LogicController.CurrentUser().password);
            foreach (string course in SeleniumLogin.courses)
            {
                Console.WriteLine(course);

                user.courses[i] = new User.Courses();
                user.courses[i].name = course;
                i++;
            }
        }
    }
}
