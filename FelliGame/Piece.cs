using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class Piece
    {
        // Character to represent the piece.
        public char Symbol { get; protected set; }

        // Color to represent the pieces.
        public ConsoleColor Color { get; set; }

        // The Piece's position.
        public Position Pos { get; set; }

        /// <summary>
        /// The constructor that asks for a color and assigns 'S' to the
        /// Symbol.
        /// </summary>
        /// <param name="color">Color to represent this as.</param>
        public Piece(ConsoleColor color)
        {
            Symbol = 'O';
            Color = color;
        }

        /*public Position GetPosition(Board board)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position);
            return desiredCoordinate;
        }*/
        private Position PositionForNumber(int position)
        {
            switch (position)
            {
                case 1:
                    // return each position of the board
                    // then the blocked positions will be set as invalid to play
                default:
                    break;
            }
        }
    }
}