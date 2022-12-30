class main 
{
    static int value = 0;
    static void Main(String[] args) 
    {
        
        foreach (string input in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"))) 
        { 
            if(input == null) { break; }

            string firstSack = input.Substring(0,input.Length / 2);
            string secondSack = input.Substring(input.Length / 2);

            foreach(char c in firstSack) 
            {
                if (secondSack.Contains(c)) { pricti(c); break; }
            }
        }
        Console.WriteLine(value);
    }
    static void pricti(char c) 
    {
        if(c <= 'Z') { value += (c - 'A')+27; return; }
        value += c - 'a' + 1;
    }
}