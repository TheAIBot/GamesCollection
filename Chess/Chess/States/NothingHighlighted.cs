using Chess.Pieces;

namespace Chess.States
{
    public sealed class NothingHighlighted : IChessUIState
    {
        private readonly ChessGame Game;

        public NothingHighlighted(ChessGame game)
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
            return new ChooseMove(Game, position, positionsHighlighted);
        }

        public IChessUIState? OnHover(Point position)
        {
            IPiece? piece = Game.GetTilePiece(position);
            if (piece == null)
            {
                return null;
            }

            IReadOnlyCollection<Point> positionsHighlighted = piece.GetPositionPieceCanMoveTo(position, Game.Board);
            return new PossibleMoveshighlighted(Game, positionsHighlighted);
        }

        public string GetTileCustomStyle(Point position)
        {
            return string.Empty;
        }
    }
}