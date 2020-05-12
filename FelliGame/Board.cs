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
            board = new Piece[5, 3];
            NextTurn = State.Black;
            AssignStates();
        }

        private bool IsPieceInCenter(Position pos)
        {
            // Center is (2, 1).
            // Additionally, 
            if ((pos.X == 2 && pos.Y == 1)
                || (pos.X == 1 && pos.Y == 0)
                || (pos.X == 1 && pos.Y == 2)
                || (pos.X == 3 && pos.Y == 0)
                || (pos.X == 3 && pos.Y == 2))
                return true;
            else
                return false;
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

            // If the piece is in the center, we'll add the diagonal movement
            // to check as well.
            int possiblePos;

            if (IsPieceInCenter(currentPos))
                possiblePos = 8;
            else
                possiblePos = 4;

            // Create the possible positions.
            Position[] possiblePositions = new Position[possiblePos];

            // Add our possible positions.
            // Upper Middle.
            possiblePositions[0] = new Position(
                currentPos.X - 1, currentPos.Y);
            // Middle Left.
            possiblePositions[1] = new Position(
                currentPos.X, currentPos.Y - 1);
            // Middle Right.
            possiblePositions[2] = new Position(
                currentPos.X, currentPos.Y + 1);
            // Lower Middle.
            possiblePositions[3] = new Position(
                currentPos.X + 1, currentPos.Y);

            // If the piece is in the center, add the diagonal options.
            if (IsPieceInCenter(currentPos))
            {
                // Lower Right.
                possiblePositions[4] = new Position(
                    currentPos.X + 1, currentPos.Y + 1);

                // Lower Left.
                possiblePositions[5] = new Position(
                    currentPos.X - 1, currentPos.Y + 1);

                // Upper Right.
                possiblePositions[6] = new Position(
                    currentPos.X + 1, currentPos.Y - 1);

                // Upper Left.
                possiblePositions[7] = new Position(
                    currentPos.X - 1, currentPos.Y - 1);
            }

            // For every possible position, check if they aren't occupied.
            // If not, return true immediately since there's a free spot.
            //
            // For our checking if the piece in there is beyond, we must return
            // true here.
            for (int i = 0; i < possiblePositions.Length; i++)
                if (CanMoveToLocation(possiblePositions[i]))
                        return true;
            return false;
        }

        public Position Move(Piece selectedPiece)
        {
            // The converted input.
            int convertedAux = 0;

            // Boolean to check if the output convertion worked..
            bool convertSuccesful = false;

            // Invalid position to say that it was a failed move.
            Position blockedPosition = new Position(0, 2);

            // Array of possible destinations.
            Position[] destinations = new Position[8];

            // Add our possible positions.
            // Upper Middle.
            destinations[0] = new Position(
                selectedPiece.Pos.X - 1, selectedPiece.Pos.Y);
            // Middle Left.
            destinations[1] = new Position(
                selectedPiece.Pos.X, selectedPiece.Pos.Y - 1);
            // Middle Right.
            destinations[2] = new Position(
                selectedPiece.Pos.X, selectedPiece.Pos.Y + 1);
            // Lower Middle.
            destinations[3] = new Position(
                selectedPiece.Pos.X + 1, selectedPiece.Pos.Y);

            // If the piece is in the center, add the diagonal options.
            if (IsPieceInCenter(selectedPiece.Pos))
            {
                // Lower Right.
                destinations[4] = new Position(
                    selectedPiece.Pos.X + 1, selectedPiece.Pos.Y + 1);

                // Lower Left.
                destinations[5] = new Position(
                    selectedPiece.Pos.X - 1, selectedPiece.Pos.Y + 1);

                // Upper Right.
                destinations[6] = new Position(
                    selectedPiece.Pos.X + 1, selectedPiece.Pos.Y - 1);

                // Upper Left.
                destinations[7] = new Position(
                    selectedPiece.Pos.X - 1, selectedPiece.Pos.Y - 1);
            }

            Console.WriteLine("Which direction?");

            Console.WriteLine("Up/Middle (1) | Middle/Left (2) |" +
                " Middle/Right (3) | Lower/Middle (4)");

            // If our piece is in the middle, it can move diagonally.
            if (IsPieceInCenter(selectedPiece.Pos))
                Console.WriteLine("Lower/Right (5) | Lower/Left (6) |" +
                    " Upper/Right (7) | Upper/Left (8)");

            while(!convertSuccesful)
            {
                Console.Write("Which direction? (Insert a valid option.)");
                convertSuccesful = int.TryParse(Console.ReadLine(),
                    out convertedAux)
                    && (convertedAux > 0 && convertedAux <= 8);
            }

            // Adjust for our ForLoop.
            convertedAux--;

            for(int i = 0; i <= destinations.Length; i++)
            {
                if(i == convertedAux)
                {
                    if(IsOccupied(destinations[i]))
                    {
                        if(CanEat(destinations[i]))
                        {
                            return JumpPosition(convertedAux, destinations[i]);
                        }
                    }
                    else
                        return destinations[i];
                }
            }
            return blockedPosition;
        }

        private Position JumpPosition(int option, Position position)
        {
            board[position.X, position.Y] = null;

            switch (option)
            {
                case 0:
                    return new Position(position.X - 2, position.Y);
                case 1:
                    return new Position(position.X, position.Y - 2);
                case 2:
                    return new Position(position.X, position.Y + 2);
                case 3:
                    return new Position(position.X + 2, position.Y);
                case 4:
                    return new Position(position.X + 2, position.Y + 2);
                case 5:
                    return new Position(position.X - 2, position.Y + 2);
                case 6:
                    return new Position(position.X + 2, position.Y - 2);
                default:
                    return new Position(position.X - 2, position.Y - 2);
            }
        }

        private void MovePiece(Piece piece, Position position)
        {
            // Place the piece in the desired location.
            board[position.X, position.Y] = piece;

            // Remove the origin.
            board[piece.Pos.X, piece.Pos.Y] = null;
        }

        public bool WasTurnSuccesful(Piece piece, Position position)
        {
            // If this spot is occupied, return it as false.
            if (IsOccupied(position)) return false;

            // Else, we move the position and then move onto next turn.
            MovePiece(piece, position);
            SwitchNextTurn();
            return true;
        }

        public void ShowAvailableStates(State currentPlayer)
        {
            int number = 0;

            // This will run through the board and
            // check which ones can move. Printing
            // Out the relevant pieces
            Console.WriteLine("\nAvailable pieces for movement:");
            for (int x = 0; x < board.GetLength(0); x++)
                for(int y = 0; y < board.GetLength(1); y++)
                {
                    Position position = new Position(x, y);
                    number++;

                    if (!IsOccupied(position))
                    {
                        if(GetPiece(position).State == currentPlayer)
                        {
                            if (CanMoveAtAll(position))
                            {
                                Console.WriteLine($"({number}) - {x}, {y}");
                            }
                        }
                    }
                }
            Console.WriteLine();
        }

        public Piece GetPiece(Position position)
        {
            return board[position.X, position.Y];
        }

        public bool IsOccupied(Position pos)
        {

            if (pos.Y > board.GetLength(1) - 1 || pos.Y < 0 ||
                pos.X > board.GetLength(0) - 1 || pos.X < 0)
                return true;

            else
                return board[pos.X, pos.Y] != null;
        }

        private bool CanMoveToLocation(Position destination)
        {
            if (IsOccupied(destination))
            {
                if (CanEat(destination))
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public bool CanEat(Position currentPos)
        {
            // WIP: Later on to check if there is a spot to "eat"
            // should also ask for the currentPiece's state as well
            // then we can use ifs to check!
            //
            // If it's white, use GetPiece to check for the opponent
            //
            // This is just so we can't hop over our own pieces to "eat",
            // because that makes no sense.

            // If the piece is in the center, we'll add the diagonal movement
            // to check as well.

            // Create the possible positions.
            Position[] possiblePositions = new Position[8];

            // Add our possible positions.

            // Upper Left.
            possiblePositions[0] = new Position(
                currentPos.X - 1, currentPos.Y - 1);

            // Upper Middle.
            possiblePositions[1] = new Position(
                currentPos.X - 1, currentPos.Y);

            // Upper Right.
            possiblePositions[2] = new Position(
                currentPos.X - 1, currentPos.Y + 1);

            // lower right.
            possiblePositions[3] = new Position(
                currentPos.X + 1, currentPos.Y + 1);

            // Lower Middle.
            possiblePositions[4] = new Position(
                currentPos.X + 1, currentPos.Y);

            // Lower Left.
            possiblePositions[5] = new Position(
                currentPos.X + 1, currentPos.Y - 1);

            // Middle Left.
            possiblePositions[6] = new Position(
                currentPos.X, currentPos.Y - 1);

            // Middle Right.
            possiblePositions[7] = new Position(
                currentPos.X, currentPos.Y + 1);

            for (int i = 0; i < possiblePositions.Length; i++)
                if (possiblePositions[i].Y < board.GetLength(1) - 1 || possiblePositions[i].Y > 0 ||
                    possiblePositions[i].X < board.GetLength(0) - 1 || possiblePositions[i].X > 0)
                    if (GetPiece(currentPos).State == State.White)
                    {
                        if (GetPiece(possiblePositions[i]).State == State.Black)
                        {
                            if (i == 0)
                                if (!IsOccupied(possiblePositions[3]))
                                    return true;
                            if (i == 1)
                                if (!IsOccupied(possiblePositions[4]))
                                    return true;
                            if (i == 2)
                                if (!IsOccupied(possiblePositions[5]))
                                    return true;
                            if (i == 3)
                                if (!IsOccupied(possiblePositions[0]))
                                    return true;
                            if (i == 4)
                                if (!IsOccupied(possiblePositions[1]))
                                    return true;
                            if (i == 5)
                                if (!IsOccupied(possiblePositions[2]))
                                    return true;
                            if (i == 6)
                                if (!IsOccupied(possiblePositions[7]))
                                    return true;
                            if (i == 7)
                                if (!IsOccupied(possiblePositions[6]))
                                    return true;
                        }
                    }

                    else if (GetPiece(possiblePositions[i]).State == State.Black)
                    {
                            if (i == 0)
                                if (!IsOccupied(possiblePositions[3]))
                                    return true;
                            if (i == 1)
                                if (!IsOccupied(possiblePositions[4]))
                                    return true;
                            if (i == 2)
                                if (!IsOccupied(possiblePositions[5]))
                                    return true;
                            if (i == 3)
                                if (!IsOccupied(possiblePositions[0]))
                                    return true;
                            if (i == 4)
                                if (!IsOccupied(possiblePositions[1]))
                                    return true;
                            if (i == 5)
                                if (!IsOccupied(possiblePositions[2]))
                                    return true;
                            if (i == 6)
                                if (!IsOccupied(possiblePositions[7]))
                                    return true;
                            if (i == 7)
                                if (!IsOccupied(possiblePositions[6]))
                                    return true;
                    }

                    return false;
        }

        public void SwitchNextTurn()
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
            SetInitialLocation(0, 1, State.Black);
            SetInitialLocation(0, 2, State.Black);
            SetInitialLocation(1, 0, State.Black);
            SetInitialLocation(1, 1, State.Black);
            SetInitialLocation(1, 2, State.Black);

            // WHITE SIDE
            SetInitialLocation(3, 0, State.White);
            SetInitialLocation(3, 1, State.White);
            SetInitialLocation(3, 2, State.White);
            SetInitialLocation(4, 0, State.White);
            SetInitialLocation(4, 1, State.White);
            SetInitialLocation(4, 2, State.White);

            // BLOCKED
            SetInitialLocation(2, 0, State.Blocked);
            SetInitialLocation(2, 2, State.Blocked);
        }
    }
}