namespace CirclePath
{
    using System.Collections.Generic;
    using Windows.Foundation;

    public class PointsLine
    {
        private List<Point> points;

        public List<Point> Points
        {
            get
            {
                return this.points ?? (this.points = new List<Point>());
            }
        }
    }
}