using board;
namespace game
{
    internal class ChessGame
    {
        public Board board { get; set; }

        public int Turn { get; set; }
        public Color ActualPlayer { get; set; }
        public bool Finished { get; set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            Turn = 1;
            Finished = false;
            ActualPlayer = Color.White;
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
        }

        private void PutPieces()
        {
            board.SetPiece(new Tower(board, Color.White), new ChessPosition('a', 1).ToPosition());
            board.SetPiece(new Horse(board, Color.White), new ChessPosition('b', 1).ToPosition());
            board.SetPiece(new Bishop(board, Color.White), new ChessPosition('c', 1).ToPosition());
            board.SetPiece(new Queen(board, Color.White), new ChessPosition('d', 1).ToPosition());
            board.SetPiece(new King(board, Color.White), new ChessPosition('e', 1).ToPosition());
            board.SetPiece(new Bishop(board, Color.White), new ChessPosition('f', 1).ToPosition());
            board.SetPiece(new Horse(board, Color.White), new ChessPosition('g', 1).ToPosition());
            board.SetPiece(new Tower(board, Color.White), new ChessPosition('h', 1).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('a', 7).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('b', 7).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('c', 7).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('d', 7).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('e', 7).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('f', 7).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('g', 7).ToPosition());
            board.SetPiece(new Pawn(board, Color.Black), new ChessPosition('h', 7).ToPosition());
            board.SetPiece(new Tower(board, Color.Black), new ChessPosition('a', 8).ToPosition());
            board.SetPiece(new Horse(board, Color.Black), new ChessPosition('b', 8).ToPosition());
            board.SetPiece(new Bishop(board, Color.Black), new ChessPosition('c', 8).ToPosition());
            board.SetPiece(new Queen(board, Color.Black), new ChessPosition('d', 8).ToPosition());
            board.SetPiece(new King(board, Color.Black), new ChessPosition('e', 8).ToPosition());
            board.SetPiece(new Bishop(board, Color.Black), new ChessPosition('f', 8).ToPosition());
            board.SetPiece(new Horse(board, Color.Black), new ChessPosition('g', 8).ToPosition());
            board.SetPiece(new Tower(board, Color.Black), new ChessPosition('h', 8).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('a', 2).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('b', 2).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('c', 2).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('d', 2).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('e', 2).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('f', 2).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('g', 2).ToPosition());
            board.SetPiece(new Pawn(board, Color.White), new ChessPosition('h', 2).ToPosition());
        }

    }
}
