namespace Foundation4;

public class Cycling : Activity
{
    public Cycling(DateTime date, int duration, float speed)
        : base(date, duration)
    {
        Speed = speed;
        Distance = CalculateDistance();
    }
}