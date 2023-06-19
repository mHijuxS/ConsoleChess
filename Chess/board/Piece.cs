namespace board
{
    internal class Piece
    {
        public Color Color { get; protected set; }

        public Position Position { get; set; }

        public int MoveCounter { get; protected set; }

        public Board Board { get; set; }

        public Piece(Position pos, Board board, Color color)
        {
            Position = pos;
            Board = board;
            Color = color;
            MoveCounter = 0;
        }
    }
}
