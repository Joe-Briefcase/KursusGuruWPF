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

            // User dictionary initialiseres med nogle brugere
            User userAdmin = new User();
            userAdmin.userName = "Ted Bundy";
            userAdmin.id = 185143;
            DataController.SaveUserData(userAdmin);
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

            UserId.Text = LogicController.CurrentUser().id.ToString();
            LoadCourses(LogicController.CurrentUser());
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

            /*
            SeleniumLogin.SeleniumLoginLearn("s" + LogicController.CurrentUser().id, LogicController.CurrentUser().password);
            for (int course = 0; course < 0; course++)
            {
                for (int announcement = 0; announcement < 0; announcement++)
                {
                    Console.WriteLine(SeleniumLogin.announcements[course][announcement]);
                    Console.WriteLine("LOL");
                }
            }
            */
        }
    }
}
