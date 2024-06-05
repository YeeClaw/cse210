namespace Foundation4;

public class Swimming : Activity
{
    public int Laps { get; set; }
public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        Laps = laps;
        Distance = CalculateDistance();
        Speed = Distance / (duration / 60f);
    }

    public override float CalculateDistance()
    {
        return (float)Laps * 50 / 1000;
    }
}