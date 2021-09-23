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
            Square curPos = board.FindPiece(this);
            Square reqPos;
            bool blocked = false;
            if (Player == Player.White)
            {
                reqPos = Square.At(curPos.Row - 1, curPos.Col);
                switch (board.Legal(reqPos))
                {
                    case 1:
                        moves.Add(reqPos);
                        break;
                    case 2:
                        moves.Add(reqPos);
                        blocked = true;
                        break;
                    case 3:
                        blocked = true;
                        break;
                    default:
                        break;
                }
                if (curPos.Row == 6 && !blocked)
                {
                    reqPos = Square.At(curPos.Row - 2, curPos.Col);
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
            }
            if (Player == Player.Black)
            {
                reqPos = Square.At(curPos.Row + 1, curPos.Col);
                switch (board.Legal(reqPos))
                {
                    case 1:
                        moves.Add(reqPos);
                        break;
                    case 2:
                        moves.Add(reqPos);
                        blocked = true;
                        break;
                    case 3:
                        blocked = true;
                        break;
                    default:
                        break;
                }
                if (curPos.Row == 1 && !blocked)
                {
                    reqPos = Square.At(curPos.Row + 2, curPos.Col);
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
            }

            return moves;
        }
    }
}