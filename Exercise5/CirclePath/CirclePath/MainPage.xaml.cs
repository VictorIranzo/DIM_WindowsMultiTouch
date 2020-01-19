﻿namespace CirclePath
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

        private Dictionary<uint, Polyline> lines = new Dictionary<uint, Polyline>();

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
            if (this.lines.TryGetValue(e.Pointer.PointerId, out Polyline line))
            {
                Point touchPoint = e.GetCurrentPoint(this.canvas).Position;

                line.Points.Add(touchPoint);

                canvas.InvalidateArrange();
            }
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Point touchPoint = e.GetCurrentPoint(this.canvas).Position;

            if (!this.IsInTouchWithCircles(touchPoint))
            {
                return;
            }

            Polyline newLine = new Polyline()
            {
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 5,
                FillRule = FillRule.EvenOdd,
            };

            newLine.Points.Add(touchPoint);

            this.lines.Add(e.Pointer.PointerId, newLine);
        }

        private bool IsInTouchWithCircles(Point touchPoint)
        {
            return this.circles.Any(c => c.Contains(touchPoint));
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.lines.Remove(e.Pointer.PointerId);
        }
    }
}