namespace MultipleImages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
            transform.TranslateX += e.Delta.Translation.X;
            transform.TranslateY += e.Delta.Translation.Y;
        }
    }
}