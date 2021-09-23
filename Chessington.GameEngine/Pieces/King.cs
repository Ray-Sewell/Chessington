using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves_raw = new List<Square>();
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);

            moves_raw.Add(Square.At(curPos.Row + 1, curPos.Col));
            moves_raw.Add(Square.At(curPos.Row - 1, curPos.Col));
            moves_raw.Add(Square.At(curPos.Row, curPos.Col + 1));
            moves_raw.Add(Square.At(curPos.Row, curPos.Col - 1));
            moves_raw.Add(Square.At(curPos.Row + 1, curPos.Col + 1));
            moves_raw.Add(Square.At(curPos.Row + 1, curPos.Col - 1));
            moves_raw.Add(Square.At(curPos.Row - 1, curPos.Col + 1));
            moves_raw.Add(Square.At(curPos.Row - 1, curPos.Col - 1));

            foreach (Square move in moves_raw)
            {
                if (Board.Legal(move) && curPos != move)
                {
                    moves.Add(move);
                }
            }
            return moves;
        }
    }
}