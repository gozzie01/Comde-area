namespace RPG;
public class SubTiles
{
    //this class is used to represent a subtile in the world
    //the subtile will have a type and a position
    private int _x;
    private int _y;
    private string _type;
    public SubTiles(int x, int y, string type)
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
}