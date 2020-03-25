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
using System.Windows.Shapes;
using KursusGuru.Data_Layer;

namespace KursusGuru
{
    /// <summary>
    /// Interaction logic for DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        /*
         * Tester data laget ved at gemme og hente en bruger
         * og vise dens brugernavn.
         */
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            User user = new User();
            user.userName = username;
            user.id = Int32.Parse(username.Remove(0, 1));
            DataController.SaveUserData(user);
            User user2 = DataController.LoadUserData(user.id);
            DebugTextBox.Text = user2.userName + "\n" + user2.id;
        }
    }
}
