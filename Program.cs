struct Coordinates 
{
    public int x;
    public int y;

    public bool IsTouching(Coordinates input) 
    {
        int XDiference = Math.Abs(x - input.x);
        int YDiference = Math.Abs(y - input.y);
        return YDiference <= 1 && XDiference <= 1;
    }
    //H
    //.
    //T
    public bool IsHeadAbove(Coordinates tail) 
    {
        return tail.x == x && tail.y + 2 == y;
    }
    public bool IsHeadBelow(Coordinates tail)
    {
        return tail.x == x && tail.y - 2 == y;
    }
    public bool IsHeadLeft(Coordinates tail)
    {
        return tail.y == y && tail.x - 2 == x;
    }
    public bool IsHeadRight(Coordinates tail)
    {
        return tail.y == y && tail.x + 2 == x;
    }
    public bool IsHeadRightUp(Coordinates tail) 
    {
        return tail.y + 2 == y && tail.x + 1 == x || tail.y + 1 == y && tail.x + 2 == x;
    }
    public bool IsHeadRightDown(Coordinates tail)
    {
        return tail.y - 2 == y && tail.x + 1 == x || tail.y - 1 == y && tail.x + 2 == x;
    }
    public bool IsHeadLeftUp(Coordinates tail)
    {
        return tail.y + 2 == y && tail.x - 1 == x || tail.y + 1 == y && tail.x - 2 == x;
    }
    public bool IsHeadLeftDown(Coordinates tail)
    {
        return tail.y - 2 == y && tail.x - 1 == x || tail.y - 1 == y && tail.x - 2 == x;
    }




}
class main
{
    static HashSet<Coordinates> Set = new();
    static Coordinates Head = new();
    static Coordinates Tail = new();
    static void Main()
    {
        Set.Add(Tail);


        foreach (string input in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt")))
        {
            char direction = input[0];
            int distance = int.Parse(input.Substring(2));
            MoveHead(direction, distance);

        }
        Console.WriteLine(Set.Count());
    }
    static void MoveHead(char direction, int distance) 
    {
        for(int i = 0;i< distance; i++) 
        {
            switch (direction) 
            {
                case 'R':
                    Head.x++;
                    break;
                case 'U':
                    Head.y++;
                    break;
                case 'L':
                    Head.x--;
                    break;
                case 'D':
                    Head.y--;
                    break;
            }
            Check();
            Set.Add(Tail);
        }
    }
    static void Check() 
    {
        
        if (Head.IsTouching(Tail)) { return; }
        else if (Head.IsHeadAbove(Tail)) { Tail.y++;return; }
        else if (Head.IsHeadBelow(Tail)) { Tail.y--;return; }
        else if (Head.IsHeadLeft(Tail)) { Tail.x--;return; }
        else if (Head.IsHeadRight(Tail)) { Tail.x++;return; }
        else if (Head.IsHeadLeftDown(Tail)) { Tail.x--;Tail.y--;return; }
        else if (Head.IsHeadLeftUp(Tail)){ Tail.x--;Tail.y++;return; }
        else if (Head.IsHeadRightDown(Tail)) { Tail.x++;Tail.y--;return; }
        else if (Head.IsHeadRightUp(Tail)) { Tail.x++;Tail.y++;return; }
        throw new Exception("Unhadled Exception"); 
    }
}
