using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);

            for (int i = 0; i <= 7; i++)
            {
                moves.Add(Square.At(curPos.Row, i));
                moves.Add(Square.At(i, curPos.Col));
            }

            return moves;
        }
    }
}