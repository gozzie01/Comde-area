namespace RPG;
public class World
{
    //generate a world in similar fasion to the dungeon but with out doors and rooms, it needs to have some dungeons scattered around
    //the world will be a 2d array of tile
    private Tile[,] _World;
    private int _xSize;
    private int _ySize;
    private List<Dungeon> _Dungeon;
    public World(int xSize, int ySize)
    {
        _xSize = xSize;
        _ySize = ySize;
        _World = new Tile[_xSize, _ySize];
        _Dungeon = new List<Dungeon>();
        //fill the world with grass
        for (int i = 0; i < _xSize; i++)
        {
            for (int j = 0; j < _ySize; j++)
            {
                _World[i, j] = new Tile(i, j, "grass");
            }
        }
        //add a dungeon to a random number of locations
        Random rand = new Random();
        int numDungeons = rand.Next(1, 5);
        for (int i = 0; i < numDungeons; i++)
        {
            int x = rand.Next(0, _xSize);
            int y = rand.Next(0, _ySize);
            _World[x, y] = new Tile(x, y, "dungeon");
            _Dungeon.Add(new Dungeon(10, 10));
            _World[x, y].setDID(_Dungeon.Count - 1);
        }
    }
    public World(string saveData)
    {
        //load the world from the save data
        string[] saveDataArray = saveData.Split(',');
        _xSize = int.Parse(saveDataArray[0]);
        _ySize = int.Parse(saveDataArray[1]);
        string _WorldText = saveDataArray[2];
        _World = new Tile[_xSize, _ySize];
        _Dungeon = new List<Dungeon>();
        for (int i = 0; i < _xSize; i++)
        {
            for (int j = 0; j < _ySize; j++)
            {
                if (_WorldText[i * _xSize + j] == 'D')
                {
                    _World[i, j] = new Tile(i, j, "dungeon");
                }
                else
                {
                    _World[i, j] = new Tile(i, j, "grass");
                }
            }
        }
        //generate the dungeons
        for (int i = 0; i < _xSize; i++)
        {
            for (int j = 0; j < _ySize; j++)
            {
                if (_World[i, j].getType() == "dungeon")
                {
                    _Dungeon.Add(new Dungeon(10, 10));
                    _Dungeon[_Dungeon.Count - 1].Generate();
                    _World[i, j].setDID(_Dungeon.Count - 1);
                }
            }
        }
    }
    public void PrintWorld(int x, int y)
    {
        //print out the world
        //world appears upside down because of the way the array is stored
        for (int i = _ySize - 1; i >= 0; i--)
        {
            for (int j = 0; j < _xSize; j++)
            {
                //if the player is on the tile print a red P
                //if the tile is a dungeon print a blue D
                //if the player is on a dungeon print a red D
                //if the tile is a grass print a green G

                if (j == x && i == y)
                {
                    if (_World[j, i].getType() == "dungeon")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("D");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("P");
                    }
                }
                else if (_World[j, i].getType() == "dungeon")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("D");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("G");
                }
            }
            Console.WriteLine();
        }
    }
    public void PrintWorld(int x, int y,int SubX,int SubY)
    {
        _World[x, y].printTile(SubX, SubY);
    }
    public Tile getTile(int x, int y)
    {
        return _World[x, y];
    }
    public void setTile(int x, int y, Tile tile)
    {
        _World[x, y] = tile;
    }
    public Dungeon getDungeon(int DID)
    {
        return _Dungeon[DID];
    }
    public string getSaveData()
    {
        string world = "";
        world += _xSize + "," + _ySize + ",";
        foreach (Tile tile in _World)
        {
            if (tile.getType() == "dungeon")
            {
                world += "D";
            }
            else
            {
                world += "G";
            }
        }
        return world;
    }    
}