using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_SYNC_
{
    public class Counter: INotifyPropertyChanged
    {
        public static Object locker = new Object();
        static private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
            }
        }
        Thread thread = null;
        public int Power { get; set; }

        public Counter()
        {
            Count = 0;          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Increment()
        {
            for(int i=0;i<1000000;i++)
            {
                lock (locker)
                {
                    Count++;
                }
               // Thread.Sleep(Power);
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
