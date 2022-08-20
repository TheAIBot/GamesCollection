namespace Chess.Pieces
{
    public sealed class King : IPiece
    {
        public Player Player { get; private init; }

        public King(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board)
        {
            var positionsCanMoveTo = new List<Point>();
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition + new Point(0, 1));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition + new Point(1, 0));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition - new Point(0, 1));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition - new Point(1, 0));

            return positionsCanMoveTo;
        }

        private static void AddToListOfMoveablePositionIfCanMoveToPosition(List<Point> positionsCanMoveTo, ChessBoard board, Point position)
        {
            // Should actually be more complicated since the king can't move to a position where it can be taken
            if (board.IsFreePosition(position))
            {
                positionsCanMoveTo.Add(position);
            }
        }
    }
}
