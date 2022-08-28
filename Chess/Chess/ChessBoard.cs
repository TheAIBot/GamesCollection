using Chess.Pieces;
using System.Diagnostics.CodeAnalysis;

namespace Chess
{
    public sealed class ChessBoard
    {
        private const int BoardSideLength = 8;
        private readonly IPiece?[,] Board = new IPiece[BoardSideLength, BoardSideLength];

        public IPiece? this[Point position]
        {
            get
            {
                if (!WithinBoard(position.X, position.Y))
                {
                    throw new ArgumentException($"Tile position out of range: X: {position.X} Y: {position.Y}");
                }
                return Board[position.X, position.Y];
            }
            set
            {
                Board[position.X, position.Y] = value;
            }
        }

        public IEnumerable<Point> GetBoardPositions()
        {
            for (int y = 0; y < BoardSideLength; y++)
            {
                for (int x = 0; x < BoardSideLength; x++)
                {
                    yield return new Point(x, y);
                }
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

        public bool IsFreePosition(Point position) => WithinBoard(position) && this[position] == null;

        public bool TryGetPiece(Point position, [NotNullWhen(true)] out IPiece? piece)
        {
            if (!WithinBoard(position))
            {
                piece = null;
                return false;
            }

            piece = this[position];
            return piece != null;
        }

        public bool ContainsEnemyPiece(Point position, Player friendlyPlayer)
        {
            if (!TryGetPiece(position, out IPiece? piece))
            {
                return false;
            }

            return piece.Player != friendlyPlayer;
        }
    }
}