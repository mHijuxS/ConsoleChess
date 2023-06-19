using board;
using game;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.SetPiece(new Tower(board, Color.White), new Position(0,0));
            board.SetPiece(new King(board, Color.Black), new Position(0,4));
            board.SetPiece(new Pawn(board, Color.White), new Position(2,3));


            Screen.PrintBoard(board);
            
        }
    }
}