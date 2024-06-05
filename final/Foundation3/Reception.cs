using Foundation2;

class Reception : Event
{
    public List<Person> RsvpList { get; set; }
    
    // Constructor without RSVP list
    public Reception(string title, string description, DateTime date, Address location) 
        : base(title, description, date, location)
    {
        RsvpList = new List<Person>();
    }
    
    // Constructor with RSVP list
    public Reception(string title, string description, DateTime date, Address location, List<Person> rsvpList) 
        : base(title, description, date, location)
    {
        RsvpList = rsvpList;
    }
    
    public string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nLocation: {Location.ToInlineString()}\nEvent: {this.GetType()}\nRSVP List: {string.Join(", ", RsvpList)}";
    }

    public void RegisterPerson(Person person)
    {
        RsvpList.Add(person);
    }
}