using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public struct Position
    {
        // Variables.
        public int X { get; }
        public int Y { get; }

        // X and Y position assignment.
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}