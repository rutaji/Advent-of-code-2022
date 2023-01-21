using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

class Folder
{
    public Dictionary<string,Folder> Folders= new();
    public int sizeOfFiles = 0;
    public Folder parent;
    private int WholeSize = 0;
    public Folder(Folder p)
    {
        parent = p;
    }
    public int GetwholeSize() 
    {
        if(WholeSize != 0) { return WholeSize; }
        foreach(Folder p in Folders.Values) 
        {
           WholeSize += p.GetwholeSize();
        }
        WholeSize += sizeOfFiles;
        return WholeSize;
    }
    
}
class main 
{


    static Folder root = new Folder(null);
    static Folder curent = root;

   static int state = 1;
    static public void cd(string name) 
    {
        if(name == "..") { curent = curent.parent; return; }
        if(name == "/") { curent = root;return; }
        if (!curent.Folders.ContainsKey(name)) { curent.Folders.Add(name, new Folder(curent)); }
        curent = curent.Folders[name];
    }
    static public void ls() 
    {
        curent.sizeOfFiles= 0;
        state = 0;
    }
    static public void Main() 
    {
       
        foreach(string input in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"))) 
        {
           string[] Inputs = input.Split(' ');
            
            
            if (state == 0)
            {
                if (Inputs[0] == "$") { state = 1; }
                else if(Inputs[0] != "dir"){ curent.sizeOfFiles += int.Parse(Inputs[0]); }
                else if (!curent.Folders.ContainsKey(Inputs[1])){ curent.Folders.Add(Inputs[1], new Folder(curent)); }
            }

            if(state == 1)
            { 
                 if (Inputs[1] == "cd") { cd(Inputs[2]); }
                 else if (Inputs[1] == "ls") { ls(); }

            }
        }
        root.GetwholeSize();
        List<Folder> cool = GetAll(root, x => x.GetwholeSize() >= 30000000 - (70000000 - root.GetwholeSize()));
        cool.Sort((a,b) => a.GetwholeSize().CompareTo(b.GetwholeSize()));

        Console.WriteLine(cool[0].GetwholeSize());

    }
    
    static List<Folder> GetAll(Folder start,Func<Folder,bool> filtr) 
    {
        List<Folder> list = new List<Folder>();
        if (filtr(start)) { list.Add(start); }
        foreach(Folder f in start.Folders.Values) 
        {
            foreach(Folder done in GetAll(f, filtr)) 
            {
                list.Add(done);
            } 
        }
        return list;
    }

}
