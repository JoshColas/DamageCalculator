using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator : CalculatorBase  // Calculator is constructed with a Dictionary that it uses to set its field values, which are then used to calculate damage.
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
            var targetsTotalDefense = armor + toughness;                      // Find the sum of the target's Armor and Toughness
            if (penetration >= targetsTotalDefense)                           // If the attack's Penetration value exceed this number
            {                                                                 // Reduce the target's total defense to zero
                targetsTotalDefense = 0;
            }
            else                                                             // Otherwise reduce the targets total defense by the attack's penetration value
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