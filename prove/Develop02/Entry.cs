public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
       Console.WriteLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")} - {_promptText}\n-{_entryText}");
    }
}