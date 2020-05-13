using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// Position that stores a X and Y value.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Row/X.
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Column/Y.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Constructor to make a Position.
        /// </summary>
        /// <param name="x">Row/X.</param>
        /// <param name="y">Column/Y.</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}