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
    /// Логика взаимодействия для AutorizationPage2UA.xaml
    /// </summary>
    public partial class AutorizationPage2UA : Page
    {
        MainViewModel MvM;
        public AutorizationPage2UA(MainViewModel mvm)
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
            MvM.bMenuAutoriz1UA_Click.Execute(null);
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
            MvM.bMenuMainUA_Click.Execute(null);
        }
    }
}
