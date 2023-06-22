using board;
namespace game
{
    internal class ChessGame
    {
        public Board board { get; set; }

        public int Turn { get; set; }
        public Color ActualPlayer { get; set; }
        public bool Finished { get; set; }

        public HashSet<Piece> CapturedPieces { get; set; }

        public HashSet<Piece> Pieces { get; set; }

        public bool Check { get; set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            Turn = 1;
            Finished = false;
            ActualPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PutPieces();
            Check = false;
        }

        public void MakePlay(Position origin, Position destin)
        {
            Piece capturedPiece = MakeMove(origin, destin);
            
            if (IsInCheck(ActualPlayer))
            {
                UndoMovement(origin,destin,capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (IsInCheck(Adversary(ActualPlayer)))
            {
                Check = true;
            }

            if (CheckMate(Adversary(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                Check = false;
            }


            
            Turn++;
            ChangePlayer();
        }

        public void UndoMovement(Position origin, Position destin, Piece capturePiece)
        {
            Piece p = board.RemovePiece(destin);
            p.DecreaseMoveCounter();
            if (capturePiece != null)
            {
                board.PutPiece(capturePiece, destin);
                CapturedPieces.Remove(capturePiece);
            }
            board.PutPiece(p, origin);
        }
        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece TheKing(Color color)
        {
            foreach (Piece x in InGamePieces(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece R = TheKing(color); 
            if (R == null)
            {
                throw new BoardException($"There are no Kings with the color {color} on the board!");
            }
            foreach (Piece piece in InGamePieces(Adversary(color)))
            {
                bool[,] mat = piece.PossibleMoves();
                if (mat[R.Position.Row, R.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There is no piece at this position!");
            }
            if (ActualPlayer != board.piece(pos).Color)
            {
                throw new BoardException("This piece is not yours!");
            }
            if (!board.piece(pos).IsItPossibleToMove())
            {
                throw new BoardException("This piece can't move anywhere!");
            }
        }

        public void ValidateDestinPosition(Position origin, Position destin)
        {
            if (!board.piece(origin).CanMoveTo(destin))
            {
                throw new BoardException("Invalid destination!");
            }
        }
        private void ChangePlayer()
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }
            else
            {
                ActualPlayer = Color.White;
            }
        }

        public Piece MakeMove(Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.IncreaseMoveCounter();
            Piece CapturedPiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
            if(CapturedPiece != null)
            {
                CapturedPieces.Add(CapturedPiece);
            }
            return CapturedPiece;
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        public HashSet<Piece> CapturedPiecesSet(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in CapturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPiecesSet(color));
            return aux;
        }

        public bool CheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece piece in InGamePieces(color))
            {
                bool[,] mat = piece.PossibleMoves();
                for (int i = 0; i < board.Rows; i++)
                {
                    for (int j = 0; j < board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position p = new Position(i, j);
                            Piece capturedPiece = MakeMove(piece.Position, p);
                            bool testCheck = IsInCheck(color);
                            UndoMovement(piece.Position,p,capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void PutPieces()
        {
            /*
            PutNewPiece('a', 1, new Tower(board, Color.White));
            PutNewPiece('b', 1, new Horse(board, Color.White));
            PutNewPiece('c', 1, new Bishop(board, Color.White));
            PutNewPiece('d', 1, new Queen(board, Color.White));
            PutNewPiece('e', 1, new King(board, Color.White));
            PutNewPiece('f', 1, new Bishop(board, Color.White));
            PutNewPiece('g', 1, new Horse(board, Color.White));
            PutNewPiece('h', 1, new Tower(board, Color.White));
            PutNewPiece('a', 2, new Pawn(board, Color.White));
            PutNewPiece('b', 2, new Pawn(board, Color.White));
            PutNewPiece('c', 2, new Pawn(board, Color.White));
            PutNewPiece('d', 2, new Pawn(board, Color.White));
            PutNewPiece('e', 2, new Pawn(board, Color.White));
            PutNewPiece('f', 2, new Pawn(board, Color.White));
            PutNewPiece('g', 2, new Pawn(board, Color.White));
            PutNewPiece('h', 2, new Pawn(board, Color.White));
            PutNewPiece('a', 7, new Pawn(board, Color.Black));
            PutNewPiece('b', 7, new Pawn(board, Color.Black));
            PutNewPiece('c', 7, new Pawn(board, Color.Black));
            PutNewPiece('d', 7, new Pawn(board, Color.Black));
            PutNewPiece('e', 7, new Pawn(board, Color.Black));
            PutNewPiece('f', 7, new Pawn(board, Color.Black));
            PutNewPiece('g', 7, new Pawn(board, Color.Black));
            PutNewPiece('h', 7, new Pawn(board, Color.Black));
            PutNewPiece('a', 8, new Tower(board, Color.Black));
            PutNewPiece('b', 8, new Horse(board, Color.Black));
            PutNewPiece('c', 8, new Bishop(board, Color.Black));
            PutNewPiece('d', 8, new Queen(board, Color.Black));
            PutNewPiece('e', 8, new King(board, Color.Black));
            PutNewPiece('f', 8, new Bishop(board, Color.Black));
            PutNewPiece('g', 8, new Horse(board, Color.Black));
            PutNewPiece('h', 8, new King(board, Color.Black));
        */

            PutNewPiece('c', 8, new King(board, Color.Black));
            PutNewPiece('c', 7, new Pawn(board, Color.Black));
            PutNewPiece('b', 6, new Queen(board, Color.White));
            PutNewPiece('h', 4, new Tower(board, Color.White));
            PutNewPiece('c', 3, new King(board, Color.White));
            PutNewPiece('a', 1, new Tower(board, Color.White));
        }

    }
}
