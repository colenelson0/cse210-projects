class ReflectingActivity : Activity
{
    // Attributes
    private string _prompt;
    private List<string> _questions;
    private int _questionDuration;
    
    // Constructor
    public ReflectingActivity(string prompt, List<string> questions, int questionDuration)
    {
        SetActivityType(2);
        _prompt = prompt;
        _questions = questions;
        _questionDuration = questionDuration;
    }

    // Methods
    public void RunActivity()
    {
        Random rng = new Random();

        int duration = GetDuration(); // duration of activity
        int wholeReflections = duration / _questionDuration; // number of whole reflections possible in given time
        int partialReflection = duration % _questionDuration; // seconds left over for partial reflection

        // shuffle the follow up questions
        _questions = _questions.OrderBy(x => Random.Shared.Next()).ToList();

        InitialPrompt();
        Console.Clear();

        string question;
        if (partialReflection == 0) // the duration of the activity is divisible by the time of one breath
        {
            for (int i = 0; i < wholeReflections; i++) // the duration of the activity is divisible by the time of one reflection
            {
                question = _questions[i % _questions.Count];
                DisplayQuestion(question);
            }
        }
        else if (partialReflection > 8) // the duration of the activity leaves at least 9 extra seconds of reflecting
        {
            // use the extra seconds to add one extra reflection that is partial length
            for (int i = 0; i < (wholeReflections + 1); i++) // the duration of the activity is divisible by the time of one reflection
            {
                // the extra reflection should be the partial reflection
                if (i == wholeReflections)
                {
                    _questionDuration = partialReflection;
                }
                question = _questions[i % _questions.Count];
                DisplayQuestion(question);
            }
        }
        else // the duration of the activity leaves less than 9 extra seconds of reflecting
        {
            int extraSeconds = partialReflection / wholeReflections;
            int remainder = partialReflection % wholeReflections;
            // add extra seconds to each reflection
            _questionDuration += extraSeconds;

            for (int i = 0; i < wholeReflections; i++) // the duration of the activity is divisible by the time of one reflection
            {
                // the length of the final reflection should change if there are still remainding seconds
                if (i == wholeReflections - 1)
                {
                    _questionDuration += remainder;
                }
                question = _questions[i % _questions.Count];
                DisplayQuestion(question);
            }
        }

        Console.Write("\n");
    }
    public void InitialPrompt()
    {
        Console.Write("Consider the following prompt:\n\n");
        Console.Write($" --- {_prompt} ---\n\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }
    public void DisplayQuestion(string question)
    {
        Spinner reflectSpinner = new(_questionDuration);

        Console.Write($"> {question} ");
        reflectSpinner.Spin();
        Console.Write("\n");
    }
}