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

            if (Player == Player.White)
            {
                reqPos = Square.At(curPos.Row - 1, curPos.Col);
                if (board.WithinRange(reqPos))
                {
                    if (!board.ExistingPiece(reqPos))
                    {
                        moves.Add(reqPos);
                        if (curPos.Row == 6)
                        {
                            reqPos = Square.At(curPos.Row - 2, curPos.Col);
                            if (!board.ExistingPiece(reqPos))
                            {
                                moves.Add(reqPos);
                            }
                        }
                    }
                }
                reqPos = Square.At(curPos.Row - 1, curPos.Col + 1);
                if (board.WithinRange(reqPos) && board.ExistingPiece(reqPos) && !board.CheckFriendly(this, reqPos))
                {
                    moves.Add(reqPos);
                }
                reqPos = Square.At(curPos.Row - 1, curPos.Col - 1);
                if (board.WithinRange(reqPos) && board.ExistingPiece(reqPos) && !board.CheckFriendly(this, reqPos))
                {
                    moves.Add(reqPos);
                }
            } 
            else
            {
                reqPos = Square.At(curPos.Row + 1, curPos.Col);
                if (board.WithinRange(reqPos))
                {
                    if (!board.ExistingPiece(reqPos))
                    {
                        moves.Add(reqPos);
                        if (curPos.Row == 1)
                        {
                            reqPos = Square.At(curPos.Row + 2, curPos.Col);
                            if (!board.ExistingPiece(reqPos))
                            {
                                moves.Add(reqPos);
                            }
                        }
                    }
                }
                reqPos = Square.At(curPos.Row + 1, curPos.Col + 1);
                if (board.WithinRange(reqPos) && board.ExistingPiece(reqPos) && !board.CheckFriendly(this, reqPos))
                {
                    moves.Add(reqPos);
                }
                reqPos = Square.At(curPos.Row + 1, curPos.Col - 1);
                if (board.WithinRange(reqPos) && board.ExistingPiece(reqPos) && !board.CheckFriendly(this, reqPos))
                {
                    moves.Add(reqPos);
                }
            }
            
            return moves;
        }
    }
}