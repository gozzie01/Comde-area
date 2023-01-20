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
    public Weapon(string saveData) : base(saveData)
    {
        //split the string into an array of strings
        string[] data = saveData.Split('|');
        //assign the values to the properties
        Name = data[0];
        Value = int.Parse(data[1]);
        Weight = int.Parse(data[2]);
        Quantity = int.Parse(data[3]);
        Tier = int.Parse(data[4]);
        Damage = 10;
        Heavy = false;
    }
    override public string ToString()
    {
        return Name + "," + Value + "," + Weight + "," + Quantity + "," + Tier + "," + Damage + "," + Heavy;
    }
    public string getSaveData()
    {
        //use a different delimiter than the one used in the base class
        return Name + "|" + Value + "|" + Weight + "|" + Quantity + "|" + Tier + "|" + Damage + "|" + Heavy;
    }
} 