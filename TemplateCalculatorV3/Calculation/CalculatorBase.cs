using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorBase
    {
        public Dictionary<string, uint> calculationValues;
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