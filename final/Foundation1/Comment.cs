public class Comment
{
    public string Content { get; set; }
    public Person Author { get; set; }
    
    public Comment(string content, Person author)
    {
        Content = content;
        Author = author;
    }

    public int CountKeywords(string keyword)
    {
        var words = Content.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var keywordCount = words.Count(word => string.Equals(word, keyword, StringComparison.OrdinalIgnoreCase));

        return keywordCount;
    }
    
    public override string ToString()
    {
        return $"{Author.UserName}: {Content}";
    }
}