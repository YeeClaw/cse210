public class Circle : Shape
{
    public float Radius { get; set; }

    public Circle(float radius, string color) : base(color)
    {
        Radius = radius;
    }

    public override float GetArea()
    {
        return (float)(Math.PI * Math.Pow(Radius, 2));
    }
}