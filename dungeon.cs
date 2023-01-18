namespace RPG;
public class Dungeon
{
    //this class is used for the dungeon
    //the dungeon should be represented as a 2d array of rooms
    //the dungeon should be able to be generated randomly
    //the dungeon should be coherent, if you go through the left door 4 times you should end up in the same room
    private Room[,] _Rooms;
    private Random _Rand = new Random();
    private int _Width;
    private int _Height;
    private int _Area;
    //create a list of players in the dungeon
    private List<Player> _Players = new List<Player>();
    //create a complimentary list of tuples containg x and y values for the location of each player
    private List<Tuple<int,int>> _PlayerLocations = new List<Tuple<int,int>>();
    public Dungeon(int width, int height)
    {
        _Width = width;
        _Height = height;
        _Area = width * height;
        _Rooms = new Room[width, height];
    }
    public void Generate()
    {
        //generate the dungeon
        //generate a layout
        bool[,] layout = new bool[_Rooms.GetLength(0), _Rooms.GetLength(1)];
        //the every room in the layout must have a connection to the first room 
        //the first room should always be center left
        layout[0, _Rooms.GetLength(1) / 2] = true;
        //generate a random number for the number of rooms
        int numRooms = _Rand.Next(_Area/4, _Area/2);
        List<Tuple<int,int>> generatedRoomsXY = new List<Tuple<int,int>>();
        generatedRoomsXY.Add(new Tuple<int, int>(0, _Rooms.GetLength(1) / 2));
        while(generatedRoomsXY.Count<numRooms)
        {
            //pick a random room in the layout
            Tuple<int,int> room = generatedRoomsXY[(int)Math.Floor(_Rand.NextDouble()*generatedRoomsXY.Count)];
            //pick a random direction
            int direction = _Rand.Next(0, 10);
            //check if the room in that direction is already generated
            if (direction == 0 && room.Item2-1 >= 0)
            {
                //check if the room is already generated
                if (!layout[room.Item1, room.Item2-1])
                {
                    //generate the room
                    layout[room.Item1, room.Item2-1] = true;
                    generatedRoomsXY.Add(new Tuple<int,int>(room.Item1, room.Item2-1));
                }
            }
            else if (direction == 1 && room.Item1+1 < _Rooms.GetLength(0))
            {
                //check if the room is already generated
                if (!layout[room.Item1+1, room.Item2])
                {
                        //generate the room
                        layout[room.Item1+1, room.Item2] = true;
                        generatedRoomsXY.Add(new Tuple<int,int>(room.Item1+1, room.Item2));
                }
            }
            else if (direction == 2 && room.Item2+1 < _Rooms.GetLength(1))
            {
                //check if the room is already generated
                if (!layout[room.Item1, room.Item2+1])
                {
                        //generate the room
                        layout[room.Item1, room.Item2+1] = true;
                        generatedRoomsXY.Add(new Tuple<int,int>(room.Item1, room.Item2+1));
                    
                }
            }
            else if (direction == 3 && room.Item1-1 >= 0)
            {
                //check if the room is already generated
                if (!layout[room.Item1-1, room.Item2])
                {
                        //generate the room
                        layout[room.Item1-1, room.Item2] = true;
                        generatedRoomsXY.Add(new Tuple<int,int>(room.Item1-1, room.Item2));
                }
            }
            else if (direction >= 5 && room.Item1+1 < _Rooms.GetLength(0))
            {
                //check if the room is already generated
                if (!layout[room.Item1+1, room.Item2])
                {
                        //generate the room
                        layout[room.Item1+1, room.Item2] = true;
                        generatedRoomsXY.Add(new Tuple<int,int>(room.Item1+1, room.Item2));
                }
            }
        }
        //generate the rooms and doors
        for(int x=0; x<_Rooms.GetLength(0); x++)
        {
            for(int y=0; y<_Rooms.GetLength(1); y++)
            {
                if(layout[x,y])
                {
                    //generate the room
                    _Rooms[x,y] = new Room("Room", "A room", 0);
                    //generate the doors
                    if(x>0)
                    {
                        if(layout[x-1,y])
                        {
                            //generate a door to the left
                            _Rooms[x,y].Exits = Bin.SetBit(_Rooms[x,y].Exits, 0);
                        }
                    }
                    if(x<_Rooms.GetLength(0)-1)
                    {
                        if(layout[x+1,y])
                        {
                            //generate a door to the right
                            _Rooms[x,y].Exits = Bin.SetBit(_Rooms[x,y].Exits, 1);
                        }
                    }
                    if(y>0)
                    {
                        if(layout[x,y-1])
                        {
                            //generate a door to the top
                            _Rooms[x,y].Exits = Bin.SetBit(_Rooms[x,y].Exits, 2);
                        }
                    }
                    if(y<_Rooms.GetLength(1)-1)
                    {
                        if(layout[x,y+1])
                        {
                            //generate a door to the bottom
                            _Rooms[x,y].Exits = Bin.SetBit(_Rooms[x,y].Exits, 3);
                        }
                    }
                }
            }
        }
        //Generate the items in a chest object
        //generate 1 chest per room
        for(int x=0; x<_Rooms.GetLength(0); x++)
        {
            for(int y=0; y<_Rooms.GetLength(1); y++)
            {
                if(_Rooms[x,y]!=null)
                {
                    Items?[] items = new Items?[5];
                    //generate the items
                    int numItems = _Rand.Next(1, 5);
                    for(int i=0; i<numItems; i++)
                    {
                        items[i] = Bin.GenerateItem();
                    
                    }
                    items[numItems] = Bin.GenerateWeapon();
                    Object[] objects = new Object[1];
                    objects[0] = new Object("chest", "chest", 100, 100, 100, 0, 100, _Rand.Next(0,100), items);
                    _Rooms[x,y].Objects = objects;
                }
            }
        }
    }

    public Room GetRoom(int x, int y)
    {
        return _Rooms[x,y];
    }
    public Room GetRoom(int index)
    {
        return _Rooms[index % _Width, index / _Width];
    }
    public int GetWidth()
    {
        return _Width;
    }
    public int GetHeight()
    {
        return _Height;
    }
    public int GetArea()
    {
        return _Area;
    }
    public void printDungeon()
    {
        for(int y=0; y<_Rooms.GetLength(1); y++)

        {
            for(int x=0; x<_Rooms.GetLength(0); x++)
            {
                if(_Rooms[x,y]!=null)
                {
                    //print the number of doors
                    int doors = 0;
                    for(int i=0; i<4; i++)
                    {
                        if(Bin.GetBit(_Rooms[x,y].Exits, i))
                        {
                            doors++;
                        }
                    }
                    Console.Write(doors);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
    public int addPlayer(Player player, int x, int y)
    {
        _Players.Add(player);
        _Rooms[x,y].Players.Add(player);
        _PlayerLocations.Add(new Tuple<int,int>(x,y));
        return player.ID;
    }
    public Tuple<int,int>? getPlayerLocation(int ID)
    {
        for(int i=0; i<_Players.Count; i++)
        {
            if(_Players[i].ID == ID)
            {
                return _PlayerLocations[i];
            }
        }
        return null;
    }
    public Room getPlayerRoom(int ID)
    {
        for(int i=0; i<_Players.Count; i++)
        {
            if(_Players[i].ID == ID)
            {
                return _Rooms[_PlayerLocations[i].Item1, _PlayerLocations[i].Item2];
            }
        }
        return null;
    }
}