public class Reference
{
    // Attributes
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructors
    public Reference()
    {
        _book = "";
        _chapter = -1;
        _verse = -1;
        _endVerse = -1;
    }
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1;
    }
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // Methods
    public string GetReference()
    {
        string referenceStr = $"{_book} {_chapter}:{_verse}";
        if (_endVerse != -1)
        {
            referenceStr += $"-{_endVerse}";
        }
        return referenceStr;
    }
    public void SetBook(string book)
    {
        _book = book;
    }
    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }
    public void SetVerse(int verse)
    {
        _verse = verse;
    }
    public void SetEndVerse(int endVerse)
    {
        _endVerse = endVerse;
    }
}