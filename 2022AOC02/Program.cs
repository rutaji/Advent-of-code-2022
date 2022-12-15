class MainClass
{
    static void Main ()
    {
        int points = 0;
        int me = 0 ;
        foreach(string Line in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt")))
        {
            string[] input = Line.Split(' ');
            switch (input[1]) 
            {
                case "X": me = (input[0].First() - 1)%3; break; //lose
                case "Y": me = (input[0].First())%3; points += 3; break; //draw
                case "Z": me =(input[0].First() + 1)%3; points += 6; break; //win
            }
            switch (me) 
            {
                case 0: points+=2; break;
                case 1: points+=3; break;
                case 2: points++;break;
            }
            
        }
        Console.WriteLine(points);
    }
    
}