using board;
using game;
using System.Globalization;

namespace Chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(8-i + " ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < board.Columns; j++)
                {
                        PrintPiece(board.piece(i, j));
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  a  b  c  d  e  f  g  h");
            Console.ForegroundColor = ConsoleColor.White;
            
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine()!;
            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
