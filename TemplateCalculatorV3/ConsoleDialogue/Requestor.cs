using System;

namespace Calculator
{
    public static class Requestor
    {
        public static void RequestValuesOf(CombatEntity thisEntity)
        {
            requestFlagsIn(thisEntity);        //request and validate user input related to the CombatEntity's Flags. Set values based on that data
            requestValuesIn(thisEntity);       //request and validate user input related to the CombatEntity's Stats. Set values based on that data
        }

        // Make Private
        public static void requestFlagsIn(CombatEntity thisEntity)
        {
            foreach (var flag in thisEntity.flags)
            {
                Console.Write(flag._questionForUser);                                              //ask the user this flag's question
                string userResponse = Console.ReadLine();                                          //read the user's response
                flag._ignoresStat = BoolValidator.ValidateBool(userResponse, flag._ignoresStat);   //validate response and set the flag T/F accordingly
            }
        }

        // Make Private
        public static void requestValuesIn(CombatEntity thisEntity)
        {
            foreach (var value in thisEntity.stats)
            {
                Console.Write(value._questionForUser);                                                                      //ask the user this Stat's question
                string userResponse = Console.ReadLine();                                                                   //read the user's response
                value._value = UintValidator.ValidateUint(userResponse, value._questionForUser, value._isZeroPermitted);    //validate response and set the stat value accordingly
            }
        }
    }
}