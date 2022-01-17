using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public sealed class MovesTests
    {
        [Fact]
        public void ThrowExceptionOnInvalidFirstPlayer()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TicTacToeGame(PlayerMoves.None));
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void CorrectFirstPlayer(PlayerMoves firstPlayer)
        {
            var game = new TicTacToeGame(firstPlayer);
            
            game.TryPlace(0, 0);

            Assert.Equal(firstPlayer, game.GetTileState(0, 0));
        }

        [Theory]
        [InlineData(PlayerMoves.X, PlayerMoves.O)]
        [InlineData(PlayerMoves.O, PlayerMoves.X)]
        public void CorrectSecondPlayer(PlayerMoves firstPlayer, PlayerMoves secondPlayer)
        {
            var game = new TicTacToeGame(firstPlayer);

            game.TryPlace(0, 0);
            game.TryPlace(1, 0);

            Assert.Equal(firstPlayer, game.GetTileState(0, 0));
            Assert.Equal(secondPlayer, game.GetTileState(1, 0));
        }

        [Theory]
        [InlineData(PlayerMoves.X, PlayerMoves.O, PlayerMoves.X)]
        [InlineData(PlayerMoves.O, PlayerMoves.X, PlayerMoves.O)]
        public void CorrectThirdPlayer(PlayerMoves firstPlayer, PlayerMoves secondPlayer, PlayerMoves thirdPlayer)
        {
            var game = new TicTacToeGame(firstPlayer);

            game.TryPlace(0, 0);
            game.TryPlace(1, 0);
            game.TryPlace(2, 0);

            Assert.Equal(firstPlayer, game.GetTileState(0, 0));
            Assert.Equal(secondPlayer, game.GetTileState(1, 0));
            Assert.Equal(thirdPlayer, game.GetTileState(2, 0));
        }

        [Theory]
        [InlineData(PlayerMoves.X)]
        [InlineData(PlayerMoves.O)]
        public void NotPossibleToPlaceOnTopOfOtherPlayer(PlayerMoves firstPlayer)
        {
            var game = new TicTacToeGame(firstPlayer);

            Assert.True(game.TryPlace(0, 0));

            Assert.False(game.TryPlace(0, 0));
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(3, 0)]
        [InlineData(0, 3)]
        public void NotPossibleToPlaceOutsideBoard(int x, int y)
        {
            var game = new TicTacToeGame();

            Assert.False(game.TryPlace(x, y));
        }

        [Fact]
        public void NotPossibleToPlaceAfterGameIsOver()
        {
            var game = new TicTacToeGame();

            TestHelper.ExecuteMoves(game, new int[3, 3]
            {
                { 1, 3, 5 },
                { 2, 4, 0 },
                { 0, 0, 0 }
            });

            Assert.False(game.TryPlace(2, 2));
        }
    }
}
