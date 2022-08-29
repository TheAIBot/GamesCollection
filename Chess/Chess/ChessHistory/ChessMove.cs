using Chess.Pieces;

namespace Chess.ChessHistory
{
    public sealed record ChessMove(IPiece Piece, Point From, Point To);
}