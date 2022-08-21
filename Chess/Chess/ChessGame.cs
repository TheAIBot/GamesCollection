﻿using Chess.Pieces;

namespace Chess
{
    public sealed class ChessGame
    {
        public readonly ChessBoard Board = new ChessBoard();

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
            //PlacePiece(new Point(0, 1), new Pawn(Player.Black));
            //PlacePiece(new Point(1, 1), new Pawn(Player.Black));
            //PlacePiece(new Point(2, 1), new Pawn(Player.Black));
            //PlacePiece(new Point(3, 1), new Pawn(Player.Black));
            //PlacePiece(new Point(4, 1), new Pawn(Player.Black));
            //PlacePiece(new Point(5, 1), new Pawn(Player.Black));
            //PlacePiece(new Point(6, 1), new Pawn(Player.Black));
            //PlacePiece(new Point(7, 1), new Pawn(Player.Black));

            //PlacePiece(new Point(0, 6), new Pawn(Player.White));
            //PlacePiece(new Point(1, 6), new Pawn(Player.White));
            //PlacePiece(new Point(2, 6), new Pawn(Player.White));
            //PlacePiece(new Point(3, 6), new Pawn(Player.White));
            //PlacePiece(new Point(4, 6), new Pawn(Player.White));
            //PlacePiece(new Point(5, 6), new Pawn(Player.White));
            //PlacePiece(new Point(6, 6), new Pawn(Player.White));
            //PlacePiece(new Point(7, 6), new Pawn(Player.White));
            PlacePiece(new Point(0, 7), new Rook(Player.Black));
            PlacePiece(new Point(7, 7), new Rook(Player.Black));
            PlacePiece(new Point(1, 7), new Knight(Player.Black));
            PlacePiece(new Point(6, 7), new Knight(Player.Black));
            PlacePiece(new Point(2, 7), new Bishop(Player.Black));
            PlacePiece(new Point(5, 7), new Bishop(Player.Black));
            PlacePiece(new Point(3, 7), new Queen(Player.Black));
            PlacePiece(new Point(4, 7), new King(Player.Black));
        }

        public IEnumerable<Point> GetBoardPositions()
        {
            return Board.GetBoardPositions();
        }

        private void PlacePiece(Point pos, IPiece piece)
        {
            Board[pos.X, pos.Y] = piece;
        }

        public IPiece? GetTilePiece(Point position) => GetTilePiece(position.X, position.Y);
        public IPiece? GetTilePiece(int x, int y) => Board[x, y];
    }
}