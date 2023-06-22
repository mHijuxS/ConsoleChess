using board;
using game;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame match = new ChessGame();
                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.board);

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possibleMoves = match.board.piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.board, possibleMoves);

                    Console.Write("Destin: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.MakeMove(origin, destiny);
                    
                }

            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}