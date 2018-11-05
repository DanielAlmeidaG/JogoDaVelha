using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Marker : Position
    {
        private int _id;
        public Marker(int id)
        {
            this._id = id;
        }
        public string GetPrint()
        {
            switch (_id) {
                case 1:
                    return "X";
                case 2:
                    return "O";
                default:
                    return " ";
            }
        }
        public int GetId()
        {
            return _id;
        }
    }
}
