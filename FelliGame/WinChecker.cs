using System.Diagnostics.CodeAnalysis;

namespace FelliGame
{
    public class WinChecker
    {
        public State Check(Board board)
        {
            if (CheckForLose(board, State.Black)) return State.White;
            if (CheckForLose(board, State.White)) return State.Black;
            return State.Undecided;
        }

        private bool CheckForLose(Board board, State player)
        {
            int found = 0;
            int cantMove = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (board.GetState(new Position(row, column)) == player)
                    {
                        found =+ 1;
                        if (CheckForMove(board, player)) cantMove += 1;
                    }
                }
            }
            if (found != cantMove) return false;
            return true;
        }

        private bool CheckForMove(Board board, State player)
        {
            if (board.CanMove(player)) return false;

            return true;
        }
    }
}