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
    public Armour(string saveData) : base(saveData)
    {
        //split the string into an array of strings
        string[] data = saveData.Split('|');
        //assign the values to the properties
        Name = data[0];
        Value = int.Parse(data[1]);
        Weight = int.Parse(data[2]);
        Quantity = int.Parse(data[3]);
        Tier = int.Parse(data[4]);
        ArmorStat = int.Parse(data[5]);
        Heavy = bool.Parse(data[6]);
    }
    override public string ToString()
    {
        return Name + "," + Value + "," + Weight + "," + Quantity + "," + Tier + "," + ArmorStat + "," + Heavy;
    }
    public string getSaveData()
    {
        //use a different delimiter than the one used in the base class
        return Name + "|" + Value + "|" + Weight + "|" + Quantity + "|" + Tier + "|" + ArmorStat + "|" + Heavy;
    }
}