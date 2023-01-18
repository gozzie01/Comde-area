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
    public int ID;
    private static int nextID = 0;
    
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
        ID = nextID;
        nextID++;
    }
    public Player(string playerData)
    :base(playerData)
    {
        _Armour = new Armour?[4];
        string[] data = playerData.Split(',');
        Name = data[0];
        Level = int.Parse(data[1]);
        Experience = int.Parse(data[2]);
        Health = int.Parse(data[3]); 
        MaxHealth = int.Parse(data[4]);
        Mana = int.Parse(data[5]);
        MaxMana = int.Parse(data[6]);
        Strength = int.Parse(data[7]);
        Dexterity = int.Parse(data[8]);
        Intelligence = int.Parse(data[9]);
        BaseArmor = int.Parse(data[10]);
        BaseDamage = int.Parse(data[11]);
        Gold = int.Parse(data[12]);
        if (data[13] != "null")
        {
            _Potion = new Consumable(data[13]);
        }
        if (data[14] != "null")
        {
            _Weapon = new Weapon(data[14]);
        }
        for (int i = 0; i < 4; i++)
        {
            if (data[15 + i] != "null")
            {
                _Armour[i] = new Armour(data[15 + i]);
            }
        }
        ID = nextID;
        nextID++;
        //inventory
        _Inventory = new Items?[10];
        for (int i = 0; i < 10; i++)
        {
            if (data[19 + i] != "null")
            {
                string[] sdata = data[19+i].Split("|");
                if (sdata[0] == "Weapon")
                {
                    _Inventory[i] = new Weapon(string.Join( "|", sdata.Skip(1).ToArray()));
                }
                else if (sdata[0] == "Armour")
                {
                    _Inventory[i] = new Armour(string.Join( "|", sdata.Skip(1).ToArray()));
                }
                else if (sdata[0] == "Consumable")
                {
                    _Inventory[i] = new Consumable(string.Join( "|", sdata.Skip(1).ToArray()));
                }
                else if (sdata[0] == "Item")
                {
                    _Inventory[i] = new Items(string.Join( "|", sdata.Skip(1).ToArray()));
                }
            }
        }
    }
    public bool equipArmour(Armour armour)
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
        Console.Write("Inventory: ");
        for (int i = 0; i < _Inventory.Length; i++)
        {
            if (_Inventory[i] != null)
            {
                Console.Write(" "+_Inventory[i]);
            }   
        }
        System.Console.WriteLine();
    }
    public string getSaveData()
    {
        string saveData = "";
        saveData += Name + ",";
        saveData += Level + ",";
        saveData += Experience + ",";
        saveData += Health + ",";
        saveData += MaxHealth + ",";
        saveData += Mana + ",";
        saveData += MaxMana + ",";
        saveData += Strength + ",";
        saveData += Dexterity + ",";
        saveData += Intelligence + ",";
        saveData += BaseArmor + ",";
        saveData += BaseDamage + ",";
        saveData += Gold + ",";
        if (_Weapon != null)
        {
            saveData += _Weapon.getSaveData() + ",";
        }
        else
        {
            saveData += "null,";
        }
        if (_Potion != null)
        {
            saveData += _Potion.getSaveData() + ",";
        }
        else
        {
            saveData += "null,";
        }
        if (_Armour[0] != null)
        {
            saveData += _Armour[0].getSaveData() + ",";
        }
        else
        {
            saveData += "null,";
        }
        if (_Armour[1] != null)
        {
            saveData += _Armour[1].getSaveData() + ",";
        }
        else
        {
            saveData += "null,";
        }
        if (_Armour[2] != null)
        {
            saveData += _Armour[2].getSaveData() + ",";
        }
        else
        {
            saveData += "null,";
        }
        if (_Armour[3] != null)
        {
            saveData += _Armour[3].getSaveData() + ",";
        }
        else
        {
            saveData += "null,";
        }

        for (int i = 0; i < _Inventory.Length; i++)
        {
            if (_Inventory[i] != null)
            {
                if (_Inventory[i] is Weapon)
                {
                    saveData += "Weapon," + _Inventory[i].getSaveData() + ",";
                }
                else if (_Inventory[i] is Armour)
                {
                    saveData += "Armour," + _Inventory[i].getSaveData() + ",";
                }
                else if (_Inventory[i] is Consumable)
                {
                    saveData += "Consumable," + _Inventory[i].getSaveData() + ",";
                }
                else
                {
                    saveData += "Item" + _Inventory[i].getSaveData() + ",";
                }
            }
            else
            {
                saveData += "null,";
            }
        }
        return saveData;
    }   
}