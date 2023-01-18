namespace RPG;
using System.Text.Json;
class Client
{
    //this class is used for the client
    //at this point the client should be single player only
    private Player _Player;
    private World _World;
    private int _X;
    private int _Y;
    public Client()
    {
        //init new or load
        Console.WriteLine("Would you like to load a game or start a new one?");
        string input = Console.ReadLine();
        if (input == "new")
        {
            initNew();
        }
        else if (input == "load")
        {
            Load();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Environment.Exit(0);
        }
    }
    public void initNew()
    {
        Armour?[] armour = new Armour?[4];
        for (int i = 0; i < armour.Length; i++)
        {
            armour[i] = null;
        }
        Items[] inventory = new Items[10];
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = null;
        }
        _World = new World(10, 10);
        _Player = new Player("john", null, 100, 100, 100, 100, 1, 0, 10, 10, 10, 25, 10, 0, 1000, null, armour, inventory);
    }
    public void PlayDungeon(int DID)
    {
        Dungeon _Dungeon = _World.getDungeon(DID);
        //add player to the dungeon
        int ID = _Dungeon.addPlayer(_Player, 0, _Dungeon.getYsize()/2);
        //get info about the current room
        bool playing = true;
        while(playing)
        {
            Console.Clear();
            //get the current room
            Room room = _Dungeon.getPlayerRoom(ID);
            //print out the room
            room.PrintRoom();
            //get the input
            string input = Console.ReadLine();
            //parse the input
            string[] inputArray = input.Split(' ');
            //check the input
            switch(inputArray[0])
            {
                case "move":
                    //move the player
                    switch(inputArray[1])
                    {
                        //using the movePlayer function and the standard directions set in the generate doors
                        case "north":
                            _Dungeon.movePlayer(ID, 3);
                            break;
                        case "south":
                            _Dungeon.movePlayer(ID, 2);
                            break;
                        case "east":
                            _Dungeon.movePlayer(ID, 1);
                            break;
                        case "west":
                            _Dungeon.movePlayer(ID, 0);
                            break;
                    }
                    break;
                case "quit":
                    if (_Dungeon.getPlayerRoom(ID).getEnemyCount() == 0)
                    {
                        //remove the player from the dungeon
                        _Dungeon.removePlayer(ID);
                        //return to the world
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You can't quit while there are enemies in the room!");
                    }
                    break;
                case "save":
                    System.Console.WriteLine("Can't save in a dungeon!");
                    break;
                case "stats":
                    _Player.printStats();
                    break;
            }
        }
    }
    public void Play(int x = -1, int y =-1)
    {
        if(x == -1 && y == -1)
        {
            x = _X;
            y = _Y;
        }
        else
        {
            _X = x;
            _Y = y;
        }
        bool playing = true;
        _World.PrintWorld(x, y);
        while(playing)
        {
            Console.Clear();
            _World.PrintWorld(x, y);
            //print out the world
            //get the input
            string input = Console.ReadLine();
            //parse the input
            string[] inputArray = input.Split(' ');
            //check the input
            switch(inputArray[0])
            {
                case "move":
                    //move the player
                    switch(inputArray[1])
                    {
                        //using the movePlayer function and the standard directions set in the generate doors
                        case "north":
                            y++;
                            break;
                        case "south":
                            y--;
                            break;
                        case "east":
                            x++;
                            break;
                        case "west":
                            x--;
                            break;
                    }
                    break;
                case "enter":
                    //enter the dungeon
                    if(_World.getTile(x, y).getType() == "dungeon")
                    {
                        PlayDungeon(_World.getTile(x, y).getDID());
                    }
                    break;
                case "quit":
                    return;
                case "save":
                    Save();
                    break;
                case "stats":
                    _Player.printStats();
                    break;
            }
            _X = x;
            _Y = y;
        }
    }
    //add save and load functions using custom

    public void Save()
    {
        //save the player the string from the player class is already in a csv type format
        string player = _Player.getSaveData();
        System.IO.File.WriteAllText("save.txt", player);
        System.IO.File.AppendAllText("save.txt", Environment.NewLine);
        string world = _World.getSaveData();
        System.IO.File.AppendAllText("save.txt", world);      
        //save x and y
        System.IO.File.AppendAllText("save.txt", Environment.NewLine);
        System.IO.File.AppendAllText("save.txt", _X.ToString()+","+_Y.ToString());
    }
    public void Load()
    {
        string save = System.IO.File.ReadLines("save.txt").First();
        Player player = new Player(save);  
        _Player = player;
        string world = System.IO.File.ReadLines("save.txt").Skip(1).First();
        World world1 = new World(world);
        _World = world1; 
        string[] xy = System.IO.File.ReadLines("save.txt").Skip(2).First().Split(',');
        _X = int.Parse(xy[0]);
        _Y = int.Parse(xy[1]);
    }
}