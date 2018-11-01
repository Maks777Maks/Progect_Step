using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Ado_Net
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string connectionString = "Data Source=USER-PC;" +
            "Initial Catalog= BookShop;" +
            "Integrated Security = true;";
        private static SqlConnection connection = new SqlConnection();
        SqlDataAdapter sda = null;
        DataSet t = null;
        
        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            t = new DataSet();
            sda = new SqlDataAdapter(" Select * from Books; Select * from Authors", connection);           
            sda.Fill(t);
            View.ItemsSource = t.Tables[0].DefaultView;
            //View.ItemsSource = t.Tables[1].DefaultView;
            // MessageBox.Show(t.Relations[0].ToString());        
            //sda.Update(t);
        }

        private void Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                SqlCommandBuilder sqb = new SqlCommandBuilder(sda);
                //MessageBox.Show(sqb.GetInsertCommand().CommandText);
               // MessageBox.Show(sqb.GetSelectCommand().CommandText);
                //MessageBox.Show(sqb.GetUpdateCommand().CommandText);
                //MessageBox.Show(sqb.GetDeleteCommand().CommandText);
                sda.Update(t);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
