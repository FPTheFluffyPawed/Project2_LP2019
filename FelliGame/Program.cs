using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Start the game by creating a Game, and opening the Menu.
        /// </summary>
        static void Main()
        {
            // Create a new ConsoleGame.
            ConsoleGame game = new ConsoleGame();

            // Open the menu.
            game.Menu();
        }
    }
}
