using System;
using System.Collections.Generic;

class Monkey 
{
    public int inspected = 0;
    List<int> items;
    public Monkey(List<int> items) { this.items = items; }
    public Func<int, int> operation;
    public Func<int, bool> test;

    public Monkey TrueThrow;
    public Monkey FalseThrow;

    public void Throw(Monkey Target,int item)
    {
        Target.items.Add(item);
        items.RemoveAt(0);
    }
    void TurnItem(int item) 
    {
        inspected++;
        item = operation(item);
        item = item / 3;
        if (test(item)) { Throw(TrueThrow,item); }
        else { Throw(FalseThrow,item); }
    }
    public void Turn() 
    {
        while(items.Count > 0) 
        {
            TurnItem(items[0]);
        }
    }

    public static int GetMonkeyBussines(List<Monkey> i) 
    {
        int max = 0; ;
        int secondMax = 0;

        foreach(Monkey m in i) 
        {
            if(m.inspected > secondMax) 
            {
                if(m.inspected > max) {secondMax = max ; max = m.inspected; }
                else { secondMax = m.inspected; }
            }
        }
        return max * secondMax;
    }

}
class main
{
    static void Main()
    {
        List<Monkey> Monkeys = MonkeyFactory();

        for (int i = 0; i < 20; i++)
        {
            foreach (Monkey m in Monkeys)
            {
                m.Turn();
            }
        }
        Console.WriteLine(Monkey.GetMonkeyBussines(Monkeys));

    }

    static List<Monkey> GetExampleMonkeys()
    {
        Monkey M0 = new(new List<int> { 79, 98 });
        M0.operation = old => old * 19;
        M0.test = old => old % 23 == 0;

        Monkey M1 = new(new List<int> { 54, 65, 75, 74 });
        M1.operation = old => old + 6;
        M1.test = old => old % 19 == 0;

        Monkey M2 = new(new List<int> { 79, 60, 97 });
        M2.operation = old => old * old;
        M2.test = old => old % 13 == 0;

        Monkey M3 = new(new List<int> { 74 });
        M3.operation = old => old + 3;
        M3.test = old => old % 17 == 0;

        M0.TrueThrow = M2;
        M0.FalseThrow = M3;

        M1.TrueThrow = M2;
        M1.FalseThrow = M0;

        M2.TrueThrow = M1;
        M2.FalseThrow = M3;
        
        M3.TrueThrow = M0;
        M3.FalseThrow = M1;

        return new List<Monkey> { M0, M1, M2, M3 };
    }
    static List<Monkey> MonkeyFactory()
    {
        Monkey M0 = new(new List<int> { 50, 70,54,83,52,78 });
        M0.operation = old => old * 3;
        M0.test = old => old % 11 == 0;

        Monkey M1 = new(new List<int> { 71, 52, 58, 60, 71 });
        M1.operation = old => old * old;
        M1.test = old => old % 7 == 0;

        Monkey M2 = new(new List<int> { 66, 56, 56, 94, 60, 86, 73 });
        M2.operation = old => old + 1;
        M2.test = old => old % 3 == 0;

        Monkey M3 = new(new List<int> { 83, 99 });
        M3.operation = old => old + 8;
        M3.test = old => old % 5 == 0;

        Monkey M4 = new(new List<int> { 98, 98, 79 });
        M4.operation = old => old + 3;
        M4.test = old => old % 17 == 0;

        Monkey M5 = new(new List<int> { 76 });
        M5.operation = old => old + 4;
        M5.test = old => old % 13 == 0;

        Monkey M6 = new(new List<int> { 52, 51, 84, 54 });
        M6.operation = old => old * 17;
        M6.test = old => old % 19 == 0;

        Monkey M7 = new(new List<int> { 82, 86, 91, 79, 94, 92, 59, 94 });
        M7.operation = old => old + 7;
        M7.test = old => old % 2 == 0;

        M0.TrueThrow = M2;
        M0.FalseThrow = M7;

        M1.TrueThrow = M0;
        M1.FalseThrow = M2;

        M2.TrueThrow = M7;
        M2.FalseThrow = M5;

        M3.TrueThrow = M6;
        M3.FalseThrow = M4;

        M4.TrueThrow = M1;
        M4.FalseThrow = M0;

        M5.TrueThrow = M6;
        M5.FalseThrow = M3;

        M6.TrueThrow = M4;
        M6.FalseThrow = M1;

        M7.TrueThrow = M5;
        M7.FalseThrow = M3;

        return new List<Monkey> { M0, M1, M2, M3, M4, M5, M6, M7 };
    }
}
