using System;

class Program
{
    static void Main(string[] args)
    {
        int menuInput;
        int timeSpent = 0;
        bool newInterval = false;
        do
        {
            int newTimeSpent;

            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            menuInput = int.Parse(Console.ReadLine());
            if (menuInput == 1)
            {
                int breatheIn = 4;
                int breatheOut = 6;

                BreathingActivity activity = new(breatheIn,breatheOut);
                activity.DisplayWelcome();
                activity.DisplayGetReady();
                activity.RunActivity();
                activity.DisplayWellDone();

                // add the new time and determine if its passed the interval
                newTimeSpent = activity.GetDuration();
                newInterval = (timeSpent + newTimeSpent) / 60 > timeSpent / 60;
                timeSpent += newTimeSpent;
            }
            else if (menuInput == 2)
            {
                string prompt = "Think of a time when you did something really difficult.";
                List<string> questions = new();
                questions.Add("How did you feel when it was complete?");
                questions.Add("What is your favorite thing about this experience?");
                questions.Add("What did you learn as a result of this experience?");
                questions.Add("What helped you overcome this challenge?");
                questions.Add("What advice would you give to someone who was facing a similar challenge?");
                int reflectionDuration = 15;

                ReflectingActivity activity = new(prompt,questions,reflectionDuration);
                activity.DisplayWelcome();
                activity.DisplayGetReady();
                activity.RunActivity();
                activity.DisplayWellDone();

                // add the new time and determine if its passed the interval
                newTimeSpent = activity.GetDuration();
                newInterval = (timeSpent + newTimeSpent) / 60 > timeSpent / 60;
                timeSpent += newTimeSpent;
            }
            else if (menuInput == 3)
            {
                List<string> prompts = new();
                prompts.Add("When have you felt the Holy Ghost this month?");
                prompts.Add("When have you recently shown kindness to others?");

                ListingActivity activity = new(prompts);
                activity.DisplayWelcome();
                activity.DisplayGetReady();
                activity.RunActivity();
                activity.DisplayWellDone();

                // add the new time and determine if its passed the interval
                newTimeSpent = activity.GetDuration();
                newInterval = (timeSpent + newTimeSpent) / 60 > timeSpent / 60;
                timeSpent += newTimeSpent;
            }
            // Exceeding requirements: I added congratulations for each time the user adds at least 60 seconds of new activity
            if (newInterval)
            {
                Spinner congratsSpinner = new(5);
                int milestone = timeSpent - (timeSpent % 60);
                Console.Write($"\nYou just passed {milestone} seconds of mindfulness activities! Way to go!!\n");
                congratsSpinner.Spin();
                newInterval = false;
            }
        } while (menuInput != 4);
    }
}