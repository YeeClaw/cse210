public class Rectangle : Shape
{
    public float Length { get; set; }
    public float Width { get; set; }

    public Rectangle(float length, float width, string color) : base(color)
    {
        Length = length;
        Width = width;
    }

    public override float GetArea()
    {
        return Length * Width;
    }
}