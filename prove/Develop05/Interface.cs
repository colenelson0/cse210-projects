class Interface
{
    // Attributes
    private List<Goal> _goals;
    private List<Reward> _rewards;
    private int _totalPoints;

    // Constructor
    public Interface()
    {
        _goals = new();
        _rewards = new();
        _totalPoints = 0;
    }

    // Methods
    public void DisplayMenu()
    {
        int selection;

        do
        {
            Console.Write($"You have {_totalPoints} points.\n\n");
            Console.Write("Menu Options:\n  ");
            Console.Write("1. Create New Goal\n  ");
            Console.Write("2. Create New Reward\n  ");
            Console.Write("3. List Goals and Rewards\n  ");
            Console.Write("4. Save Goals and Rewards\n  ");
            Console.Write("5. Load Goals and Rewards\n  ");
            Console.Write("6. Record Event\n  ");
            Console.Write("7. Quit\nSelect a choice from the menu: ");
            selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                CreateNewGoal();
            }
            else if (selection == 2)
            {
                CreateNewReward();

                CheckRewards();
            }
            else if (selection == 3)
            {
                ListGoals();
            }
            else if (selection == 4)
            {
                SaveGoals();
            }
            else if (selection == 5)
            {
                LoadGoals();
            }
            else if (selection == 6)
            {
                RecordEvent();

                CheckRewards();
            }
        } while (selection != 7);
    }
    public void CreateNewGoal()
    {
        Console.Write("The types of Goals are:\n  ");
        Console.Write("1. Simple Goal\n  ");
        Console.Write("2. Eternal Goal\n  ");
        Console.Write("3. Checklist Goal\nWhich type of Goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine());

        if (goalType == 1)
        {
            SimpleGoal newGoal = new();
            Console.Write("What is the name of your goal? ");
            newGoal.SetName(Console.ReadLine());
            Console.Write("What is a short description of it? ");
            newGoal.SetDescription(Console.ReadLine());
            Console.Write("What is the amount of points associated with this goal? ");
            newGoal.SetPoints(int.Parse(Console.ReadLine()));
            Console.Write("\n");

            _goals.Add(newGoal);
        }
        else if (goalType == 2)
        {
            EternalGoal newGoal = new();
            Console.Write("What is the name of your goal? ");
            newGoal.SetName(Console.ReadLine());
            Console.Write("What is a short description of it? ");
            newGoal.SetDescription(Console.ReadLine());
            Console.Write("What is the amount of points associated with this goal? ");
            newGoal.SetPoints(int.Parse(Console.ReadLine()));
            Console.Write("\n");

            _goals.Add(newGoal);
        }
        else
        {
            ChecklistGoal newGoal = new();
            Console.Write("What is the name of your goal? ");
            newGoal.SetName(Console.ReadLine());
            Console.Write("What is a short description of it? ");
            newGoal.SetDescription(Console.ReadLine());
            Console.Write("What is the amount of points associated with this goal? ");
            newGoal.SetPoints(int.Parse(Console.ReadLine()));
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            newGoal.SetTimesNeeded(int.Parse(Console.ReadLine()));
            Console.Write("What is the bonus for accomplishing it that many times? ");
            newGoal.SetBonus(int.Parse(Console.ReadLine()));
            Console.Write("\n");

            _goals.Add(newGoal);
        }
    }
    public void CreateNewReward()
    {
        Reward newReward = new();
        Console.Write("What is the name of this reward? ");
        newReward.SetName(Console.ReadLine());
        Console.Write("What is a short description of it? ");
        newReward.SetDescription(Console.ReadLine());
        Console.Write("What is the amount of points needed to earn it? ");
        newReward.SetRequiredPoints(int.Parse(Console.ReadLine()));
        Console.Write("\n");

        _rewards.Add(newReward);
    }
    public void ListGoals()
    {
        int goalCount = _goals.Count;
        string goalString;
        int rewardCount = _rewards.Count;
        string rewardString;

        if (goalCount > 0)
        {
            Console.WriteLine("The Goals are:");
        }
        else
        {
            Console.WriteLine("No Goals in list.");
        }
        for (int i = 0; i < goalCount; i++)
        {
            goalString = _goals[i].GetTextForUser();
            Console.WriteLine($"{i+1}. {goalString}");
        }

        if (rewardCount > 0)
        {
            Console.Write("\n");
            Console.WriteLine("The Rewards are:");
        }
        else
        {
            Console.WriteLine("No Rewards in list.");
        }
        for (int j = 0; j < rewardCount; j++)
        {
            rewardString = _rewards[j].GetTextForUser();
            Console.WriteLine($"{j+1}. {rewardString}");
        }
        Console.Write("\n");
    }
    public void SaveGoals()
    {
        int goalCount = _goals.Count;
        int rewardCount = _rewards.Count;

        Console.Write("What is the filename for the Goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outFile = new StreamWriter(filename))
        {
            outFile.WriteLine(_totalPoints);
            for (int i = 0; i < goalCount; i++)
            {
                outFile.WriteLine(_goals[i].GetTextForFile());
            }
            for (int j = 0; j < rewardCount; j++)
            {
                outFile.WriteLine(_rewards[j].GetTextForFile());
            }
        }
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the Goal file? ");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);

        int lineCount = lines.Length;
        _totalPoints = int.Parse(lines[0]);

        _goals = new();
        _rewards = new();
        for (int i = 1; i < lineCount; i++)
        {
            string[] parts = lines[i].Split(":");
            string objectType = parts[0];
            string objectInfo = parts[1];
            parts = objectInfo.Split(",");

            if (objectType == "SimpleGoal")
            {
                SimpleGoal goal = new();
                goal.SetName(parts[0]);
                goal.SetDescription(parts[1]);
                goal.SetPoints(int.Parse(parts[2]));
                goal.SetComplete(bool.Parse(parts[3]));

                _goals.Add(goal);
            }
            else if (objectType == "EternalGoal")
            {
                EternalGoal goal = new();
                goal.SetName(parts[0]);
                goal.SetDescription(parts[1]);
                goal.SetPoints(int.Parse(parts[2]));

                _goals.Add(goal);
            }
            else if (objectType == "ChecklistGoal")
            {
                ChecklistGoal goal = new();
                goal.SetName(parts[0]);
                goal.SetDescription(parts[1]);
                goal.SetPoints(int.Parse(parts[2]));
                goal.SetBonus(int.Parse(parts[3]));
                goal.SetTimesNeeded(int.Parse(parts[4]));
                goal.SetTimes(int.Parse(parts[5]));

                _goals.Add(goal);
            }
            else
            {
                Reward reward = new();
                reward.SetName(parts[0]);
                reward.SetDescription(parts[1]);
                reward.SetRequiredPoints(int.Parse(parts[2]));
                reward.SetRewardEarned(bool.Parse(parts[3]));

                _rewards.Add(reward);
            }
        }
    }
    public void RecordEvent()
    {
        int goalCount = _goals.Count;
        bool allComplete = true;
        for (int i = 0; i < goalCount; i++)
        {
            if (!_goals[i].IsComplete() && allComplete)
            {
                allComplete = false;
            }
        }

        if (allComplete)
        {
            Console.Write($"All of the goals are complete. Try adding a new one!\n\n");
        }
        else
        {
            string goalName;

            Console.WriteLine("The Goals are:");

            for (int i = 0; i < goalCount; i++)
            {
                goalName = _goals[i].GetName();
                Console.WriteLine($"{i+1}. {goalName}");
            }
            Console.Write("Which goal did you accomplish? ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;
            while (_goals[goalIndex].IsComplete())
            {
                Console.WriteLine("This goal has already been completed, please select a different goal.");

                Console.Write("Which goal did you accomplish? ");
                goalIndex = int.Parse(Console.ReadLine()) - 1;
            }

            int earnedPoints = _goals[goalIndex].RecordEvent();
            Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");

            _totalPoints += earnedPoints;
            Console.Write($"You now have {_totalPoints} points.\n\n");
        }
    }
    private void CheckRewards()
    {
        int rewardCount = _rewards.Count;
        for (int j = 0; j < rewardCount; j++)
        {
            int requiredPoints = _rewards[j].GetRequiredPoints();
            bool earned = _rewards[j].GetRewardEarned();
            if (_totalPoints >= requiredPoints && !earned)
            {
                _rewards[j].EarnReward();
            }
        }
    }
}