using board;
namespace game
{
    internal class Queen : Piece
    {
        public Queen(Board boar, Color color): base(boar, color) {}

        public override string ToString()
        {
            return "Q";
        }
    }
}
