using Chess.Pieces;

namespace Chess.ChessHistory
{
    public interface IChessMovesHistory
    {
        IReadOnlyList<ChessMove> AllChessMoves { get; }

        IReadOnlyList<ChessMove> GetPieceMoves(IPiece piece);
        void RecordMove(IPiece piece, Point from, Point to);
    }
}