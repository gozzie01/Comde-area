namespace RPG;
public class Dungeon
{
    public Room[,] Rooms { get; set; }
    public Dungeon(Room[,] rooms)
    {
        Rooms = rooms;
    }
    public void PrintRoom(int x, int y)
    {
        Console.WriteLine(Rooms[x, y].Name);
        Console.WriteLine(Rooms[x, y].Description);
        Console.WriteLine("Exits: " + string.Join(", ", Rooms[x, y].Exits));
    }
    public void generate(int rooms, int width = 10, int height = 10)
    {
        //rooms need to be connected by doors
        //rooms do not need to have a name
        //rooms do not need to have a description
        //rooms do need to have an exit, rooms can have multiple exits but they must be connected to another room
        //rooms need to generate from a starting room which is the center left room
        //rooms need to be generated from the starting room
        //create a 2d array of rooms
        Rooms = new Room[width, height];
        //create a random number generator
        Random random = new Random();
        //create exits randomly by generateing a number between 0 and 15 then setting the 4th bit to 0 if the number is then 0 regenerate the number
        //create the starting room
        bool generating = true;
        int exits = random.Next(0, 15);
        while (exits == 8)
        {
            exits = random.Next(0, 15);
        }
        if (exits > 8)
        {
            exits -= 8;
        }
        int x = 0;
        int y = height / 2;
        Rooms[x, y] = new Room("Starting Room", "This is the starting room", exits, new Object[] { }, new List<Enemy> { }, new List<Player> { });
        //create the rest of the rooms
        while(generating)
        {
            //generate a room on the side of the current room that has an exit
            //create exits randomly by generateing a number between 0 and 15 then setting the required bit to align the exit to the current room
            //if the room is on the edge of the map then there musnt be an exit in that direction
            if(exits == 1)
            {
                //create a room above the current room
                exits = random.Next(0, 15);
                
            }

        }


    }
}