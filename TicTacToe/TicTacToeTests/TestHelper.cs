using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    internal static class TestHelper
    {
        internal static void ExecuteMoves(TicTacToeGame game, int[,] moves)
        {
            int moveCount = 0;
            foreach (var move in moves)
            {
                moveCount = Math.Max(moveCount, move);
            }

            for (int i = 1; i <= moveCount; i++)
            {
                Point pos = GetMovePosition(moves, i);
                Assert.False(game.GameIsOver);
                game.AssertPlace(pos.X, pos.Y);
            }
        }

        private static Point GetMovePosition(int[,] moves, int moveNumber)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (moves[y, x] == moveNumber)
                    {
                        return new Point(x, y);
                    }
                }
            }

            throw new ArgumentException("Failed to find the next move in the move matrix.");
        }

        internal static void AssertPlace(this TicTacToeGame game, int x, int y)
        {
            Assert.True(game.TryPlace(x, y));
        }
    }
}
