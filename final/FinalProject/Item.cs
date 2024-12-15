abstract class Item
{
    // Attributes
    private string _category;
    private string _phase;
    private int _price;

    // Constructors
    public Item()
    {
        _phase = "empty"; // Item needs to be composed

    }

    // Methods
    public abstract string GetStringForMenu();
    public string GetCategory()
    {
        return _category;
    }
    public string GetPhase()
    {
        return _phase;
    }
    public int GetPrice()
    {
        return _price;
    }
    public void SetCategory(string category)
    {
        // not to be used outside child class constructors
        _category = category;
    }
    public void SetPhase(string phase)
    {
        // used in game when actions are taken
        _phase = phase;
    }
    public void SetPrice(int price)
    {
        _price = price;
    }
    public abstract void CalculatePrice();
    public abstract void Compose();
    public string CapitalizeWord(string word)
    {
        // Convert the word into a character array
        char[] charArr = word.ToCharArray();
        // Get the capitalized version of the first letter of the word
        char upper = word.ToUpper()[0];
        // Change the first letter in the character array to the capital
        charArr[0] = upper;
        // Create a new string from the character array
        string newWord = new(charArr);

        return newWord;
    }
}