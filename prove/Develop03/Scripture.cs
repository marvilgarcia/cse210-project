using System.Text;
using System.Collections.Generic;

public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = CreateWordList(text);
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> wordsToHide = _words.Where(word => !word.IsHidden()).ToList();
        int wordsCount = wordsToHide.Count;
        
        if (numberToHide > wordsCount)
        {
            numberToHide = wordsCount;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(wordsCount);
            wordsToHide[index].Hide();
            wordsToHide.RemoveAt(index);
            wordsCount--;
        }
    }

    public string GetDisplayText()
    {
        StringBuilder displayText = new StringBuilder();
        displayText.Append($"{Reference.GetDisplayText()}: ");
        
        foreach (Word word in _words)
        {
            displayText.Append(word.GetDisplayText());
            displayText.Append(" ");
        }

        return displayText.ToString();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    private List<Word> CreateWordList(string text)
    {
        List<Word> wordList = new List<Word>();
        string[] wordArray = text.Split(' ');

        foreach (string wordText in wordArray)
        {
            wordList.Add(new Word(wordText));
        }

        return wordList;
    }
}
