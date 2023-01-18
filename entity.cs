//player should have stats like a dnd character but have an inventory of 40 slots and 4 armor slots and a weapon slot as well as a potion slot for a potion that can be used mid battle

namespace RPG;
public class Entity
{
    protected string Name;
    protected int Health;
    protected int MaxHealth;
    protected int BaseArmor;
    protected int BaseDamage;
    public int AddArmor;
    public int Gold;
    protected Items?[] _Inventory;
    public Entity(string name, int health, int maxHealth, int baseArmor, int baseDamage, int addArmor, int gold, Items?[] inventory)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        BaseArmor = baseArmor;
        BaseDamage = baseDamage;
        AddArmor = addArmor;
        Gold = gold;
        _Inventory = inventory;
    
    }
    public Entity(string saveData)
    {
        //trust in the save data
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
    //overide toString to return the name of the entity
    public override string ToString()
    {
        return Name;
    }
}