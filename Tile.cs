namespace RPG;
public class Tile
{
    //this class is used to represent a tile in the world
    //the tile will have a type and a position
    public SubTiles[,] _SubTiles;
    private static Random _Random = new Random();
    private int _x;
    private int _y;
    private string _type;
    private int _DID;
    public Tile(int x, int y, string type)
    {
        _x = x;
        _y = y;
        _type = type;
        GenerateSubTiles();
    }
    public void GenerateSubTiles()
    {
        _SubTiles = new SubTiles[40,40];
        for(int i = 0; i < 40; i++)
        {
            for(int j = 0; j < 40; j++)
            {
                _SubTiles[i,j] = new SubTiles(i, j, "Grass");
            }
        }
        if (_type == "Dungeon")
        {
            //generate a random subtile to be a dungeon entrance
            int x = _Random.Next(0, 40);
            int y = _Random.Next(0, 40);
            _SubTiles[x, y].setType("Dungeon");
        }
    }
    public int getX()
    {
        return _x;
    }
    public int getY()
    {
        return _y;
    }
    public string getType()
    {
        return _type;
    }
    public void setType(string type)
    {
        _type = type;
    }
    public int getDID()
    {
        return _DID;
    }
    public void setDID(int DID)
    {
        _DID = DID;
    }
    public SubTiles[,] getSubTiles()
    {
        return _SubTiles;
    }
    public void setSubTiles(SubTiles[,] SubTiles)
    {
        _SubTiles = SubTiles;
    }
    public void printTile(int x, int y)
    {
        //print in a similar way to the world
        //red D for dungeon
        //green G for grass
        //blue for Player (P)
        //if player is standing on a dungeon entrance, print a blue D
        string print = "";
        //print a 9x9 square around the player
        for(int i = x - 4; i < x + 5; i++)
        {
            for(int j = y - 4; j < y + 5; j++)
            {
                if(i < 0 || j < 0 || i > 39 || j > 39)
                {
                    print += " ";
                }
                else
                {
                    if(i == x && j == y)
                    {
                        print += "P";
                    }
                    else if(_SubTiles[i,j].getType() == "Grass")
                    {
                        print += "G";
                    }
                    else if(_SubTiles[i,j].getType() == "Dungeon")
                    {
                        print += "D";
                    }
                }
            }
            print += "" + System.Environment.NewLine;
        }
        System.Console.WriteLine(print);
    }
}