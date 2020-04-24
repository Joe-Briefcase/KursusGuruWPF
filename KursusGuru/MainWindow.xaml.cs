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

            // User dictionary initialiseres med nogle brugere
            User user1 = new User();
            user1.userName = "Teddy Roosevelt";
            user1.id = 183939;
            User user2 = new User();
            user2.userName = "Woodrow Wilson";
            user2.id = 191747;
            User user3 = new User();
            user3.userName = "Abraham Lincoln";
            user3.id = 182828;
            User userAdmin = new User();
            userAdmin.userName = "Ted Bundy";
            userAdmin.id = 185143;
            DataController.SaveUserData(user1);
            DataController.SaveUserData(user2);
            DataController.SaveUserData(user3);
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

            UserId.Text = LogicController.CurrentUser().userName;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            SeleniumLogin.SeleniumLoginInside(LogicController.CurrentUser().userName, LogicController.CurrentUser().password);
            Console.WriteLine(SeleniumLogin.courses.ToString());
        }
    }
}
