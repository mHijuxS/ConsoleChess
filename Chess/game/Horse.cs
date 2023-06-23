﻿using board;
namespace game
{
    internal class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board,color) {}

        private bool CanMoveTo(Position position)
        {
            Piece p = Board.piece(position);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Row -1, Position.Column - 2);
            if(Board.ValidPosition(pos) && CanMoveTo(pos)) 
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMoveTo(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMoveTo(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMoveTo(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMoveTo(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMoveTo(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMoveTo(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMoveTo(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
        public override string ToString()
        {
            return "H";
        }
    }
}
