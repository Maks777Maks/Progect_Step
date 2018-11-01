using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Maining
{
    
    public class VideoCard 
    {
        Thread thread = null;
        
        public string Name { get; set; }
        public int Power { get; set; }
        public ObservableCollection<Cripto> cripto { get; set; }
        public Cripto SelectedCripto { get; set; }

        public VideoCard()
        {
            cripto = new ObservableCollection<Cripto>
            {
                new Cripto { Name="BTC", Koef=0.0001, Value=0 },
                new Cripto { Name="ETH", Koef=0.1, Value=0 },
                new Cripto { Name="CAR", Koef=0.2, Value=0 }
            };
        }
               
        private void Increment()
        {
            while(true)
            {
                SelectedCripto.Value += SelectedCripto.Koef;
                Thread.Sleep(1000 - Power);
            }
        }
        public void Start()
        {
            thread = new Thread(Increment);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            thread.Abort();
        }
        
    }
}
