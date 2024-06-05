namespace Foundation4;

public class Swimming : Activity
{
public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        Distance = (float)laps * 50 / 1000;
        Speed = Distance / (duration / 60f);
    }
}