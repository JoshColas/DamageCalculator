namespace Calculator
{
    public class Target : CombatEntity
    {
        public Stat hitPoints = new Stat("hitPoints", "What is the target's HP? ", 1, false);
        public Stat toughness = new Stat("toughness", "What is the target's Toughness? ", 0, false);
        public Stat armor = new Stat("armor", "What is the target's Armor? ", 0, true);

        public delegate void generateTarget(Attack thisAttack, Stat thisStat, Target thisTarget);
        static generateTarget addStatIfRelevant = AddStatsRespectedByAttack;

        public Target(Attack thisAttack)                          // The constructor requires an Attack argument, some of which may ignore Armor and/or Toughness.
        {                                                         // Upon instantiation, only the relevant Stat objects will be added to the Target's List<Stat> 
            stats.Add(hitPoints);
            addStatIfRelevant(thisAttack, toughness, this);
            addStatIfRelevant(thisAttack, armor, this);
        }

        public static void AddStatsRespectedByAttack(Attack thisAttack, Stat thisStat, Target thisTarget)
        {
            foreach (Flag flag in thisAttack.flags)
            {
                if (flag._name.Contains(thisStat._name) && flag._ignoresStat == false)
                {
                    thisTarget.stats.Add(thisStat);
                }
            }
        }
    }
}