public class Job
{
    // I think it's lame that we're making these fields public

    // This class is missing a constructor and private fields.
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}