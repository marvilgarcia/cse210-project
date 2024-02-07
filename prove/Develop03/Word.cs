public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Initialize as not hidden by default
    }

    public void Hide()
    {
        _isHidden = true; // Set the word as hidden
    }

    public void Show()
    {
        _isHidden = false; // Set the word as not hidden
    }

    public bool IsHidden()
    {
        return _isHidden; // Return the hidden status of the word
    }

    public string GetDisplayText()
    {
        return _isHidden ? "____" : _text; // Return the word text or placeholder if hidden
    }
}
