struct tree 
{
    public int height;
    public bool visible = false;
    public tree(int height) { this.height = height; }
}
class main 
{
    static void Main(string[] args) 
    {
        string[] Lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"));
        int pocetRadku = Lines.Length;
        int pocetSloupcu = Lines[0].Length;
        tree[,] Array = new tree[pocetRadku,pocetSloupcu];

        for(int i = 0;i < pocetRadku; i++) 
        {
            for(int j = 0; j < pocetSloupcu; j++) 
            {
                Array[i, j] = new tree((Lines[i][j]) - '0');
            }
        }

        int vid;

        for (int radek = 0; radek < pocetRadku; radek++)
        {
            vid = -1;

            for (int i = 0; i < pocetSloupcu; i++)
            {
                if (Array[radek,i].height > vid) {vid = Array[radek,i].height; Array[radek, i].visible = true; }
            }
            vid = -1;
            for (int i = pocetSloupcu-1; i >= 0; i--)
            {
                if (Array[radek, i].height > vid) { vid = Array[radek, i].height; Array[radek, i].visible = true; }
            }
        }
        for (int sloupec = 0; sloupec < pocetSloupcu; sloupec++)
        {
            vid = -1;

            for (int i = 0; i < pocetRadku; i++)
            {
                if (Array[i, sloupec].height > vid) { vid = Array[i, sloupec].height; Array[i, sloupec].visible = true; }
            }
            vid = -1;
            for (int i = pocetRadku-1; i >= 0; i--)
            {
                if (Array[i, sloupec].height > vid) { vid = Array[i, sloupec].height; Array[i, sloupec].visible = true; }
            }
        }
        int sum = 0;
        foreach(tree t in Array) { if (t.visible) { sum++; } }
        Console.WriteLine(sum);
    }
}


