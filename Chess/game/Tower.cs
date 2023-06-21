using board;
namespace game
{
    internal class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color) { }

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }


        public override string ToString()
        {
            return "T";
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //down
            pos.DefineValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Row += 1;
            }

            //right
            pos.DefineValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Column += 1;
            }

            //left
            pos.DefineValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Column -= 1;
            }

            //up
            pos.DefineValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Row -= 1;
            }

            return mat;
        }

    }
}