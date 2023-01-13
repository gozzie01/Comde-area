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
}