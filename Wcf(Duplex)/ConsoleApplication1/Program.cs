using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.ServiceReference1;
using System.ServiceModel;
using WMPLib;

namespace ConsoleApplication1
{
    public class TimerCallBack : IService1Callback
    {
        public void CallBack(string mes)
        {
            Console.WriteLine(mes);
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = @"C:\Users\User\Desktop\Music\2-linkin_park-don_t_say_(zvukoff.ru).mp3";
            player.controls.play();
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new TimerCallBack());
            Service1Client proxy = new Service1Client(context);
            Console.WriteLine("Enter Time:");
            DateTime time = Convert.ToDateTime(Console.ReadLine());
         
            proxy.Subscribe(time);
            Console.ReadLine();
        }
    }
}
