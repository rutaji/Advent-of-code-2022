using System.Globalization;

class CircularBuffer
{
    int[] Values;
    int read = 0;
    int write;
    int max;
    public CircularBuffer(int length) { this.max = length - 1; Values = new int[length]; write = length - 1; }


    public int Read()
    {
        int value = Values[read++];
        if (read > max) { read = 0; }
        return value;
    }
    public void Write(int value)
    {
        Values[write++] = value;
        if (write > max) { write = 0; }
    }
    public int[] GetValues()
    {
        return Values;
    }
}

class main
{
    static void Main()
    {
        int lenght = 4;
        CircularBuffer Buffer = new(lenght);
        StreamReader Reader = new(Path.Combine(Environment.CurrentDirectory, "Input.txt"));
        for(int i = 0; i < lenght-1; i++) 
        {
            Buffer.Write(Reader.Read());
        }
        int index = lenght;
        do
        {
            
            Buffer.Write(Reader.Read());
            if (AllDiferent(Buffer.GetValues())) { break; }
            index++;
        }while(!Reader.EndOfStream);
        Console.WriteLine(index);
           
        
    }
    static bool AllDiferent(int[] input) 
    {
        int first;
        for(int i = 0; i < input.Length ; i++)
        {
            first = input[i];
            for(int j = i+1; j < input.Length ; j++) 
            {
                if (input[j] == first) { return false; }
            }
        }
        return true;
    }
}
