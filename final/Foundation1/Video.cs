using System;
using System.Collections.Generic;

class Video
{
    public string _title;
    public string _author;
    public int _length;
    private List<Comment> _comments; 

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public  string GetInfo()
    {
        return $"Title: {_title}\nAuthor: {_author}\nLength: {_length} seconds";
    }
}
