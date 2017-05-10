using System.Collections.Generic;

namespace Calculator
{
    public abstract class CombatEntity                       // This is the base class for the user-defined types, "Attack" and "Target"
    {                                                        // Both of these classes have very simimar blueprints and passed to the same methods
                                                             // By sharing a base class, both the "Attack" and "Target" type are interchangable in arguments

        public List<Flag> flags = new List<Flag>();   // Maybe make these protected?
        public List<Stat> stats = new List<Stat>();
        
        public class Flag                       // The "Flag" type helps the calculation algorithm choose to observe or ignore certain Attack or Defensive characteristics
        {                                       // It contains its variable name which is used as a key value later(?), the string that contains the question that will be asked of the user,
            public string _name;                // and a bool which is set by user input
            public string _questionForUser;
            public bool _ignoresStat;

            public Flag(string flagName, string questionForUser, bool trueOrFalse)
            {
                _name = flagName;
                _questionForUser = questionForUser;
                _ignoresStat = trueOrFalse;
            }
        }

        public class Stat                      // The "Stat" type contains a numerical value used by the calculation algorithm.  It contains:
        {                                      
            public string _name;           // The stat's name that will be used as a key value
            public string _questionForUser;    // The request written to console asking the user to set this Stat's value (e.g. "How much HP does the target have?")
            public uint _value;                // This Stat's value
            public bool _isZeroPermitted;      // Some Stat's can be valued at zero (determined by the developer during compile)

            public Stat(string statName, string questionForUser, uint value, bool isZeroPermitted)
            {
                _name = statName;
                _questionForUser = questionForUser;
                _value = value;
                _isZeroPermitted = isZeroPermitted;
            }
        }
    }
}