using System.Security.Authentication.ExtendedProtection;

class Game
{
    // Attributes
    private Player _you;
    private Options _options;
    private int _gameDays;
    private int _day;
    private bool _failure;
    private int _gameDuration;
    private int _waitTime;
    private int _lastCallTime;
    private int _gameTime;
    private bool _stop;
    private List<Order> _orders;

    // Constructors
    public Game(int playerLives, int gameDays, int dayStart)
    {
        _you = new(playerLives);
        _options = new();
        _gameDays = gameDays;
        _day = dayStart;
        _failure = false;
    }

    // Methods
    public void SetGameDuration(int gameDuration, int waitTime, int lastCallTime)
    {
        _gameDuration = gameDuration;
        _waitTime = waitTime;
        _lastCallTime = lastCallTime;
    }
    private void SetOptions()
    {
        // This method will refer to different text files to add the options for each available item to the _options attribute.

        // Get data from text files
        string customerFile = "customers.txt";
        if (File.Exists(customerFile)) { 
            string[] strings = File.ReadAllLines(customerFile);

            foreach (string str in strings)
            {
                _options.AddCustomer(str);
            }
        }
        string pizzaToppingFile = "pizza_toppings.txt";
        if (File.Exists(pizzaToppingFile)) { 
            string[] strings = File.ReadAllLines(pizzaToppingFile);

            foreach (string str in strings)
            {
                _options.AddPizzaTopping(str);
            }
        }
        string pizzaTypeFile = "pizza_types.txt";
        if (File.Exists(pizzaTypeFile)) { 
            string[] strings = File.ReadAllLines(pizzaTypeFile);

            PizzaType newPizza;
            foreach (string str in strings)
            {
                // split the type from its toppings (num str)
                string[] contents = str.Split(';');
                // set the pizza's type
                newPizza = new(contents[0]);
                // split the toppings into an array (num str)
                string[] toppings = contents[1].Split(',');
                for (int p = 0; p < toppings.Count(); p++)
                {
                    if (toppings[p] != "")
                    {
                        // get the topping from the list (num int)
                        int topInd = int.Parse(toppings[p]);
                        // add the topping to the pizza type (topping)
                        newPizza.AddTopping(_options.GetToppingAtIndex(topInd));
                    }
                }
                _options.AddPizzaType(newPizza);
            }
        }
        string sideFile = "sides.txt";
        if (File.Exists(sideFile)) { 
            string[] strings = File.ReadAllLines(sideFile);
            string[] breadList = strings[0].Split(',');
            foreach (string breadSeasoning in breadList)
            {
                _options.AddBreadSeasoning(breadSeasoning);
            }
            string[] wingsList = strings[1].Split(',');
            foreach (string wingSauce in wingsList)
            {
                _options.AddWingSauce(wingSauce);
            }
            string[] sodaList = strings[2].Split(',');
            foreach (string sodaBase in sodaList)
            {
                _options.AddSodaBase(sodaBase);
            }
            string[] flavorList = strings[3].Split(',');
            foreach (string sodaFlavor in flavorList)
            {
                _options.AddSodaFlavor(sodaFlavor);
            }
        }
    }
    public void RunGame()
    {
        const string placeName = "Oswald's Pizza Factory";
        // initialize the options - the container for all the menu contents
        SetOptions();

        // Introduce the game
        Console.Clear();
        Console.Write("Hello! You must be our new employee, uh... what was your name again? ");
        string yourName = Reader.ReadLine();
        Console.Write($"\nAh yes, of course! Welcome to {placeName}, {yourName}!\n");
        Console.Write("You're here right on schedule, but before I put you to work, I want to remind you about what we do here.\n\n(Press enter to continue)");
        string enter = Reader.ReadLine();
        Console.Clear();
        Console.Write($"[1/3]\n\nAt {placeName}, we offer our customers four different kinds of items: pizza, bread, wings, and soda.\n\n");
        Console.WriteLine("For the pizza, we have several different combinations for them to choose from. You won't need to worry about the names of these since you'll only be seeing the toppings they come with.");
        Console.WriteLine("For the bread, we offer quantities of 6 and 12 as well as some different seasoning options.");
        Console.WriteLine("For the wings, we offer quantities of 8 and 16 and a variety of different sauces.");
        Console.Write("For the sodas, we carry a number of popular brands but we also offer customers different flavored syrups to add in case they want to mix things up.\n\n(Press enter to continue)");
        enter = Reader.ReadLine();
        Console.Clear();
        Console.Write("[2/3]\n\nAs time goes by, you will see more orders appear on your screen.\n");
        Console.Write("Once an order becomes available you will only have a certain amount of time to submit it.\n\n");
        Console.WriteLine($"Our policy at {placeName} is simple: three strikes and you're out.");
        Console.WriteLine("For example, if you fail to submit an order correctly in the given time, that's a strike.");
        Console.Write("However, if you submit an order, but there's something only slightly wrong with it, you will be given another chance to try again. In any other case, incorrect order submissions will be penalized.\n\n(Press enter to continue)");
        enter = Reader.ReadLine();
        Console.Clear();
        int dayCount = _gameDays - _day + 1;
        Console.Write($"[3/3]\n\nOne more thing, {yourName}! Since I know you're just visiting, I only scheduled you to work for the next {dayCount} days. :)\n\n");
        Console.Write($"That's it for now! Good luck with the orders and have a pizza-rific time!\n\n(Press enter to begin)");
        enter = Reader.ReadLine();

        //
        while (_day - 1 < _gameDays && !_failure)
        {
            Console.Clear();
            Console.Write($"- Day {_day} -\n{yourName} x {_you.GetLives()}\n\n");
            Console.WriteLine("[ C - compose new item and add to deck ]");
            Console.WriteLine("[ B -     bake uncooked item from deck ]");
            Console.WriteLine("[ D -  dispose unwanted item from deck ]");
            Console.Write("[ S -           submit items from deck ]\n\n");
            Console.Write("Pro tip: Work on one order at a time to ensure that correct items from other orders don't get erased\n\nStarting in ");
            for (int d = 9; d > 0; d--)
            {
                Console.Write(d);
                Thread.Sleep(1000);
                Console.Write("\b");
            }
            Console.Clear();

            GameDay();
            _day++;
        }
        // Final results of game
        Console.Clear();
        DisplayGameEnd(yourName);
    }
    private void GameDay()
    {
        // This method will run one game day.
        _stop = false;
        _gameTime = 0;                          // Initial ingame time
        int dayEarnings = 0;                    // Initial earnings
        int dayOrdersDone = 0;                  // Initial number of orders done

        _orders = SetOrders();                  // The orders for the day
        List<Item> deck = new();                // Initial items being worked on.

        // sort the orders by start time
        int i;
        for (i = 0; i < _gameDuration; i++)
        {
            bool found = false;
            int j = 0;
            // search the orders for the value i
            while (j < _orders.Count && !found)
            {
                Order checkOrder = _orders[j];
                int timeStart = checkOrder.GetTimeStart();
                if (timeStart == i)
                {
                    // if it matches the value, move it to the end of the list
                    found = true;
                    _orders.Remove(checkOrder);
                    _orders.Add(checkOrder);
                }
                j++;
            }
        }

        Thread timer = new Thread(StartDayTimer);
        timer.Start();

        // Action code
        char act;
        do
        {
            // activate hidden orders
            List<Order> displayOrders = new();
            i = _orders.Count;
            while (i > 0)
            {
                i--;
                Order order = _orders[i];
                string status = order.GetStatus();
                if (status == "expired")
                {
                    // remove an expired order
                    _orders.Remove(order);
                    _failure = _you.LoseLife();
                }
                else if (status == "hidden")
                {
                    // order should not be visible
                    if (order.GetTimeStart() <= _gameTime)
                    {
                        // order should become visible
                        order.SetStatus("first try");
                        // start the order's timer
                        // set order to be displayed
                        displayOrders.Add(order);
                    }
                }
                else
                {
                    // order should be visible
                    // set order to be displayed
                    displayOrders.Add(order);
                }
            }
            displayOrders.Reverse();

            DisplayDayClock();
            DisplayLives();
            DisplayOrderQueue(displayOrders);
            DisplayDeckStatus(displayOrders,deck);
            if (_stop || _failure)
            {
                // _stop - time is out, you can no longer do anything
                // _failure - too many orders have expired, its game over
                foreach (Order o in _orders)
                {
                    o.OrderDeleted();
                }
                act = 'T';
            }
            else
            {
                act = ChooseAction();
            }
            Console.Clear();

            switch (act)
            {
                case 'C':
                    DisplayDayClock();
                    DisplayLives();
                    deck.Add(ComposeItem());
                    break;
                case 'B':
                    DisplayDayClock();
                    DisplayLives();
                    BakeItem(deck);
                    break;
                case 'D':
                    DisplayDayClock();
                    DisplayLives();
                    DisposeItem(deck);
                    break;
                case 'S':
                    DisplayDayClock();
                    DisplayLives();

                    // check if there is at least one item ready before allowing submission
                    bool itemsReady = false;
                    i = 0;
                    while (i < deck.Count && !itemsReady)
                    {
                        if (deck[i].GetPhase() == "ready")
                        {
                            itemsReady = true;
                        }
                        i++;
                    }

                    if (displayOrders.Count == 0)
                    {
                        Console.Write("There are no orders that can be submitted.\nPress enter to return to menu");
                        string enter = Reader.ReadLine();
                    }
                    else if (!itemsReady)
                    {
                        Console.Write("There are no items that can be submitted.\nPress enter to return to menu");
                        string enter = Reader.ReadLine();
                    }
                    else
                    {
                        // gather all the ready items into a list while removing them from the deck
                        List<Item> readyItemsList = new();
                        i = deck.Count;
                        while (i > 0)
                        {
                            i--;
                            Item item = deck[i];
                            if (item.GetPhase() == "ready")
                            {
                                readyItemsList.Add(item);
                                deck.Remove(item);
                            }
                        }

                        // Submit the items, get the order in displayOrders that will be submitted and its priority,
                        // which will determine the fate of the submission
                        int submitIndex = -1;
                        int priority = -1; // real value is assigned in SubmitItems
                        SubmitItems(displayOrders,readyItemsList,ref submitIndex,ref priority);

                        // What you see depends on how you did
                        if (priority == 5)
                        {
                            // No order was selected, so a random one will be picked
                            Random fate = new Random();
                            submitIndex = fate.Next(displayOrders.Count);
                        }
                        // determine whether the order should be kept
                        // priority: 3 or 4 - there is only one mistake in the order
                        // selectStatus: first try - its the first time the order is being submitted
                        string selectStatus = displayOrders[submitIndex].GetStatus();
                        bool keepOrder = (priority == 3 || priority == 4) && selectStatus == "first try";

                        // display the outcome of the submission and gather rewards if any
                        Order theOrder = displayOrders[submitIndex];
                        DisplaySubmitOutcome(theOrder, priority, ref dayEarnings, ref dayOrdersDone);
                        // order shouldnt be deleted if youre given another chance
                        if (!keepOrder)
                        {
                            theOrder.OrderDeleted();
                            _orders.Remove(theOrder);
                        }
                        Console.Write($"\n\nPress any key to continue. ");
                        string ok = Reader.ReadLine();
                    }
                    break;
                default:
                    break;
            }
            if (_orders.Count == 0)
            {
                // nothing to do - youre free to go
                _stop = true;
            }
            Console.Clear();
        } while (!_stop && !_failure);
        
        int missedOrders = 0;
        while (missedOrders < _orders.Count && !_failure)
        {
            _failure = _you.LoseLife();
            missedOrders++;
        }
        if (!_failure && _stop)
        {
            // Show the end of the day screen
            EndDayTransfer(dayEarnings,dayOrdersDone);
        }
    }
    private List<Order> SetOrders()
    {
        // This method will add a set number of random orders to random time slots. The number and complexity of the orders will be determined by the game day.
        // _day: game day
        Random rng = new Random();
        const int INITIAL_ORDERS = 4;
        const int ORDERS_PER_DAY = 2;

        // calculate the number of orders based on the day
        int orderCount = ((_day - 1) * ORDERS_PER_DAY) + INITIAL_ORDERS;
        // limit the number if its too much
        if (orderCount > _gameDuration)
        {
            orderCount = _gameDuration;
        }

        // get the random list of customers
        List<string> customers = _options.GetRandomCustomers(orderCount);
        // get the maximum list of starting times
        List<int> startTimes = new();
        for (int i = 0; i < _gameDuration; i++)
        {
            startTimes.Add(i);
        }
        startTimes = startTimes.OrderBy(x => Random.Shared.Next()).ToList();

        List<Order> newOrders = new();
        // start adding orders to the list
        for (int j = 0; j < orderCount; j++)
        {
            newOrders.Add(GenerateOrder(startTimes[j], customers[j]));
        }
        return newOrders;
    }
    private Order GenerateOrder(int t, string c)
    {
        // t: starting time
        // c: customer
        Random rng = new Random();
        Order newOrder = new(t, c);

        int sodaComplexity;
        int chance;
        int flavorNum;
        // determine the complexity with _day
        // day 1   - includes 0-1 pizza orders, soda can have up to 1 flavor
        // day 2   - includes 0-2 pizza orders, soda can have up to 1 flavor
        // day 3-4 - includes 0-2 pizza orders, soda can have up to 2 flavors
        // day 5+  - includes 0-3 pizza orders, soda can have up to 2 flavors
        switch (_day)
        {
            case 1:
                chance = rng.Next(1,8); // 1-7
                sodaComplexity = 2; // to 1
                break;
            case 2:
                chance = rng.Next(1,11); // 1-10
                sodaComplexity = 2; // to 1
                break;
            case 3:
            case 4:
                chance = rng.Next(1,11); // 1-10
                sodaComplexity = 3; // to 2
                break;
            default:
                chance = rng.Next(1,14); // 1-13
                sodaComplexity = 1; // soda complexity will not be used
                break;
        }
        // use the first value in chance to determine the number of pizzas
        if (chance < 3)
        {
            // 0 pizza order = no bread
            // use chance again to determine the number of wings
            Wings wings;
            chance = rng.Next(1,6); // 1-5
            // add the wings
            switch (chance)
            {
                case 5: // includes 16 wings
                    wings = new(true, _options.GetRandomWingSauce());
                    wings.CalculatePrice();
                    newOrder.AddItem(wings);
                    break;
                case 4: // includes 8 wings
                    wings = new(false, _options.GetRandomWingSauce());
                    wings.CalculatePrice();
                    newOrder.AddItem(wings);
                    break;
                default: // doesnt include wings
                    break;
            }

            // use chance again to determine the number of sodas
            chance = rng.Next(1,3); // 1-2
            // add a soda
            flavorNum = rng.Next(sodaComplexity); // complexity depends on day
            Soda soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
            soda.CalculatePrice();
            newOrder.AddItem(soda);
            if (chance == 2)
            {
                // add another soda
                flavorNum = rng.Next(sodaComplexity); // complexity depends on day
                soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
                soda.CalculatePrice();
                newOrder.AddItem(soda);
            }
        }
        else if (chance < 8)
        {
            // 1 pizza order
            // add pizza
            Pizza pizza = new(_options.GetRandomPizzaType());
            pizza.CalculatePrice();
            newOrder.AddItem(pizza);

            // use chance again to determine if there is bread, wings, or neither
            chance = rng.Next(1,5); // 1-4
            switch (chance)
            {
                case 1: // doesnt include either
                    break;
                case 2: // includes 8 wings
                    Wings wings = new(false, _options.GetRandomWingSauce());
                    wings.CalculatePrice();
                    newOrder.AddItem(wings);
                    break;
                default: // includes 6 bread
                    Bread bread = new(false, _options.GetRandomBreadSeasoning());
                    bread.CalculatePrice();
                    newOrder.AddItem(bread);
                    break;
            }
            
            // use chance again to determine the number of sodas
            chance = rng.Next(1,4); // 1-3
            // add a soda
            flavorNum = rng.Next(sodaComplexity); // complexity depends on day
            Soda soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
            soda.CalculatePrice();
            newOrder.AddItem(soda);
            if (chance == 3)
            {
                // add another soda
                flavorNum = rng.Next(sodaComplexity); // complexity depends on day
                soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
                soda.CalculatePrice();
                newOrder.AddItem(soda);
            }
        }
        else if (chance < 11)
        {
            // 2 pizza order
            // add pizzas
            Pizza pizza = new(_options.GetRandomPizzaType());
            pizza.CalculatePrice();
            newOrder.AddItem(pizza);
            pizza = new(_options.GetRandomPizzaType());
            pizza.CalculatePrice();
            newOrder.AddItem(pizza);

            // use chance again to determine if there is bread, wings, or both
            chance = rng.Next(1,6); // 1-5
            if (chance < 5)
            {
                // add bread
                Bread bread = new(chance != 4, _options.GetRandomBreadSeasoning());
                bread.CalculatePrice();
                newOrder.AddItem(bread);
            }
            if (chance > 3)
            {
                // add wings
                Wings wings = new(chance == 5, _options.GetRandomWingSauce());
                wings.CalculatePrice();
                newOrder.AddItem(wings);
            }

            // add a soda
            flavorNum = rng.Next(sodaComplexity); // complexity depends on day
            Soda soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
            soda.CalculatePrice();
            newOrder.AddItem(soda);
            if (chance != 4)
            {
                // add another soda
                flavorNum = rng.Next(sodaComplexity); // complexity depends on day
                soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
                soda.CalculatePrice();
                newOrder.AddItem(soda);
            }
        }
        else
        {
            // 3 pizza order - EXTREME!!
            // add pizzas
            Pizza pizza = new(_options.GetRandomPizzaType());
            pizza.CalculatePrice();
            newOrder.AddItem(pizza);
            pizza = new(_options.GetRandomPizzaType());
            pizza.CalculatePrice();
            newOrder.AddItem(pizza);
            pizza = new(_options.GetRandomPizzaType());
            pizza.CalculatePrice();
            newOrder.AddItem(pizza);

            // use chance again to determine if there is two bread, two wings, or one of each
            chance = rng.Next(1,7); // 1-6
            if (chance < 5)
            {
                // add bread
                Bread bread = new(true, _options.GetRandomBreadSeasoning());
                bread.CalculatePrice();
                newOrder.AddItem(bread);
                if (chance == 4)
                {
                    // add another bread
                    bread = new(false, _options.GetRandomBreadSeasoning());
                    bread.CalculatePrice();
                    newOrder.AddItem(bread);
                }
            }
            if (chance != 4)
            {
                // add wings
                Wings wings = new(true, _options.GetRandomWingSauce());
                wings.CalculatePrice();
                newOrder.AddItem(wings);
                if (chance > 4)
                {
                    // add another
                    wings = new(true, _options.GetRandomWingSauce());
                    wings.CalculatePrice();
                    newOrder.AddItem(wings);
                }
            }

            // add two sodas
            flavorNum = rng.Next(1,3); // 1-2
            Soda soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
            soda.CalculatePrice();
            newOrder.AddItem(soda);
            flavorNum = rng.Next(1,3); // 1-2
            soda = new(_options.GetRandomSodaBase(), _options.GetRandomSodaFlavors(flavorNum));
            soda.CalculatePrice();
            newOrder.AddItem(soda);
        }
        newOrder.CalculateTimeAvailable();
        return newOrder;
    }
    private void StartDayTimer()
    {
        while (_gameTime < _gameDuration && !_stop && !_failure)
        {
            int w = 0;
            while (w < _waitTime && !_stop && !_failure)
            {
                Thread.Sleep(1000);
                w++;
            }
            _gameTime++;
        }
        if (_gameTime == _gameDuration && !_failure && !_stop)
        {
            // stop pushing orders until the game is over
            int lc = 0;
            while (lc < _lastCallTime && !_stop && !_failure)
            {
                Thread.Sleep(1000);
                lc++;
            }
            _stop = true;
        }
    }
    private void DisplayDayClock()
    {
        // This method will write the ingame day and time to the console as a formatted string.
        const int START_HOUR = 2;
        const int END_HOUR = 12;
        // calculate the time the clock jumps every tick based on the clock's start hour, end hour, and number of ticks
        int totalMins = (END_HOUR - START_HOUR) * 60;
        int minsPerTick = totalMins / _gameDuration;
        int timeDivisor = 60 / minsPerTick;

        int clockHour = (((_gameTime / timeDivisor) + START_HOUR - 1) % 12) + 1;
        int clockMin = _gameTime % timeDivisor * minsPerTick;

        string clockStr = $"Day {_day:00} - ";
        clockStr += string.Format("({0,2}:{1:00}) ", clockHour, clockMin);
        if (_gameTime == _gameDuration)
        {
            // add a warning when the end time has been reached
            clockStr += "- {closing soon, finish your work!} ";
        }
        Console.WriteLine(clockStr);
    }
    private void DisplayLives()
    {
        // This method will write the number of lives left as to the console as a formatted string.
        // Lives: [ ][ ][ ]
        // Lives: [ ][X][X]
        _you.DisplayLives();
    }
    private void DisplayDeckStatus(List<Order> orders, List<Item> itemList)
    {
        // This method will display all the item phases and the number of items in each phase.
        // Need: # | Uncooked: # | Baking: # | Ready: #
        int needed = 0;
        if (orders.Count > 0)
        {
            foreach (Order order in orders)
            {
                needed += order.GetItems().Count;
            }
        }
        int uncooked = 0;
        int baking = 0;
        int ready = 0;
        if (itemList.Count > 0)
        {
            foreach (Item item in itemList)
            {
                string phase = item.GetPhase();
                if (phase == "uncooked")
                {
                    uncooked++;
                }
                else if (phase == "baking")
                {
                    baking++;
                }
                else if (phase == "ready")
                {
                    ready++;
                }
            }
        }
        Console.Write($"Need: {needed} | Uncooked: {uncooked} | Baking: {baking} | Ready: {ready}\n\n");
    }
    private char ChooseAction()
    {
        // [C: COMPOSE] [B: BAKE] [D: DISPOSE] [S: SUBMIT]
        //
        // CHOOSE ACTION: _
        string input;
        char choice;
        try
        {
            Console.Write("[C: COMPOSE] [B: BAKE] [D: DISPOSE] [S: SUBMIT]\n\nCHOOSE ACTION: ");
            input = Reader.ReadLine(1000 * _waitTime).ToUpper();
        }
        catch (TimeoutException)
        {
            input = "";
        }

        if (input == "")
        {
            choice = 'E';
        }
        else
        {
            choice = input[0];
        }
        return choice;
    }
    private void DisplayOrderQueue(List<Order> orders)
    {
        // This method will display all the unfinished orders.
        if (orders.Count > 0)
        {
            foreach (Order order in orders)
            {
                string orderStr = order.GetStringForMenu();
                Console.WriteLine($"- [{orderStr}");
            }
            Console.Write("\n");
        }
    }
    private Item ComposeItem()
    {
        // Present the options for what items can be composed
        Console.Write("OPTIONS:\n\nPIZZA [1]\nBREAD [2]\nWINGS [3]\nSODA  [4]\n\nSELECT: ");
        int selection;
        bool inRange;
        do
        {
            while (!int.TryParse(Reader.ReadLine(), out selection))
            {
                Console.Write("Invalid input\nSELECT: ");
            }
            inRange = selection > 0 && selection < 5;
            if (!inRange)
            {
                Console.Write("Invalid input\nSELECT: ");
            }
        } while (!inRange);
        Console.Clear();
        DisplayDayClock();
        DisplayLives();

        // Create the item
        switch (selection)
        {
            case 1:
                Pizza newPizza = new();
                newPizza.Compose();
                return newPizza;
            case 2:
                Bread newBread = new();
                newBread.Compose();
                return newBread;
            case 3:
                Wings newWings = new();
                newWings.Compose();
                return newWings;
            default:
                Soda newSoda = new();
                newSoda.Compose();
                return newSoda;
        }
    }
    private void BakeItem(List<Item> itemList)
    {
        // Collect items that need to be baked
        List<WarmItem> needBaking = new();
        foreach (Item item in itemList)
        {
            string phase = item.GetPhase();
            if (phase == "uncooked")
            {
                needBaking.Add((WarmItem)item);
            }
        }

        // Present the options for what items can be baked
        int itemCount = needBaking.Count;
        if (itemCount < 1)
        {
            Console.Write("No items need to be baked at this time.\nPress enter to return to menu");
            string enter = Reader.ReadLine();
        }
        else
        {
            Console.WriteLine("Uncooked Items:");
            for (int h = 0; h < itemCount; h++)
            {
                Console.WriteLine($"{h+1}: {needBaking[h].GetStringForMenu()}");
            }
            Console.Write("\nSELECT: ");
            int option;
            bool inRange;
            do
            {
                while (!int.TryParse(Reader.ReadLine(), out option))
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
                inRange = option > 0 && (option-1) < itemCount;
                if (!inRange)
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
            } while (!inRange);

            // Bake the selected item
            needBaking[option-1].Bake();
        }
    }
    private void DisposeItem(List<Item> itemList)
    {
        // List the items that have been composed
        int itemCount = itemList.Count;

        if (itemCount < 1)
        {
            Console.Write("There are no items, therefore nothing can be disposed.\nPress enter to return to menu");
            string enter = Reader.ReadLine();
        }
        else
        {
            Console.WriteLine("Items:");
            for (int h = 0; h < itemCount; h++)
            {
                Console.WriteLine($"{h+1}: {itemList[h].GetStringForMenu()}");
            }
            Console.Write("\nSELECT: ");
            int option;
            bool inRange;
            do
            {
                while (!int.TryParse(Reader.ReadLine(), out option))
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
                inRange = option > 0 && (option-1) < itemCount;
                if (!inRange)
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
            } while (!inRange);

            // Remove the chosen item from the list
            itemList.RemoveAt(option-1);
        }
    }
    private void SubmitItems(List<Order> orders, List<Item> itemList, ref int ind, ref int pri)
    {
        // Get the number of items in the deck
        int deckSize = itemList.Count;
        List<int> deltaList = new();
        List<int> errorList = new();

        // Check each order to see how well it matches the deck
        // Only check VISIBLE orders !!
        foreach (Order order in orders)
        {
            // Copy the deck into a new list so that it can be changed
            List<string> deckStrings = new();
            foreach(Item item in itemList)
            {
                deckStrings.Add(item.GetStringForMenu());
            }
            // Get the list of items from the order
            List<Item> orderItems = order.GetItems();

            {
                // Get the number of items in the order
                int orderSize = orderItems.Count;
                // Add the delta to the delta list
                deltaList.Add(deckSize - orderSize);
            }

            int errorCount = 0;
            // Compare each item in the order with the items from the deck
            foreach (Item a in orderItems)
            {
                // Initialize the deck check
                bool matching = false;
                int i = 0;
                int tempDeckSize = deckStrings.Count;

                // Run the comparison loop
                // Loop exits either when match is found or when the index is equal to the decksize
                while (!matching && i < tempDeckSize)
                {
                    string b = deckStrings[i];
                    if (a.GetStringForMenu() == b)
                    {
                        matching = true;
                        deckStrings.RemoveAt(i);
                    }
                    i++;
                }
                if (!matching)
                {
                    errorCount++;
                }
            }
            errorList.Add(errorCount);
        }

        // At this point, the delta list and the error list should be filled with their respective values
        // Get the number of orders
        int orderListSize = orders.Count;

        // Create a third list that will represent each order's selection priority
        List<int> selectionPriority = new();
        int prioritySelect = 5;
        for (int h = 0; h < orderListSize; h++)
        {
            int del = deltaList[h];
            int err = errorList[h];
            int prior;

            if (del == 0)
            {
                // there are the same number of items in the deck as there are in the order
                switch (err)
                {
                    case 0: prior = 1; // the contents of the order match the contents of the deck
                        break;
                    case 1: prior = 4; // the numbers match, but one item is off
                        break;
                    default: prior = 5; // the numbers match, but more than one item is off
                        break;
                }
            }
            else if (del > 0)
            {
                // there are more items in the deck than there are in the order
                if (err <= del)
                {
                    // the contents of the deck include every item in the order
                    prior = 2;
                }
                else if (err == del+1)
                {
                    // there is one mistake in the contents of the deck
                    prior = 3;
                }
                else
                {
                    // there is more than one mistake in the contents of the deck
                    prior = 5;
                }
                
            }
            else
            {
                // there are less items in the deck than there are in the order
                prior = 5;
            }
            if (prior < prioritySelect)
            {
                prioritySelect = prior;
            }
            selectionPriority.Add(prior);
        }

        // using prioritySelect, determine the order that will be given attention, if any
        int indexSelect = -1;
        if (prioritySelect < 5) // only check the list if at least one order needed to be looked at
        {
            int j = 0;
            while (j < orderListSize && indexSelect == -1) // first condition only there for caution
            {
                if (selectionPriority[j] == prioritySelect)
                {
                    indexSelect = j;
                }
                j++;
            }
        }

        ind = indexSelect;
        pri = prioritySelect;
    }
    private void DisplaySubmitOutcome(Order order, int success, ref int earns, ref int orderCount)
    {
        string customer = order.GetCustomer();
        string orderStatus = order.GetStatus();
        Console.Write("Submission Evaluation:\n\n");
        if (success < 3)
        {
            // 1-2: Correct order
            Console.Write($"SUCCESS! You successfully submitted {customer}'s order.\n\n");
            earns += order.GetPaid();
            orderCount++;
        }
        else if (success < 5 && orderStatus == "first try")
        {
            // 3-4: One mistake
            // + "first try" = second chance
            Console.Write($"Hold on! You got one item wrong in {customer}'s order.\n");
            Console.Write($"It's not too late for you to fix it though! You have ONE MORE chance to try again!");
            order.SecondChance();
        }
        else
        {
            // 5: More than one mistake
            // or 3-4 + "second try"
            _failure = _you.LoseLife();
            int lives = _you.GetLives();
            Console.Write($"FAILURE.\n\nYou now have {lives} lives.");
        }
    }
    private void EndDayTransfer(int earnings, int ordersDone)
    {
        // This method will transfer the earned money and completed orders to the player's total for each.
        _you.TransferEarnings(earnings);
        _you.TransferOrdersDone(ordersDone);

        // Also you get a summary
        string ordersStr = string.Format("{0,11}", ordersDone);
        string earningsStr = string.Format("{0,9:0.00}", (double)earnings/100);
        Console.Write($"Day {_day} Results:\n\n\n");
        Console.WriteLine($"ORDERS DONE -{ordersStr}");
        Console.Write($"    REVENUE - ${earningsStr}\n\n");
        Console.Write("Press enter when ready");
        string enter = Reader.ReadLine();
    }
    private void DisplayGameEnd(string name)
    {
        if (_failure)
        {
            // YOU LOST
            Console.Write("YOU LOSE\n\n\"Peter, you're a nice guy. You're just not dependable.\"\n\n");
            Console.Write("Better luck next time!\n\n");
        }
        else
        {
            // YOU WON!
            Console.Write($"YOU WIN!\n\nCongratulations, {name}! You made it through all the days!\n\n");

            string ordersStr = string.Format("{0,12}", _you.GetTotalOrdersDone());
            string earningsStr = string.Format("{0,10:0.00}", (double)_you.GetTotalEarnings()/100);
            Console.Write("Here are the final results:\n\n\n");
            Console.WriteLine($"TOTAL ORDERS DONE -{ordersStr}");
            Console.Write($"    TOTAL REVENUE - ${earningsStr}\n\n");
            Console.Write("Hope we find you another time! ;)\n\n");
        }
    }
}