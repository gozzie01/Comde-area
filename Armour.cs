namespace RPG;
public class Armour : Items
{
    public int ArmorStat { get; set; }
    public bool Heavy { get; set; }
    public Armour(string name, int value, int weight, int quantity, int tier, int armor, bool heavy) : base(name, value, weight, quantity, tier)
    {
        ArmorStat = armor;
        Heavy = heavy;
    }
    override public string ToString()
    {
        return Name + "," + Value + "," + Weight + "," + Quantity + "," + Tier + "," + ArmorStat + "," + Heavy;
    }
}