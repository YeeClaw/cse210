namespace Foundation4;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new()
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8f),
            new Cycling(new DateTime(2024, 04, 01), 20, 15),
            new Swimming(new DateTime(2024, 06, 04), 10, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}