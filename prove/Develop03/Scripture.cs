public class Scripture
{
    // Attributes
    private Reference _reference;
    private List<Word> _words;

    // Constructors
    public Scripture()
    {
        _reference = new();
        _words = new();
    }
    public Scripture(Reference reference, string words)
    {
        _reference = reference;
        _words = new();
        string[] wordList = words.Split(" ");
        foreach (string word in wordList)
        {
            Word newWord = new(word);
            _words.Add(newWord);
        }
    }
    
    // Methods
    public string GetReference()
    {
        return _reference.GetReference();
    }
    public string GetWords()
    {
        string scriptureStr = "";
        foreach (Word word in _words)
        {
            scriptureStr += $"{word.GetText()} ";
        }
        return scriptureStr;
    }
    public void SetReference(Reference reference)
    {
        _reference = reference;
    }
    public void SetWords(string words)
    {
        string[] wordList = words.Split(" ");
        foreach (string word in wordList)
        {
            Word newWord = new(word);
            _words.Add(newWord);
        }
    }
    public bool HideWords()
    {
        Random rng = new Random();

        List<int> visibleWords = new();
        bool allWordsHidden = false;
        foreach (Word word in _words)
        {
            bool isHidden = word.GetIsHidden();
            if (!isHidden)
            {
                visibleWords.Add(_words.IndexOf(word));
            }
        }
        visibleWords = visibleWords.OrderBy(x => Random.Shared.Next()).ToList();
        if (visibleWords.Count > 3)
        {
            for (int i = 0; i < 3; i++)
            {
                _words[visibleWords[i]].HideWord();
            }
        }
        else
        {
            foreach (Word word in _words)
            {
                word.HideWord();
            }
            allWordsHidden = true;
        }
        return allWordsHidden;
    }
}