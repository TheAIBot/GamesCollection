namespace Chess.Pieces
{
    public sealed class King : IPiece
    {
        public Player Player { get; private init; }

        public King(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board, ChessMovesHistory movesHistory)
        {
            // Should actually be more complicated since the king can't move to a position where it can be taken
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(0, 1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, 0), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, -new Point(0, 1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, -new Point(1, 0), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, 1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, -1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, 1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, -1), Player);

            return positionsCanMoveTo;
        }
    }
}
