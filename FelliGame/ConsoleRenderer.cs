using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class ConsoleRenderer
    {
        public void RenderBoard(Board board)
        {
            char[,] symbols = new char[5, 3];
            Console.WriteLine("   0  1  2");
            for (int row = 0; row < symbols.GetLength(0); row++)
            {
                Console.Write("{0} ", row);
                for (int column = 0; column < symbols.GetLength(1); column++)
                {
                    Position position = new Position(row, column);

                    if (board.IsOccupied(position))
                    {
                        symbols[row, column] = SymbolFor(
                            board.GetPiece(new Position(row, column)).State);
                        Console.Write(" {0} ", symbols[row, column]);
                    }
                    else
                        Console.Write(" . ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Check the Pieces in that position and render
        /// out the correct symbol.
        /// </summary>
        /// <param name="state">Piece.</param>
        /// <returns>A char.</returns>
        private char SymbolFor(State piece)
        {
            if (piece == State.Black)
                return 'B';
            else if (piece == State.White)
                return 'W';
            else if (piece == State.Blocked)
                return ' ';
            else
                return '.';
        }

        public void RenderResults(State winner)
        {
            if (winner == State.White)
                Console.WriteLine("\nWhite wins!");
            else
                Console.WriteLine("\nBlack wins!");
        }
    }
}
