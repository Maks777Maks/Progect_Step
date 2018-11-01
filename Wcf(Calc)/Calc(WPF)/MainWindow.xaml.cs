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

namespace Calc_WPF_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result = 0;
        string tmp = "";
        bool fist = false;
        bool second = true;
        bool flag = false;


        public MainWindow()
        {
            InitializeComponent();
            t2.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (fist == false)
            {
                t1.Clear();
                t2.Clear();
                flag = false;
                result = 0;
                fist = true;
            }
            if (second == true)
            {
                t2.Text += (string)button.Content;
            }
            else
            {
                t2.Text = (string)button.Content;
                second = true;
            }
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            t1.Clear();
            t2.Clear();
            flag = false;
            result = 0;
        }

        private void Button_Operation(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string str;
            str = (string)button.Content;
            second = false;
            t1.Text += t2.Text + str;
            if (flag == true)
            {
                switch (tmp)
                {
                    case "+":

                        result += Double.Parse(t2.Text);
                        t2.Text = result.ToString();
                        tmp = str;
                        break;
                    case "-":
                        result -= Double.Parse(t2.Text);
                        t2.Text = result.ToString();
                        tmp = str;
                        break;
                    case "*":
                        result *= Double.Parse(t2.Text);
                        t2.Text = result.ToString();
                        tmp = str;
                        break;
                    case "/":
                        if (t2.Text != "0")
                        {
                            result /= Double.Parse(t2.Text);
                            t2.Text = result.ToString();
                            tmp = str;
                        }
                        else
                        {
                            t2.Text = "Деление на ноль не возможно!!!";
                            fist = false;
                        }
                        break;
                }

            }

            else
            {
                result = Double.Parse(t2.Text);
                tmp = str;
                flag = true;
            }
        }

        private void Button_Result(object sender, RoutedEventArgs e)
        {
            CalcService.CalcStandartClient calc = new CalcService.CalcStandartClient();
            double res;
            t1.Clear();
            switch (tmp)
            {
                case "+":
                    res = calc.GetPlus(result, Double.Parse(t2.Text));
                    result = res;
                    t2.Text = result.ToString();
                    break;
                case "-":
                    res = calc.GetMinus(result, Double.Parse(t2.Text));
                    result = res;
                    t2.Text = result.ToString();
                    break;
                case "*":
                    res = calc.GetMulti(result, Double.Parse(t2.Text));
                    result = res;
                    t2.Text = result.ToString();
                    break;
                case "/":
                    if (t2.Text != "0")
                    {
                        res = calc.GetDivision(result, Double.Parse(t2.Text));
                        result = res;
                        t2.Text = result.ToString();
                    }
                    else
                    {
                        t2.Text = "Деление на ноль не возможно!!!";
                        fist = false;
                    }
                    break;
            }
            flag = false;
            tmp = "";
        }

        private void POW(object sender, RoutedEventArgs e)
        {
            
        }

        private void Fact(object sender, RoutedEventArgs e)
        {
            CalcService.CalcAdvansedClient calc = new CalcService.CalcAdvansedClient();
            int res = calc.Factorial(Int32.Parse(t2.Text));
            t2.Text = res.ToString();
            flag = false;
        }      

        private void E2(object sender, RoutedEventArgs e)
        {
            Quadratic quad = new Quadratic();
            quad.ShowDialog();
        }
    }
}
