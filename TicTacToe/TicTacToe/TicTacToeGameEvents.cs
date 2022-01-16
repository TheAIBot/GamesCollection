namespace TicTacToe
{
    public sealed partial class TicTacToeGame
    {
        public delegate void GameOverHandler(PlayerMoves playerWinning);
        public event GameOverHandler OnGameOver;
    }
}