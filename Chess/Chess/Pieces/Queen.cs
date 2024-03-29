﻿using Chess.ChessHistory;

namespace Chess.Pieces
{
    public sealed class Queen : IPiece
    {
        public Player Player { get; private init; }

        public Queen(Player player)
        {
            Player = player;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board, IChessMovesHistory movesHistory)
        {
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(0, 1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(1, 0), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(0, -1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(-1, 0), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(1, 1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(1, -1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(-1, 1), Player);
            PieceMoveHelper.AddPositionsItCanMoveToGivenACertainDirection(positionsCanMoveTo, board, piecePosition, new Point(-1, -1), Player);

            return positionsCanMoveTo;
        }
    }
}
