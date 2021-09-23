using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            // find current location
            Square currentPosition = board.FindPiece(this);
            var availableSquares = new List<Square>();

            if (Player == Player.White)
            {
                moves.Add(Square.At(currentPosition.Row - 1, currentPosition.Col));
                if (currentPosition.Row == 6)
                {
                    moves.Add(Square.At(currentPosition.Row - 2, currentPosition.Col));
                } 
            }
            if (Player == Player.Black)
            {
                moves.Add(Square.At(currentPosition.Row + 1, currentPosition.Col));
                if (currentPosition.Row == 1)
                {
                    moves.Add(Square.At(currentPosition.Row + 2, currentPosition.Col));
                }
            }

            foreach (Square move in moves)
            {
                availableSquares.Add(move);
            }
            return availableSquares;
        }
    }
}