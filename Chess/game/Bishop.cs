using board;
namespace game
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color): base(board, color) {}

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //NE
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Row -= 1;
                pos.Column += 1;
            }

            //NO
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Row -= 1;
                pos.Column -= 1;
            }

            //SE
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Row += 1;
                pos.Column += 1;
            }

            //SO
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Row += 1;
                pos.Column -= 1;
            }

            return mat;
        }
        public override string ToString()
        {
            return "B";
        }
    }
}
