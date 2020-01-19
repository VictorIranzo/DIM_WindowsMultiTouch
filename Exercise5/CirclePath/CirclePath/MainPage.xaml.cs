namespace CirclePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Shapes;

    public sealed partial class MainPage : Page
    {
        private static Random random = new Random();

        private List<Ellipse> circles = new List<Ellipse>();

        private Dictionary<uint, PointsLine> lines = new Dictionary<uint, PointsLine>();

        public MainPage()
        {
            this.InitializeComponent();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Refresh();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.Refresh();
        }

        private void Refresh()
        {
            this.canvas.Children.Clear();
            this.circles.Clear();

            for (int i = 0; i < 3; i++)
            {
                SolidColorBrush color = new SolidColorBrush(Color.FromArgb(
                    (byte)random.Next(byte.MinValue, byte.MaxValue),
                    (byte)random.Next(byte.MinValue, byte.MaxValue),
                    (byte)random.Next(byte.MinValue, byte.MaxValue),
                    (byte)random.Next(byte.MinValue, byte.MaxValue)));

                this.CreateCircle(color);
                this.CreateCircle(color);
            }
        }

        private void CreateCircle(SolidColorBrush color)
        {
            Ellipse circle1 = new Ellipse()
            {
                Width = 100,
                Height = 100,
                Fill = color,
            };

            Canvas.SetTop(circle1, this.canvas.ActualHeight * random.NextDouble());
            Canvas.SetLeft(circle1, this.canvas.ActualWidth * random.NextDouble());

            circles.Add(circle1);
            this.canvas.Children.Add(circle1);
        }

        private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (this.lines.TryGetValue(e.Pointer.PointerId, out PointsLine line))
            {
                Point touchPoint = e.GetCurrentPoint(this.canvas).Position;
                Point lastPoint = line.Line.Points.Last();

                if (touchPoint.CalculateDistanceToPoint(lastPoint) < 10)
                {
                    return;
                }

                line.Line.Points.Add(touchPoint);
            }
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Point touchPoint = e.GetCurrentPoint(this.canvas).Position;

            if (!this.IsInTouchWithCircles(touchPoint, out Ellipse selectedEllipse))
            {
                return;
            }

            PointsLine newLine = new PointsLine()
            {
                Line = new Polyline()
                {
                    Stroke = new SolidColorBrush(Colors.Wheat),
                    StrokeThickness = 5,
                    FillRule = FillRule.EvenOdd,
                    StrokeLineJoin = PenLineJoin.Round
                },
                InitialCircle = selectedEllipse
            };

            newLine.Line.Points.Add(touchPoint);

            this.lines.Add(e.Pointer.PointerId, newLine);

            canvas.Children.Add(newLine.Line);
        }

        private bool IsInTouchWithCircles(Point touchPoint, out Ellipse selectedEllipse)
        {
            selectedEllipse = this.circles.FirstOrDefault(c => c.Contains(touchPoint));

            return selectedEllipse != null;
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Point touchPoint = e.GetCurrentPoint(this.canvas).Position;

            if (this.lines.TryGetValue(e.Pointer.PointerId, out PointsLine line))
            {
                this.lines.Remove(e.Pointer.PointerId);
                this.canvas.Children.Remove(line.Line);

                if (this.IsInTouchWithCircles(touchPoint, out Ellipse selectedEllipse))
                {
                    if (selectedEllipse.Fill == line.InitialCircle.Fill
                        && selectedEllipse != line.InitialCircle)
                    {
                        this.canvas.Children.Remove(line.InitialCircle);
                        this.canvas.Children.Remove(selectedEllipse);
                    }
                }
            }
        }
    }
}