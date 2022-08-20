using Chess.Pieces;

namespace Chess
{
    public sealed class ChessBoard
    {
        private const int BoardSideLength = 8;
        private readonly IPiece?[,] Board = new IPiece[BoardSideLength, BoardSideLength];

        public IPiece? this[int x, int y]
        {
            get
            {
                if (!WithinBoard(x, y))
                {
                    throw new ArgumentException($"Tile position out of range: X: {x} Y: {y}");
                }
                return Board[x, y];
            }
            set
            {
                Board[x, y] = value;
            }
        }

        public bool WithinBoard(Point position) => WithinBoard(position.X, position.Y);

        public bool WithinBoard(int x, int y)
        {
            return x >= 0 &&
                   y >= 0 &&
                   x < BoardSideLength &&
                   y < BoardSideLength;
        }

        public bool IsFreePosition(Point position) => WithinBoard(position) && this[position.X, position.Y] == null;
    }
}