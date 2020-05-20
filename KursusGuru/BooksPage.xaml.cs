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
    }
}
