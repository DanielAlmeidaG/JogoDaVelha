using System;
using System.Collections.Generic;
using System.Text;

namespace game
{    
    public class Match
    {
        private Board _board;
        private int __choice;
        private int _gameMode;

        public void InitializeMatch(int gameMode, int difficulty)
        {
            _gameMode = gameMode;
            switch (gameMode)
            {
                case 1:
                    PlayerVsPlayer();
                    break;
                case 2:
                    PlayerVsComputer(difficulty);
                    break;
                case 3:
                    ComputerVsComputer(difficulty);
                    break;
            }
            
        }

        private void PlayerVsPlayer()
        {
            _board = new Board();
            _board.InitializeGrid();            

            Human h1 = new Human(1);
            Human h2 = new Human(2);
            Human player = h1;

            int round = 1;

            h1.SetMarker(h1.GetId());
            h2.SetMarker(h2.GetId());

            int _choice;
            bool hasChosen;

            while (!_board.IsOver() && !_board.isFull())
            {
                PrintGame();
                _choice = player.ChoseAction();

                if(_choice == 0)
                {
                    return;
                }
                else if(1<=_choice && _choice <= 9)
                {
                    hasChosen = _board.InsertMarker(_choice, player.GetMarker());
                    while (!hasChosen)
                    {
                        PrintGame();
                        Console.WriteLine("Atencão! Insira um local que esteja vazio!");
                        _choice = player.ChoseAction();
                        if (_choice == 0)
                            return;
                        hasChosen = _board.InsertMarker(_choice, player.GetMarker());
                    }

                    if (round == 1)
                    {
                        player = h2;
                        round = 2;
                    }
                    else
                    {
                        player = h1;
                        round = 1;
                    }                            
                }
                else
                {
                    PrintGame();
                    Console.WriteLine("Atencão! Insira um numero entre 0 e 9 apenas");
                }
            }

            if (round == 1 && _board.IsOver())
            {
                PrintFinalGame(2);
            }
            else if(round == 2 && _board.IsOver())
            {

                PrintFinalGame(1);
            }
            else
            {
                PrintFinalGame(0);
            }
            return;
        }

        private void PlayerVsComputer(int difficulty)
        {
            _board = new Board();
            _board.InitializeGrid();

            Human h1 = new Human(1);
            Computer c1 = new Computer(2);

            int round = 1;

            h1.SetMarker(h1.GetId());
            c1.SetMarker(c1.GetId());

            int _choice;
            bool hasChosen;

            while (!_board.IsOver() && !_board.isFull())
            {
                PrintGame();
                if (round == 1)
                {
                    _choice = h1.ChoseAction();

                    if (_choice == 0)
                    {
                        return;
                    }
                    else if (1 <= _choice && _choice <= 9)
                    {
                        hasChosen = _board.InsertMarker(_choice, h1.GetMarker());
                        while (!hasChosen)
                        {
                            PrintGame();
                            Console.WriteLine("Atencão! Insira um local que esteja vazio!");
                            _choice = h1.ChoseAction();
                            if (_choice == 0)
                                return;
                            hasChosen = _board.InsertMarker(_choice, h1.GetMarker());
                        }
                        round = 2;
                    }
                    else
                    {
                        PrintGame();
                        Console.WriteLine("Atencão! Insira um numero entre 0 e 9 apenas");
                    }
                }
                else
                {
                    hasChosen = _board.InsertMarker(c1.ChoseAction(difficulty, _board), c1.GetMarker());
                    round = 1;
                }
            }

            if (round == 1 && _board.IsOver())
            {
                PrintFinalGame(2);
            }
            else if (round == 2 && _board.IsOver())
            {

                PrintFinalGame(1);
            }
            else
            {
                PrintFinalGame(0);
            }
            return;
        }

        private void ComputerVsComputer(int difficulty)
        {
            _board = new Board();
            _board.InitializeGrid();

            Computer c1 = new Computer(1);
            Computer c2 = new Computer(2);

            int round = 1;

            c1.SetMarker(c1.GetId());
            c2.SetMarker(c2.GetId());

            int _choice;
            bool hasChosen;

            while (!_board.IsOver() && !_board.isFull())
            {
                PrintGame();
                if (round == 1)
                {
                    hasChosen = _board.InsertMarker(c1.ChoseAction(difficulty, _board), c1.GetMarker());
                    round = 2;
                }
                else
                {
                    hasChosen = _board.InsertMarker(c1.ChoseAction(difficulty, _board), c2.GetMarker());
                    round = 1;
                }
            }
            if (round == 1 && _board.IsOver())
            {
                PrintFinalGame(2);
            }
            else if (round == 2 && _board.IsOver())
            {

                PrintFinalGame(1);
            }
            else
            {
                PrintFinalGame(0);
            }
            return;
        }

        private void PrintGame()
        {
            Console.Clear();
            switch (_gameMode)
            {
                case 1:
                    Console.WriteLine("---Jogador Vs Jogador---");
                    break;
                case 2:
                    Console.WriteLine("---Jogador Vs Computador---");
                    break;
                case 3:
                    Console.WriteLine("---Computador Vs Computador---");
                    break;
            }
            _board.PrintGrid();
        }

        private void PrintFinalGame(int id)
        {
            Console.Clear();
            if(id == 0)
            {
                switch (_gameMode)
                {
                    case 1:
                        Console.WriteLine("---Jogador Vs Jogador---");
                        break;
                    case 2:
                        Console.WriteLine("---Jogador Vs Computador---");
                        break;
                    case 3:
                        Console.WriteLine("---Computador Vs Computador---");
                        break;
                }
                _board.PrintGrid();
                Console.WriteLine("\nEmpate!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
                return;
            }
            string markerStr;
            if (id == 1)
                markerStr = "X";
            else
                markerStr = "O";
            switch (_gameMode)
            {
                case 1:
                    Console.WriteLine("---Jogador Vs Jogador---");
                    break;
                case 2:
                    Console.WriteLine("---Jogador Vs Computador---");
                    break;
                case 3:
                    Console.WriteLine("---Computador Vs Computador---");
                    break;
            }
            _board.PrintGrid();
            Console.WriteLine("\nVitória do jogador: " + markerStr + "!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            return;
        }
    }
}
