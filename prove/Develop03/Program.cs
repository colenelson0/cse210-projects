using System;

class Program
{
    static void Main(string[] args)
    {
        // 1 Nephi 3:7
        Reference reference = new("1 Nephi", 3, 7);
        string scrWords = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        Scripture scripture = new();
        scripture.SetReference(reference);
        scripture.SetWords(scrWords);

        bool outOfWords = false;
        string printStr;
        while (!outOfWords)
        {
            Console.Clear();
            printStr = $"{scripture.GetReference()} {scripture.GetWords()}\n\n";
            Console.Write(printStr);
            Console.Write("Press enter to continue or type \"quit\" to finish:\n");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                outOfWords = true;
            }
            else
            {
                outOfWords = scripture.HideWords();
                if (outOfWords)
                {
                    Console.Clear();
                    printStr = $"{scripture.GetReference()} {scripture.GetWords()}\n\n";
                    Console.Write(printStr);
                    Console.Write("Press enter to continue or type \"quit\" to finish:\n");
                }
            }
        }
    }
}