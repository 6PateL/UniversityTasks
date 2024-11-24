using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UniversityTasksOOP;

class Rrogram
{
    static void Main(string[] args)
    {
        BasicCalculator calculator = new BasicCalculator(3, 3);

        Console.WriteLine(calculator.Mul());
        Console.WriteLine(calculator.Sum());
        Console.WriteLine(calculator.Div());
        Console.WriteLine(calculator.Sub());
        Console.WriteLine(calculator.GetNum1());
        Console.WriteLine(calculator.GetNum2());
        calculator.SetNum1(4);
        Console.WriteLine(calculator.GetNum1());
        //version
        Console.WriteLine(calculator.GetModel());

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        AdvancedCalculator advancedCalculator = new AdvancedCalculator(9, 9);
        Console.WriteLine(advancedCalculator.Sqrt());
        Console.WriteLine(advancedCalculator.Sqrt(IsFirstSelected: false));
        Console.WriteLine(advancedCalculator.Mul());
        Console.WriteLine(advancedCalculator.GetNum1());
        Console.WriteLine(advancedCalculator.GetNum2());
        //version 
        Console.WriteLine(advancedCalculator.GetModel());
    }
}