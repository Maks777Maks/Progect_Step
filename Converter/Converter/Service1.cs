using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Converter
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public ConvertedUnits LinearMeasure(double meters)
        {
            ConvertedUnits tmp = new ConvertedUnits();
            tmp.foot = meters * 3.2808;
            tmp.inch = meters * 39.370;
            tmp.yard = meters * 1.0936;
            return tmp;
        }

        public ConvertedUnits CelsiusToFahrenheit(double c)
        {
            ConvertedUnits tmp = new ConvertedUnits();
            tmp.Fahrenheit = c * 1.8000 + 32.00;
            return tmp;
        }

        public ConvertedUnits FahrenheitToCelsius(double f)
        {
            ConvertedUnits tmp = new ConvertedUnits();
            tmp.Celsius = (f - 32) / 1.8000;
            return tmp;
        }
    }
}
