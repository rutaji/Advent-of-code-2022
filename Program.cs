using System.Text.RegularExpressions;

class main 
{
    static int cycle = 0;
    static int x = 1;
    static void Main() 
    {
        foreach (string input in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"))) 
        {
            var matches = Regex.Match(input, @"(\w+) ?([\d-]*)?");
            switch (matches.Groups[1].Value) 
            {
                case "addx":
                    addx(int.Parse(matches.Groups[2].Value));
                    break;
                case "noop":
                    Noop();
                    break;
            }
            
        }
    }
    static void Noop()
    {
        cycle++;
        CheckCykle();
    }
    static void CheckCykle() 
    {
        int drawPosition = cycle % 40 -1;
        if (drawPosition  >= x -1 && drawPosition <= x+1 ) { Console.Write('#'); }
        else { Console.Write("."); }
        if(cycle % 40 == 0) { Console.WriteLine(); }
    }
    static void addx(int x) 
    {
        cycle++;
        CheckCykle();
        cycle++;
        CheckCykle();
        main.x += x;
    }

}
