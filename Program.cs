namespace RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riptide;
using Encoding = System.Text.Encoding;
public class Program
{
    public static void Main(string[] args)
    {
        //just print out hello world
        Console.WriteLine("Hello World!");
        test();
    }
    public static void test()
    {
        //test the player class
        Items?[] inventory = new Items?[40];
        Player player = new Player("player", null, 100, 100, 100, 100, 1, 0, 10, 10, 10, 10, 10, 10, 0, null, new Armour?[4], inventory);
        //add a sword to the inventory
        player.AddItem(new Weapon("sword", 10, 10, 1, 1, 10, false));
        //equip the sword
        player.AddWeaponFromInv(0);
        //add an apple to the inventory
        player.AddItem(new Items("apple", 10, 1, 1, 1));
        //print out the stats
        player.printStats();
        //test the dungeon class
        Dungeon dungeon = new Dungeon(10, 10);
        dungeon.Generate();
        dungeon.printDungeon();
    }
}