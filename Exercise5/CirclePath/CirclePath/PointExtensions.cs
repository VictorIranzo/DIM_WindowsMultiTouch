namespace CirclePath
{
    using System;
    using Windows.Foundation;

    public static class PointExtensions
    {
        public static float CalculateDistanceToPoint(this Point point1, Point point2)
        {
            return (float)Math.Sqrt((point1.Y - point2.Y) * (point1.Y - point2.Y) + (point1.X - point2.X) * (point1.X - point2.X));
        }
    }
}