using System.Collections.Generic;

namespace Calculator
{
    public static class Parser      // The Parser adds values to a Dictionary, drawn from an "Attack" type and a "Target" type
    {
        public delegate void addStats(CombatEntity thisEntity, Dictionary<string, uint> calculationValues);
        static addStats addStat = AddStatsToCalculationValues;

        public static void createCalculationValues(CombatEntity thisAttack, CombatEntity thisTarget, Dictionary<string, uint> calculationValues)
        {
            addStat(thisAttack, calculationValues);
            addStat(thisTarget, calculationValues);
        }

        public static void AddStatsToCalculationValues(CombatEntity thisEntity, Dictionary<string, uint> calculationValues)
        {
            foreach (var entry in thisEntity.stats)  
            {
                calculationValues.Add(entry._statName, entry._value);
            }
        }
    }
}