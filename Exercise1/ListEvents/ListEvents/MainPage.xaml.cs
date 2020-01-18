using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListEvents
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Image_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerCanceled) X: {pointerXPosition} Y: {pointerYPosition}");
        }

        private void Image_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerCaptureLost) X: {pointerXPosition} Y: {pointerYPosition}");
        }

        private void Image_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerEntered) X: {pointerXPosition} Y: {pointerYPosition}");
        }

        private void Image_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerExited) X: {pointerXPosition} Y: {pointerYPosition}");
        }

        private void Image_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerMoved) X: {pointerXPosition} Y: {pointerYPosition}");
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerPressed) X: {pointerXPosition} Y: {pointerYPosition}");
        }

        private void Image_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerReleased) X: {pointerXPosition} Y: {pointerYPosition}");
        }

        private void Image_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            double pointerXPosition = e.GetCurrentPoint(this.image).Position.X;
            double pointerYPosition = e.GetCurrentPoint(this.image).Position.Y;

            this.listView.Items.Add($"(PointerWheelChanged) X: {pointerXPosition} Y: {pointerYPosition}");
        }
    }
}