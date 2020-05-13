using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// A piece in the game that contains a State and a Position.
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// The state of the piece.
        /// </summary>
        public State State { get; private set; }

        /// <summary>
        /// The position of the piece.
        /// </summary>
        public Position Pos { get; set; }

        /// <summary>
        /// Piece.
        /// </summary>
        /// <param name="selectedState">White, Black or Blocked.</param>
        public Piece(State selectedState)
        {
            State = selectedState;
        }
    }
}
