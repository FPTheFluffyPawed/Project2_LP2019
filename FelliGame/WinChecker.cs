using System.Diagnostics.CodeAnalysis;

namespace FelliGame
{
    public class WinChecker
    {
        public State Check(Board board)
        {
            if (CheckForWin(board, State.Black)) return State.White;
            if (CheckForWin(board, State.White)) return State.Black;
            return State.Undecided;
        }

        private bool CheckForWin(Board board, State player)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (board.GetState(new Position(row, column)) == player)
                    {
                        if (board.checkMove())
                        {
                            return true;
                        }
                        return false;
                    }    
                }
            }
            return true;
        }
}