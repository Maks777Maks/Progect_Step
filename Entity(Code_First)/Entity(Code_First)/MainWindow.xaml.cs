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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.IO;

namespace Entity_Code_First_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class MyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
          //  File.WriteAllText("c:/TEST.TXT", $"{ (values[0] as Person)?.Name}  ====   {(values[0] as Person)?.Name}");
            if((values[0] as Person)?.Name == (values[1] as Person)?.Name)
            {
                return HorizontalAlignment.Left;
            }
            return HorizontalAlignment.Right;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public partial class MainWindow : MetroWindow
    {
        Model1 db = new Model1();              

        public MainWindow()
        {
            InitializeComponent();
           
            list1.ItemsSource = db.Persons.ToList();
            list2.ItemsSource = db.Messages.ToList();
            list3.ItemsSource = db.Persons.ToList();
            list1.SelectedIndex = 1;
           
            _scrollViewer.ScrollToEnd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Chat.Text == "" || list1.SelectedItem == null) { return; }
            else
            {
                Message m = new Message();              
                
                m.IDPersonSender = list1.SelectedIndex + 1;
                if (list3.SelectedIndex != -1)
                {
                    m.IDPersonGetter = list3.SelectedIndex + 1;
                }
                
                m.Text = "    " + Chat.Text;
                m.Time = DateTime.Now.ToShortTimeString();

                db.Messages.Add(m);
                db.SaveChanges();
                Chat.Text = "";
                list2.ItemsSource = db.Messages.ToList();
                list1.SelectedItem = null;
                list3.SelectedItem = null;

                _scrollViewer.ScrollToEnd();
            }

        }
    }
}

