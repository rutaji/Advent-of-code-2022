class main
{
    static void Main()
    {
        char[] c = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Input.txt")).ToCharArray();
        for(int i = 3;i < c.Length;i++){
            if (c[i] != c[i - 1] && c[i] != c[i-2] && c[i] != c[i-3] &&
                c[i - 1] != c[i - 2] && c[i-1] != c[i-3] &&
                c[i - 2] != c[i - 3]) 
            { Console.WriteLine(i+1);return; }
        }
    }
}
