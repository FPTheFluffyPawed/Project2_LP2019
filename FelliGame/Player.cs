using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class Player
    {
        public Position GetPosition(Board board)
        {
            int position = Int32.Parse(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position);
            return desiredCoordinate;
        }
        
        private Position PositionForNumber(int position)
        {
            switch (position)
            {
                // return each position of the board
                // then the blocked positions will be set as invalid to play
                case 1: return new Position(0, 0); 
                case 2: return new Position(0, 1);
                case 3: return new Position(0, 2);
                case 4: return new Position(0, 3);
                case 5: return new Position(0, 4);
                case 6: return new Position(1, 1);
                case 7: return new Position(1, 2);
                case 8: return new Position(1, 3);
                case 9: return new Position(2, 2);
                case 10: return new Position(3, 1);
                case 11: return new Position(3, 2);
                case 12: return new Position(3,3);
                case 13: return new Position(4,0);
                case 14: return new Position(4,2);
                case 15: return new Position(4,3);
                case 16: return new Position(4,4);
                default: return null; // All the other positions "dont exist"
            }
        }
    }
}