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
using KursusGuru.Logic_Layer;
//using WpfScheduler;

namespace KursusGuru
{
    /// <summary>
    /// Interaction logic for scheduele.xaml
    /// </summary>
    /// 

    public class Insertdata {
        String id;
        String subject; 
    
        public Insertdata()
        {
            String id = this.id;
            String subject = this.subject;
        }

        public string Id  // property
        {
            get { return id; }   // get method
            set { id = value; }  // set method
        }

        public string Subject  // property
        {
            get { return subject; }   // get method
            set { subject = value; }  // set method
        }


    }

    public partial class schedule : Page
    {
        List<Insertdata> numbers = new List<Insertdata>();
        public schedule()
        {
            InitializeComponent();
        }

        //method to generate the schedule
        private void Calculate(List<Insertdata> numbers1) {

            for (int i = 0; i < numbers1.Count; i++)
            {
                //mandag
                if (numbers1[i].Id.Contains("earlymonday")) {
                    earlymonday.Content = numbers1[i].Subject;
                    earlymonday.Visibility = Visibility.Visible; 
                }

                if (numbers1[i].Id.Contains("latemonday"))
                {
                    latemonday.Content = numbers1[i].Subject;
                    latemonday.Visibility = Visibility.Visible;
                }

                //tirsdag 

                if (numbers1[i].Id.Contains("earlytuesday"))
                {
                    earltuesday.Content = numbers1[i].Subject;
                    earltuesday.Visibility = Visibility.Visible;
                }
                if (numbers1[i].Id.Contains("latetuesday"))
                {
                    latetuesday.Content = numbers1[i].Subject;
                    latetuesday.Visibility = Visibility.Visible;
                }

                //onsdag
                if (numbers1[i].Id.Contains("earlywednesday"))
                {
                    earlywednesday.Content = numbers1[i].Subject;
                    earlywednesday.Visibility = Visibility.Visible;
                }

                if (numbers1[i].Id.Contains("latewednesday"))
                {
                    latewednesday.Content = numbers1[i].Subject;
                    latewednesday.Visibility = Visibility.Visible;
                }

                //torsdag

                if (numbers1[i].Id.Contains("earlythursday"))
                {
                    earlythursday.Content = numbers1[i].Subject;
                    earlythursday.Visibility = Visibility.Visible;
                }

                if (numbers1[i].Id.Contains("latethursday"))
                {
                    latethursday.Content = numbers1[i].Subject;
                    latethursday.Visibility = Visibility.Visible;
                }

                //friday
                if (numbers1[i].Id.Contains("earlyfriday"))
                {
                    earlyfriday.Content = numbers1[i].Subject;
                    earlyfriday.Visibility = Visibility.Visible;
                }

                if (numbers1[i].Id.Contains("latefriday"))
                {
                    latefriday.Content = numbers1[i].Subject;
                    latefriday.Visibility = Visibility.Visible;
                }

            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Insertdata newday = new Insertdata();
            newday.Subject = LogicController.CurrentUser().courses[0].name;
            newday.Id = "earlymonday";

            Insertdata newday2 = new Insertdata();
            newday2.Subject = LogicController.CurrentUser().courses[1].name;
            newday2.Id = "latemonday";

            Insertdata newday3 = new Insertdata();
            newday3.Subject = LogicController.CurrentUser().courses[2].name;
            newday3.Id = "earlywednesday";

            Insertdata newday4 = new Insertdata();
            newday4.Subject = LogicController.CurrentUser().courses[3].name;
            newday4.Id = "earlythursday";

            Insertdata newday5 = new Insertdata();
            newday5.Subject = LogicController.CurrentUser().courses[4].name;
            newday5.Id = "latefriday";

            numbers.Add(newday);
            numbers.Add(newday2);
            numbers.Add(newday3);
            numbers.Add(newday4);
            numbers.Add(newday5);
            Calculate(numbers);
        }
    }
}
