namespace RPG;
public class Object : Entity
{
    protected string Type; 
    public Object(string name, string type, int health, int maxHealth, int baseArmor, int baseDamage, int addArmor, int gold, Items?[] inventory)
    :base(name, health, maxHealth, baseArmor, baseDamage, addArmor, gold, inventory)
    {
        Type = type;
    }
    override public string ToString()
    {
        return Name + "," + Type + "," + Health + "," + MaxHealth + "," + BaseArmor + "," + BaseDamage + "," + AddArmor + "," + Gold;
    }
    public string getSaveData()
    {
        //use a different delimiter than the one used in the base class
        return Name + "|" + Type + "|" + Health + "|" + MaxHealth + "|" + BaseArmor + "|" + BaseDamage + "|" + AddArmor + "|" + Gold;
    }
}