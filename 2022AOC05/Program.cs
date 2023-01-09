using System.Collections.Generic;
using System.Text.RegularExpressions;

class main 
{
    public static void Main(String[] args) 
    {
        Crane crane = new();
        foreach (string Line in File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input.txt"))) 
        {
            if (Line == null || Line == "")
            { continue; }
            //input
            if (Line[0] == '[')
            {
                for (int i = 0; i * 4 + 1 < Line.Length; i++)
                {
                    if (Line[1 + i * 4] != ' ')
                    {
                        crane.Addbot(Line[1 + i * 4], i + 1);
                    }
                }
            }

            //moving crane
            if (Line[0] == 'm') 
            {
                crane.Move9001( Regex.Matches(Line, "[0-9]+"));
            }
        }
        crane.GetFirst(10);
    }
}
class Crane
{
    Dictionary<int,LinkedList> dictionary = new();

    public void GetFirst(int max) 
    {
        for(int i = 0; i <= max; i++) 
        {
            if (dictionary.ContainsKey(i)) {Console.Write(dictionary[i].GetFirst()); }
        }
    }
    public void Addbot(char c,int i) 
    {
        if(!dictionary.ContainsKey(i)) { dictionary.Add(i, new LinkedList()); }
        dictionary[i].addBot(new Node(c));
    }
    public void Move(MatchCollection m)
    {
        for(int i = 0; i< int.Parse(m[0].Value); i++) 
        {
            char? cache = dictionary[int.Parse(m[1].Value)].Pop();
            dictionary[int.Parse(m[2].Value)].addTop(new Node(cache.Value));
        }
    }
    public void Move9001(MatchCollection m) 
    {
        for (int i = int.Parse(m[0].Value); i > 0 ; i--)
        {
            char? cache = dictionary[int.Parse(m[1].Value)].Pop(i-1);
            dictionary[int.Parse(m[2].Value)].addTop(new Node(cache.Value));
        }
    }
}
class Node
{
    public char GetValue() { return Value; }
    char Value;
    public Node? next;

    public Node(char Value)
    {
        this.Value = Value;
    }
}
class LinkedList
{
    public char? GetFirst() { return first?.GetValue(); }
    Node? first;
    Node? last;
    public char? Pop(int index) 
    {
        if(index == 0) { return Pop(); }
        Node node= first;
        for(int i = 0;i < index - 1; i++) 
        { node = node.next; }
        char? value = node.next.GetValue();
        node.next = node.next.next;
        return value;
    }
    public char? Pop()
    {
        if (first == null) { return null; }
        char result = first.GetValue();
        if (first.next == null) { last = null; }
        first = first.next;
        return result;
    }
    public void addTop(Node n) //lifo
    {
        if (first == null)
        {
            first = n;
            last = n;
            return;
        }
        Node cache = first;
        first = n;
        n.next = cache;
    }
    public void addBot(Node n)//fifo
    {
        if (last == null)
        {
            first = n;
            last = n;
            return;
        }
        last.next = n;
        last = last.next;
    }



}
