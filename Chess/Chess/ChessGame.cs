using Chess.Pieces;

namespace Chess
{
    public sealed record ChessMove(IPiece Piece, Point From, Point To);

    public sealed class ChessMovesHistory
    {
        private readonly List<ChessMove> ChessMoves = new List<ChessMove>();
        private readonly Dictionary<IPiece, List<ChessMove>> PieceMoves = new Dictionary<IPiece, List<ChessMove>>();
        public IReadOnlyList<ChessMove> AllChessMoves => ChessMoves;

        public void RecordMove(IPiece piece, Point from, Point to)
        {
            var chessMove = new ChessMove(piece, from, to);
            ChessMoves.Add(chessMove);

            if (!PieceMoves.TryGetValue(piece, out List<ChessMove>? pieceMoves))
            {
                pieceMoves = new List<ChessMove>();
                PieceMoves.Add(piece, pieceMoves);
            }

            pieceMoves.Add(chessMove);
        }

        public IReadOnlyList<ChessMove> GetPieceMoves(IPiece piece)
        {
            if (PieceMoves.TryGetValue(piece, out List<ChessMove>? pieceMoves))
            {
                return pieceMoves;
            }

            return Array.Empty<ChessMove>();
        }
    }

    public sealed class ChessGame
    {
        public readonly ChessBoard Board = new ChessBoard();
        public readonly ChessMovesHistory MovesHistory = new ChessMovesHistory();

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

            if (pieceToMove is ICustomMoveBehavior customMovePiece && customMovePiece.MoveIfIsCustomMove(from, to, Board, MovesHistory))
            {
                return;
            }

            Board[to] = pieceToMove;
            Board[from] = null;
            MovesHistory.RecordMove(pieceToMove, from, to);
        }
    }
}