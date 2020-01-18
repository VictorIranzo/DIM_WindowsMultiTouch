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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScaleAndRotateImage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.image.ManipulationMode = ManipulationModes.Scale | ManipulationModes.Rotate;
        }

        private void Image_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            FrameworkElement elem = sender as FrameworkElement;

            CompositeTransform transform = elem.RenderTransform as CompositeTransform;
            transform.Rotation += e.Delta.Rotation;
            transform.CenterX = elem.Width / 2;
            transform.CenterY = elem.Height / 2;
            transform.ScaleX *= e.Delta.Scale;
            transform.ScaleY *= e.Delta.Scale;

            ////Windows.Foundation.Point pointOfElement = elem.TransformToVisual(Window.Current.Content).TransformPoint(new Windows.Foundation.Point(0, 0));
            ////transform.CenterX = pointOfElement.X + 75;
            ////transform.CenterY = pointOfElement.Y + 75;
            ////transform.CenterX = Canvas.GetLeft(elem);
            ////transform.CenterY = Canvas.GetTop(elem);
            ////CompositeTransform compositeTransform = new CompositeTransform()
            ////{
            ////    Rotation = e.Delta.Rotation,
            ////    ScaleX = e.Delta.Scale,
            ////    ScaleY = e.Delta.Scale,
            ////};

            ////elem.RenderTransform = compositeTransform;
        }
    }
}