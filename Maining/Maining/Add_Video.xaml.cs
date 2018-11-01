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
using System.Windows.Shapes;

namespace Maining
{
    /// <summary>
    /// Логика взаимодействия для Add_Crypto.xaml
    /// </summary>
    public partial class Add_Video : MetroWindow
    {
        public VideoCard Video = new VideoCard();
        public Add_Video()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Video.Name = t1.Text;
            Video.Power = Convert.ToInt32(t2.Text);
            Close();
        }
    }
}
