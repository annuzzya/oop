using System;

interface IShape
{
    int GetArea();
}

class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

class Square : IShape
{
    public int Side { get; set; }

    public int GetArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IShape rect = new Rectangle { Width = 5, Height = 10 };
        Console.WriteLine(rect.GetArea());   // 50

        IShape sq = new Square { Side = 10 };
        Console.WriteLine(sq.GetArea());     // 100

        Console.ReadKey();
    }
}