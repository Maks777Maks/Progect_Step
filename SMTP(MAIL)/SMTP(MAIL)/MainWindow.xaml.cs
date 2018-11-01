using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SMTP_MAIL_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // MailAddress address = new MailAddress("m.rogach777@gmail.com");
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        Authentication auth;
        public MainWindow()
        {
            InitializeComponent();
            auth = new Authentication();
            auth.ShowDialog();

        }

        List<Attachment> list = new List<Attachment>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage("m.rogach777@gmail.com", SENDER.Text, Subject.Text, TEXT.Text);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(auth.login, auth.password);
            foreach(var i in list)
            {
                message.Attachments.Add(i);
            }
            
            try
            {
                client.Send(message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != true)
                return;           
            Attachment at = new Attachment(ofd.FileName);
            list.Add(at);           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            YouMessage messages = new YouMessage(auth.login, auth.password);
            messages.ShowDialog();
        }
    }
}
