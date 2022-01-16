namespace TicTacToe
{
    public sealed partial class TicTacToeGame
    {
        private static readonly Point[][] WinDirections = new Point[][]
        {
            // Horizontal
            new Point[] { new Point(0, 0), new Point(1, 0), new Point(2, 0) },
            new Point[] { new Point(0, 1), new Point(1, 1), new Point(2, 1) },
            new Point[] { new Point(0, 2), new Point(1, 2), new Point(2, 2) },

            // Vertical
            new Point[] { new Point(0, 0), new Point(0, 1), new Point(0, 2) },
            new Point[] { new Point(1, 0), new Point(1, 1), new Point(1, 2) },
            new Point[] { new Point(2, 0), new Point(2, 1), new Point(2, 2) },

            // Diagonal
            new Point[] { new Point(0, 0), new Point(1, 1), new Point(2, 2) },
            new Point[] { new Point(2, 0), new Point(1, 1), new Point(0, 2) },
        };
        private readonly PlayerMoves[,] BoardState = new PlayerMoves[3, 3];
        private PlayerMoves PlayersTurn = PlayerMoves.X;
        public bool GameIsOver { get; private set; } = false;

        public PlayerMoves GetTileState(int x, int y)
        {
            if (!WithinBoard(x, y))
            {
                throw new ArgumentException($"Tile position out of range: X: {x} Y: {y}");
            }

            return BoardState[x, y];
        }

        public bool TryPlace(int x, int y)
        {
            if (GameIsOver)
            {
                return false;
            }

            if (!WithinBoard(x, y))
            {
                return false;
            }

            if (BoardState[x, y] != PlayerMoves.None)
            {
                return false;
            }

            BoardState[x, y] = PlayersTurn;

            if (SomeoneWon())
            {
                GameIsOver = true;
                OnGameOver?.Invoke(PlayersTurn);
            }
            else if (GameIsATie())
            {
                GameIsOver = true;
                OnGameOver?.Invoke(PlayerMoves.None);
            }

            PlayersTurn = GetNextPlayersTurn(PlayersTurn);
            return true;
        }

        private bool WithinBoard(int x, int y)
        {
            return x >= 0 && x < BoardState.GetLength(0) &&
                   y >= 0 && y < BoardState.GetLength(1);
        }

        private static PlayerMoves GetNextPlayersTurn(PlayerMoves currentPlayersTurn) => currentPlayersTurn switch
        {
            PlayerMoves.X => PlayerMoves.O,
            PlayerMoves.O => PlayerMoves.X,
            _ => throw new ArgumentException($"Invalid player move. Move: {currentPlayersTurn}")
        };

        private bool SomeoneWon()
        {
            foreach (var winDir in WinDirections)
            {
                var playersInDir = winDir.Select(x => BoardState[x.X, x.Y]).Distinct();
                if (playersInDir.Count() == 1 &&
                    playersInDir.All(x => x != PlayerMoves.None))
                {
                    return true;
                }
            }

            return false;
        }

        private bool GameIsATie()
        {
            for (int y = 0; y < BoardState.GetLength(1); y++)
            {
                for (int x = 0; x < BoardState.GetLength(0); x++)
                {
                    if (BoardState[x, y] == PlayerMoves.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}