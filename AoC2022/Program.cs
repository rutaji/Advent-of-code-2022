using System.ComponentModel.DataAnnotations;

public class MainClass 
{
    static void Main() 
    {
        int Max = 0;
        int CurentElf = 0;
        foreach(string Line in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"))) 
        {
            if (Line == "") { if (CurentElf > Max) { Max = CurentElf; } CurentElf = 0; }
            else
            {
                CurentElf += int.Parse(Line);
            }
        }
        if (CurentElf > Max) { Max = CurentElf; }
        Console.WriteLine(Max);
    }
}
