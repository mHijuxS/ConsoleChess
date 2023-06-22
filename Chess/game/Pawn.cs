using board;
namespace game
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color): base(board, color) {}

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

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
                if (Board.ValidPosition(pos) && Free(pos) && MoveCounter==0)
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
            }
            else
            {
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && MoveCounter == 0)
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
            }

            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
