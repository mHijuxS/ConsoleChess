using board;
namespace game
{
    internal class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board,color) {}

        public override string ToString()
        {
            return "H";
        }
    }
}
