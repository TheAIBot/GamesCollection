using Chess.Pieces;

namespace Chess.ChessHistory
{
    public sealed class ChessMovesHistory : IChessMovesHistory
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
}