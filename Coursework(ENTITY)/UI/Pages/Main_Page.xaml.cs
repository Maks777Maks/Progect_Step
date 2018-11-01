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
using UI;

namespace AUTOSALE_Entity_.Pages
{
    /// <summary>
    /// Логика взаимодействия для Start_Page.xaml
    /// </summary>
    public partial class Main_Page : Page
    {
        User u = new User();
        MainViewModel MvM;
        string tmp = "";
        public Main_Page(MainViewModel mvm)
        {
            InitializeComponent();
            MvM = mvm;           
        }

        private void Select_Transport(object sender, RoutedEventArgs e)
        {            
            using (CONTEXT db = new CONTEXT())
            {
                Brand.ItemsSource = null;
                Model.ItemsSource = null;
                Fuel.ItemsSource = db.Fuels.ToList();
                Registration.ItemsSource = db.Years.ToList();
                if ((sender as Button).Name == "Moto")
                {
                    Brand.ItemsSource = db.Moto_Brand.ToList();
                    tmp = "Moto";
                }
                else if ((sender as Button).Name == "Car")
                {
                    Brand.ItemsSource = db.Car_Brand.ToList();
                    tmp = "Car";
                }
                else if ((sender as Button).Name == "Truck")
                {
                    Brand.ItemsSource = db.Trucks_Brand.ToList();
                    tmp = "Truck";
                }
                else if ((sender as Button).Name == "Bus")
                {
                    Brand.ItemsSource = db.Bus_Brand.ToList();
                    tmp = "Bus";
                }
            }
        }

        private void Button_Det_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Select_Brand(object sender, SelectionChangedEventArgs e)
        {
            if (Brand.SelectedIndex == -1) { return; }
            using (CONTEXT db = new CONTEXT())
            {
                
                if (tmp == "Moto")
                {
                    Moto_Brand b = new Moto_Brand();
                    string str = (Brand.SelectedItem as Moto_Brand).Brand;
                    b = db.Moto_Brand.First(x => x.Brand == str);
                    Model.ItemsSource = b._Moto_Model;
                }
                else if (tmp == "Car")
                {
                    Car_Brand b = new Car_Brand();
                    string str = (Brand.SelectedItem as Car_Brand).Brand;
                    b = db.Car_Brand.First(x => x.Brand == str);
                    Model.ItemsSource = b._Car_Model;
                }
                else if (tmp == "Truck")
                {
                    Trucks_Brand b = new Trucks_Brand();
                    string str = (Brand.SelectedItem as Trucks_Brand).Brand;
                    b = db.Trucks_Brand.First(x => x.Brand == str);
                    Model.ItemsSource = b._Trucs_Model;
                }
                else if (tmp == "Bus")
                {                  
                    Bus_Brand b = new Bus_Brand();
                    string str = (Brand.SelectedItem as Bus_Brand).Brand;
                    b = db.Bus_Brand.First(x => x.Brand == str);
                    Model.ItemsSource = b._Bus_Model;                                                                        
                }                                
            }
        }

        private void Select_Model(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
