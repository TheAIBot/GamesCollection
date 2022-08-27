namespace Chess.Pieces
{
    public sealed class Bishop : IPiece
    {
        public Player Player { get; private init; }

        public Bishop(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board)
        {
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(1, 1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(1, -1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(-1, 1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(-1, -1), Player);

            return positionsCanMoveTo;
        }
    }
}
