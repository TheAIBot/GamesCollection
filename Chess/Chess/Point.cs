﻿namespace Chess
{
    public record struct Point(int X, int Y)
    {
        public static Point operator +(Point left, Point right) => new Point(left.X + right.X, left.Y + right.Y);
        public static Point operator -(Point left, Point right) => new Point(left.X - right.X, left.Y - right.Y);
    }
}
