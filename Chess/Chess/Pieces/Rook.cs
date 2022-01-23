namespace Chess.Pieces
{
    public sealed class Rook : IPiece
    {
        public Player Player { get; private init; }

        public Rook(Player player)
        {
            Player = player;
        }
    }
}
