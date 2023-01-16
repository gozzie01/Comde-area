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
    //overide ToString() to return the name of the item
    public override string ToString()
    {
        return Name;
    }
}