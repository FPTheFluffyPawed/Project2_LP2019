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

        // Create our board for use. For now, it'll be limited to 5 x 5.
        // It will automatically assign the states to the proper locations.
        public Board()
        {
            board = new State[5, 5];
            AssignStates();
        }

        public State GetState(Position position)
        {
            return board[position.X, position.Y];
        }

        private void AssignStates()
        {
            // Since the default state of the board is always the same,
            // there just isn't any other way to go around this.
            // WIP: Could be iterated instead of hard-coded? Probably not worth
            // the trouble.

            // From top to down.
            // BLACK SIDE
            board[0, 0] = State.Black;
            board[0, 2] = State.Black;
            board[0, 4] = State.Black;
            board[1, 1] = State.Black;
            board[1, 2] = State.Black;
            board[1, 3] = State.Black;

            // WHITE SIDE
            board[3, 1] = State.White;
            board[3, 2] = State.White;
            board[3, 3] = State.White;
            board[4, 0] = State.White;
            board[4, 2] = State.White;
            board[4, 4] = State.White;

            // Block the non-playable locations.
            board[1, 0] = State.Blocked;
            board[1, 4] = State.Blocked;
            board[2, 0] = State.Blocked;
            board[2, 1] = State.Blocked;
            board[2, 3] = State.Blocked;
            board[2, 4] = State.Blocked;
            board[3, 0] = State.Blocked;
            board[3, 4] = State.Blocked;
        }
    }
}