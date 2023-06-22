using board;
using game;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessPosition test = new ChessPosition('a', 2);

            Console.WriteLine(test);

            Console.WriteLine(test.ToPosition());

        }
    }
}