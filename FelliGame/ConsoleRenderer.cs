using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class ConsoleRenderer
    {
        public void RenderBoard(Board board)
        {
            string[,] symbols = new string[5, 3];
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
                        if(row == 1 || row == 3) Console.Write(" ");
                        if(column == 0 && (row == 1 || row == 3))
                            Console.Write(" "); 
                        if (row == 0 || row == 4) 
                            Console.Write(" {0} ", symbols[row, column]);
                        else Console.Write(symbols[row, column]);
                    }
                    else
                    {
                        if(row < 2) Console.Write(" .");
                        if(row == 2) Console.Write(".");
                        if(row > 2) Console.Write(" .");
                    }   
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
        private string SymbolFor(State piece)
        {
            if (piece == State.Black)
                return "B";
            else if (piece == State.White)
                return "W";
            else if (piece == State.Blocked)
                return "    ";
            else
                return ".";
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
