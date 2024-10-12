public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public void GetDate()
    {
        DateTime time = DateTime.Now;
        _date = time.ToShortDateString();
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.Write($"{_response}\n\n");
    }
}