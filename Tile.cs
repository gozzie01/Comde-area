namespace RPG;
public class Tile
{
    //this class is used to represent a tile in the world
    //the tile will have a type and a position
    private int _x;
    private int _y;
    private string _type;
    private int _DID;
    public Tile(int x, int y, string type)
    {
        _x = x;
        _y = y;
        _type = type;
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
}