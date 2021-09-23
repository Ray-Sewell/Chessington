using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
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
        public Queen(Player player)
            : base(player) { }
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return GenerateLegalMoves(board, directions);
        }
    }
}