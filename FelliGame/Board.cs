using System;
using System.Collections.Generic;
using System.Text;

namespace FelliGame
{
    /// <summary>
    /// We'll create a regular 5x5 board and then restrict the player movements
    /// to the desired spots that make the board for this games.
    /// </summary>
    public class Board
    {
        // We can say that the board is made up of state, since the board house
        // will have a given state
        private Piece[,] board;

        public State NextTurn { get; private set; }

        // Create our board for use. For now, it'll be limited to 5 x 5.
        // It will automatically assign the states to the proper locations.
        public Board()
        {
            board = new Piece[5, 5];
            NextTurn = State.Black;
            AssignStates();
        }

        /// <summary>
        /// Used to check if a piece can move in any direction.
        /// WIP: Check if there is a free spot past the actual piece.
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool CanMoveAtAll(Position currentPos)
        {
            // WIP: Later on to check if there is a spot to "eat"
            // should also ask for the currentPiece's state as well
            // then we can use ifs to check!
            //
            // If it's white, use GetPiece to check for the opponent
            //
            // This is just so we can't hop over our own pieces to "eat",
            // because that makes no sense.

            Position[] possiblePositions = new Position[8];

            // All possible movement positions go here.
            possiblePositions[0] = new Position(
                currentPos.X - 1, currentPos.Y - 1);
            possiblePositions[1] = new Position(
                currentPos.X, currentPos.Y - 1);
            possiblePositions[2] = new Position(
                currentPos.X + 1, currentPos.Y - 1);
            possiblePositions[3] = new Position(
                currentPos.X - 1, currentPos.Y);
            possiblePositions[4] = new Position(
                currentPos.X + 1, currentPos.Y);
            possiblePositions[5] = new Position(
                currentPos.X - 1, currentPos.Y + 1);
            possiblePositions[6] = new Position(
                currentPos.X, currentPos.Y + 1);
            possiblePositions[7] = new Position(
                currentPos.X + 1, currentPos.Y + 1);

            for (int i = 0; i < possiblePositions.Length; i++)
                if (!IsOccupied(possiblePositions[i]))
                    return true;
            return false;
        }

        public Position Move(Piece selectedPiece)
        {
            // The position to move towards...
            Position moveTo;
            // Auxiliary string for input.
            string aux;

            do
            {

                Console.WriteLine("Which direction?");
                Console.WriteLine("Up/Left (1) | Up/Middle (2) | Up/Right (3)");
                Console.WriteLine("Middle/Left (4) | Middle/Right (5)");
                Console.WriteLine("Lower/Left (6) | Lower/Middle (7) |" +
                    " Lower/Right (8)");
                aux = Console.ReadLine();

                switch(aux)
                {
                    case "1":
                        moveTo = new Position(selectedPiece.Pos.X - 1, selectedPiece.Pos.Y - 1);
                        if(CanMoveToLocation(moveTo))
                        {
                            MovePiece(selectedPiece, moveTo);
                            selectedPiece.Pos = moveTo;
                            break;
                        }
                        aux = null;
                        break;
                }

                // Check for available movement options,
                // and only print out the possible ones.

            } while (aux == null);
        }

        private void MovePiece(Piece piece, Position position)
        {
            // Place the piece in the desired location.
            board[position.X, position.Y] = piece;

            // Remove the origin.
            board[piece.Pos.X, piece.Pos.Y] = null;
        }

        public bool SetState(Position position, State newState)
        {
            if (newState != NextTurn) return false;
            if (IsOccupied(position)) return false;

            SwitchNextTurn();
            return true;
        }

        public void ShowAvailableStates(State currentPlayer)
        {
            int number = 0;

            // This will run through the board and
            // check which ones can move. Printing
            // Out the relevant pieces
            Console.WriteLine("\nPossible positions:");
            for (int x = 0; x < board.GetLength(0); x++)
                for(int y = 0; y < board.GetLength(1); y++)
                {
                    Position position = new Position(x, y);

                    if(IsOccupied(position))
                    {
                        if(GetPiece(position).State == State.Black)
                        {
                            if (CanMoveAtAll(position))
                            {
                                Console.WriteLine($"({number}) - {x + 1}, {y + 1}");
                            }
                        }
                    }

                    number++;
                }
            Console.WriteLine();
        }

        public Piece GetPiece(Position position)
        {
            return board[position.X, position.Y];
        }

        public bool IsOccupied(Position pos)
        {
            // Check if the position is out of bounds of the board.
            if (pos.Y > board.GetLength(1) - 1 || pos.Y < 0
                || pos.X > board.GetLength(0) || pos.X < 0)
                return true;
            // Else if the position is simply null, meaning that its a free
            // spot.
            else
                return board[pos.X, pos.Y] != null;
        }

        public bool CanMoveToLocation(Position destination)
        {
            if (IsOccupied(destination))
            {
                Console.WriteLine("This piece can't move there!");
                return false;
            }
            else
                return true;
        }

        private void SwitchNextTurn()
        {
            if (NextTurn == State.Black) NextTurn = State.White;
            else NextTurn = State.Black;
        }

        private Piece SetInitialLocation(int x, int y, State state)
        {
            Piece piece = new Piece(state);
            piece.Pos = new Position(x, y);
            return board[x, y] = piece;
        }

        private void AssignStates()
        {
            // Since the default state of the board is always the same,
            // there just isn't any other way to go around this.
            // WIP: Could be iterated instead of hard-coded? Probably not worth
            // the trouble.

            // From top to down.
            // BLACK SIDE
            SetInitialLocation(0, 0, State.Black);
            SetInitialLocation(0, 2, State.Black);
            SetInitialLocation(0, 4, State.Black);
            SetInitialLocation(1, 1, State.Black);
            SetInitialLocation(1, 2, State.Black);
            SetInitialLocation(1, 3, State.Black);

            // WHITE SIDE
            SetInitialLocation(3, 1, State.White);
            SetInitialLocation(3, 2, State.White);
            SetInitialLocation(3, 3, State.White);
            SetInitialLocation(4, 0, State.White);
            SetInitialLocation(4, 2, State.White);
            SetInitialLocation(4, 4, State.White);

            // BLOCKED
            SetInitialLocation(1, 0, State.Blocked);
            SetInitialLocation(1, 4, State.Blocked);
            SetInitialLocation(2, 0, State.Blocked);
            SetInitialLocation(2, 1, State.Blocked);
            SetInitialLocation(2, 3, State.Blocked);
            SetInitialLocation(2, 4, State.Blocked);
            SetInitialLocation(3, 0, State.Blocked);
            SetInitialLocation(3, 4, State.Blocked);
        }
    }
}