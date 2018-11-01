using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
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

namespace Tic_tac_toe_UDP_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        BitmapImage image1 = new BitmapImage(new Uri(@"http://icons.iconarchive.com/icons/iconexpo/speech-balloon-green/128/speech-balloon-green-x-icon.png"));
        BitmapImage image2 = new BitmapImage(new Uri(@"http://icons.iconarchive.com/icons/iconexpo/speech-balloon-green/128/speech-balloon-green-o-icon.png"));
        bool finish = false;
        bool victory = false;
        //bool defeat = false;
        bool turn = false;
        List<User> Users = new List<User>();
        List<User> Users1= new List<User>();
        DataContractJsonSerializer jsonFormatter;
        Random rand = new Random();
        int temp;

        User mynickname = new User();

        public async Task<bool> TURN()
        {

            temp = rand.Next(100);
            string IP = (USERS.SelectedItem as User).IP;
            
            byte[] arr = Encoding.Unicode.GetBytes(Convert.ToString(temp));
            client.SendTo(arr, new IPEndPoint(IPAddress.Parse(IP), 8888));
            //client.SendTo(arr, new IPEndPoint(IPAddress.Parse("192.168.1.39"), 8889));
            byte[] arr1 = new byte[256];
            
            EndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            // EndPoint sender = new IPEndPoint(IPAddress.Parse("192.168.1.39"), 8889);
            string message1 = "";
            int digit = -1;
            await Task.Run(() =>
            {
                MessageBox.Show("Start");
                while (true)
                {
                    MessageBox.Show("Start While");
                    int bytes = server.ReceiveFrom(arr1, ref sender);
                    MessageBox.Show(bytes.ToString());
                    message1 = Encoding.Unicode.GetString(arr1, 0, bytes);
                    if (message1 != "") { break; }
                }
                digit = Convert.ToInt32(message1);

                MessageBox.Show(digit.ToString());
            });
          
            if (digit > temp) { return false; }
            else { return true; }
        }

        public MainWindow()
        {
            InitializeComponent();
            string Host = System.Net.Dns.GetHostName();
            string IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();          
            server.Bind(new IPEndPoint(IPAddress.Parse(IP), 8888));           
                  
            jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));            

            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                Users = (List<User>)jsonFormatter.ReadObject(fs);              
            }
            foreach(var i in Users)
            {
                Users1.Add(i);
            }
            

            for (int i = 0; i < Users.Count; i++)
            {
                if(Users[i].IP== IP)
                {
                    mynickname = Users[i];
                    Users.Remove(Users[i]);
                    break;
                }
            }
            USERS.ItemsSource = Users;
            Listbox.ItemsSource = Users1;
            

            Task.Run(() =>
            {
                while (true)
                {
                    if (finish == true)
                    {
                        victory = true;
                        Loser loser = new Loser();
                        loser.ShowDialog();
                        (USERS.SelectedItem as User).Quantity++;
                        using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
                        {
                            jsonFormatter.WriteObject(fs, Users1);
                        }
                        return;
                    }
                    byte[] arr1 = new byte[256];
                    EndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    int bytes = server.ReceiveFrom(arr1, ref sender);

                    string message1 = Encoding.Unicode.GetString(arr1, 0, bytes);

                    
                    this.Dispatcher.Invoke(() =>
                    {
                        switch (message1)
                        {
                            case "0.0":
                                Im0.Source = image2;
                                turn = true;
                                break;
                            case "0.1":
                                Im1.Source = image2;
                                turn = true;
                                break;
                            case "0.2":
                                Im2.Source = image2;
                                turn = true;
                                break;
                            case "1.0":
                                Im3.Source = image2;
                                turn = true;
                                break;
                            case "1.1":
                                Im4.Source = image2;
                                turn = true;
                                break;
                            case "1.2":
                                Im5.Source = image2;
                                turn = true;
                                break;
                            case "2.0":
                                Im6.Source = image2;
                                turn = true;
                                break;
                            case "2.1":
                                Im7.Source = image2;
                                turn = true;
                                break;
                            case "2.2":
                                Im8.Source = image2;
                                turn = true;
                                break;
                        }
                        Turn.Text = "Your turn";
                    });
                }
            });
        }       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            if (turn == false) { return; }
            if (finish == true)
            {
                victory = true;
                Winner winner = new Winner();
                winner.ShowDialog();
                mynickname.Quantity++;
                using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, Users1);
                }
                return;
            }
            var send = sender as Button;
            
            switch (send.Name)
            {              
                case "B0":
                    if (Im0.Source == null)
                    {
                        Im0.Source = image1;
                        message = "0.0";
                        turn = false;                      
                    }                 
                    break;
                case "B1":
                    if (Im1.Source == null)
                    {
                        Im1.Source = image1;
                        message = "0.1";
                        turn = false;
                    }                      
                    break;
                case "B2":
                    if (Im2.Source == null)
                    {
                        Im2.Source = image1;
                        message = "0.2";
                        turn = false;
                    }                       
                    break;
                case "B3":
                    if (Im3.Source == null)
                    {
                        Im3.Source = image1;
                        message = "1.0";
                        turn = false;
                    }                      
                    break;
                case "B4":
                    if (Im4.Source == null)
                    {
                        Im4.Source = image1;
                        message = "1.1";
                        turn = false;
                    }                       
                    break;
                case "B5":
                    if (Im5.Source == null)
                    {
                        Im5.Source = image1;
                        message = "1.2";
                        turn = false;
                    }                       
                    break;
                case "B6":
                    if (Im6.Source == null)
                    {
                        Im6.Source = image1;
                        message = "2.0";
                        turn = false;
                    }                        
                    break;
                case "B7":
                    if (Im7.Source == null)
                    {
                        Im7.Source = image1;
                        message = "2.1";
                        turn = false;
                    }                       
                    break;
                case "B8":
                    if (Im8.Source == null)
                    {
                        Im8.Source = image1;
                        message = "2.2";
                        turn = false;
                    }                        
                    break;
            }
            if(Im0.Source == image1 && Im1.Source==image1 && Im2.Source == image1)
            {
                finish = true;               
            }
            else if (Im3.Source == image1 && Im4.Source == image1 && Im5.Source == image1)
            {
                finish = true;
            }
            else if (Im6.Source == image1 && Im7.Source == image1 && Im8.Source == image1)
            {
                finish = true;
            }
            else if (Im0.Source == image1 && Im3.Source == image1 && Im6.Source == image1)
            {
                finish = true;
            }
            else if (Im1.Source == image1 && Im4.Source == image1 && Im7.Source == image1)
            {
                finish = true;
            }
            else if (Im2.Source == image1 && Im5.Source == image1 && Im8.Source == image1)
            {
                finish = true;
            }
            else if (Im0.Source == image1 && Im4.Source == image1 && Im8.Source == image1)
            {
                finish = true;
            }
            else if (Im2.Source == image1 && Im4.Source == image1 && Im6.Source == image1)
            {
                finish = true;
            }

            if (USERS.SelectedIndex!=-1 && turn == false)
            {
                string IP = (USERS.SelectedItem as User).IP;
                byte[] arr = Encoding.Unicode.GetBytes(message);
                client.SendTo(arr, new IPEndPoint(IPAddress.Parse(IP), 8888));
                Turn.Text = "Opponent turn";
            }
            

            if (finish==true)
            {
                victory = true;
                Winner winner = new Winner();
                winner.ShowDialog();
            }
        }

        private async void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (USERS.SelectedIndex == -1) { return; }
            
            Im0.Source = null;
            Im1.Source = null;
            Im2.Source = null;
            Im3.Source = null;
            Im4.Source = null;
            Im5.Source = null;
            Im6.Source = null;
            Im7.Source = null;
            Im8.Source = null;
            finish = false;
            victory = false;

            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                Users1 = (List<User>)jsonFormatter.ReadObject(fs);
            }
            Listbox.ItemsSource = Users1;
            
            if (await TURN() == true)
            {
                Turn.Text = "Your turn";
                turn = true;
                MessageBox.Show(turn.ToString());
            }
            else
            {
                Turn.Text = "Opponent turn";
                turn = false;
                MessageBox.Show(turn.ToString());
            }

        }
    }
}
