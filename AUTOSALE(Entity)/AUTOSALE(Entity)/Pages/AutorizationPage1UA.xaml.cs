using AUTOSALE_Entity_.ViewModel;
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
    /// Логика взаимодействия для AutorizationPage1UA.xaml
    /// </summary>
    public partial class AutorizationPage1UA : Page
    {
        MainViewModel MvM;
        public AutorizationPage1UA(MainViewModel mvm)
        {
            InitializeComponent();
            MvM = mvm;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MvM.bMenuAutorizUA_Click.Execute(null);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            
            MvM.bMenuAutoriz2UA_Click.Execute(null);
        }
    }
}
