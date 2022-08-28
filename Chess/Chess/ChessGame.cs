using Chess.Pieces;

namespace Chess
{
    public sealed class ChessGame
    {
        public readonly ChessBoard Board = new ChessBoard();

        public ChessGame()
        {
            PlacePiece(new Point(0, 0), new Rook(Player.Black));
            PlacePiece(new Point(7, 0), new Rook(Player.Black));
            PlacePiece(new Point(1, 0), new Knight(Player.Black));
            PlacePiece(new Point(6, 0), new Knight(Player.Black));
            PlacePiece(new Point(2, 0), new Bishop(Player.Black));
            PlacePiece(new Point(5, 0), new Bishop(Player.Black));
            PlacePiece(new Point(3, 0), new Queen(Player.Black));
            PlacePiece(new Point(4, 0), new King(Player.Black));
            PlacePiece(new Point(0, 1), new Pawn(Player.Black, new Point(0, 1), new Point(0, 1)));
            PlacePiece(new Point(1, 1), new Pawn(Player.Black, new Point(0, 1), new Point(1, 1)));
            PlacePiece(new Point(2, 1), new Pawn(Player.Black, new Point(0, 1), new Point(2, 1)));
            PlacePiece(new Point(3, 1), new Pawn(Player.Black, new Point(0, 1), new Point(3, 1)));
            PlacePiece(new Point(4, 1), new Pawn(Player.Black, new Point(0, 1), new Point(4, 1)));
            PlacePiece(new Point(5, 1), new Pawn(Player.Black, new Point(0, 1), new Point(5, 1)));
            PlacePiece(new Point(6, 1), new Pawn(Player.Black, new Point(0, 1), new Point(6, 1)));
            PlacePiece(new Point(7, 1), new Pawn(Player.Black, new Point(0, 1), new Point(7, 1)));

            PlacePiece(new Point(0, 7), new Rook(Player.White));
            PlacePiece(new Point(7, 7), new Rook(Player.White));
            PlacePiece(new Point(1, 7), new Knight(Player.White));
            PlacePiece(new Point(6, 7), new Knight(Player.White));
            PlacePiece(new Point(2, 7), new Bishop(Player.White));
            PlacePiece(new Point(5, 7), new Bishop(Player.White));
            PlacePiece(new Point(3, 7), new Queen(Player.White));
            PlacePiece(new Point(4, 7), new King(Player.White));
            PlacePiece(new Point(0, 6), new Pawn(Player.White, new Point(0, -1), new Point(0, 6)));
            PlacePiece(new Point(1, 6), new Pawn(Player.White, new Point(0, -1), new Point(1, 6)));
            PlacePiece(new Point(2, 6), new Pawn(Player.White, new Point(0, -1), new Point(2, 6)));
            PlacePiece(new Point(3, 6), new Pawn(Player.White, new Point(0, -1), new Point(3, 6)));
            PlacePiece(new Point(4, 6), new Pawn(Player.White, new Point(0, -1), new Point(4, 6)));
            PlacePiece(new Point(5, 6), new Pawn(Player.White, new Point(0, -1), new Point(5, 6)));
            PlacePiece(new Point(6, 6), new Pawn(Player.White, new Point(0, -1), new Point(6, 6)));
            PlacePiece(new Point(7, 6), new Pawn(Player.White, new Point(0, -1), new Point(7, 6)));
        }

        public IEnumerable<Point> GetBoardPositions()
        {
            return Board.GetBoardPositions();
        }

        private void PlacePiece(Point pos, IPiece piece)
        {
            Board[pos] = piece;
        }

        public IPiece? GetTilePiece(Point position) => Board[position];

        public void MovePiece(Point from, Point to)
        {
            IPiece? pieceToMove = Board[from];
            if (pieceToMove == null)
            {
                throw new ArgumentOutOfRangeException(nameof(from), "Piece could not be moved since none were found at the location.");
            }

            Board[to] = pieceToMove;
            Board[from] = null;
        }
    }
}