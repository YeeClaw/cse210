public class Resume
{
    // This class is also missing a constructor and private fields.
    public string _name;
    public List<Job> _jobs;

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}