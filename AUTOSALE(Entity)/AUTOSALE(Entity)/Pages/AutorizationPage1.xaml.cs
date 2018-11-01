using AUTOSALE_Entity_.ViewModel;
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

namespace AUTOSALE_Entity_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage1.xaml
    /// </summary>
    public partial class AutorizationPage1 : Page
    {
        MainViewModel Mvm;
        public AutorizationPage1(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mvm.bMenuAutoriz1_Click.Execute(null);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            //using (Base_Autosale db = new Base_Autosale())
            //{
            //    //db.Users.Attach(s);
            //    //db.Messages.Add(m);
            //    //db.SaveChanges();
            //}
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            
            Mvm.bMenuAutoriz_Click.Execute(null);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Mvm.u._login = Login.Text;
            Mvm.u._password = Password.Password;
            Mvm.bMenuAutoriz2_Click.Execute(null);
        }
    }
}
