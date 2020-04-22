using System;
using System.Collections.Generic;
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

namespace KursusGuru
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = StudentNumber.Text;
            string password = StudentPassword.Password;
            int id = Int32.Parse(username.Remove(0, 1));
            User user = DataController.LoadUserData(id);
            LogicController.SetCurrentUser(user);
            Properties.Settings.Default.IsUserLoggedIn = true;
            Console.WriteLine("Test");
        }
    }
}
