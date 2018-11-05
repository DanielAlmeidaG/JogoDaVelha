using System;

namespace game
{
    class Program
    {        
        static void Main(string[] args)
        {
            int difficulty = 1;
            int gameMode = 1;
            IMenu menu = new MainMenu();
            menu.PrintMenu();
            ConsoleKey keyPressed = menu.GetAction();
            while(!(menu.GetID() == 4 && keyPressed == ConsoleKey.Enter))
            {
                menu.PrintMenu();
                keyPressed = menu.GetAction();

                if (menu.GetID() == 3 && keyPressed == ConsoleKey.Enter)
                {
                    IMenu gameModeMenu = new GameModeMenu();
                    gameModeMenu.PrintMenu();
                    keyPressed = gameModeMenu.GetAction();
                    while (keyPressed != ConsoleKey.Enter)
                    {
                        gameModeMenu.PrintMenu();
                        keyPressed = gameModeMenu.GetAction();
                    }
                    gameMode = gameModeMenu.GetID();
                }
                else if(menu.GetID() == 2 && keyPressed == ConsoleKey.Enter)
                {
                    IMenu difficultyMenu = new DifficultyMenu();
                    difficultyMenu.PrintMenu();
                    keyPressed = difficultyMenu.GetAction();
                    while (keyPressed != ConsoleKey.Enter)
                    {
                        difficultyMenu.PrintMenu();
                        keyPressed = difficultyMenu.GetAction();
                    }
                    difficulty = difficultyMenu.GetID();
                }
                else if (menu.GetID() == 1 && keyPressed == ConsoleKey.Enter)
                {
                    Match match = new Match();
                    match.InitializeMatch(gameMode, difficulty);
                }
            }
            return;
        }
    }
}
