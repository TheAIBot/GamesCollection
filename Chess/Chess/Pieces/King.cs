namespace Chess.Pieces
{
    public sealed class King : IPiece
    {
        public Player Player { get; private init; }

        public King(Player player)
        {
            Player = player;
        }
    }
}
