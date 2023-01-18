namespace RPG;
public class Weapon : Items
{
    public int Damage { get; set; }
    public bool Heavy { get; set; }
    public Weapon(string name, int value, int weight, int quantity, int tier, int damage, bool heavy) : base(name, value, weight, quantity, tier)
    {
        Damage = damage;
        Heavy = heavy;
    }
    override public string ToString()
    {
        return Name + "," + Value + "," + Weight + "," + Quantity + "," + Tier + "," + Damage + "," + Heavy;
    }
} 