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

namespace Сheckers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        BitmapImage checkwhite = new BitmapImage(new Uri(@"C:\Users\User\Desktop\Шашки\шашки\2.png"));
        BitmapImage checkblack = new BitmapImage(new Uri(@"C:\Users\User\Desktop\Шашки\шашки\1.png"));
        BitmapImage kingblack = new BitmapImage(new Uri(@"C:\Users\User\Desktop\Шашки\шашки\7.png"));
        BitmapImage kingwhite = new BitmapImage(new Uri(@"C:\Users\User\Desktop\Шашки\шашки\8.png"));
        bool white = false;

        public MainWindow()
        {
            InitializeComponent();
            if (white == true)
            {

            }
            A8.Source = checkblack;
            C8.Source = checkblack;
            E8.Source = checkblack;
            G8.Source = checkblack;
            B7.Source = checkblack;
            D7.Source = checkblack;
            F7.Source = checkblack;
            H7.Source = checkblack;
            A6.Source = checkblack;
            C6.Source = checkblack;
            E6.Source = checkblack;
            G6.Source = checkblack;

            B1.Source = checkwhite;
            D1.Source = checkwhite;
            F1.Source = checkwhite;
            H1.Source = checkwhite;
            A2.Source = checkwhite;
            C2.Source = checkwhite;
            E2.Source = checkwhite;
            G2.Source = checkwhite;
            B3.Source = checkwhite;
            D3.Source = checkwhite;
            F3.Source = checkwhite;
            H3.Source = checkwhite;
        }
    }
}
