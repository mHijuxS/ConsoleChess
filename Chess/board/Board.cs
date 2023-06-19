﻿namespace board
{
    internal class Board
    {
        public int Rows { get; set; }

        public int Columns { get; set; }

        private Piece[,] Pieces; 
        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece piece(int row, int column)
        {
            return Pieces[row, column];
        }
    }
}
