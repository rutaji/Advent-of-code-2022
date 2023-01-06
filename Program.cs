using System.Security.Cryptography;
using System.Text.RegularExpressions;

struct Range 
{
    public int start;
    public int end;
    public Range(int start, int end) {this.start= start; this.end = end;}
}

class main 
{
    static Range R1;
    static Range R2;
    static void Main() 
    {
        int count = 0;
        foreach (string Line in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"))) 
        {
            var matches = Regex.Matches(Line, "[0-9]+");
            ToTange(matches);
            if (ContainsFully()) { count++; }
        }
        Console.WriteLine(count);
    }
    static void ToTange(MatchCollection c) 
    {
        R1 = new(int.Parse(c[0].Value), int.Parse(c[1].Value)) ;
        R2 = new(int.Parse(c[2].Value), int.Parse(c[3].Value));

    }
    static bool ContainsFully() 
    {
        if(R1.start <= R2.start && R1.end >= R2.end) return true;
        if(R2.start <= R1.start && R2.end >= R1.end) return true;
        return false;
    }
    
}
