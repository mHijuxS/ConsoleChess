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

        public abstract bool[,] PossibleMoves();
        
    }
}
