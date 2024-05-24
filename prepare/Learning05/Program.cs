class Program
{
    static void Main(string[] args)
    {
        var circle = new Circle(5f, "green");
        var square = new Square("red", 2.5f);
        var rect = new Rectangle(3f, 7f, "blue");

        List<Shape> shapes = new List<Shape>() { circle, square, rect };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType()}: {shape.Color}, {shape.GetArea()}");
        }
    }
}