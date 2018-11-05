using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Position : Board
    {
        Marker _marker;

        public void SetMarker(Marker marker)
        {
            this._marker = marker;
        }
        public Marker GetMarker()
        {
            return this._marker;
        }
    }
}
