using AUTOSALE_Entity_.ViewModel;
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
using UI;

namespace AUTOSALE_Entity_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage1.xaml
    /// </summary>
    public partial class AutorizationPage1 : Page
    {
        MainViewModel Mvm;
        bool _login = false;
        bool _password = false;

        public AutorizationPage1(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mvm.bMenuAutoriz1_Click.Execute(null);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            using (CONTEXT db = new CONTEXT())
            {
                //db.Users.Attach(s);
                //db.Messages.Add(m);
                //db.SaveChanges();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {            
            Mvm.bMenuAutoriz_Click.Execute(null);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "" || ConfirmPassword.Password == "")
            {
                MessageBox.Show("Not all fields are full!!!");
                return;
            }
            if (ConfirmPassword.Password != Password.Password)
            {
                MessageBox.Show("Wrong password!!!");
                return;
            }
            Mvm.u._login = Login.Text;
            Mvm.u._password = Password.Password;
            Mvm.bMenuAutoriz2_Click.Execute(null);
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_login == false)
            {
                Bar.Value += 20;
                _login = true;
            }
            if (Login.Text == "")
            {
                _login = false;
                Bar.Value -= 20;
            }
        }

        private void Pass_TextChanged(object sender, RoutedEventArgs e)
        {
            if (_password == false)
            {
                Bar.Value += 20;
                _password = true;
            }
            if (Password.Password == "")
            {
                _password = false;
                Bar.Value -= 20;
            }
        }
    }
}
