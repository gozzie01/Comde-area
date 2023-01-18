namespace RPG;
class Client
{
    //this class is used for the client
    //at this point the client should be single player only
    private Player _Player;
    private Dungeon _Dungeon;
    public Client()
    {
        Armour?[] armour = new Armour?[4];
        foreach (Armour? a in armour)
        {
            a = null;
        }
        Items[] inventory = new Items[10];
        foreach (Items i in inventory)
        {
            i = null;
        }
        _Player = new Player("john", null, 100, 100, 100, 100, 1, 0, 10, 10, 10, 25, 10, 0, 1000, null, armour, inventory);
        _Dungeon = new Dungeon(10, 10);
        _Dungeon.Generate();
    }
    public void Play()
    {
        //add player to the dungeon
        ID = _Dungeon.AddPlayer(_Player);
        //get info about the current room
        bool playing = true;
        while(playing)
        {
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
                        case "north":
                            _Dungeon.MovePlayer(ID, 0, -1);
                            break;
                        case "south":
                            _Dungeon.MovePlayer(ID, 0, 1);
                            break;
                        case "east":
                            _Dungeon.MovePlayer(ID, 1, 0);
                            break;
                        case "west":
                            _Dungeon.MovePlayer(ID, -1, 0);
                            break;
                    }
                    break;
                case "quit":
                    playing = false;
                    break;
            }
        }
    }
}