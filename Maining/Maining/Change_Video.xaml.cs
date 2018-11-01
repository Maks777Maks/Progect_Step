using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Change_Video.xaml
    /// </summary>
    public partial class Change_Video : MetroWindow
    {
        public ObservableCollection<VideoCard> videocards = new ObservableCollection<VideoCard>();

        public Change_Video(ObservableCollection<VideoCard> v )
        {
            InitializeComponent();
            videocards = v;
            Brand.ItemsSource = videocards;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brand.SelectedIndex == -1 || t2.Text=="") { return; }
            else
            {
                videocards[Brand.SelectedIndex].Power = Convert.ToInt32(t2.Text);
            }
            Close();
        }
    }
}
