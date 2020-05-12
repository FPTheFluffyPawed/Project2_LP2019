using System.Diagnostics.CodeAnalysis;

namespace FelliGame
{
    public class WinChecker
    {
        public State Check(Board board)
        {
            if (CheckForLose(board, State.Black)) return State.White;
            if (CheckForLose(board, State.White)) return State.Black;
            return State.Blocked;
        }

        private bool CheckForLose(Board board, State player)
        {
            int found = 0;
            int cantMove = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Piece piece = board.GetPiece(new Position(row, column));

                    if(piece != null)
                        if (piece.State == player)
                        {
                            found =+ 1;
                            if (CheckForMove(board, new Position(row, column)))
                                cantMove += 1;
                        }
                }
            }
            if (found != cantMove) return false;
            return true;
        }

        private bool CheckForMove(Board board, Position position)
        {
            if (board.CanMoveAtAll(position)) return true;
            return false;
        }
    }
}