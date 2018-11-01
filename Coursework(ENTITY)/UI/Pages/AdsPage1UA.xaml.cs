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
    /// Логика взаимодействия для AdsPage1UA.xaml
    /// </summary>
    public partial class AdsPage1UA : Page
    {
        MainViewModel Mvm;
        string tmp = "";

        public AdsPage1UA(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;
            
        }

        private void Select_Transport(object sender, RoutedEventArgs e)
        {
            using (CONTEXT db = new CONTEXT())
            {
                Brand.ItemsSource = null;
                Model.ItemsSource = null;
                Fuel.ItemsSource = db.Fuels.ToList();
                Engine.ItemsSource = db.Engines.ToList();
                Trans.ItemsSource = db.Transmissions.ToList();
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

        private void Next(object sender, RoutedEventArgs e)
        {
            if (Brand.SelectedIndex == -1 || Model.SelectedIndex == -1 || Engine.SelectedIndex == -1 || Trans.SelectedIndex == -1 || Fuel.SelectedIndex == -1)
            {
                MessageBox.Show("Not all fields are full");
                return;
            }
            else
            {
                if (tmp == "Moto")
                {
                    Mvm.Ad._brand = (Brand.SelectedItem as Moto_Brand).Brand;
                    Mvm.Ad._model = (Model.SelectedItem as Moto_Model).Model;
                    Mvm.Ad._fuel = (Fuel.SelectedItem as Fuel);
                    Mvm.Ad._engine = (Engine.SelectedItem as Engine);
                    Mvm.Ad._transmission = (Trans.SelectedItem as Transmission);
                }
                else if (tmp == "Car")
                {
                    Mvm.Ad._brand = (Brand.SelectedItem as Car_Brand).Brand;
                    Mvm.Ad._model = (Model.SelectedItem as Car_Model).Model;
                    Mvm.Ad._fuel = (Fuel.SelectedItem as Fuel);
                    Mvm.Ad._engine = (Engine.SelectedItem as Engine);
                    Mvm.Ad._transmission = (Trans.SelectedItem as Transmission);
                }
                else if (tmp == "Truck")
                {
                    Mvm.Ad._brand = (Brand.SelectedItem as Trucks_Brand).Brand;
                    Mvm.Ad._model = (Model.SelectedItem as Trucs_Model).Model;
                    Mvm.Ad._fuel = (Fuel.SelectedItem as Fuel);
                    Mvm.Ad._engine = (Engine.SelectedItem as Engine);
                    Mvm.Ad._transmission = (Trans.SelectedItem as Transmission);
                }
                else if (tmp == "Bus")
                {
                    Mvm.Ad._brand = (Brand.SelectedItem as Bus_Brand).Brand;
                    Mvm.Ad._model = (Model.SelectedItem as Bus_Model).Model;
                    Mvm.Ad._fuel = (Fuel.SelectedItem as Fuel);
                    Mvm.Ad._engine = (Engine.SelectedItem as Engine);
                    Mvm.Ad._transmission = (Trans.SelectedItem as Transmission);
                }
            }
            Mvm.bAds2_Click.Execute(null);
        }
    }
}
