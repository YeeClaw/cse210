using System;

class Program
{
    static void Main(string[] args)
    {
        var byui = new Person("BYUI", "https://www.youtube.com/BYUI"); // Did you know that BYUI has a YouTube channel?
        var john = new Person("JohnDoe", "https://www.youtube.com/JohnDoe");
        var jane = new Person("JaneDoe", "https://www.youtube.com/JaneDoe");
        var yeeclaw = new Person("YeeClaw", "https://www.youtube.com/YeeClaw");
        var emeraldSlime = new Person("TheEmeraldSlime", "https://www.youtube.com/TheEmeraldSlime");

        var interchanges = new Video(
            "Navigating Divergent Diamond Interchanges",
            byui,
            101,
            new DateTime(2024, 5, 31)
        );
        var byuiDegree = new Video(
            "What is a BYU-Idaho Degree Worth?",
            byui,
            31,
            new DateTime(2024, 5, 30)
        );
        var studentLife = new Video(
            "BYU Idaho Student Life Activities",
            byui,
            35,
            new DateTime(2024, 5, 22)
        );
        
        var comment1 = new Comment("I love this video!", john);
        var comment2 = new Comment("This is so helpful!", jane);
        var comment3 = new Comment("I'm so glad I found this channel!", yeeclaw);
        var comment4 = new Comment("This city is getting too big!!", emeraldSlime);
        
        interchanges.AddComment(comment1);
        interchanges.AddComment(comment3);
        interchanges.AddComment(comment4);
        
        byuiDegree.AddComment(comment2);
        byuiDegree.AddComment(comment3);
        byuiDegree.AddComment(comment1);
        
        studentLife.AddComment(comment4);
        studentLife.AddComment(comment2);
        studentLife.AddComment(comment1);
        studentLife.AddComment(comment3);
        
        var videos = new[] {interchanges, byuiDegree, studentLife};
        
        foreach (var video in videos)
        {
            Console.WriteLine($"{video.ToString()} - {video.CountComments()} comments");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine(comment.ToString());
            }
            Console.WriteLine(
                $"Keyword 'this' appears {video.Comments.Sum(comment => comment.CountKeywords("this"))} times in the comments\n");
        }
    }
}