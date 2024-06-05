using Foundation2;

class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Address Location { get; set; }

    public Event(string title, string description, DateTime date, Address location)
    {
        Title = title;
        Description = description;
        Date = date;
        Location = location;
    }

    public string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nLocation: {Location.ToInlineString()}";
    }
    
    public string GetShortDescription()
    {
        return $"{this.GetType()}\n{Title} - {Date.ToShortDateString()}";
    }
}