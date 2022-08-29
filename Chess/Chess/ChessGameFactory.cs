using Chess.ChessHistory;
using Chess.Pieces;

namespace Chess
{
    public static class ChessGameFactory
    {
        public static ChessGame CreateGame()
        {
            var board = new ChessBoard();
            board[new Point(0, 0)] = new Rook(Player.Black);
            board[new Point(7, 0)] = new Rook(Player.Black);
            board[new Point(1, 0)] = new Knight(Player.Black);
            board[new Point(6, 0)] = new Knight(Player.Black);
            board[new Point(2, 0)] = new Bishop(Player.Black);
            board[new Point(5, 0)] = new Bishop(Player.Black);
            board[new Point(3, 0)] = new Queen(Player.Black);
            board[new Point(4, 0)] = new King(Player.Black);
            board[new Point(0, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(0, 1));
            board[new Point(1, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(1, 1));
            board[new Point(2, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(2, 1));
            board[new Point(3, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(3, 1));
            board[new Point(4, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(4, 1));
            board[new Point(5, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(5, 1));
            board[new Point(6, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(6, 1));
            board[new Point(7, 1)] = new Pawn(Player.Black, new Point(0, 1), new Point(7, 1));

            board[new Point(0, 7)] = new Rook(Player.White);
            board[new Point(7, 7)] = new Rook(Player.White);
            board[new Point(1, 7)] = new Knight(Player.White);
            board[new Point(6, 7)] = new Knight(Player.White);
            board[new Point(2, 7)] = new Bishop(Player.White);
            board[new Point(5, 7)] = new Bishop(Player.White);
            board[new Point(3, 7)] = new Queen(Player.White);
            board[new Point(4, 7)] = new King(Player.White);
            board[new Point(0, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(0, 6));
            board[new Point(1, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(1, 6));
            board[new Point(2, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(2, 6));
            board[new Point(3, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(3, 6));
            board[new Point(4, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(4, 6));
            board[new Point(5, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(5, 6));
            board[new Point(6, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(6, 6));
            board[new Point(7, 6)] = new Pawn(Player.White, new Point(0, -1), new Point(7, 6));

            var movesHistory = new ChessMovesHistory();
            return new ChessGame(board, movesHistory);
        }
    }
}