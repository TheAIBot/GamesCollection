namespace Chess.Pieces
{
    public sealed class Queen : IPiece
    {
        public Player Player { get; private init; }

        public Queen(Player player)
        {
            Player = player;
        }
    }
}
