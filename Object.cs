namespace RPG;
public class Object : Entity
{
    protected string Type; 
    public Object(string name, string type, int health, int maxHealth, int baseArmor, int baseDamage, int addArmor, int gold, Items?[] inventory)
    :base(name, health, maxHealth, baseArmor, baseDamage, addArmor, gold, inventory)
    {
        Type = type;
    }
}