namespace Chess.Pieces
{
    internal interface ICustomMoveBehavior
    {
        bool MoveIfIsCustomMove(Point from, Point to, ChessBoard board, ChessMovesHistory movesHistory);
    }
    public sealed class Pawn : IPiece, ICustomMoveBehavior
    {
        private readonly Point MoveDirection;
        private readonly Point StartPosition;
        public Player Player { get; private init; }

        public Pawn(Player player, Point moveDirection, Point startPosition)
        {
            Player = player;
            MoveDirection = moveDirection;
            StartPosition = startPosition;
        }

        public IReadOnlyCollection<Point> GetPositionPieceCanMoveTo(Point piecePosition, ChessBoard board, ChessMovesHistory movesHistory)
        {
            var positionsCanMoveTo = new List<Point>();
            PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, MoveDirection, Player);
            if (piecePosition == StartPosition)
            {
                PieceMoveHelper.AddPositionIfCanMoveToPosition(positionsCanMoveTo, board, piecePosition, MoveDirection * 2, Player);
            }

            //Need to implement the conversion and the wierd takeover
            AddEnPessantIfCanMove(positionsCanMoveTo, piecePosition, new Point(1, 0), board, movesHistory);
            AddEnPessantIfCanMove(positionsCanMoveTo, piecePosition, new Point(-1, 0), board, movesHistory);

            return positionsCanMoveTo;
        }

        private void AddEnPessantIfCanMove(List<Point> positionsCanMoveTo, Point piecePosition, Point relativeEnemyPosition, ChessBoard board, ChessMovesHistory movesHistory)
        {
            if (!board.TryGetPiece(piecePosition + relativeEnemyPosition, out IPiece? enemyPiece))
            {
                return;
            }

            if (enemyPiece is not Pawn enemyPawn)
            {
                return;
            }

            IReadOnlyList<ChessMove> chessMoves = movesHistory.AllChessMoves;
            // Technically if the games state is correct then this case will never be hit
            // but lets just handle it anyway
            if (chessMoves.Count == 0)
            {
                return;
            }

            if (chessMoves[^1].Piece != enemyPawn)
            {
                return;
            }

            positionsCanMoveTo.Add(piecePosition + MoveDirection + relativeEnemyPosition);
        }

        public bool MoveIfIsCustomMove(Point from, Point to, ChessBoard board, ChessMovesHistory movesHistory)
        {
            IPiece? pieceToMove = board[from];
            if (pieceToMove == null)
            {
                throw new ArgumentOutOfRangeException(nameof(from), "Piece could not be moved since none were found at the location.");
            }

            if (TryHandleEnPessantMove(from, to, board, movesHistory, pieceToMove))
            {
                return true;
            }

            return false;
        }

        private bool TryHandleEnPessantMove(Point from, Point to, ChessBoard board, IChessMovesHistory movesHistory, IPiece pieceToMove)
        {
            Point moveVector = to - from;
            if (moveVector.ManhattanDistance() != 2)
            {
                return false;
            }

            Point enemyPosition = new Point(from.X + moveVector.X, from.Y);
            board[enemyPosition] = null;

            board[to] = pieceToMove;
            board[from] = null;
            movesHistory.RecordMove(pieceToMove, from, to);
            return true;
        }
    }
}
