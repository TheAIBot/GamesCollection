using Chess.Pieces;

namespace Chess.States
{
    public sealed class ChooseMove : IChessUIState
    {
        private readonly ChessGame Game;
        private readonly Point PositionOgPieceHighlightedMoves;
        private readonly IReadOnlyCollection<Point> PositionsHighlighted;

        public ChooseMove(ChessGame game, Point positionOgPieceHighlightedMoves, IReadOnlyCollection<Point> positionsHighlighted)
        {
            Game = game;
            PositionOgPieceHighlightedMoves = positionOgPieceHighlightedMoves;
            PositionsHighlighted = positionsHighlighted;
        }

        public IChessUIState? OnClick(Point position)
        {
            if (!PositionsHighlighted.Contains(position))
            {
                IPiece? piece = Game.GetTilePiece(position);
                if (piece == null)
                {
                    return new NothingHighlighted(Game);
                }

                IReadOnlyCollection<Point> positionsHighlighted = piece.GetPositionPieceCanMoveTo(position, Game.Board, Game.MovesHistory);
                return new ChooseMove(Game, position, positionsHighlighted);
            }

            Game.MovePiece(PositionOgPieceHighlightedMoves, position);
            return new NothingHighlighted(Game);
        }

        public IChessUIState? OnHover(Point position)
        {
            return null;
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