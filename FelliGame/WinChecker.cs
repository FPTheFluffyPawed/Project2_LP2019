using System.Diagnostics.CodeAnalysis;

namespace FelliGame
{
    /// <summary>
    /// Win condition checker for the game.
    /// </summary>
    public class WinChecker
    {
        /// <summary>
        /// This method checks if any player won.
        /// </summary>
        /// <param name="board">Board to check.</param>
        /// <returns>Returns a State.</returns>
        public State Check(Board board)
        {
            if (CheckForLose(board, State.Black)) return State.White;
            if (CheckForLose(board, State.White)) return State.Black;
            return State.Blocked;
        }

        /// <summary>
        /// This methods verifies if the selected player activated any 
        /// of the lose conditions.
        /// </summary>
        /// <param name="board">Board to check.</param>
        /// <param name="player">Player to check if they lost.</param>
        /// <returns>True if they lost, false if not.</returns>
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
                            found += 1;
                            if (CheckForMove(board, new Position(row, column)))
                                cantMove += 1;
                        }
                }
            }
            if (found == cantMove) return true;
            if (found == 0) return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the current Piece has any move available.
        /// </summary>
        /// <param name="board">Board to check.</param>
        /// <param name="position">Position to check.</param>
        /// <returns></returns>
        private bool CheckForMove(Board board, Position position)
        {
            if (board.CanMoveAtAll(position)) return false;
            return true;
        }
    }
}