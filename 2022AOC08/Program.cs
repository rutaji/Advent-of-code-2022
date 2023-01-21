using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

struct tree 
{
    public int height;
    public bool visible = false;
    public int visionScore = 0;
    public tree(int height) { this.height = height; }
}
class main 
{
    static int pocetRadku;
    static int pocetSloupcu;
    static tree[,] Array;
    static void Main(string[] args) 
    {
        string[] Lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"));
        pocetRadku = Lines.Length;
        pocetSloupcu = Lines[0].Length;
        Array = new tree[pocetRadku,pocetSloupcu];

        for(int i = 0;i < pocetRadku; i++) 
        {
            for(int j = 0; j < pocetSloupcu; j++) 
            {
                Array[i, j] = new tree((Lines[i][j]) - '0');
            }
        }

        for(int y = 0;y < pocetRadku; y++) 
        {
            for(int x = 0; x < pocetSloupcu; x++) 
            {
                int sum = 1;
                sum *= GetVisionScore(y => ++y, x => x, y, x, Array[y, x].height);
                sum *= GetVisionScore(y => --y, x => x, y, x, Array[y, x].height);
                sum *= GetVisionScore(y => y, x => ++x, y, x, Array[y, x].height);
                sum *= GetVisionScore(y => y, x => --x, y, x, Array[y, x].height);
                Array[y,x].visionScore = sum;
            }
        }
        int max = 0;
        foreach(tree t in Array) {if(t.visionScore > max) max = t.visionScore; }
        Console.WriteLine(max);
      
    }
    static int GetVisionScore( Func<int, int> posunY,Func<int,int> posunX, int y, int x, int vyska)
    {
        int score = 0;
        while (true) { 
            x = posunX(x);
            y = posunY(y);
            if (y >= pocetRadku || y < 0 || x >= pocetSloupcu || x < 0)
            {
                return score;
            }
            if (Array[y, x].height >= vyska) { return ++score; }
            score++;
        }
    }
}


