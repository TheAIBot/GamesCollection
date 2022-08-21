using Chess.Pieces;

namespace Chess.States
{
    public sealed class MovePieceMoveshighlighted : IChessUIState
    {
        private readonly ChessGame Game;
        private readonly IReadOnlyCollection<Point> PositionsHighlighted;

        public MovePieceMoveshighlighted(ChessGame game, IReadOnlyCollection<Point> positionsHighlighted)
        {
            Game = game;
            PositionsHighlighted = positionsHighlighted;
        }

        public IChessUIState? OnClick(Point position)
        {
            return null;
        }

        public IChessUIState? OnHover(Point position)
        {
            IPiece? piece = Game.GetTilePiece(position);
            if (piece == null)
            {
                return new MovePieceNothingHighlighted(Game);
            }

            IReadOnlyCollection<Point> positionsHighlighted = piece.GetPositionPieceCanMoveTo(position, Game.Board);
            return new MovePieceMoveshighlighted(Game, positionsHighlighted);
        }

        public string GetTileCustomStyle(Point position)
        {
            if (!PositionsHighlighted.Contains(position))
            {
                return string.Empty;
            }

            return "background-image: linear-gradient(rgb(70, 39, 103), rgb(70, 39, 123));";
        }
    }
}