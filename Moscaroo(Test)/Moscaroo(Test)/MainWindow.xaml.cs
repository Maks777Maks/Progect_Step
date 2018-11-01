using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Moscaroo_Test_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MOCK_DATA_DBEntities db = null;
        int counter = 0;
        int counter1;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Select()
        {
            
            Task t = Task.Run(() =>
            {
                db = new MOCK_DATA_DBEntities();
                counter = db.MOCK_DATA.ToList().Count;
                
                this.Dispatcher.Invoke(() =>
                {
                    var v= db.MOCK_DATA.Take(1000);
                    PersonView.ItemsSource = v.ToList();
                    //PersonView.ItemsSource =
                   this.Title = counter.ToString();
                });
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            int tmp = Convert.ToInt32(Text.Text);

            Task t = Task.Run(() =>
            {
                db = new MOCK_DATA_DBEntities();

                var customers = db.MOCK_DATA;
                counter1 = 0;
                foreach (var i in customers)
                {
                    counter1++;
                    i.age += tmp;
                    if (counter1 % (counter / 100) == 0)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Bar.Value++;
                        });
                    }
                }
                MessageBox.Show("Start");
                this.Dispatcher.Invoke(() =>
                {
                    Ring.IsActive = true;
                });
                
                db.SaveChanges();
                this.Dispatcher.Invoke(() =>
                {
                    Ring.IsActive = false;
                });
                
                MessageBox.Show("Finish");
                this.Dispatcher.Invoke(() =>
                {
                    PersonView.ItemsSource = null;
                    Bar.Value = 0;
                });
                Select();
            });
           
        }
    }
}
