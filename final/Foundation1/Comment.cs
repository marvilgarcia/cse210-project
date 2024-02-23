class Comment
{
    public string _commenterName; 
    public string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public  string GetInfo()
    {   
        return $"Commenter: {_commenterName}, Text: {_text}";
    }
}
