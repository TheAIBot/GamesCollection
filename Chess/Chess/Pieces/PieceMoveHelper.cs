namespace Chess.Pieces
{
    internal static class PieceMoveHelper
    {
        public static void AddPositionsItCanMoveToGivenACertainDirection(List<Point> positionsCanMoveTo, ChessBoard board, Point position, Point moveDirection, Player player)
        {
            position += moveDirection;
            while (board.IsFreePosition(position))
            {
                positionsCanMoveTo.Add(position);
                position += moveDirection;
            }

            if (board.ContainsEnemyPiece(position, player))
            {
                positionsCanMoveTo.Add(position);
            }
        }

        public static void AddPositionIfCanMoveToPosition(List<Point> positionsCanMoveTo, ChessBoard board, Point currentPosition, Point relativePosition, Player player)
        {
            Point absolutePosition = currentPosition + relativePosition;
            if (!board.TryGetPiece(absolutePosition, out IPiece? piece) || (board.WithinBoard(absolutePosition) && piece.Player != player))
            {
                positionsCanMoveTo.Add(absolutePosition);
            }
        }
    }
}
