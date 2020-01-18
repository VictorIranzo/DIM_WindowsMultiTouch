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
            Image image = e.OriginalSource as Image;

            // Rotate the Rectangle.
            CompositeTransform compositeTransform = new CompositeTransform()
            {
                Rotation = e.Delta.Rotation,
                CenterX = image.CenterPoint.X,
                CenterY = image.CenterPoint.Y,
                ScaleX = e.Delta.Scale,
                ScaleY = e.Delta.Scale,
            };

            this.image.RenderTransform = compositeTransform;
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.listView.Items.Add($"Pressed X: {e.GetCurrentPoint(this.image).Position.X} {e.GetCurrentPoint(this.image).Position.Y}");
        }
    }
}
