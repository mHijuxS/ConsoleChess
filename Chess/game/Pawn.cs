using board;
namespace game
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color, ChessGame match): base(board, color) {
            this.match = match;
        }

        private ChessGame match;


        private bool Free(Position position)
        {
            return Board.piece(position) == null;
        }

        private bool EnemyExists(Position position)
        {
            Piece p = Board.piece(position);
            return p != null && p.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            Position pos = new Position(0, 0);
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            if(Color == Color.White)
            {
                pos.DefineValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 2, Position.Column);
                Position p2 = new Position(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && MoveCounter==0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row -1, Position.Column -1);
                if (Board.ValidPosition(pos)  && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }


                //EnPassant

                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(left) && EnemyExists(left) && Board.piece(left) == match.EnPassantVulnerable)
                    {
                        mat[left.Row - 1, left.Column] = true;
                    }
                    if (Board.ValidPosition(right) && EnemyExists(right) && Board.piece(right) == match.EnPassantVulnerable)
                    {
                        mat[right.Row -1, right.Column] = true;
                    }
                
                
                }
            }


            //Black
            else
            {
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 2, Position.Column);
                Position p2 = new Position(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && MoveCounter == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //EnPassant

                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(left) && EnemyExists(left) && Board.piece(left) == match.EnPassantVulnerable)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    if (Board.ValidPosition(right) && EnemyExists(right) && Board.piece(right) == match.EnPassantVulnerable)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }


                }
            }

            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
