using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTasksOOP
{
    public class AdvancedCalculator : BasicCalculator, IAdvancedCalculator
    {
        private double _num1;
        private double _num2;

        public AdvancedCalculator(double num1, double num2) :
            base(num1, num2)
        {
            _num1 = num1;
            _num2 = num2;
        }

        public double Sqrt(bool IsFirstSelected = true)
        {
            if (IsFirstSelected && _num1 > 0 || _num2 > 0)
            {
                return Math.Sqrt(_num1); 
            }
            else if(!IsFirstSelected)
            {
                return Math.Sqrt(_num2);  
            }
            else
            {
                throw new Exception("cannot sqrt number that < 0"); 
            }
        }

        public string GetModel()
            => GetCalcModel(); 

        protected override string GetCalcModel() 
            => "Advanced calc";
    }
}
