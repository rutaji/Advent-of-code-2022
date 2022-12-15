class MainClass
{
    static void Main ()
    {
        int points = 0;
        foreach(string Line in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt")))
        {
            string[] input = Line.Split(' ');
            switch (input[1]) 
            {
                case "X": points++; break;
                case "Y": points+=2; break;
                case "Z": points += 3; break;
            }
            points += Result(input[0].First(), input[1].First());
        }
        Console.WriteLine(points);
    }
    static int Result(char Opponet,char me) 
    {
        if(Opponet == me -23) { return 3; }
        if(Opponet == (me - 24) || (me - 22) == Opponet) { return 6; }
        return 0;
    }
}