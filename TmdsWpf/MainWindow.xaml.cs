using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tmds.Components;
using g = Tmds.Graphics.Components;

namespace Tmds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;



        public MainWindow()
        {
            InitializeComponent();

            TerritoryScroll.ScrollChanged += OnTerritoryScrollScrollChanged;
            TerritoryScroll.MouseLeftButtonUp += OnMouseLeftButtonUp;
            TerritoryScroll.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
            TerritoryScroll.PreviewMouseWheel += OnPreviewMouseWheel;
            TerritoryScroll.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
            TerritoryScroll.MouseMove += OnMouseMove;
            slider.ValueChanged += OnSliderValueChanged;




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tracks = new Tracks();
            tracks.LoadByTerritory(100);

            var tags = new Tags();
            tags.Load(100);
            tags.AttachToTracks(tracks);

            foreach (Track ct in tracks)
            {
                g.Track t = new g.Track(TerritoryCanvas, ct);
                t.Draw();
            }

            foreach (Tag ct in tags)
            {
                g.Tag tg = new g.Tag(TerritoryCanvas, ct);
                tg.Draw();
            }


        }

        #region Event Handlers

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point posNow = e.GetPosition(TerritoryScroll);
            MouseLocationStatus.Text = posNow.ToString();

            if (lastDragPoint.HasValue)
            {
                if (posNow == lastDragPoint) return;

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                TerritoryScroll.ScrollToHorizontalOffset(TerritoryScroll.HorizontalOffset - dX);
                TerritoryScroll.ScrollToVerticalOffset(TerritoryScroll.VerticalOffset - dY);

                lastDragPoint = posNow;
            }
        }

        void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(Keyboard.IsKeyDown(Key.LeftCtrl) || (Keyboard.IsKeyDown(Key.RightCtrl)))) return;

            var mousePos = e.GetPosition(TerritoryScroll);
            if (mousePos.X <= TerritoryScroll.ViewportWidth && 
                mousePos.Y < TerritoryScroll.ViewportHeight) //make sure we still can use the scrollbars
            {
                TerritoryScroll.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(TerritoryScroll);
            }
        }

        void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(TerritoryCanvas);

            if (e.Delta > 0)
            {
                slider.Value += 1;
            }
            if (e.Delta < 0)
            {
                slider.Value -= 1;
            }

            e.Handled = true;
        }

        void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TerritoryScroll.Cursor = Cursors.Arrow;
            TerritoryScroll.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged(object sender,
             RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;
            scaleTransform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(TerritoryScroll.ViewportWidth / 2,
                                             TerritoryScroll.ViewportHeight / 2);
            lastCenterPositionOnTarget = TerritoryScroll.TranslatePoint(centerOfViewport, TerritoryCanvas);
        }

        void OnTerritoryScrollScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(TerritoryScroll.ViewportWidth / 2,
                                                         TerritoryScroll.ViewportHeight / 2);
                        Point centerOfTargetNow =
                              TerritoryScroll.TranslatePoint(centerOfViewport, TerritoryCanvas);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(TerritoryCanvas);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / TerritoryCanvas.Width;
                    double multiplicatorY = e.ExtentHeight / TerritoryCanvas.Height;

                    double newOffsetX = TerritoryScroll.HorizontalOffset -
                                        dXInTargetPixels * multiplicatorX;
                    double newOffsetY = TerritoryScroll.VerticalOffset -
                                        dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    TerritoryScroll.ScrollToHorizontalOffset(newOffsetX);
                    TerritoryScroll.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }

        private void OnLostMouseCapture(object sender, MouseEventArgs e)
        {
            MouseCaptureIndicator.Fill = StatusBar.Background;
        }

        private void OnGotMouseCapture(object sender, MouseEventArgs e)
        {
            MouseCaptureIndicator.Fill = System.Windows.Media.Brushes.Yellow;
        }

        #endregion

 

    }
}
