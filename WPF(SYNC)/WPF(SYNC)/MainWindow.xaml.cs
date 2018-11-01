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
using WPF_SYNC_;

namespace WPF_SYNC_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Counter counter = new Counter();
        Counter counter1 = new Counter();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = counter;
            counter.Power = 1;
            counter1.Power = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter.Start();
            counter1.Start();
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            counter.Stop();
            counter1.Stop();
            Stop.IsEnabled = false;
            Start.IsEnabled = true;
        }
    }
}
