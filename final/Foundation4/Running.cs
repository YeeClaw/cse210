namespace Foundation4;

public class Running : Activity
{
    public Running(DateTime date, int duration, float distance) : base(date, duration)
    {
        Distance = distance;
        Speed = CalculateSpeed();
    }
}