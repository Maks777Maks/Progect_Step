using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
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

namespace Ado.net_Silpo_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    //public class NameConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
            
    //        return values[0] + " " + values[1];
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        string[] splitValues = ((string)value).Split(' ');
    //        return splitValues;
    //    }
    //}

    public partial class MainWindow : MetroWindow
    {
        private static string connectionString = "Data Source=USER-PC;" +
           "Initial Catalog= Silpo;" +
           "Integrated Security = true;";
        private static SqlConnection connection = new SqlConnection();
        SqlDataAdapter sda = null;
        SqlDataAdapter sca = null;
        DataTable dtb = null;
        DataTable card = null;
        SqlCommandBuilder sqb;

        double result = 0;
        double price = 0;  

        public MainWindow()
        {
            InitializeComponent();
            dtb = new DataTable();
            card = new DataTable();

            connection = new SqlConnection(connectionString);           
            sda = new SqlDataAdapter("Select Products.IDPRoduct, Products.Name, Products.Price, Products.Quantity, Categories.Name as 'Category', Producers.Name as 'Producer' from Products inner join Categories on Categories.IDCategory = Products.IDCategory inner join Producers on Producers.IDProducer = Products.IDProducer", connection);
            
            try
            {
                sda.Fill(dtb);
                connection.Close();                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            string item = " ";
            for(int i=0; i<dtb.Rows.Count;i++)
            {
                item = dtb.Rows[i][0] + " " + dtb.Rows[i][1];
                ID.Items.Add(item);
            }
            Result.Text = "TOTAL:   " + result.ToString() + "  grn";
            sca = new SqlDataAdapter("Select Cards.IDPCard, Cards.Name, Cards.SurName, Cards.Quantity, Cards.Tel from Cards", connection);
            try
            {
                sca.Fill(card);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            if (Num.Value != null)
                Num.Value = new double();
            Num.Value = 1;
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            string tmp = "";
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                if (ID.SelectedItem.ToString() == (dtb.Rows[i][0] + " " + dtb.Rows[i][1]))
                {
                    price = Convert.ToDouble(dtb.Rows[i][2]) * Convert.ToDouble(Num.Value);
                    tmp = dtb.Rows[i][1].ToString() + "           " + Num.Value + "    X    " + Convert.ToDouble(dtb.Rows[i][2]).ToString() + "    =    " + price + "  grn";
                    break;
                }
            }
            
            Check.Items.Add(tmp);
            result += price;
            Result.Text = "TOTAL:   " + result.ToString() + "  grn";
        }   

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            AddClient DI = new AddClient(card);
            if (DI.ShowDialog() == true)
            {
                if (DI.DialogResult == true)
                {                  
                    card = DI.tmp;
                    
                    try
                    {
                        sqb = new SqlCommandBuilder(sca);
                        sca.Update(card);
                        Sale.Text = card.Rows[card.Rows.Count - 1][4].ToString();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }           
                Visibility = Visibility.Visible;               
            }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if(result==0) { return; }

            if(Sale.Text=="")
            {
                Visibility = Visibility.Collapsed;
                AddClient DI = new AddClient(card);
                if (DI.ShowDialog() == true)
                {
                    if (DI.DialogResult == true)
                    {
                        card = DI.tmp;

                        try
                        {                           
                            sqb = new SqlCommandBuilder(sca);
                            sca.Update(card);
                            Sale.Text = card.Rows[card.Rows.Count - 1][4].ToString();                                                      
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }                   
                }                              
            }
            else
            {                
                for (int i = 0; i < card.Rows.Count; i++)
                {
                    if (Sale.Text == card.Rows[i][4].ToString())
                    {                      
                        DataTable tmp1 = new DataTable();
                        tmp1 = card;
                        tmp1.Rows[i][3] = Convert.ToDouble(tmp1.Rows[i][3]) + (result / 50);
                        card = tmp1;
                        
                        try
                        {                            
                            sqb = new SqlCommandBuilder(sca);
                            sca.Update(card);
                            ID.SelectedIndex = -1;
                            Check.Items.Clear();
                            Num.Value = 1;
                            result = 0;
                            Sale.Text = "";
                            Result.Text = "TOTAL:   " + result.ToString() + "  grn";

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }

                        break;
                    }
                }
            }            
            Visibility = Visibility.Visible;
        }        
    }
}
