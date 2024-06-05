using Foundation2;

class OutdoorGathering : Event
{
    public string CurrentWeather { get; set; }
    
    public OutdoorGathering(string title, string description, DateTime date, Address location, string currentWeather) 
        : base(title, description, date, location)
    {
        CurrentWeather = currentWeather;
    }
    
    public string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nLocation: {Location.ToInlineString()}\nEvent: {this.GetType()}\nExpected Weather: {CurrentWeather}";
    }
    
    // This is functionally the same as a setter ????
    public void UpdateWeather(string newWeather)
    {
        CurrentWeather = newWeather;
    }
}