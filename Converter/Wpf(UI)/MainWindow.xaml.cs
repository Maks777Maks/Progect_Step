using MahApps.Metro.Controls;
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
using Wpf_UI_.ServiceReference1;

namespace Wpf_UI_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Combo.Items.Add("Celsius");
            Combo.Items.Add("Fahrenheit");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Combo.SelectedIndex == -1)
            {
                Temp.Content = "";
                Result.Text = "";
                return;
            }
            else if (Combo.SelectedIndex == 0)
            {
                Service1Client service = new Service1Client();                
                Temp.Content = "Fahrenheit:";
                Result.Text = service.CelsiusToFahrenheit(Convert.ToDouble(Temperature.Text)).Fahrenheit.ToString();
            }
            else
            {
                Service1Client service = new Service1Client();
                Temp.Content = "Celsius:";
                Result.Text = service.FahrenheitToCelsius(Convert.ToDouble(Temperature.Text)).Celsius.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Service1Client service = new Service1Client();
            Inches.Content=service.LinearMeasure(Convert.ToDouble(Meters.Text)).inch.ToString();
            Foot.Content= service.LinearMeasure(Convert.ToDouble(Meters.Text)).foot.ToString();
            Yards.Content= service.LinearMeasure(Convert.ToDouble(Meters.Text)).yard.ToString();
        }
    }
}
