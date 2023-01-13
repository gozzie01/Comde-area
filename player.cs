//player should have stats like a dnd character but have an inventory of 40 slots and 4 armor slots and a weapon slot as well as a potion slot for a potion that can be used mid battle

namespace RPG;
public class Player
{
    private string Name;
    private int Health;
    private int MaxHealth;
    private int Level;
    private int Experience;
    private int Mana;
    private int MaxMana;
    private int Strength;
    private int Dexterity;
    private int Intelligence;
    private int BaseArmor;
    private int BaseDamage;
    public int AddArmor;
    public int Gold;
    private Armour?[] _Armour;
    private Items?[] _Inventory;
    private Weapon? _Weapon;
    private Consumable? _Potion;
    public Player(string name, Consumable potion, int health, int mana, int maxHealth, int level, int experience, int strength, int dexterity, int intelligence, int baseArmor, int baseDamage, int addArmor, int gold, Weapon? weapon, Armour?[] armour, Items?[] inventory)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Level = level;
        Experience = experience;
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        BaseArmor = baseArmor;
        BaseDamage = baseDamage;
        AddArmor = addArmor;
        Gold = gold;
        _Weapon = weapon;
        _Armour = armour;
        _Inventory = inventory;
        _Potion = potion;
        Mana = mana;
    }
    public bool AddItem(Items item)
    {
        for (int i = 0; i < _Inventory.Length; i++)
        {
            if (_Inventory[i] == null)
            {
                _Inventory[i] = item;
                return true;
            }
        }
        return false;
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
        if(_Inventory[index] is Armour){
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
        if(_Inventory[index] is Consumable){
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
}