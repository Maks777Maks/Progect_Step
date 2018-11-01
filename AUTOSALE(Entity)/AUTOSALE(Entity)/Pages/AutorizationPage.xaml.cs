using AUTOSALE_Entity_.ViewModel;
using ClassLibrary;
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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        MainViewModel Mvm;
        public AutorizationPage(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;          
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            Mvm.bMenuAutoriz1_Click.Execute(null);
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {

            //using (Base_Autosale db = new Base_Autosale())
            //{
            //    foreach (var i in db.Users)
            //    {
            //        if (i._login == Login.Text && i._password == Password.Password)
            //        {
            //            Mvm.u._name = i._name;
            //            Mvm.u._password = i._password;
            //            Mvm.u._mail = i._mail;
            //            Mvm.u._tel = i._tel;
            //            Mvm.u._login = i._login;
            //            Mvm.u._city = i._city;
            //            MessageBox.Show(i._name);
            //            Mvm.bMenuMain_Click.Execute(null);
            //        }
            //    }
            //}
        }
    }
}
