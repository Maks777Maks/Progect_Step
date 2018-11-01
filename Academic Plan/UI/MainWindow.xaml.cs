using DAL;
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

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Repository<Student> db = new Repository<Student>();
            listBox1.ItemsSource = db.ReadAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student st = new Student();
            st = listBox1.SelectedItem as Student;
            Change Change = new Change(st);
            Change.ShowDialog();
        }        
    }
}
