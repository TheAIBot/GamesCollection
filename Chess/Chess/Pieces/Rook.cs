namespace Chess.Pieces
{
    public sealed class Rook : IPiece
    {
        public Player Player { get; private init; }

        public Rook(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board, ChessMovesHistory movesHistory)
        {
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(0, 1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(1, 0), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(0, -1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(-1, 0), Player);

            return positionsCanMoveTo;
        }
    }
}
