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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(origin);
                        bool[,] possibleMoves = match.board.piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.board, possibleMoves);

                        Console.Write("Destin: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestinPosition(origin, destiny);
                        match.MakePlay(origin, destiny);
                        Console.Clear();
                        Screen.PrintMatch(match);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}