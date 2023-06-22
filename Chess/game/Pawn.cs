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
        public override bool[,] PossibleMoves()
        {
            Position pos = new Position(0, 0);
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            if (Color == Color.Black)
            {
                //abaixo
                pos.DefineValues(Position.Row, Position.Column + 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }
            else
            {
                //acima
                pos.DefineValues(Position.Row, Position.Column - 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
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
