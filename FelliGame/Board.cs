using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// We'll create a regular 5x5 board and then restrict the player movements
    /// to the desired spots that make the board for this games.
    /// </summary>
    public class Board
    {
        // We can say that the board is made up of state, since the board house
        // will have a given state
        private State[,] board;

        // Create our board for use. For now, it'll be limited to 8 x 8.
        public Board()
        {
            board = new State[5, 5];
        }
    }
}