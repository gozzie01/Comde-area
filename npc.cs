namespace RPG;
public class friendly : Entity
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
    public friendly(string name, Consumable potion, int health, int mana, int maxmana, int maxHealth, int level, int experience, int strength, int dexterity, int intelligence, int baseArmor, int baseDamage, int addArmor, int gold, Weapon? weapon, Armour?[] armour, Items?[] inventory)
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
    public bool AddArmour(Armour armour)
    {
        for (int i = 0; i < _Armour.Length; i++)
        {
            if (_Armour[i] == null)
            {
                _Armour[i] = armour;
                return true;
            }
        }
        return false;
    }
    public bool AddWeapon(Weapon weapon)
    {
        if (_Weapon == null)
        {
            _Weapon = weapon;
            return true;
        }
        return false;
    }
    public bool AddPotion(Consumable potion)
    {
        if (_Potion == null)
        {
            _Potion = potion;
            return true;
        }
        return false;
    }
    public bool RemoveArmour(int index)
    {
        if (_Armour[index] != null)
        {
            _Armour[index] = null;
            return true;
        }
        return false;
    }
    public bool RemoveWeapon()
    {
        if (_Weapon != null)
        {
            _Weapon = null;
            return true;
        }
        return false;
    }
    public bool RemovePotion()
    {
        if (_Potion != null)
        {
            _Potion = null;
            return true;
        }
        return false;
    }

}