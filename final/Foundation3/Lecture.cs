using Microsoft.VisualBasic;
using Foundation2;

class Lecture : Event
{
    public string Speaker { get; set; }
    public string MaxCapacity { get; set; }
    
    public Lecture(string title, string description, DateTime date, Address location, string speaker, string maxCapacity) 
        : base(title, description, date, location)
    {
        Speaker = speaker;
        MaxCapacity = maxCapacity;
    }

    public string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nLocation: {Location.ToInlineString()}\nEvent: {this.GetType()}\nSpeaker: {Speaker}\nMax Capacity: {MaxCapacity}";
    }
}