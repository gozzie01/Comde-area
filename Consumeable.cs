namespace RPG;
public class Consumable : Items
{
    public int Health { get; set; }
    public int Mana { get; set; }
    public Consumable(string name, int value, int weight, int quantity, int tier, int health, int mana) : base(name, value, weight, quantity, tier)
    {
        Health = health;
        Mana = mana;
    }
    public Consumable(string saveData) : base(saveData)
    {
        //split the string into an array of strings
        string[] data = saveData.Split('|');
        //assign the values to the properties
        Name = data[0];
        Value = int.Parse(data[1]);
        Weight = int.Parse(data[2]);
        Quantity = int.Parse(data[3]);
        Tier = int.Parse(data[4]);
        Health = int.Parse(data[5]);
        Mana = int.Parse(data[6]);
    }
    override public string ToString()
    {
        return Name + "," + Value + "," + Weight + "," + Quantity + "," + Tier + "," + Health + "," + Mana;
    }
    public string getSaveData()
    {
        //use a different delimiter than the one used in the base class
        return Name + "|" + Value + "|" + Weight + "|" + Quantity + "|" + Tier + "|" + Health + "|" + Mana;
    }
}