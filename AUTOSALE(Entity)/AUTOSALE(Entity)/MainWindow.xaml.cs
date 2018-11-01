using AUTOSALE_Entity_.Pages;
using AUTOSALE_Entity_.ViewModel;
using ClassLibrary;
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

namespace AUTOSALE_Entity_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Base_Autosale db = new Base_Autosale();
        MainViewModel Mvm;
        public User _user = new User();

        public MainWindow()
        {         
            InitializeComponent();
            Mvm = new MainViewModel(_user);
            DataContext = Mvm;
            MessageBox.Show(Mvm.u._name);
            LabelUser.DataContext = Mvm.u._name;        
        }

        private void Click_Logo(object sender, MouseButtonEventArgs e)
        {
            if (Sel_Lang.Content.ToString() == "EN")
            {
                Mvm.bMenuMain_Click.Execute(null);
            }

            else if (Sel_Lang.Content.ToString() == "UA")
            {
                Mvm.bMenuMainUA_Click.Execute(null);
            }
            else if (Sel_Lang.Content.ToString() == "RUS")
            {
                Mvm.bMenuMainRUS_Click.Execute(null);
            }
            //if (_user != null) { MessageBox.Show(_user._name); }
            //else MessageBox.Show("AAAAAAAAAAAAAAA");
        }

        private void Click_stack(object sender, MouseButtonEventArgs e)
        {
            if ((sender as StackPanel).Name == "stack2")
            {
                Mvm.bMenuMainUA_Click.Execute(null);
                Sel_Lang.Content = "UA";
                Image1.Source = Image2.Source;                
                Label_Add.Content = "+  Oголошення";
                Label_Login.Content = "Авторизація";               
            }
            else if ((sender as StackPanel).Name == "stack3")
            {
                Mvm.bMenuMain_Click.Execute(null);
                Sel_Lang.Content = "EN";
                Image1.Source = Image3.Source;                
                Label_Add.Content = "Submit your ad";
                Label_Login.Content = "Login";                
            }
            else if ((sender as StackPanel).Name == "stack4")
            {
                Mvm.bMenuMainRUS_Click.Execute(null);
                Sel_Lang.Content = "RUS";
                Image1.Source = Image4.Source;                
                Label_Add.Content = "+  Oбявление";
                Label_Login.Content = "Авторизация";               
            }
            Expand.IsExpanded = false;
        }

        private void Ads(object sender, MouseButtonEventArgs e)
        {
            if(_user._name==null)
            {
                if(Sel_Lang.Content.ToString() == "EN")
                {
                    MessageBox.Show("You must be signed in");
                }
                else if (Sel_Lang.Content.ToString() == "UA")
                {
                    MessageBox.Show("Ви повинні ввійти в акаунт ");
                }
                else if (Sel_Lang.Content.ToString() == "RUS")
                {
                    MessageBox.Show("Вы должны войти в аккаунт");
                }
                return;
            }
            else
            {
                if (Sel_Lang.Content.ToString() == "EN")
                {
                    Mvm.bAds1_Click.Execute(null);
                }
                else if (Sel_Lang.Content.ToString() == "UA")
                {
                    Mvm.bAds1UA_Click.Execute(null);
                }
                else if (Sel_Lang.Content.ToString() == "RUS")
                {
                    Mvm.bAds1RUS_Click.Execute(null);
                }
                //MessageBox.Show(_user._name); 

            }
        }

        private void Login(object sender, MouseButtonEventArgs e)
        {

        }

        private void Label_Login_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Sel_Lang.Content.ToString()=="EN")
            {
                Mvm.bMenuAutoriz_Click.Execute(null);
            }
            else if (Sel_Lang.Content.ToString() == "UA")
            {
                Mvm.bMenuAutorizUA_Click.Execute(null);
            }
            else if (Sel_Lang.Content.ToString() == "RUS")
            {
                Mvm.bMenuAutorizRUS_Click.Execute(null);
            }            
        }
    }
}
