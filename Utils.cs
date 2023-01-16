namespace RPG;
//this class is used for binary utilites such as checking if a specific bit is set
//setting a specific bit
//flipping a specific bit
public class Bin
{
    public static bool GetBit(int b, int pos)
    {
        return (b & (1 << pos)) != 0;
    }
    public static int SetBit(int b, int pos)
    {
        return b | (1 << pos);
    }
    public static int FlipBit(int b, int pos)
    {
        return b ^ (1 << pos);
    }
    
}