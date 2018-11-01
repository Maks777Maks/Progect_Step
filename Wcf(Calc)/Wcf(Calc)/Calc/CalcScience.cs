using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf_Calc_.Contracts;

namespace Wcf_Calc_.Calc
{
    public class CalcScience : ICalcScience
    {
        public double[] Discriminant(double a, double b, double c)
        {
            double[] arr = null;
            double D = (b * b) - 4 * a * c;
            if (D < 0) { return arr; }
            else if(D==0)
            {
                arr = new double[1];
                arr[0] = -b / (2 * a);
                return arr;
            }
            else
            {
                arr = new double[2];
                arr[0] = (-b + Math.Sqrt(D)) / (2 * a);
                arr[1] = (-b - Math.Sqrt(D)) / (2 * a);
                return arr;
            }
        }
    }
}
