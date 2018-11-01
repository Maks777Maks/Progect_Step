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

namespace AUTOSALE_Entity_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage2.xaml
    /// </summary>
    public partial class AutorizationPage2 : Page
    {
        MainViewModel MvM;
        //Base_Autosale db = new Base_Autosale();

        public AutorizationPage2(MainViewModel mvm)
        {
            InitializeComponent();
            MvM = mvm;
           // CITY.ItemsSource = db.Cities.ToList();
            // CITY.ItemsSource=
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
           
            //MessageBox.Show(MvM.u._name);
            //MessageBox.Show(MvM.u._login);
            //MessageBox.Show(MvM.u._password);
            //MessageBox.Show(MvM.u._mail);
            //MessageBox.Show(MvM.u._tel);
            //using (Base_Autosale db = new Base_Autosale())
            //{
            //    db.Entry(MvM.u).State = EntityState.Added;
            //    db.SaveChanges();
            //}
                MvM.bMenuMain_Click.Execute(null);
        }
    }
}
