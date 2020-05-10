using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class Piece
    {
        public State State { get; private set; }

        public Position Pos { get; set; }

        public Piece(State selectedState)
        {
            State = selectedState;
        }
    }
}
