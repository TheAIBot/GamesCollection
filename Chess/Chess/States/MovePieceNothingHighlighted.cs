using Chess.Pieces;

namespace Chess.States
{
    public sealed class MovePieceNothingHighlighted : IState
    {
        private readonly ChessGame Game;

        public MovePieceNothingHighlighted(ChessGame game)
        {
            Game = game;
        }

        public IState? OnClick(Point position)
        {
            return null;
        }

        public IState? OnHover(Point position)
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