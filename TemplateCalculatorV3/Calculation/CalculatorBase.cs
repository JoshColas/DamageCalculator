using System.Collections.Generic;

namespace Calculator
{
    // Make this class abstract?
    public class CalculatorBase   // CalculatorBase houses the values that are required to calculate the damage of an attack.
    {
        public Dictionary<string, uint> calculationValues;  // Consider wrapping these fields in properties so they can be set to private
        public uint hitPoints;
        public uint toughness;
        public uint armor;
        public uint damage;
        public uint penetration;
        
        public uint SetValue(uint uintValue, string uintName)
        {
            calculationValues.TryGetValue(uintName, out uintValue);
            return uintValue;
        }
    }
}