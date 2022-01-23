namespace Chess.Pieces
{
    internal sealed class Pawn : IPiece
    {
        public Player Player { get; private init; }

        public Pawn(Player player)
        {
            Player = player;
        }
    }
}
