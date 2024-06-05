namespace Foundation4;

public class Activity
{
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public float Distance { get; set; } // in kilometers
    public float Speed { get; set; } // in kilometers per hour
    public float Pace => (float)Math.Round((60 / Speed) * 100) / 100; // in minutes per kilometer
    
    public Activity(DateTime date, int duration)
    {
        Date = date;
        Duration = duration;
    }
    
    public string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} ({this.GetType().Name}) ({Duration} min): Distance {Distance} km, Speed: {Speed} kph, Pace: {Pace} min/km";
    }

    public virtual float CalculateDistance()
    {
        return Speed * (Duration / 60f);
    }
    
    public virtual float CalculateSpeed()
    {
        return Distance / (Duration / 60f);
    }
}