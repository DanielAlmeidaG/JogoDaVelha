using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class MainMenu : IMenu
    {
        int idChoice;
        public MainMenu()
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
            Console.WriteLine("Bem-vindo ao Jovo da Velha!\n");
            switch (idChoice)
            {
                case 1:
                    Console.WriteLine(">Iniciar Partida");
                    Console.WriteLine(" Definir Dificuldade do Computador");
                    Console.WriteLine(" Definir Tipo de partida");
                    Console.WriteLine(" Sair");
                    break;
                case 2:
                    Console.WriteLine(" Iniciar Partida");
                    Console.WriteLine(">Definir Dificuldade do Computador");
                    Console.WriteLine(" Definir Tipo de partida");
                    Console.WriteLine(" Sair");
                    break;
                case 3:
                    Console.WriteLine(" Iniciar Partida");
                    Console.WriteLine(" Definir Dificuldade do Computador");
                    Console.WriteLine(">Definir Tipo de partida");
                    Console.WriteLine(" Sair");
                    break;
                case 4:
                    Console.WriteLine(" Iniciar Partida");
                    Console.WriteLine(" Definir Dificuldade do Computador");
                    Console.WriteLine(" Definir Tipo de partida");
                    Console.WriteLine(">Sair");
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
