public class Journal
{
    public List<Entry> _entries = new();
    public string _author;

    public void AddEntry()
    {
        Entry newEntry = new();
        PromptGenerator promptGenerator = new();

        newEntry.GetDate();

        promptGenerator._sourceFile = "prompts.txt";
        newEntry._prompt = promptGenerator.GeneratePrompt();
        Console.WriteLine(newEntry._prompt);

        Console.Write("> ");
        newEntry._response = Console.ReadLine();

        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        Console.Write($"Author: {_author}\n\n");
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void LoadFile()
    {
        string fileName;

        Console.WriteLine("What is the file name?");
        fileName = Console.ReadLine();

        string[] fileLines = System.IO.File.ReadAllLines(fileName);
        int entryRange = (fileLines.Length - 1) / 3; // the number of entries based on the number of lines in the file

        _entries = new();

        for (int i = 0; i < entryRange; i++)
        {
            Entry newEntry = new();
            int lineIndex = i * 3;
            
            newEntry._date = fileLines[lineIndex];
            newEntry._prompt = fileLines[lineIndex + 1];
            newEntry._response = fileLines[lineIndex + 2];

            _entries.Add(newEntry);
        }

        _author = fileLines[fileLines.Length - 1];
    }

    public void SaveToFile()
    {
        string fileName;

        Console.WriteLine("Who is the author of this journal?");
        _author = Console.ReadLine();

        Console.WriteLine("What is the file name?");
        fileName = Console.ReadLine();

        using (StreamWriter file = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                file.WriteLine(entry._date);
                file.WriteLine(entry._prompt);
                file.WriteLine(entry._response);
            }

            file.WriteLine(_author);
        }
    }
}