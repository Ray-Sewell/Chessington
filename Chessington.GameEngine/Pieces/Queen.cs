using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves_raw = new List<Square>();
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);
            for (int i = 0; i <= 7; i++)
            {
                moves_raw.Add(Square.At(curPos.Row + i, curPos.Col - i));
                moves_raw.Add(Square.At(curPos.Row + i, curPos.Col + i));
                moves_raw.Add(Square.At(curPos.Row - i, curPos.Col - i));
                moves_raw.Add(Square.At(curPos.Row - i, curPos.Col + i));
                moves_raw.Add(Square.At(curPos.Row, i));
                moves_raw.Add(Square.At(i, curPos.Col));
            }
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