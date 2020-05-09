using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class Player
    {
        // The Piece's position.
        public Position Pos { get; set; }

        /*public Position GetPosition(Board board)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position);
            return desiredCoordinate;
        }*/
        /*private Position PositionForNumber(int position)
        {
            switch (position)
            {
                case 1:
                    // return each position of the board
                    // then the blocked positions will be set as invalid to play
                default:
                    break;
            }
        }*/
    }
}