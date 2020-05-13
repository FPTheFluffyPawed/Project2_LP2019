using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// Class used for playing the game on a Console application.
    /// </summary>
    public class ConsoleGame
    {
        /// <summary>
        /// Board to run the game in.
        /// </summary>
        private Board board;

        /// <summary>
        /// Our win condition checker.
        /// </summary>
        private WinChecker winChecker;

        /// <summary>
        /// Renderer to be used for Console.
        /// </summary>
        private ConsoleUI renderer;

        /// <summary>
        /// Menu to open for Console.
        /// </summary>
        //private ConsoleMenu cm;

        /// <summary>
        /// Player 1.
        /// </summary>
        private Player player1;

        /// <summary>
        /// Player 2.
        /// </summary>
        private Player player2;

        /// <summary>
        /// Initialize all the variables needed.
        /// </summary>
        public ConsoleGame()
        {
            board = new Board();
            winChecker = new WinChecker();
            renderer = new ConsoleUI();
            player1 = new Player();
            player2 = new Player();
        }

        /// <summary>
        /// Open the menu associated to ConsoleMenu.
        /// </summary>
        public void Menu()
        {
            renderer.RenderConsoleMenu(this);
        }

        /// <summary>
        /// Play the game!
        /// </summary>
        public void Play()
        {
            string aux;

            // Ask who goes first.
            do
            {
                Console.WriteLine("Who starts, Black (1) or White (2)?");
                aux = Console.ReadLine();

                switch(aux)
                {
                    case "1":
                        Console.WriteLine("Black goes first!\n");
                        break;
                    case "2":
                        Console.WriteLine("White goes first!\n");
                        board.SwitchNextTurn();
                        break;
                    default:
                        Console.WriteLine("Insert a valid option.");
                        aux = null;
                        break;
                }
            } while (aux == null);

            // Set the initial positions.
            board.AssignStates();

            while (winChecker.Check(board) == State.Blocked)
            {
                // Order of things
                // 1 - Render Board
                // 2 - Show available pieces for current player
                // 3 - Ask for piece to move
                // 4 - Which Direction
                // Rinse and repeat until game is over!
                renderer.RenderBoard(board);

                Position nextMove;
                Piece selectedState;

                board.ShowAvailableStates(board.NextTurn);

                if (board.NextTurn == State.Black)
                {
                    Console.WriteLine("Black, it's your turn!");

                    selectedState = board.GetPiece(player1.GetPosition());

                    //We move this state...
                    nextMove = board.Move(selectedState);

                    // Finish.
                }
                else
                {
                    Console.WriteLine("White, it's your turn!");

                    selectedState = board.GetPiece(player2.GetPosition());

                    //We move this state...
                    nextMove = board.Move(selectedState);

                    // Finish.
                }

                // Check if the turn worked out for our player, if this turns
                // false, it will repeat over until the player does it right.
                if (!board.WasTurnSuccesful(selectedState, nextMove))
                {
                    Console.WriteLine("Wrong move, try again!");
                }
            }

            // When the game is over, show the results and the final board.
            renderer.RenderBoard(board);
            renderer.RenderResults(winChecker.Check(board));

            Console.ReadKey();
        }
    }
}
