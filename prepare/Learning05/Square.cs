public class Square : Shape
{
    public float SideLength { get; set; }

    public Square(string color, float sideLength) : base(color)
    {
        SideLength = sideLength;
    }

    public override float GetArea()
    {
        return (float)Math.Pow(SideLength, 2f);
    }
}