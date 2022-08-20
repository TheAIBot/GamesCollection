namespace Chess.Pieces
{
    public sealed class Knight : IPiece
    {
        public Player Player { get; private init; }

        public Knight(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board) => new List<Point>();
    }
}
