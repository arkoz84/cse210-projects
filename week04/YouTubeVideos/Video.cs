using System;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private  List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = length;
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetDisplayText()
    {
        return $"{_title} by {_author} ({_lengthInSeconds} seconds)";
    }
    public void DisplayComments()
    {   
        foreach (Comment comment in _comments)
        {
            System.Console.WriteLine($"  {comment.GetDisplayText()}");
        }
    }
}

