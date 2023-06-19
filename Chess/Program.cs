using board;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            //board.SetPiece(tower, new Position(0,0));
            //board.SetPiece(king, new Position(2,4));


            Screen.PrintBoard(board);
            
        }
    }
}