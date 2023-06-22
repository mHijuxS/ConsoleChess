namespace board
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces; 
        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public bool IsPositionOccupied(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
            
        }

            public Piece piece(Position pos)
        {
            return Pieces[pos.Row, pos.Column];
        }

        public void SetPiece(Piece p, Position pos)
        {
            Pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= this.Rows || pos.Column<0 || pos.Column >= this.Columns)
            {
                return false;
            }
            return true;
        }

        public Piece RemovePiece(Position position)
        {
            if (piece(position) == null)
            {
                return null;
            }
            else
            {
                Piece aux = piece(position);
                aux.Position = null;
                Pieces[position.Row, position.Column] = null;
                return aux;
            }
        }

        public Piece PutPiece(Piece p, Position position)
        {
            if(IsPositionOccupied(position)==null)
            {
                return null;
            }
            Piece aux = piece(position);
            aux.Position = null;
            Pieces[position.Row, position.Column] = null;
            return aux;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Posição Inválida");
            }
        }

     
    }
}
