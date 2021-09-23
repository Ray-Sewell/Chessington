using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        int[][] directions =
        {
            new int[] {2, 1},
            new int[] {2, -1},
            new int[] {-2, 1},
            new int[] {-2, -1},
            new int[] {1, 2},
            new int[] {1, -2},
            new int[] {-1, 2},
            new int[] {-1, -2}
        };
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);
            Square reqPos;
            foreach (int[] direction_raw in directions)
            {
                reqPos = Square.At(curPos.Row + direction_raw[0], curPos.Col + direction_raw[1]);
                switch (board.Legal(reqPos))
                {
                    case 1:
                        moves.Add(reqPos);
                        break;
                    case 2:
                        moves.Add(reqPos);
                        break;
                    default:
                        break;
                }
            }
            return moves;
        }
    }
}