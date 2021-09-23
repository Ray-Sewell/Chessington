using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        int[][] directions =
        {
            new int[] {1, 1},
            new int[] {1, -1},
            new int[] {-1, 1},
            new int[] {-1, -1}
        };
        public Bishop(Player player)
            : base(player) { }
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return GenerateLegalMoves(board, directions);
        }
    }
}