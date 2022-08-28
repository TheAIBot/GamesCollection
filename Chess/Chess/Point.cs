namespace Chess
{
    public record struct Point(int X, int Y)
    {
        public static Point operator +(Point left, Point right) => new Point(left.X + right.X, left.Y + right.Y);
        public static Point operator -(Point left, Point right) => new Point(left.X - right.X, left.Y - right.Y);
        public static Point operator -(Point right) => new Point(-right.X, -right.Y);
        public static Point operator *(Point left, int right) => new Point(left.X * right, left.Y * right);

        public int ManhattanDistance() => Math.Abs(X) + Math.Abs(Y);
    }
}
