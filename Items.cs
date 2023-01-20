namespace RPG;
public class Items
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int Tier { get; set; }
    public int Weight { get; set; }
    public int Quantity { get; set; }
    public Items(string name, int value, int weight, int quantity, int tier)
    {
        Name = name;
        Value = value;
        Weight = weight;
        Quantity = quantity;
        Tier = tier;
    }
    public Items(string saveData)
    {
        //split the string into an array of strings
        System.Console.WriteLine(saveData);
        string[] data = saveData.Split('|');
        //assign the values to the properties
        Name = data[0];
        Value = int.Parse(data[1]);
        Weight = int.Parse(data[2]);
        Quantity = int.Parse(data[3]);
        Tier = 1;
    }
    //overide ToString() to return the name of the item
    public override string ToString()
    {
        return Name+ "," + Value + "," + Weight + "," + Quantity + "," + Tier;
    }
    //add a method to return the data in a format suitable for saving to a file
    public string getSaveData()
    {
        //use a different delimiter than the one used in the base class
        return Name + "|" + Value + "|" + Weight + "|" + Quantity + "|" + Tier;
    }
}