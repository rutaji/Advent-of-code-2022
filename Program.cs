using System.Text.RegularExpressions;

class main 
{
    static int cycle = 0;
    static int x = 1;
    static int sum = 0;
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
        Console.WriteLine(sum);


    }
    static void Noop()
    {
        cycle++;
        CheckCykle();
    }
    static void CheckCykle() 
    {
        if(cycle  > 19 &&( cycle -20) % 40 == 0) 
        { 
            sum += x * cycle; 
        }
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
