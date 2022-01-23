using Chess.Pieces;

namespace Chess
{
    public sealed class ChessGame
    {
        private const int BoardSideLength = 8;
        private readonly IPiece?[,] Board = new IPiece[BoardSideLength, BoardSideLength];

        public ChessGame()
        {
            PlacePiece(new Point(0, 0), new Rook(Player.Black));
            PlacePiece(new Point(7, 0), new Rook(Player.Black));
            PlacePiece(new Point(1, 0), new Knight(Player.Black));
            PlacePiece(new Point(6, 0), new Knight(Player.Black));
            PlacePiece(new Point(2, 0), new Bishop(Player.Black));
            PlacePiece(new Point(5, 0), new Bishop(Player.Black));
            PlacePiece(new Point(3, 0), new Queen(Player.Black));
            PlacePiece(new Point(4, 0), new King(Player.Black));
            PlacePiece(new Point(0, 1), new Pawn(Player.Black));
            PlacePiece(new Point(1, 1), new Pawn(Player.Black));
            PlacePiece(new Point(2, 1), new Pawn(Player.Black));
            PlacePiece(new Point(3, 1), new Pawn(Player.Black));
            PlacePiece(new Point(4, 1), new Pawn(Player.Black));
            PlacePiece(new Point(5, 1), new Pawn(Player.Black));
            PlacePiece(new Point(6, 1), new Pawn(Player.Black));
            PlacePiece(new Point(7, 1), new Pawn(Player.Black));

            PlacePiece(new Point(0, 6), new Pawn(Player.White));
            PlacePiece(new Point(1, 6), new Pawn(Player.White));
            PlacePiece(new Point(2, 6), new Pawn(Player.White));
            PlacePiece(new Point(3, 6), new Pawn(Player.White));
            PlacePiece(new Point(4, 6), new Pawn(Player.White));
            PlacePiece(new Point(5, 6), new Pawn(Player.White));
            PlacePiece(new Point(6, 6), new Pawn(Player.White));
            PlacePiece(new Point(7, 6), new Pawn(Player.White));
            PlacePiece(new Point(0, 7), new Rook(Player.Black));
            PlacePiece(new Point(7, 7), new Rook(Player.Black));
            PlacePiece(new Point(1, 7), new Knight(Player.Black));
            PlacePiece(new Point(6, 7), new Knight(Player.Black));
            PlacePiece(new Point(2, 7), new Bishop(Player.Black));
            PlacePiece(new Point(5, 7), new Bishop(Player.Black));
            PlacePiece(new Point(3, 7), new Queen(Player.Black));
            PlacePiece(new Point(4, 7), new King(Player.Black));
        }

        private void PlacePiece(Point pos, IPiece piece)
        {
            Board[pos.X, pos.Y] = piece;
        }

        public IPiece? GetTilePiece(int x, int y)
        {
            if (!WithinBoard(x, y))
            {
                throw new ArgumentException($"Tile position out of range: X: {x} Y: {y}");
            }

            return Board[x, y];
        }

        private bool WithinBoard(int x, int y)
        {
            return x >= 0 && x < Board.GetLength(0) &&
                   y >= 0 && y < Board.GetLength(1);
        }
    }
}