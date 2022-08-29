using Chess.ChessHistory;
using Chess.Pieces;

namespace Chess
{
    public sealed record ChessGame(ChessBoard Board, IChessMovesHistory MovesHistory)
    {
        public IEnumerable<Point> GetBoardPositions()
        {
            return Board.GetBoardPositions();
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