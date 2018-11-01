using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Maining
{
    public class Cripto : INotifyPropertyChanged
    {
        private double _value;
        public string Name { get; set; }
 
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }
        public double Koef { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
