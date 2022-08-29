using Chess.ChessHistory;

namespace Chess.Pieces
{
    internal interface ICustomMoveBehavior
    {
        bool MoveIfIsCustomMove(Point from, Point to, ChessBoard board, IChessMovesHistory movesHistory);
    }
}
