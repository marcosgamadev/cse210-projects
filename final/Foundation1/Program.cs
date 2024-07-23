using System;
using System.Collections.Generic;

// Comment class
class Comment
{
    private string Name { get; set; }
    private string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetText()
    {
        return Text;
    }
}

// Video class
class Video
{
    private string Title { get; set; }
    private string Author { get; set; }
    private int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public string GetTitle()
    {
        return Title;
    }

    public string GetAuthor()
    {
        return Author;
    }

    public int GetLengthInSeconds()
    {
        return LengthInSeconds;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}

class Program
{
    static void Main()
    {
        // Create video instances
        Video video1 = new Video("My First Time in USA", "Alice", 300);
        Video video2 = new Video("Blinded by the FAIL!", "Bob", 600);
        Video video3 = new Video("Oh Happy Day - Sister Act ", "Mundo do Sam", 1200);

        // Add comments to videos
        video1.AddComment(new Comment("Mark", "Great review!"));
        video1.AddComment(new Comment("John", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Antonio", "Nice video."));

        video2.AddComment(new Comment("Price", "I love this product!"));
        video2.AddComment(new Comment("Amanda", "Can't wait to try it."));

        video3.AddComment(new Comment("Britney", "Amazing!."));
        video3.AddComment(new Comment("Mey", "I learned a lot."));
        video3.AddComment(new Comment("Marcos", "Well explained!"));
        video3.AddComment(new Comment("Rafa", "Thanks for the tips."));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
