using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class ConsoleRenderer
    {
        public void RenderBoard(Board board)
        {
            char[,] symbols = new char[5, 5];
            for (int row = 0; row < symbols.GetLength(0); row++)
            {
                for (int column = 0; column < symbols.GetLength(1); column++)
                {
                    symbols[row, column] = SymbolFor(
                        board.GetState(new Position(row, column)));
                    Console.Write(symbols[row, column]);
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
        private char SymbolFor(State state)
        {
            switch (state)
            {
                case State.Black: return 'B';
                case State.White: return 'W';
                default: return ' ';
            }
        }
    }
}
