namespace Chess.Pieces
{
    public sealed class Knight : IPiece
    {
        public Player Player { get; private init; }

        public Knight(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board)
        {
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(2, 1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(2, -1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-2, 1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-2, -1), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, 2), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, -2), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, 2), Player);
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, -2), Player);

            return positionsCanMoveTo;
        }
    }
}
