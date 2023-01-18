namespace RPG;
public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Exits { get; set; }
    public Object[] Objects { get; set; }
    public List<Enemy> Enemies { get; set; }
    public List<Player> Players { get; set; }
    public Room(string name, string description, int exits, Object[] objects, List<Enemy> enemies, List<Player> players)
    {
        Name = name;
        Description = description;
        Exits = exits;
        Objects = objects;
        Enemies = enemies;
        Players = players;
    }
    public Room(string name, string description, int exits)
    {
        Name = name;
        Description = description;
        Exits = exits;
        Objects = new Object[0];
        Enemies = new List<Enemy>();
        Players = new List<Player>();
    }
    public void PrintRoom()
    {
        Console.WriteLine("You are in the " + Name + ".");
        Console.WriteLine(Description);
        Console.WriteLine("There are " + Exits + " exits.");
        Console.WriteLine("There are " + Objects.Length + " objects.");
        Console.WriteLine("There are " + Enemies.Count + " enemies.");
        Console.WriteLine("There are " + Players.Count + " players.");
    }
}