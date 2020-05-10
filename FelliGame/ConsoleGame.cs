using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    public class ConsoleGame
    {
        Board board = new Board();
        WinChecker winChecker = new WinChecker();
        ConsoleRenderer renderer = new ConsoleRenderer();
        Player player1 = new Player();
        Player player2 = new Player();

        public void Play()
        {
            //string aux;

            while(true)
            {
                // Order of things
                // 1 - Render Board
                // 2 - Show available pieces for current player
                // 3 - Ask for piece to move
                // 4 - Which Direction
                // Rinse and repeat until game is over
                renderer.RenderBoard(board);

                Position nextMove;
                Piece selectedState;

                //board.ShowAvailableStates(board.NextTurn);

                //if (board.NextTurn == State.Black)
                //{
                Console.WriteLine("Black, it's your turn!");
                board.ShowAvailableStates(State.Black);

                Console.WriteLine("Which piece to move?");
                selectedState = board.GetPiece(player1.GetPosition());

                //We move this state...
                nextMove = board.Move(selectedState);

                // Finish.
                //}

                // Check if the turn worked out for our player, if this turns
                // false, it will repeat over until the player does it right.
                if(!board.SetState(nextMove, board.NextTurn))
                {
                    Console.WriteLine("Illegal move!");
                }



            }

            renderer.RenderBoard(board);
            //renderer.RenderResults(winChecker.Check(board));

            Console.ReadKey();
        }
    }
}
