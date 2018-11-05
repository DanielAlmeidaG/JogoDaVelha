using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Board
    {
        private Position[,] _grid;
        private int _blank = 0;

        public void InitializeGrid()
        {
            _grid = new Position[3,3];
            
            for(int x=0; x<3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    _grid[x, y] = new Position();
                    _grid[x, y].SetMarker(new Marker(_blank));
                }
            }
        }
        public Position[,] GetGrid()
        {
            return _grid;
        }
        public void PrintGrid()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var z = _grid[x, y].GetMarker().GetPrint();
                }
            }
            Console.WriteLine("    " + _grid[0, 0].GetMarker().GetPrint() + " | " + _grid[0, 1].GetMarker().GetPrint() + " | " + _grid[0, 2].GetMarker().GetPrint());
            Console.WriteLine("   -----------");
            Console.WriteLine("    " + _grid[1, 0].GetMarker().GetPrint() + " | " + _grid[1, 1].GetMarker().GetPrint() + " | " + _grid[1, 2].GetMarker().GetPrint());
            Console.WriteLine("   -----------");
            Console.WriteLine("    " + _grid[2, 0].GetMarker().GetPrint() + " | " + _grid[2, 1].GetMarker().GetPrint() + " | " + _grid[2, 2].GetMarker().GetPrint());

        }

        public bool InsertMarker(int spot, Marker marker)
        {
            int[] pos = GetLineAndColumn(spot);
            if (IsSpotEmpty(pos[0], pos[1]))
            {
                this._grid[pos[0], pos[1]].SetMarker(marker);
                return true;
            }
            else
                return false;
        }

        public bool IsSpotEmpty(int line, int col)
        {
            if (_grid[line, col].GetMarker().GetId() == 0)
                return true;
            else
                return false;
        }

        private int[] GetLineAndColumn(int spot)
        {
            int[] pos = new int[2];//pos[0] = line, pos[1] = column

            int line;
            int col;

            if (spot < 4)
                line = 0;
            else if (spot < 7)
                line = 1;
            else
                line = 2;


            if (line == 0)
                col = spot - 1;
            else
                col = (spot - line * 3) - 1;

            pos[0] = line;
            pos[1] = col;

            return pos;
        }

        public bool IsOver()
        {
            List<int> Ids =  new List<int>();
            //Check Horizontals
            for (int x = 0; x < 3; x++)
            {
                Ids.Clear();
                for (int y = 0; y < 3; y++)
                {
                    Ids.Add(_grid[x, y].GetMarker().GetId());
                }
                if (!Ids.Contains(0) && !(Ids.Contains(1) && Ids.Contains(2)))
                {
                    return true;
                }
            }

            //Check Verticals
            for (int y = 0; y < 3; y++)
            {
                Ids.Clear();
                for (int x = 0; x < 3; x++)
                {
                    Ids.Add(_grid[x, y].GetMarker().GetId());
                }
                if (!Ids.Contains(0) && !(Ids.Contains(1) && Ids.Contains(2)))
                {
                    return true;
                }
            }

            //Check Diagonals
            //First Diagonal
            Ids.Clear();
            for (int x=0; x<3; x++)
            {                
                Ids.Add(_grid[x, x].GetMarker().GetId());                
            }
            if (!Ids.Contains(0) && !(Ids.Contains(1) && Ids.Contains(2)))
            {
                return true;
            }
            //Second Diagonal
            Ids.Clear();
            for (int x=0; x<3; x++)
            {                
                Ids.Add(_grid[x, 2-x].GetMarker().GetId());                
            }
            if (!Ids.Contains(0) && !(Ids.Contains(1) && Ids.Contains(2)))
            {
                return true;
            }
            return false;
        }

        public bool isFull()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (_grid[x, y].GetMarker().GetId() == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
