using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Ado.net_Silpo_
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : MetroWindow
    {
        public DataTable tmp = null;

        public AddClient(DataTable t)
        {
            InitializeComponent();
            tmp = new DataTable();
            tmp = t;
        }

        private void Click_Ok(object sender, RoutedEventArgs e)
        {
            if(Name.Text=="" || Surname.Text=="" || Tel.Text=="") { return; }
            
            else
            {
                tmp.Rows.Add(Name.Text, Surname.Text, Tel.Text, 0);

                DialogResult = true;
                Close();
            }
        }
    }
}
