using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves_raw = new List<Square>();
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);

            moves_raw.Add(Square.At(curPos.Row + 1, curPos.Col + 2));
            moves_raw.Add(Square.At(curPos.Row + 2, curPos.Col + 1));
            moves_raw.Add(Square.At(curPos.Row - 1, curPos.Col + 2));
            moves_raw.Add(Square.At(curPos.Row - 2, curPos.Col + 1));
            moves_raw.Add(Square.At(curPos.Row + 1, curPos.Col - 2));
            moves_raw.Add(Square.At(curPos.Row + 2, curPos.Col - 1));
            moves_raw.Add(Square.At(curPos.Row - 1, curPos.Col - 2));
            moves_raw.Add(Square.At(curPos.Row - 2, curPos.Col - 1));

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