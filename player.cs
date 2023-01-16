//player should have stats like a dnd character but have an inventory of 40 slots and 4 armor slots and a weapon slot as well as a potion slot for a potion that can be used mid battle

namespace RPG;
public class Player : Entity
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
    public Player(string name, Consumable? potion, int health, int mana, int maxmana, int maxHealth, int level, int experience, int strength, int dexterity, int intelligence, int baseArmor, int baseDamage, int addArmor, int gold, Weapon? weapon, Armour?[] armour, Items?[] inventory)
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
    public bool AddArmourFromInv(int index)
    {
        if(_Inventory[index] is Armour && _Inventory[index] != null){
            for (int i = 0; i < _Armour.Length; i++)
            {
                if (_Armour[i] == null)
                {
                    _Armour[i] = (Armour)_Inventory[index];
                    _Inventory[index] = null;
                    return true;
                }
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
    public bool AddWeaponFromInv(int index)
    {
        if(_Inventory[index] is Weapon){
            if (_Weapon == null)
            {
                _Weapon = (Weapon)_Inventory[index];
                _Inventory[index] = null;
                return true;
            }
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
    public bool AddPotionFromInv(int index)
    {
        if(_Inventory[index] is Consumable && _Inventory[index] != null){
            if (_Potion == null)
            {
                _Potion = (Consumable)_Inventory[index];
                _Inventory[index] = null;
                return true;
            }
        }
        return false;
    }
    public bool RemoveItem(int index)
    {
        if (_Inventory[index] != null)
        {
            _Inventory[index] = null;
            return true;
        }
        return false;
    }
    //remove amour should try and move it to inventory
    public bool RemoveArmour(int index)
    {
        if (_Armour[index] != null )
        {
            if (AddItem((Items)_Armour[index]))
            {
                _Armour[index] = null;
                return true;
            }
        }
        return false;
    }
    public bool RemoveWeapon()
    {
        if (_Weapon != null)
        {
            if (AddItem((Items)_Weapon))
            {
                _Weapon = null;
                return true;
            }
        }
        return false;
    }
    public bool RemovePotion()
    {
        if (_Potion != null)
        {
            if (AddItem((Items)_Potion))
            {
                _Potion = null;
                return true;
            }
        }
        return false;
    }
    public bool usePotion()
    {
        //remove potion only if it is used if both health and mana are full it should not be removed
        if (_Potion != null)
        {
            if (Health < MaxHealth)
            {
                Health += _Potion.Health;
                if (Health > MaxHealth||Mana>MaxMana)
                {
                    Health = MaxHealth;
                    Mana = MaxMana;
                }
                RemovePotion();
                return true;
            }
        }
        return false;

    }
    public Items?[] GetInventory()
    {
        return _Inventory;
    }
    public Armour?[] GetArmour()
    {
        return _Armour;
    }
    public Weapon? GetWeapon()
    {
        return _Weapon;
    }
    public Consumable? GetPotion()
    {
        return _Potion;
    }
    public int GetLevel()
    {
        return Level;
    }
    public int GetExperience()
    {
        return Experience;
    }
    public int GetMana()
    {
        return Mana;
    }
    public int GetMaxMana()
    {
        return MaxMana;
    }
    public int GetStrength()
    {
        return Strength;
    }
    public int GetDexterity()
    {
        return Dexterity;
    }
    public int GetIntelligence()
    {
        return Intelligence;
    }
    public void SetLevel(int level)
    {
        Level = level;
    }
    public void SetExperience(int experience)
    {
        Experience = experience;
    }
    public void SetMana(int mana)
    {
        Mana = mana;
    }
    public void SetMaxMana(int maxmana)
    {
        MaxMana = maxmana;
    }
    //add for gold, health, mana, exp
    public void addGold(int gold)
    {
        Gold += gold;
    }
    public void addHealth(int health)
    {
        Health += health;
    }
    public void addMana(int mana)
    {
        Mana += mana;
    }
    public void addExp(int exp)
    {
        Experience += exp;
    }


    //add a bunch of debug methods to check if the player has a weapon or armour or potion
    public bool hasWeapon()
    {
        if (_Weapon != null)
        {
            return true;
        }
        return false;
    }
    public bool hasArmour()
    {
        for (int i = 0; i < _Armour.Length; i++)
        {
            if (_Armour[i] != null)
            {
                return true;
            }
        }
        return false;
    }
    public bool hasPotion()
    {
        if (_Potion != null)
        {
            return true;
        }
        return false;
    }
    public bool hasItem()
    {
        for (int i = 0; i < _Inventory.Length; i++)
        {
            if (_Inventory[i] != null)
            {
                return true;
            }
        }
        return false;
    }
    public bool hasItem(int index)
    {
        if (_Inventory[index] != null)
        {
            return true;
        }
        return false;
    }
    public bool hasArmour(int index)
    {
        if (_Armour[index] != null)
        {
            return true;
        }
        return false;
    }
    //debug method to print all of the stats, info, and inventory
    public void printStats()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Level: " + Level);
        Console.WriteLine("Experience: " + Experience);
        Console.WriteLine("Health: " + Health);
        Console.WriteLine("Max Health: " + MaxHealth);
        Console.WriteLine("Mana: " + Mana);
        Console.WriteLine("Max Mana: " + MaxMana);
        Console.WriteLine("Strength: " + Strength);
        Console.WriteLine("Dexterity: " + Dexterity);
        Console.WriteLine("Intelligence: " + Intelligence);
        Console.WriteLine("Gold: " + Gold);
        Console.WriteLine("Weapon: " + _Weapon);
        Console.WriteLine("Potion: " + _Potion);
        Console.WriteLine("Armour: " + _Armour[0] + " " + _Armour[1] + " " + _Armour[2]);
        for (int i = 0; i < _Inventory.Length; i++)
        {
            Console.WriteLine("Inventory: " + _Inventory[i]);
        }
    }
}