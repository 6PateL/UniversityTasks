using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTasksOOP
{
    public abstract class AbstractCaclulator
    {
        private static string CalcModel = "Basic v1.0";
        protected virtual string GetCalcModel() => CalcModel; 

        protected virtual double Mul(double num1, double num2) 
            => num1 * num2;
        protected virtual double Sum(double num1, double num2)
            => num1 + num2;
        protected virtual double Div(double num1, double num2)
            => num1 / num2;
        protected virtual double Sub(double num1, double num2)
            => num1 - num2;
    }
}
