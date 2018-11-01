using MahApps.Metro.Controls;
using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace SMTP_MAIL_
{
    /// <summary>
    /// Логика взаимодействия для YouMessage.xaml
    /// </summary>
    public partial class YouMessage : MetroWindow
    {
        //public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
        //{

        //    using (Pop3Client client = new Pop3Client())
        //    {              
        //        client.Connect(hostname, port, useSsl);
        //        client.Authenticate(username, password);
        //        int messageCount = client.GetMessageCount();
        //        List<Message> allMessages = new List<Message>(messageCount);
        //        for (int i = messageCount; i > 0; i--)
        //        {
        //            allMessages.Add(client.GetMessage(i));
        //        }
        //        return allMessages;
        //    }
        //}
        Pop3Client _client;

        public void Connect(string hostname, int port, bool isUseSsl, string username, string password)
        {
            _client = new Pop3Client();
            _client.Connect(hostname, port, isUseSsl);
            _client.Authenticate(username, password);
        }

        public List<MailMessage> GetMail()
        {
            int messageCount = this._client.GetMessageCount();

            var allMessages = new List<MailMessage>(messageCount);

            for (int i = 10; i > 0; i--)
            {
                //Task.Run(() =>
                //{
                    allMessages.Add(_client.GetMessage(i).ToMailMessage());
                //});
                
            }

            return allMessages;
        }

        public YouMessage(string login, string password)
        {
            InitializeComponent();
            bool flag = true;
            
            Connect("pop.gmail.com", 995, flag, login, password);
            
            Listbox.ItemsSource = GetMail();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
