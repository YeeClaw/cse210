public class Person
{
    public string UserName { get; set; }
    public string ProfileLink { get; set; }
    
    public Person(string userName, string profileLink)
    {
        UserName = userName;
        ProfileLink = profileLink;
    }
    
    public override string ToString()
    {
        return $"{UserName} ({ProfileLink})";
    }
}