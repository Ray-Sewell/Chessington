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
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);
            Square reqPos;
            int[][] directions =
            {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {-1, 0},
                new int[] {0, -1},
                new int[] {1, 1},
                new int[] {1, -1},
                new int[] {-1, 1},
                new int[] {-1, -1}
            };
            foreach (int[] direction_raw in directions)
            {
                bool blocked = false;
                int[] direction = new int[] { direction_raw[0], direction_raw[1] };
                while (!blocked)
                {
                    reqPos = Square.At(curPos.Row + direction[0], curPos.Col + direction[1]);
                    switch (board.Legal(reqPos))
                    {
                        case 1:
                            moves.Add(reqPos);
                            break;
                        case 2:
                            moves.Add(reqPos);
                            blocked = true;
                            break;
                        default:
                            blocked = true;
                            break;
                    }
                    direction[0] += direction_raw[0];
                    direction[1] += direction_raw[1];
                }
            }

            return moves;
        }
    }
}