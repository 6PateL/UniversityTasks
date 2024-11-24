using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTasksOOP
{
    public class BasicCalculator : AbstractCaclulator
    {
        private double _num1;
        private double _num2;

        public BasicCalculator(double num1, double num2)
        { 
            _num1 = num1;
            _num2 = num2;
        }

        //set
        public void SetNum1(double num1) => _num1 = num1;
        public void SetNum2(double num2) => _num2 = num2;

        //get
        public double GetNum1() => _num1; 
        public double GetNum2() => _num2;   

        //operations
        public double Mul() => Mul(_num1, _num2);
        public double Sum() => Sum(_num1, _num2);
        public double Div() => Div(_num1, _num2);    
        public double Sub() => Sub(_num1, _num2);

        //other
        public string GetModel()
            => GetCalcModel();

        //overrided methods 
        protected override double Mul(double num1, double num2)
        {
            Console.WriteLine("Mul operation successfully completed!");
            return base.Mul(num1, num2);
        }
        protected override double Div(double num1, double num2)
        {
            Console.WriteLine("Div operation successfully completed!");
            return base.Div(num1, num2);
        }
        protected override double Sub(double num1, double num2)
        {
            Console.WriteLine("Sub operation successfully completed!");
            return base.Sub(num1, num2);
        }
        protected override double Sum(double num1, double num2)
        {
            Console.WriteLine("Sum operation successfully completed!");
            return base.Sum(num1, num2);
        }
        protected override string GetCalcModel()
            => "Basic calc"; 
    }
}
