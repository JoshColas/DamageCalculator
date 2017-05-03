namespace Calculator
{
    public class Target : CombatEntity
    {
        public Stat hitPoints = new Stat("hitPoints", "What is the target's HP? ", 1, false);         //Target's health
        public Stat toughness = new Stat("toughness", "What is the target's Toughness? ", 0, false);   //Target's natural durability
        public Stat armor = new Stat("armor", "What is the target's Armor? ", 0, true);              //Target's durability from equipment

        public delegate void generateTarget(Attack thisAttack, Stat thisStat, Target thisTarget);
        static generateTarget flagCheck = CheckFlags;

        public Target(Attack thisAttack)
        {
            stats.Add(hitPoints);                       //All targets have hit points
            flagCheck(thisAttack, toughness, this);     //Check if the passed Attack object contains an Ignore Toughness Flag 
            flagCheck(thisAttack, armor, this);         //Check if the passed Attack object contains an Ignore Armor Flag 
        }

        public static void CheckFlags(Attack thisAttack, Stat thisStat, Target thisTarget)
        {
            foreach (Flag flag in thisAttack.flags)                                             //Iterate through the passed Attack object's List<Flag>
            {
                if (flag._flagName.Contains(thisStat._statName) && flag._trueOrFalse == false)  //If this Flag matches the passed Stat and is False...
                {
                    thisTarget.stats.Add(thisStat);                                             //Add that defensive stat to the Target object's List<Stat>
                }
            }
        }
    }
}