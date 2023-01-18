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
    //item generation
    //not items that are useful for Shield, Sword, Potions and Scrolls
    string[] uselessDescriptions = {"A red apple", "A skull", "A pile of sticks", "A pile of stones", "A pile of leaves", "A pile of pebbles"};
    string[] uselessTypes = {"Crunchy", "Sharp", "Rough", "Smooth", "Soft", "Hard"};
    string[] weaponDescriptions = {"A sword", "An axe", "A great axe", "A long sword", "A staff", "A dagger", "A mace", "A great sword", "A great mace", "A great staff", "A great dagger", "A great long sword"};
    string[] weaponTypes = {"Sharp", "Sharp", "Sharp", "Sharp", "Blunt", "Sharp", "Blunt", "Sharp", "Blunt", "Blunt", "Sharp", "Sharp"};
    string[] armorDescriptions = {"A leather armor", "A chainmail", "A plate armor", "A leather helmet", "A chainmail helmet", "A plate helmet", "A leather shield", "A chainmail shield", "A plate shield", "A leather boots", "A chainmail boots", "A plate boots"};
    string[] armorTypes = {"Light", "Medium", "Heavy", "Light", "Medium", "Heavy", "Light", "Medium", "Heavy", "Light", "Medium", "Heavy"};
    
    public static Items GenerateItem()
    {
        string[] uselessNames = {"Apple", "Skull", "Sticks", "Stones", "Leaves", "Pebbles"};
        //generate a ranndom useless item
        Random random = new Random();
        int uselessItem = random.Next(0, uselessNames.Length);
        return new Items(uselessNames[uselessItem], 1, 1, 1, 0);
    }
    public static Weapon GenerateWeapon()
    {
        string[] weaponNames = {"Sword", "Axe", "Great Axe", "Long Sword", "Staff", "Dagger", "Mace", "Great Sword", "Great Mace", "Great Staff", "Great Dagger", "Great Long Sword"};
        //generate a random weapon
        Random random = new Random();
        int weaponItem = random.Next(0, weaponNames.Length);
        return new Weapon(weaponNames[weaponItem], 1, 1, 1, 0, 1, false);
    }
    public static Armour GenerateArmor()
    {
        string[] armorNames = {"Leather Armor", "Chainmail", "Plate Armor", "Leather Helmet", "Chainmail Helmet", "Plate Helmet", "Leather Shield", "Chainmail Shield", "Plate Shield", "Leather Boots", "Chainmail Boots", "Plate Boots"};
        //generate a random armor
        Random random = new Random();
        int armorItem = random.Next(0, armorNames.Length);
        return new Armour(armorNames[armorItem], 1, 1, 1, random.Next(0,5), 1, false);
    }
    
}