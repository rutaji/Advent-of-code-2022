using System.ComponentModel.DataAnnotations;

public class MainClass 
{
    static int[] Max = new int[3];
    static void Main() 
    {
        
        int CurentElf = 0;
        foreach(string Line in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"))) 
        {
            if (Line == "") { if (CurentElf > Max[0]) { Change(CurentElf); } CurentElf = 0; }
            else
            {
                CurentElf += int.Parse(Line);
            }
        }
        if (CurentElf > Max[0]) { Change(CurentElf); }
        int sum = 0;
        foreach(int s in Max) { sum += s; }
        Console.WriteLine(sum);
    }
    static void Change(int i) 
    {
        Max[0] = i;
        Array.Sort(Max);
    }

}
