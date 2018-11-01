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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maining
{
    
    public partial class MainWindow : MetroWindow
    {
        ObservableCollection<VideoCard> videocards; 

        public MainWindow()
        {
            InitializeComponent();
            videocards = new ObservableCollection<VideoCard>()
            {
                new VideoCard { Name="GTX1060", Power=192 },
                new VideoCard { Name="GTX 1080", Power=352 },
                new VideoCard { Name="GTX 1050", Power=128 }
            };
            List.ItemsSource = videocards;
            
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedIndex == -1) return;
            (List.SelectedItem as VideoCard).Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (List.SelectedIndex == -1) return;
            (List.SelectedItem as VideoCard).Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Add_Video add = new Add_Video();
            add.ShowDialog();
            VideoCard tmp;
            tmp = add.Video;
            videocards.Add(tmp);
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddCripto add = new AddCripto();
            add.ShowDialog();
            Cripto tmp;
            tmp = add.cripto;
            foreach(var i in videocards)
            {
                i.cripto.Add(new Cripto { Value = tmp.Value, Name= tmp.Name, Koef=tmp.Koef});
            }
            
        }

        private void V(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((List.SelectedItem as VideoCard).SelectedCripto.Name.ToString());
            MessageBox.Show((List.SelectedItem as VideoCard).SelectedCripto.Value.ToString());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Change_Video change = new Change_Video(videocards);
            change.ShowDialog();
            videocards = change.videocards;
        }
    }
}
