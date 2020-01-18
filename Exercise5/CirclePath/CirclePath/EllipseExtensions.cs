namespace CirclePath
{
    using Windows.Foundation;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Shapes;

    public static class EllipseExtensions
    {
        public static bool Contains(this Ellipse Ellipse, Point location)
        {
            Point center = new Point(
                  Canvas.GetLeft(Ellipse) + (Ellipse.Width / 2),
                  Canvas.GetTop(Ellipse) + (Ellipse.Height / 2));

            double xRadius = Ellipse.Width / 2;
            double yRadius = Ellipse.Height / 2;


            if (xRadius <= 0.0 || yRadius <= 0.0)
                return false;

            Point normalized = new Point(location.X - center.X,location.Y - center.Y);

            return ((double)(normalized.X * normalized.X) / (xRadius * xRadius)) + ((double)(normalized.Y * normalized.Y) / (yRadius * yRadius)) <= 1.0;
        }
    }
}