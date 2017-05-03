namespace Calculator
{
    public class Attack : CombatEntity
    {                                           
        public Attack()                         // The "Attack" type contains values of an attack's characteristics
        {
            Stat damage = new Stat("damage", "What is the attack's Damage? ", 1, false);                                     // Damage may not be zero
            Stat penetration = new Stat("penetration", "What is the attack's Penetration? ", 0, true);                       // Penetration may be zero
            Flag ignoresArmor = new Flag("ignores armor", "Enter 'y' if this attack ignores Armor: ", false);                // Reduced by Armor by default
            Flag ignoresToughness = new Flag("ignores toughness", "Enter 'y' if this attack ignores Toughness: ", false);    // Reduced by Toughness by default

            stats.Add(damage);                  // How much damage this attack deals
            stats.Add(penetration);             // How much of the target's defensive stats this attack ignores
            flags.Add(ignoresArmor);            // Will this attack ignore the target's Armor?
            flags.Add(ignoresToughness);        // Will this attack ignore the target's Toughness?
        }
    }
}