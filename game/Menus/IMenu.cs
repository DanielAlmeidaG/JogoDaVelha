using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public interface IMenu
    {
        int GetID();

        void PrintMenu();

        ConsoleKey GetAction();
        
    }
}
