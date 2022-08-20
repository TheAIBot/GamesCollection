namespace Chess.Pieces
{
    public interface IPiece
    {
        Player Player { get; }

        IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board);
    }
}
