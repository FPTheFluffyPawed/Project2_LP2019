using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class ConsoleRenderer
    {

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
