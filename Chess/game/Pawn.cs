using board;
namespace game
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color): base(board, color) {}

        public override string ToString()
        {
            return "P";
        }
    }
}
