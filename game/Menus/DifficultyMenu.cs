using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class DifficultyMenu : IMenu
    {
        int idChoice;

        public DifficultyMenu()
        {
            idChoice = 1;
        }

        public int GetID()
        {
            return idChoice;
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha a dificuldade de jogo desejada\n");
            switch (idChoice)
            {
                case 1:
                    Console.WriteLine(">Difícil");
                    Console.WriteLine(" Médio");
                    Console.WriteLine(" Fácil");
                    Console.WriteLine(" Voltar");
                    break;
                case 2:
                    Console.WriteLine(" Difícil");
                    Console.WriteLine(">Médio");
                    Console.WriteLine(" Fácil");
                    Console.WriteLine(" Voltar");
                    break;
                case 3:
                    Console.WriteLine(" Difícil");
                    Console.WriteLine(" Médio");
                    Console.WriteLine(">Fácil");
                    Console.WriteLine(" Voltar");
                    break;
                case 4:
                    Console.WriteLine(" Difícil");
                    Console.WriteLine(" Médio");
                    Console.WriteLine(" Fácil");
                    Console.WriteLine(">Voltar");
                    break;
            }
            Console.WriteLine("\n-Use as setas para andar pelo menu e a tecla Enter para escolher uma opção-");
        }

        public ConsoleKey GetAction()
        {
            ConsoleKey pressed = Console.ReadKey().Key;
            if (pressed == ConsoleKey.DownArrow && idChoice < 4)
                idChoice++;
            else if (pressed == ConsoleKey.UpArrow && idChoice > 1)
                idChoice--;
            else if (pressed == ConsoleKey.Enter && idChoice != 4)
                this.DoAction();
            return pressed;
        }

        public void DoAction()
        {
        }
    }
}
