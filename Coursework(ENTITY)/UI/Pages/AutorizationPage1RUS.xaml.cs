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

namespace AUTOSALE_Entity_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage1RUS.xaml
    /// </summary>
    public partial class AutorizationPage1RUS : Page
    {
        MainViewModel MvM;
        public AutorizationPage1RUS(MainViewModel mvm)
        {
            InitializeComponent();
            MvM = mvm;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MvM.bMenuAutorizRUS_Click.Execute(null);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "" || ConfirmPassword.Password == "")
            {
                MessageBox.Show("Не все поля заполненны!!!");
                return;
            }
            if (ConfirmPassword.Password != Password.Password)
            {
                MessageBox.Show("Пароль не верный!!!");
                return;
            }
            MvM.u._login = Login.Text;
            MvM.u._password = Password.Password;
            MvM.bMenuAutoriz2RUS_Click.Execute(null);
        }
    }
}
