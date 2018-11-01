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
using System.Windows.Shapes;

namespace Calc_WPF_
{
    /// <summary>
    /// Логика взаимодействия для Quadratic.xaml
    /// </summary>
    public partial class Quadratic : Window
    {
        public double[] digit = null;
        public Quadratic()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(T1.Text=="" || T2.Text =="" || T3.Text == "") { return; }
            else
            {
                CalcService.CalcScienceClient client = new CalcService.CalcScienceClient();
                double[] arr = client.Discriminant(Double.Parse(T1.Text), Double.Parse(T2.Text), Double.Parse(T3.Text));
                if (arr == null)
                {
                    T4.Text = "Descriminant not found!!!";
                }
                else if(arr.Length==1)
                {
                    T4.Text = $"You have 1 Descriminant{arr[0]}";
                }
                else
                {
                    T4.Text = $"You have first Descriminant{arr[0]} second {arr[1]}";
                }
            }
        }
    }
}
