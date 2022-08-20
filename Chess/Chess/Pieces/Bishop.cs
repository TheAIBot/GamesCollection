namespace Chess.Pieces
{
    public sealed class Bishop : IPiece
    {
        public Player Player { get; private init; }

        public Bishop(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board) => new List<Point>();
    }
}
