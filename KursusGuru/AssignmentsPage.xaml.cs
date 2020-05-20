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
    }
}
