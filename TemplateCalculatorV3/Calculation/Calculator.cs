using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator : CalculatorBase
    {
        public Calculator(Dictionary<string, uint> values)
        {
            calculationValues = values;
            hitPoints = SetValue(hitPoints, (nameof(hitPoints)));
            toughness = SetValue(toughness, (nameof(toughness)));
            armor = SetValue(armor, (nameof(armor)));
            damage = SetValue(damage, (nameof(damage)));
            penetration = SetValue(penetration, (nameof(penetration)));
        }

        public void CalculateDamage()
        {
            var targetsTotalDefense = armor + toughness;
            if (penetration >= targetsTotalDefense)
            {
                targetsTotalDefense = 0;
            }
            else
            {
                targetsTotalDefense = targetsTotalDefense - penetration;
            }
            var damageTotal = damage - targetsTotalDefense;
            var sign = Math.Sign(damageTotal);
            if (sign == -1)
            {
                Console.WriteLine("\nThis attack deals no damage");
                Console.WriteLine("\nThe target's remaining HP is " + (hitPoints));
            }
            if (damageTotal >= hitPoints)
            {
                Console.WriteLine("\n{0} damage was dealt.", damageTotal);
                Console.WriteLine("\nThe target has been killed!");
            }
            else
            {
                var remainingHp = hitPoints - damageTotal;
                Console.WriteLine("\nThe target's remaining HP is " + (remainingHp));
                hitPoints = remainingHp;
            }
        }
    }
}
