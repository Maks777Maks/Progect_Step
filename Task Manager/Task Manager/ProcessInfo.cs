using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    public class ProcessInfo : INotifyPropertyChanged
    {
        private string memory;
        private static int Counter;
        public int ID { get; set; }
        public string Name { get; set; }       
        public string Memory
        {
            get { return memory; }
            set
            {
                memory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Memory"));
            }
            
        }
                   
        public string StartTime { get; set; }
        public string ThreadCount { get; set; }

        public ProcessInfo(Process p)
        {          
            try
            {
                // ID = ++Counter;
                ID = p.Id;
                Name = p.ProcessName;
                Memory = Math.Round((p.PagedMemorySize64 / (1024 * 1024.0)), 1).ToString();
                StartTime = p.StartTime.ToString();
                ThreadCount = p.Threads.Count.ToString();
            }
           catch(Exception ex) { }          
        }

        public static void StartProcess(Process p)
        {
            try
            {
                p.Start();
            }
            catch(Exception ex) { }
        }

        public static void KillProcess(Process p)
        {
            try
            {
                p.Kill();
            }
            catch (Exception ex) { }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
