namespace Chess.Pieces
{
    internal sealed class Knight : IPiece
    {
        public Player Player { get; private init; }

        public Knight(Player player)
        {
            Player = player;
        }
    }
}
