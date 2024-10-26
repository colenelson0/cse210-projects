public class Word
{
    // Attributes
    private string _text;
    private bool _isHidden;

    // Constructors
    public Word()
    {
        _text = "";
        _isHidden = false;
    }
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Methods
    public string GetText()
    {
        return _text;
    }
    public bool GetIsHidden()
    {
        return _isHidden;
    }
    public void SetText(string text)
    {
        _text = text;
    }
    public void HideWord()
    {
        string newText = "";
        int wordLength = _text.Length;
        for (int i = 0; i < wordLength; i++)
        {
            if (_text[i] == ',' ||
            _text[i] == ':' ||
            _text[i] == ';' ||
            _text[i] == '.')
            {
                newText += _text[i];
            }
            else
            {
                newText += '_';
            }
        }
        _text = newText;
        _isHidden = true;
    }
}