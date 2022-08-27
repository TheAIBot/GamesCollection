namespace Chess.Pieces
{
    internal static class PieceMoveHelper
    {
        public static void AddToListOfMoveablePositionIfCanMoveToPosition(List<Point> positionsCanMoveTo, ChessBoard board, Point position, Point moveDirection, Player player)
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
    }
}
