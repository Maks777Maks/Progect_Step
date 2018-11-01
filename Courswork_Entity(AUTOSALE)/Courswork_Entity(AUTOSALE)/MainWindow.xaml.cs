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
using Library1;

namespace Courswork_Entity_AUTOSALE_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        Base_Autosale db = new Base_Autosale();

        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(db.Cities.First().Name_UA);
            
            //.ItemsSource = db.Years.ToList();
            //Fuel.ItemsSource = db.Fuels.ToList();
            
        }

        private void Click_Logo(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Click_stack(object sender, MouseButtonEventArgs e)
        {
            if ((sender as StackPanel).Name == "stack2")
            {
                Sel_Lang.Content = "UA";
                Image1.Source = Image2.Source;
                Block_Brand.Text = "Марка";
                Block_Model.Text = "Модель";
                Block_Price.Text = "Ціна";
                Block_Registr.Text = "1-ша регістрація";
                Buy.Content = "Купити";
                Block_Mill.Text = "Пробіг до";
                Block_Fuel.Text = "Тип палива";
                Label_Add.Content = "+  Oголошення";
                Label_Login.Content = "Авторизація";
                Button_Det_Search.Content = "Детальний пошук";
                Button_Search.Content = "ПОШУК";
            }
            else if ((sender as StackPanel).Name == "stack3")
            {
                Sel_Lang.Content = "EN";
                Image1.Source = Image3.Source;
                Block_Brand.Text = "Brand";
                Block_Model.Text = "Model";
                Block_Price.Text = "Price";
                Block_Registr.Text = "1st Registration";
                Buy.Content = "Buy";
                Block_Mill.Text = "Mileage to";
                Block_Fuel.Text = "Type of fuel";
                Label_Add.Content = "Submit your ad";
                Label_Login.Content = "Login";
                Button_Det_Search.Content = "Detailed Search";
                Button_Search.Content = "SEARCH";
            }
            else if((sender as StackPanel).Name == "stack4")
            {
                Sel_Lang.Content = "RUS";
                Image1.Source = Image4.Source;
                Block_Brand.Text = "Марка";
                Block_Model.Text = "Модель";
                Block_Price.Text = "Цена";
                Block_Registr.Text = "1-я регистрация";
                Buy.Content = "Купить";
                Block_Mill.Text = "Пробег до";
                Block_Fuel.Text = "Тип топлива";
                Label_Add.Content = "+  Oбявление";
                Label_Login.Content = "Авторизация";
                Button_Det_Search.Content = "Детальный поиск";
                Button_Search.Content = "ПОИСК";
            }
            Expand.IsExpanded = false;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Login(object sender, MouseButtonEventArgs e)
        {
            Autorization _autorization = new Autorization();
                                      
                if (_autorization.ShowDialog() == true)
                {                  
                       
                }           
        }

        private void Select_Transport(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "Moto")
            {
                Brand.ItemsSource = db.Moto_Brand.ToList();
            }
            else if ((sender as Button).Name == "Car")
            {
                Brand.ItemsSource = db.Car_Brand.ToList();
            }
            else if ((sender as Button).Name == "Truck")
            {
                Brand.ItemsSource = db.Trucks_Brand.ToList();
            }
            else if ((sender as Button).Name == "Bus")
            {
                Brand.ItemsSource = db.Bus_Brand.ToList();
            }
        }

        private void Button_Det_Search_Click(object sender, RoutedEventArgs e)
        {
            Detail_Search _detail = new Detail_Search();

            if (_detail.ShowDialog() == true)
            {

            }
        }

        private void Ads(object sender, MouseButtonEventArgs e)
        {
            Window_Ads _ads = new Window_Ads();
            _ads.ShowDialog();
        }
    }
}
