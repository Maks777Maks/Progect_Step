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

namespace Entity_Product_
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : MetroWindow
    {
        SilpoEntities db = null;
        public Add()
        {
            InitializeComponent();
            db = new SilpoEntities();
            category.ItemsSource = db.Categories.ToList();
            producer.ItemsSource = db.Producers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            if (name.Text == null || producer.Text == null || category.Text == null || price.Text == null || quantity.Text == null)
            {
                return;
            }
            else
            {
                p.Name = name.Text;
                p.Price = Convert.ToDecimal(price.Text);
                p.Producer = (producer.SelectedItem as Producer);
                p.Category = (category.SelectedItem as Category);
                p.Quantity = Convert.ToInt16(quantity.Text);
                db.Products.Add(p);
                db.SaveChanges();
            }

            this.DialogResult = true;
        }

        private void TextBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Category cat = new Category();
                cat.Name = (newcat.Text);
                foreach (var i in db.Categories)
                {
                    if (i.Name == cat.Name) return;
                }
                db.Categories.Add(cat);
                db.SaveChanges();
                category.ItemsSource = db.Categories.ToList();
                newcat.Clear();
                Exsp1.IsExpanded = false;
            }

        }

        private void TextBlock_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Producer prod = new Producer();
                prod.Name = (newprod.Text);
                foreach (var i in db.Categories)
                {
                    if (i.Name == prod.Name) return;
                }
                db.Producers.Add(prod);
                db.SaveChanges();
                producer.ItemsSource = db.Producers.ToList();
                newprod.Clear();
                Ex2.IsExpanded = false;
            }
        }
    }
}
