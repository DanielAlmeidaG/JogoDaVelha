using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Player
    {
        private Marker _marker;
        private bool _isTurn;

        public void SetMarker(int idMarker)
        {
            _marker = new Marker(idMarker);
        }

        public Marker GetMarker()
        {
            return _marker;
        }
    }
}
