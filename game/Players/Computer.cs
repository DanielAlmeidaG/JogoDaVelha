using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Computer : Player
    {
        int _id;
        public Computer(int id)
        {
            this._id = id;
        }
        public int GetId()
        {
            return _id;
        }
        public int ChoseAction(int difficulty, Board board)
        {
            switch (difficulty)
            {
                case 1:
                    return HardMode(board);
                case 2:
                    return MediumMode(board);
                case 3:
                    return EasyMode(board);
            }
            return 1;
        }

        private int EasyMode(Board board)
        {
            Position[,] grid = board.GetGrid();
            int spot;

            List<int> ListSpots = GetEmptys(board);
            int listCount = ListSpots.Count();
            Random rnd = new Random();
            int listRandom = rnd.Next(1, listCount);
            int[] possibilities = ListSpots.ToArray();
            return possibilities[listRandom - 1];
        }

        private int MediumMode(Board board)
        {
            Position[,] grid = board.GetGrid();
            int spot;

            spot = TestLosses(grid);
            if (spot != 0)
                return spot;

            List<int> ListSpots = GetEmptys(board);
            int listCount = ListSpots.Count();
            Random rnd = new Random();
            int listRandom = rnd.Next(1, listCount);
            int[] possibilities = ListSpots.ToArray();
            return possibilities[listRandom - 1];
        }

        private int HardMode(Board board)
        {   
            Position[,] grid = board.GetGrid();
            int spot;

            spot = TestWins(grid);
            if (spot != 0)
                return spot;

            spot = TestLosses(grid);
            if (spot != 0)
                return spot;

            List<int> ListSpots = GetEmptys(board);
            int listCount = ListSpots.Count();
            Random rnd = new Random();
            int listRandom = rnd.Next(1, listCount);
            int[] possibilities = ListSpots.ToArray();
            return possibilities[listRandom-1];
        }

        private bool CanWin(List<int> Ids)
        {
            List<int> tempList = new List<int>();
            for (int x = 0; x < Ids.Count(); x++)
            {
                tempList.Add(Ids[x]);
            }
            if (_id == 1)
            {
                if (tempList.Contains(2))
                    return false;                
            }
            else
            {
                if (tempList.Contains(1))
                    return false;
            }
            for(int x=1; x<=3; x++)
            {
                tempList.Remove(0);
            }            
            if (tempList.Count() == 2)
                return true;

            return false;        
        }

        private bool CanLose(List<int> Ids)
        {
            List<int> tempList = new List<int>();
            for (int x = 0; x < Ids.Count(); x++)
            {
                tempList.Add(Ids[x]);
            }
            
            if (_id == 1)
            {
                if (tempList.Contains(1))
                    return false;
            }
            else
            {
                if (tempList.Contains(2))
                    return false;
            }
            for (int x = 1; x <= 3; x++)
            {
                tempList.Remove(0);
            }
            if (tempList.Count() == 2)
                return true;

            return false;
        }

        private int TestLosses(Position[,] grid)
        {
            List<int> Ids = new List<int>();
            int line;
            int column;
            //Check Horizontals
            for (int x = 0; x < 3; x++)
            {
                Ids.Clear();
                for (int y = 0; y < 3; y++)
                {
                    Ids.Add(grid[x, y].GetMarker().GetId());
                }
                if (CanLose(Ids))
                {
                    line = x;
                    column = GetPosEmpty(Ids);
                    return GetSpot(line, column);
                }
            }

            //Check Verticals
            for (int y = 0; y < 3; y++)
            {
                Ids.Clear();
                for (int x = 0; x < 3; x++)
                {
                    Ids.Add(grid[x, y].GetMarker().GetId());
                }
                if (CanLose(Ids))
                {
                    column = y;
                    line = GetPosEmpty(Ids);
                    return GetSpot(line, column);
                }
            }

            //Check Diagonals
            //First Diagonal
            Ids.Clear();
            for (int x = 0; x < 3; x++)
            {
                Ids.Add(grid[x, x].GetMarker().GetId());
            }
            if (CanLose(Ids))
            {
                line = GetPosEmpty(Ids);
                column = line;
                return GetSpot(line, column);
            }
            //Second Diagonal
            Ids.Clear();
            for (int x = 0; x < 3; x++)
            {
                Ids.Add(grid[x, 2 - x].GetMarker().GetId());
            }
            if (CanLose(Ids))
            {
                line = GetPosEmpty(Ids);
                column = 2 - line;
                return GetSpot(line, column);
            }

            return 0;
        }

        private int TestWins(Position[,] grid)
        {
            List<int> Ids = new List<int>();
            int line;
            int column;
            //Check Horizontals
            for (int x = 0; x < 3; x++)
            {
                Ids.Clear();
                for (int y = 0; y < 3; y++)
                {
                    Ids.Add(grid[x, y].GetMarker().GetId());
                }
                if (CanWin(Ids))
                {
                    line = x;
                    column = GetPosEmpty(Ids);
                    return GetSpot(line, column);
                }
            }

            //Check Verticals
            for (int y = 0; y < 3; y++)
            {
                Ids.Clear();
                for (int x = 0; x < 3; x++)
                {
                    Ids.Add(grid[x, y].GetMarker().GetId());
                }
                if (CanWin(Ids))
                {
                    column = y;
                    line = GetPosEmpty(Ids);
                    return GetSpot(line, column);
                }
            }

            //Check Diagonals
            //First Diagonal
            Ids.Clear();
            for (int x = 0; x < 3; x++)
            {
                Ids.Add(grid[x, x].GetMarker().GetId());
            }
            if (CanWin(Ids))
            {
                line = GetPosEmpty(Ids);
                column = line;
                return GetSpot(line, column);
            }
            //Second Diagonal
            Ids.Clear();
            for (int x = 0; x < 3; x++)
            {
                Ids.Add(grid[x, 2 - x].GetMarker().GetId());
            }
            if (CanWin(Ids))
            {
                line = GetPosEmpty(Ids);
                column = 2 - line;
                return GetSpot(line, column);
            }

            return 0;
        }

        private int GetPosEmpty(List<int> Ids)
        {
            if (Ids[0] == 0)
                return 0;
            else if (Ids[1] == 0)
                return 1;
            else
                return 2;
        }

        private int GetSpot(int line, int column)
        {
            if (line == 0)
            {
                return column + 1;
            }
            else if (line == 1)
            {
                return column + 4;
            }
            else
                return column + 7;
        }

        private List<int> GetEmptys(Board board)
        {
            List<int> Ids = new List<int>();

            for(int x=0; x<3; x++)
            {
                for(int y=0; y<3; y++)
                {
                    if(board.IsSpotEmpty(x, y))
                    {
                        Ids.Add(GetSpot(x, y));
                    }
                }
            }

            return Ids;
        }
    }
}
