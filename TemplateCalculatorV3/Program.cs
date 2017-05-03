using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Set values of Attack object based on user input entered in console
            var thisAttack = new Attack();
            Requestor.RequestValuesOf(thisAttack);

            // 2. Set values of Target object based on user input entered in console
            var thisTarget = new Target(thisAttack);
            Requestor.RequestValuesOf(thisTarget);

            // 3. Set "calculationValues" Dictionary based on the Attack and Target objects
            var calculationValues = new Dictionary<string, uint>();
            Parser.createCalculationValues(thisAttack, thisTarget, calculationValues);

            // 4. Build a calculator object with the "CalculationValues" Dictionary passed to the constructor
            var calculator = new Calculator(calculationValues);

            // 5. Calculate the damage dealt
            calculator.CalculateDamage();
            Console.Read();
        }
    }
}