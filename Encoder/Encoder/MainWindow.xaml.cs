using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Encoder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str = "";
        string str1 = "";
        
        CancellationToken token;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlgOp = new OpenFileDialog();

            if (true == dlgOp.ShowDialog())
            {
                if (File.Exists(dlgOp.FileName))
                {
                    using (StreamReader reader = new StreamReader(dlgOp.FileName, Encoding.UTF8))
                    {
                        str = reader.ReadToEnd();                       
                    }
                }
                label1.Content = dlgOp.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Key.Text == "") { return; }
            

            string key = Key.Text;
            int counter = 0;
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            Task t = Task.Run(() =>
                {                   
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            MessageBox.Show("Операция прервана");
                            this.Dispatcher.Invoke(() =>
                            {
                                Bar.Value = 0;
                            });
                           
                            return;
                        }
                        if (counter == key.Length)
                        {
                            counter = 0;
                        }
                        str1 += Convert.ToChar(str[i] ^ key[counter]);
                        ++counter;
                        if (i % Convert.ToInt32((str.Length / 100)) == 0)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                Bar.Value++;
                            });
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\Test.txt", false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(str1);
                    }
                    Process.Start(@"C:\Users\User\Desktop\Test.txt");
                    str = "";
                });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\Test.txt", System.Text.Encoding.UTF8))
            {
                str1 = sr.ReadToEnd();
            }
            if (Key.Text == "" || str1 == "") { return; }
                      
                string key = Key.Text;
                int counter = 0;
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            Task t = Task.Run(() =>
                {
                    for (int i = 0; i < str1.Length; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            MessageBox.Show("Операция прервана");
                            this.Dispatcher.Invoke(() =>
                            {
                                Bar.Value = 0;
                            });
                            return;
                        }
                        if (counter == key.Length)
                        {
                            counter = 0;
                        }
                        str += Convert.ToChar(str1[i] ^ key[counter]);
                        ++counter;
                    }
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\Test.txt", false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(str);
                    }
                    Process.Start(@"C:\Users\User\Desktop\Test.txt");
                    str1 = "";
                });           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            cancelTokenSource.Cancel();
        }
    }
}
