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
    /// Логика взаимодействия для Start_Page.xaml
    /// </summary>
    public partial class Main_Page : Page
    {
        User u = new User();
        MainViewModel MvM;
        public Main_Page(MainViewModel mvm)
        {
            InitializeComponent();
            MvM = mvm;
            test.DataContext = u;
        }

        private void Select_Transport(object sender, RoutedEventArgs e)
        {
            //using (Base_Autosale db = new Base_Autosale())
            //{
            //    Fuel.ItemsSource = db.Fuels.ToList();
            //    Registration.ItemsSource = db.Years.ToList();
            //    if ((sender as Button).Name == "Moto")
            //    {
            //        Brand.ItemsSource = db.Moto_Brand.ToList();
            //    }
            //    else if ((sender as Button).Name == "Car")
            //    {
            //        Brand.ItemsSource = db.Car_Brand.ToList();
            //    }
            //    else if ((sender as Button).Name == "Truck")
            //    {
            //        Brand.ItemsSource = db.Trucks_Brand.ToList();
            //    }
            //    else if ((sender as Button).Name == "Bus")
            //    {
            //        Brand.ItemsSource = db.Bus_Brand.ToList();
            //    }
            //}
        }

        private void Button_Det_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Select_Brand(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
