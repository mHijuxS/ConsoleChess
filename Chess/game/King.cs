using board;
namespace game
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board,color) {}

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }



        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows,Board.Columns];

            Position pos = new Position(0, 0);
            
            //esquerda
            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row,pos.Column] = true;               
            }

            //direita
            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //abaixo
            pos.DefineValues(Position.Row, Position.Column+1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            
            //acima
            pos.DefineValues(Position.Row, Position.Column-1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //SO
            pos.DefineValues(Position.Row - 1, Position.Column+1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //NO
            pos.DefineValues(Position.Row - 1, Position.Column-1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //SE
            pos.DefineValues(Position.Row + 1, Position.Column +1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //NE
            pos.DefineValues(Position.Row + 1, Position.Column -1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}
