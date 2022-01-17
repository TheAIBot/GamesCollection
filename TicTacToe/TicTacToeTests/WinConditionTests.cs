using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public sealed class GameOverTests
    {
        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinHorizontalTop(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 1, 3, 5 },
                { 2, 4, 0 },
                { 0, 0, 0 }
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinHorizontalMiddle(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 0, 0, 0 },
                { 1, 3, 5 },
                { 2, 4, 0 }
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinHorizontalBottom(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 0, 0, 0 },
                { 2, 4, 0 },
                { 1, 3, 5 },
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinVerticalLeft(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 1, 2, 0 },
                { 3, 4, 0 },
                { 5, 0, 0 },
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinVerticalMiddle(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 0, 1, 2 },
                { 0, 3, 4 },
                { 0, 5, 0 },
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinVerticalRight(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 0, 2, 1 },
                { 0, 4, 3 },
                { 0, 0, 5 },
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinDiagonalUp(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 4, 0, 5 },
                { 2, 3, 0 },
                { 1, 0, 0 },
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanWinDiagonalDown(PlayerMoves winner)
        {
            VerifyMovesToWin(winner, winner, new int[3, 3]
            {
                { 1, 2, 4 },
                { 0, 3, 0 },
                { 0, 0, 5 },
            });
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CanBeTie(PlayerMoves firstPlayer)
        {
            VerifyMovesToWin(firstPlayer, PlayerMoves.None, new int[3, 3]
            {
                { 6, 7, 2 },
                { 8, 5, 9 },
                { 1, 4, 3 },
            });
        }

        private static void VerifyMovesToWin(PlayerMoves firstPlayer, PlayerMoves winner, int[,] moves)
        {
            var game = new TicTacToeGame(firstPlayer);
            PlayerMoves? actualWinner = null;
            game.OnGameOver += x => { actualWinner = x; };

            TestHelper.ExecuteMoves(game, moves);

            Assert.True(game.GameIsOver);
            Assert.NotNull(actualWinner);
            Assert.Equal(winner, actualWinner);
        }
    }
}
