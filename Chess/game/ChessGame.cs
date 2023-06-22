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

        public ChessGame()
        {
            board = new Board(8, 8);
            Turn = 1;
            Finished = false;
            ActualPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PutPieces();
        }

        public void MakePlay(Position origin, Position destin)
        {
            MakeMove(origin, destin);
            ChangePlayer();
            Turn++;
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

        public void MakeMove(Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.IncreaseMoveCounter();
            Piece CapturedPiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
            if(CapturedPiece != null)
            {
                CapturedPieces.Add(CapturedPiece);
            }
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
            foreach (Piece x in CapturedPieces)
            {
                aux.Add(x);
            }
            return aux;
        }
        private void PutPieces()
        {
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
        }

    }
}
