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

namespace WpfApplication2_Template_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combo.Items.Add("Man");
            combo.Items.Add("Woman");
        }

        private void IsCheked(object sender, RoutedEventArgs e)
        {
                check.Content = "Bye!!!";
        }

        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
                check.Content = "Hello!!!";
        }
    }
}
