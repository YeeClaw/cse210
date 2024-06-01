using System.Diagnostics.CodeAnalysis;

public class Video
{
    public string Title { get; set; }
    public Person Author { get; set; }
    public int Length { get; set; }
    public DateTime PublishedDate { get; set; }
    public List<Comment> Comments { get; set; }
    
    public Video(string title, Person author, int length, DateTime publishedDate)
    {
        Title = title;
        Author = author;
        Length = length;
        PublishedDate = publishedDate;

        Comments = new();
    }
    
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int CountComments()
    {
        return Comments.Count();
    }

    public override string ToString()
    {
        return $"{Title} - {Author.UserName} ({Length} seconds) ({PublishedDate.ToShortDateString()})";
    }
}