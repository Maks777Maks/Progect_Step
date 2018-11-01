using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf_Calc_.Contracts;

namespace Wcf_Calc_.Calc
{
    public class CalcAdvansed: ICalcAdvansed
    {
        public int Factorial(int a)
        {
            int res = 1;
            for(int i=1;i<=a;i++)
            {
                res *= i;
            }
            return res;
        }
        
        public double Pow(double a, int b)
        {
            double res = a;
            for (int i = 1; i <= b; i++)
            {
                b *= b;
            }
            return res;
        }
    }
}
