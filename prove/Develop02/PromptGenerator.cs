public class PromptGenerator
{
    public string _sourceFile;
    public string GeneratePrompt()
    {
        Random random = new Random();
        // gets the list of prompts
        string[] lines = File.ReadAllLines(_sourceFile);
        // gets the number of items in the list
        int listSize = lines.Length;
        // gets a random number that falls within the range of the list
        int index = random.Next(listSize);
        // returns the selected prompt
        return lines[index];
    }
}