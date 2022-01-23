namespace Chess.Pieces
{
    public sealed class Bishop : IPiece
    {
        public Player Player { get; private init; }

        public Bishop(Player player)
        {
            Player = player;
        }
    }
}
