namespace Chess.Pieces
{
    public sealed class Pawn : IPiece
    {
        public Player Player { get; private init; }

        public Pawn(Player player)
        {
            Player = player;
        }
    }
}
