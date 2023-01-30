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
        return tail.y + 2 == y && tail.x + 1 == x || tail.y + 1 == y && tail.x + 2 == x || tail.y + 2 == y && tail.x + 2 == x;
    }
    public bool IsHeadRightDown(Coordinates tail)
    {
        return tail.y - 2 == y && tail.x + 1 == x || tail.y - 1 == y && tail.x + 2 == x || tail.y - 2 == y && tail.x + 2 == x;
    }
    public bool IsHeadLeftUp(Coordinates tail)
    {
        return tail.y + 2 == y && tail.x - 1 == x || tail.y + 1 == y && tail.x - 2 == x || tail.y + 2 == y && tail.x - 2 == x;
    }
    public bool IsHeadLeftDown(Coordinates tail)
    {
        return tail.y - 2 == y && tail.x - 1 == x || tail.y - 1 == y && tail.x - 2 == x || tail.y - 2 == y && tail.x - 2 == x;
    }




}
class main
{
    static HashSet<Coordinates> Set = new();
    static Coordinates Head = new();
    static Coordinates Tail = new();
    static Coordinates Tail2 = new();
    static Coordinates Tail3 = new();
    static Coordinates Tail4 = new();
    static Coordinates Tail5 = new();
    static Coordinates Tail6 = new();
    static Coordinates Tail7 = new();
    static Coordinates Tail8 = new();
    static Coordinates Tail9 = new();
    static void Main()
    {
        Set.Add(Tail9);


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
            Check(ref Tail,ref Head);
            Check(ref Tail2,ref Tail);
            Check(ref Tail3,ref  Tail2);
            Check(ref Tail4,ref  Tail3);
            Check(ref Tail5,ref  Tail4);
            Check(ref Tail6,ref  Tail5);
            Check(ref Tail7,ref  Tail6);
            Check(ref Tail8,ref  Tail7);
            Check(ref Tail9,ref  Tail8);
            Set.Add(Tail9);
        }
    }
    static void Check(ref Coordinates Tail,ref Coordinates Head) 
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
