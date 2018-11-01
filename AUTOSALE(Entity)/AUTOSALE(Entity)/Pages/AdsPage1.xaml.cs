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
    /// Логика взаимодействия для AdsPage1.xaml
    /// </summary>
    public partial class AdsPage1 : Page
    {
        MainViewModel Mvm;
        public AdsPage1(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;
        }
    }
}
