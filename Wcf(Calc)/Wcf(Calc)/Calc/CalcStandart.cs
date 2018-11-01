using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_Calc_
{    
    public class CalcStandart : ICalcStandart
    {
        public double GetPlus(double a, double b) => a + b;

        public double GetMinus(double a, double b) => a - b;

        public double GetMulti(double a, double b) => a * b;

        public double GetDivision(double a, double b)
        {
            if (b == 0) { return 0; }
            else { return a / b; }
        }
    }
}
