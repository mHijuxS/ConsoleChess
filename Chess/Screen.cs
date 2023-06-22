using board;
using game;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

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

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.Gray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = background;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.Write(" ");
                    Console.BackgroundColor = background;
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  a  b  c  d  e  f  g  h");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void PrintMatch(ChessGame match)
        {
            PrintBoard(match.board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn + "\nPlayer: " + match.ActualPlayer + "\n"); 
        }

        public static void PrintCapturedPieces(ChessGame match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("Whites: ");
            PrintSet(match.CapturedPiecesSet(Color.White));
            Console.Write("Blacks: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPiecesSet(Color.Black));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");

            foreach (Piece piece in set)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]\n");
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
