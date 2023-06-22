using board;
namespace game
{
    internal class King : Piece
    {
        private ChessGame Match;
        public King(Board board, Color color, ChessGame match) : base(board,color) {
        
            this.Match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }


        private bool TestTowerForRoque(Position position)
        {
            Piece p = Board.piece(position);
            return p != null && p is Tower && p.Color == Color && p.MoveCounter == 0;
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

            //Jogadas especiais

            if (MoveCounter == 0 && !Match.Check)
            {
                Position posTl = new Position(Position.Row, Position.Column + 3);
                if (TestTowerForRoque(posTl))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.piece(p1) == null && Board.piece(p2) == null)
                    {
                        mat[Position.Row, Position.Column+2] = true;
                    }
                }
            }

            if (MoveCounter == 0 && !Match.Check)
            {
                Position posTb = new Position(Position.Row, Position.Column - 4);
                if (TestTowerForRoque(posTb))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }


            return mat;
        }

    }


}
