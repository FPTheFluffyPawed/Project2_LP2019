using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// Class used for rendering in a Console.
    /// </summary>
    public class ConsoleUI
    {
        /// <summary>
        /// The dictionary is used to swap between menus.
        /// </summary>
        private Dictionary<string, string> menus;

        /// <summary>
        /// The List is used to save the current menu the user is in so we can
        /// go back between the menus.
        /// </summary>
        private List<string> historic;

        /// <summary>
        /// Variable to check the current menu option we're at.
        /// </summary>
        private string currentMenu;

        /// <summary>
        /// Initialize our variables.
        /// </summary>
        public ConsoleUI()
        {
            menus = new Dictionary<string, string>();
            historic = new List<string>();
        }

        /// <summary>
        /// Run our entire Menu.
        /// </summary>
        /// <param name="game">Game to play.</param>
        public void RenderConsoleMenu(ConsoleGame game)
        {
            menus.Add("mainMenu", "1 - Start Game\n2 - Instructions\nb - Exit");
            menus.Add("instructions", "*** How does the game work? ***\n" +
                "\nFelliGame is a PvP tabletop game." +
                "\nWhere each player have 6 pieces." +
                "\n6 white pieces are placed on one side of the map, where " +
                "6 black pieces are placed on the opposite side of the map." +
                "\nThe players play in turns." +
                "\nThe players can move the pieces (always following the " +
                "path line) in any direction where exists a free adjacent spot." +
                "\nYou can take out enemy pieces by jumping above them, and " +
                "you'll land on the free spot adjacent to the previous enemy" +
                " spot. (Just like in Checkers.)" +
                "\n\n*** Win conditions ***\n" +
                "\nThe player who takes all the opponent pieces first wins!" +
                "\nIf the current player blocks all the opponent's pieces," +
                " the current player wins!" +
                "\nb - Back");

            currentMenu = "mainMenu";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("FelliGame");
                Console.ResetColor();

                Console.WriteLine(menus[currentMenu]);
                switch (Console.ReadLine())
                {
                    // This option will start the game.
                    case "1":
                        Console.WriteLine("\n*** Game is starting! ***\n");
                        game.Play();
                        Console.WriteLine("\n*** Game is over! ***\n");
                        break;

                    // Open the instructions menu.
                    case "2":
                        if (currentMenu == "mainMenu")
                        {
                            historic.Add(currentMenu);
                            currentMenu = "instructions";
                        }
                        break;

                    // Exit the game, if we're at the top level of our menu.
                    case "b":
                        if (currentMenu == "mainMenu")
                        {
                            Environment.Exit(1);
                        }
                        currentMenu = historic[historic.Count - 1];
                        historic.RemoveAt(historic.Count - 1);
                        break;

                    // Always ask for a valid option while in the menu.
                    default:
                        Console.WriteLine("Insert a valid input!");
                        break;
                }
            }
        }

        /// <summary>
        /// Method that renders out the board with numbers, pieces, along with
        /// the diagonal style that FelliGame has.
        /// </summary>
        /// <param name="board">Board to render.</param>
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

                    // If the position is occupied.
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
                    // If its empty, draw dots!
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
        /// <param name="piece">Piece.</param>
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

        /// <summary>
        /// Render out who won the game..
        /// </summary>
        /// <param name="winner">State to receive.</param>
        public void RenderResults(State winner)
        {
            if (winner == State.White)
                Console.WriteLine("\nWhite wins!");
            else
                Console.WriteLine("\nBlack wins!");
        }
    }
}
