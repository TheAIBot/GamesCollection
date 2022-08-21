using Chess.Pieces;

namespace Chess.States
{
    public sealed class MovePieceNothingHighlighted : IChessUIState
    {
        private readonly ChessGame Game;

        public MovePieceNothingHighlighted(ChessGame game)
        {
            Game = game;
        }

        public IChessUIState? OnClick(Point position)
        {
            IPiece? piece = Game.GetTilePiece(position);
            if (piece == null)
            {
                return null;
            }

            IReadOnlyCollection<Point> positionsHighlighted = piece.GetPositionPieceCanMoveTo(position, Game.Board);
            return new MovePieceChooseMove(Game, position, positionsHighlighted);
        }

        public IChessUIState? OnHover(Point position)
        {
            IPiece? piece = Game.GetTilePiece(position);
            if (piece == null)
            {
                return null;
            }

            IReadOnlyCollection<Point> positionsHighlighted = piece.GetPositionPieceCanMoveTo(position, Game.Board);
            return new MovePieceMoveshighlighted(Game, positionsHighlighted);
        }

        public string GetTileCustomStyle(Point position)
        {
            return string.Empty;
        }
    }
}