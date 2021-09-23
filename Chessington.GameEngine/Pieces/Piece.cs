using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
        public List<Square> GenerateLegalMoves(Board board, int[][] directions)
        {
            List<Square> moves = new List<Square>();
            Square curPos = board.FindPiece(this);
            Square reqPos;
            foreach (int[] direction_raw in directions)
            {
                bool blocked = false;
                int[] direction = new int[] { direction_raw[0], direction_raw[1] };
                while (!blocked)
                {
                    reqPos = Square.At(curPos.Row + direction[0], curPos.Col + direction[1]);
                    
                    if (board.WithinRange(reqPos))
                    {
                        if(board.ExistingPiece(reqPos))
                        {
                            if(board.CheckFriendly(this, reqPos))
                            {
                                blocked = true;
                                
                            } else
                            {
                                moves.Add(reqPos);
                                blocked = true;
                            }
                        } else
                        {
                            moves.Add(reqPos);
                        }
                    } else
                    {
                        blocked = true;
                    }
                    
                    direction[0] += direction_raw[0];
                    direction[1] += direction_raw[1];
                }
            }
            return moves;
        }
    }
}