using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf_Calc_.Contracts;

namespace Wcf_Calc_
{
    public class GeneralCalc: ICalcScience, ICalcAdvansed, ICalcStandart
    {
        public double[] Discriminant(double a, double b, double c)
        {
            double[] arr = null;
            double D = (b * b) - 4 * a * c;
            if (D < 0) { return arr; }
            else if (D == 0)
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

        public int Factorial(int a)
        {
            int res = 1;
            for (int i = 1; i <= a; i++)
            {
                res *= i;
            }
            return res;
        }

        public double Pow(double a, int b)
        {
            double res = a;
            for (int i = 1; i < b; i++)
            {
                res *= a;
            }
            return res;
        }

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
