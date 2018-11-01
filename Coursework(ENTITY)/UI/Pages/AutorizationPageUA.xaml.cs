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
    /// Логика взаимодействия для AutorizationPageUA.xaml
    /// </summary>
    public partial class AutorizationPageUA : Page
    {
        MainViewModel MvM;
        public AutorizationPageUA(MainViewModel mvm)
        {
            InitializeComponent();
            MvM = mvm;
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            MvM.bMenuMainUA_Click.Execute(null);
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            MvM.bMenuAutoriz1UA_Click.Execute(null);
        }
    }
}
