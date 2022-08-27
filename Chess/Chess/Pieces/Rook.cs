namespace Chess.Pieces
{
    public sealed class Rook : IPiece
    {
        public Player Player { get; private init; }

        public Rook(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board)
        {
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(0, 1), Player);
            PieceMoveHelper.AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(1, 0), Player);
            PieceMoveHelper.AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(0, -1), Player);
            PieceMoveHelper.AddToListOfMoveablePositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, new Point(-1, 0), Player);

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
