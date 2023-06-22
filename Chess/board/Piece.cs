namespace board
{
    internal abstract class Piece
    {
        public Color Color { get; protected set; }

        public Position Position { get; set; }

        public int MoveCounter { get; protected set; }

        public Board Board { get; set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MoveCounter = 0;
        }

        public void IncreaseMoveCounter()
        {
            MoveCounter++;
        }
        public abstract bool[,] PossibleMoves();

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }
        public bool IsItPossibleToMove()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}
