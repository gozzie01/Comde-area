namespace RPG;
public class Enemy : Entity
{
    protected int Level;
    protected int Experience;
    protected int Mana;
    protected int MaxMana;
    protected int Strength;
    protected int Dexterity;
    protected int Intelligence;
    protected Consumable? _Potion;
    protected Weapon? _Weapon;
    protected Armour?[] _Armour;
    public Enemy(string name, Consumable potion, int health, int mana, int maxmana, int maxHealth, int level, int experience, int strength, int dexterity, int intelligence, int baseArmor, int baseDamage, int addArmor, int gold, Weapon? weapon, Armour?[] armour, Items?[] inventory)
    :base(name, health, maxHealth, baseArmor, baseDamage, addArmor, gold, inventory)
    {
        Level = level;
        Experience = experience;
        Mana = mana;
        MaxMana = maxmana;
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        _Potion = potion;
        _Weapon = weapon;
        _Armour = armour;
    }
    //enemies can't add armour or weapons or potions
    //overide toString to return the name of the enemy
    public override string ToString()
    {
        return Name;
    }

}