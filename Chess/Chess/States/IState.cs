namespace Chess.States
{
    public interface IState
    {
        IState? OnHover(Point position);
        IState? OnClick(Point position);

        string GetTileCustomStyle(Point position);
    }
}