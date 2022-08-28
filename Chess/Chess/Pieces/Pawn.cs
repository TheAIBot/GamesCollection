namespace Chess.Pieces
{
    public sealed class Pawn : IPiece
    {
        private readonly Point MoveDirection;
        private readonly Point StartPosition;
        public Player Player { get; private init; }

        public Pawn(Player player, Point moveDirection, Point startPosition)
        {
            Player = player;
            MoveDirection = moveDirection;
            StartPosition = startPosition;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board)
        {
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, MoveDirection, Player);
            if (piecePosition == StartPosition)
            {
                PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, MoveDirection * 2, Player);
            }

            //Need to implement the conversion and the wierd takeover

            return positionsCanMoveTo;
        }
    }
}
