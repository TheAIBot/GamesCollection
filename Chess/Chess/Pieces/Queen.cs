namespace Chess.Pieces
{
    public sealed class Queen : IPiece
    {
        public Player Player { get; private init; }

        public Queen(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board)
        {
            var positionsCanMoveTo = new List<Point>();
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(0, 1));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, 0));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(0, -1));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, 0));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, 1));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, -1));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, 1));
            AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, -1));

            return positionsCanMoveTo;
        }

        private static void AddToListOfMoveablePositionIfCanMoveToPosition(List<Point> positionsCanMoveTo, ChessBoard board, Point position, Point moveDirection)
        {
            position += moveDirection;
            while (board.IsFreePosition(position))
            {
                positionsCanMoveTo.Add(position);
                position += moveDirection;
            }
        }
    }
}
