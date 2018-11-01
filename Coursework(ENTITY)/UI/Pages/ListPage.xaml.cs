using ClassLibrary;
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

namespace UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        Ads ad = new Ads();

        public ListPage()
        {
            InitializeComponent();
        }

        private void view_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ad = (view.SelectedItem as Ads);
            Detailedinformation DI = new Detailedinformation(ad);
            DI.ShowDialog();
        }
    }
}
