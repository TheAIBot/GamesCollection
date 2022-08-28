using Chess.Pieces;

namespace Chess.States
{
    public sealed class PossibleMoveshighlighted : IChessUIState
    {
        private readonly ChessGame Game;
        private readonly IReadOnlyCollection<Point> PositionsHighlighted;

        public PossibleMoveshighlighted(ChessGame game, IReadOnlyCollection<Point> positionsHighlighted)
        {
            Game = game;
            PositionsHighlighted = positionsHighlighted;
        }

        public IChessUIState? OnClick(Point position)
        {
            IPiece? piece = Game.GetTilePiece(position);
            if (piece == null)
            {
                return null;
            }

            IReadOnlyCollection<Point> positionsHighlighted = piece.GetPositionPieceCanMoveTo(position, Game.Board, Game.MovesHistory);
            if (positionsHighlighted.Count == 0)
            {
                return null;
            }
            return new ChooseMove(Game, position, positionsHighlighted);
        }

        public IChessUIState? OnHover(Point position)
        {
            IPiece? piece = Game.GetTilePiece(position);
            if (piece == null)
            {
                return new NothingHighlighted(Game);
            }

            IReadOnlyCollection<Point> positionsHighlighted = piece.GetPositionPieceCanMoveTo(position, Game.Board, Game.MovesHistory);
            return new PossibleMoveshighlighted(Game, positionsHighlighted);
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