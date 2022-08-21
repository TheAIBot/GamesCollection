namespace Chess.States
{
    public interface IChessUIState
    {
        IChessUIState? OnHover(Point position);
        IChessUIState? OnClick(Point position);

        string GetTileCustomStyle(Point position);
    }
}