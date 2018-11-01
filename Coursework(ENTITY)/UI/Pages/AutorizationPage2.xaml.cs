using AUTOSALE_Entity_.ViewModel;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using UI;

namespace AUTOSALE_Entity_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage2.xaml
    /// </summary>
    public partial class AutorizationPage2 : Page
    {
        MainViewModel MvM;
        bool _name = false;
        bool _mail = false;
        bool _phone = false;
        bool _city = false;

        public AutorizationPage2(MainViewModel mvm)
        {
            InitializeComponent();
            MvM = mvm;
            using (CONTEXT db = new CONTEXT())
            {
                CITY.ItemsSource = db.Cities.ToList();
            }
            
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MvM.bMenuAutoriz1_Click.Execute(null);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            MvM.u._name = NAME.Text;
            MvM.u._mail = MAIL.Text;
            MvM.u._tel = PHONE.Text;
            MvM.u._city = CITY.SelectedItem as City;
                      
            using (CONTEXT db = new CONTEXT())
            {
                db.Entry(MvM.u).State = EntityState.Added;
                db.SaveChanges();
            }
                MvM.bMenuMain_Click.Execute(null);
        }

        private void NAME_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_name == false)
            {
                Bar.Value += 15;
                _name = true;
            }
            if(NAME.Text=="")
            {
                _name = false;
                Bar.Value -= 15;
            }
            
        }

        private void MAIL_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_mail == false)
            {
                Bar.Value += 15;
                _mail = true;
            }
            if (MAIL.Text == "")
            {
                _mail = false;
                Bar.Value -= 15;
            }
        }

        private void PHONE_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_phone == false)
            {
                Bar.Value += 15;
                _phone = true;
            }
            if (PHONE.Text == "")
            {
                _phone = false;
                Bar.Value -= 15;
            }
        }

        private void CITY_Selected(object sender, RoutedEventArgs e)
        {
            if (_city == false)
            {
                Bar.Value += 15;
                _city = true;
            }           
        }
    }
}
