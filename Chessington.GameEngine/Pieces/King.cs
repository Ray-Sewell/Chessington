using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        int[][] directions =
        {
            new int[] {1, -1},
            new int[] {1, 1},
            new int[] {-1, -1},
            new int[] {-1, 1},
            new int[] {1, 0},
            new int[] {0, 1},
            new int[] {-1, 0},
            new int[] {0, -1}
        };
        public King(Player player)
            : base(player) { }
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);
            Square reqPos;

            foreach (int[] direction_raw in directions)
            {
                reqPos = Square.At(curPos.Row + direction_raw[0], curPos.Col + direction_raw[1]);
                if (board.WithinRange(reqPos))
                {
                    if (board.ExistingPiece(reqPos))
                    {
                        if (!board.CheckFriendly(this, reqPos))
                        {
                            moves.Add(reqPos);
                        }
                    }
                    else
                    {
                        moves.Add(reqPos);
                    }
                }
            }
            return moves;
        }
    }
}