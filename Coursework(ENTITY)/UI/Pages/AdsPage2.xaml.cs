using AUTOSALE_Entity_.ViewModel;
using ClassLibrary;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AdsPage2.xaml
    /// </summary>
    public partial class AdsPage2 : Page
    {
        MainViewModel Mvm;
        public AdsPage2(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;
            
        }

        private void OK(object sender, RoutedEventArgs e)
        {
           
        }

        private void Add_Image(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            if (true == ofd.ShowDialog())
            {
                ClassLibrary.Image im = new ClassLibrary.Image();
                im.Name = ofd.FileName;
            }                     
                //OpenFileDialog dlgOp = new OpenFileDialog();
                //dlgOp.DefaultExt = ".png";
                //dlgOp.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                //Nullable<bool> result = dlgOp.ShowDialog();

                //if (result == true)
                //{
                //    string filename = dlgOp.FileName;
                //    ClassLibrary.Image im = new ClassLibrary.Image();
                //    im.Name = filename;
                //    MessageBox.Show(im.Name);
                //    Mvm.Ad._image.Add(im);

                //    MessageBox.Show(Mvm.Ad._image[0].Name);

                //}
            }      
    }
}
