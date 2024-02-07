public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse; // Set endVerse to verse by default for single verse references
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string reference)
    {
        string[] parts = reference.Split(':', '-', ' ');
        _book = parts[0];
        _chapter = int.Parse(parts[1]);
        _verse = int.Parse(parts[2]);
        
        if (parts.Length == 4) // If end verse is provided
        {
            _endVerse = int.Parse(parts[3]);
        }
        else
        {
            _endVerse = _verse; // Set endVerse to verse by default for single verse references
        }
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}
