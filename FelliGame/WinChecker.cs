using System.Diagnostics.CodeAnalysis;

namespace FelliGame
{
    /// <summary>
    /// This class verifies if there was any winner
    /// </summary>
    public class WinChecker
    {
        /// <summary>
        /// This method checks if any player won
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public State Check(Board board)
        {
            if (CheckForLose(board, State.Black)) return State.White;
            if (CheckForLose(board, State.White)) return State.Black;
            return State.Blocked;
        }

        /// <summary>
        /// This methods verifies if the selected player activated any 
        /// of the lose conditions
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method verifies if the corrent piece has any move avaible
        /// </summary>
        /// <param name="board"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool CheckForMove(Board board, Position position)
        {
            if (board.CanMoveAtAll(position)) return true;
            return false;
        }
    }
}