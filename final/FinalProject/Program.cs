using System;

class Program
{
    static void Main(string[] args)
    {
        const int START_LIVES = 3;
        const int TOTAL_DAYS = 3;
        const int STARTING_DAY = 1;
        const int CLOCK_TICKS = 60;
        const int GAME_MINS = 4;
        const int LASTCALL_SECONDS = 60;

        int gameSeconds = GAME_MINS * 60;
        int tickSeconds = gameSeconds / CLOCK_TICKS;

        Game game = new(START_LIVES,TOTAL_DAYS,STARTING_DAY);
        game.SetGameDuration(CLOCK_TICKS,tickSeconds,LASTCALL_SECONDS);
        
        game.RunGame();
    }
}