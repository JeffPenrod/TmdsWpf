using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tmds.Graphics.Components
{
    public class Track
        : IComponent, IDisposable
    {

        private Brush _strokeBrush;
        private Brush _fillBrush;
        private const double _strokeThickness = 0.7;
        private Rectangle _rect;


        public Track(Canvas canvas, Tmds.Components.Track trackComponent)
        {
            Canvas = canvas;
            TrackComponent = trackComponent;
            _strokeBrush = Brushes.Black;
            _fillBrush = Brushes.White;
        }

        public Tmds.Components.Track TrackComponent { get; private set; }

        public Canvas Canvas { get; set; }

        public float MouseMiles { get; private set; }

        public void Draw()
        {
            _rect = GetOutline();

            _rect.Stroke = _strokeBrush;
            _rect.Fill = _fillBrush;
            _rect.StrokeThickness = _strokeThickness;
            _rect.ToolTip = TrackComponent.Guid.ToString("D");
            _rect.BringIntoView();

            Canvas.SetLeft(_rect, TrackComponent.LX);
            Canvas.SetTop(_rect, TrackComponent.LY);

            Canvas.Children.Add(_rect);

            DrawMileLines();

        }

        private Rectangle GetOutline()
        {
            Rectangle r = new Rectangle();

            r.Width = Math.Abs(TrackComponent.RX - TrackComponent.LX);
            r.Height = 9;

            r.MouseDown += TrackMouseDown;
            r.MouseUp += TrackMouseUp;
            r.MouseMove += TrackMouseMove;

            return r;
        }

        private void DrawMileLines()
        {
            MilepostInfo mpi = DetermineMilepostSequence(TrackComponent.LeftLimitMPRange, TrackComponent.RightLimitMPRange);
            var interval = CalculateInterval(mpi, _rect.Width);
            if (interval <= 0 || double.IsInfinity(interval)) return;

            var offset = CalculateOffset(mpi, interval);

            if (offset + interval >= _rect.Width) return;

            int mp = mpi.FirstMilepost;

            for (Double x = offset; x < _rect.Width + offset; x += interval)
            {

                Line ln = new Line()
                {
                    Stroke = System.Windows.Media.Brushes.Blue,
                    StrokeThickness = 1,
                    X1 = x + TrackComponent.LX,
                    X2 = x + TrackComponent.LX,
                    Y1 = TrackComponent.LY,
                    Y2 = TrackComponent.LY + _rect.Height,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    ToolTip = mp.ToString("d")
                };

                Canvas.Children.Add(ln);

                mp += mpi.IncrementAmount;
            }

        }

        private MilepostInfo DetermineMilepostSequence(float milepostLeft, float milepostRight)
        {
            double nextMp;

            if (milepostRight > milepostLeft)
            {
                nextMp = Math.Ceiling(milepostLeft);
                if (nextMp > milepostRight) return new MilepostInfo(milepostLeft, milepostRight, 0, 1);

                return new MilepostInfo(milepostLeft, milepostRight, (int)nextMp, 1);

            }
            else if (milepostRight < milepostLeft)
            {
                nextMp = Math.Floor(milepostLeft);
                if (nextMp < milepostRight) return new MilepostInfo(milepostLeft, milepostRight, 0, -1);

                return new MilepostInfo(milepostLeft, milepostRight, (int)nextMp, -1);
            }
            else
            {
                return new MilepostInfo(milepostLeft, milepostRight, 0, 0);
            }

        }

        private double CalculateInterval(MilepostInfo mpi, double graphicTrackLength)
        {
            double lm = Math.Abs(mpi.LeftMilepost - mpi.RightMilepost);
            return graphicTrackLength / lm;
        }

        private double CalculateOffset(MilepostInfo mpi, double interval)
        {

            if (mpi.FirstMilepost == 0) return 0;

            double distance = Math.Abs(mpi.FirstMilepost - mpi.LeftMilepost);
            return distance * interval;

        }
        private void TrackMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Rectangle r = sender as Rectangle;
            r.Fill = Brushes.White;
        }

        private void TrackMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Rectangle r = sender as Rectangle;
            r.Fill = Brushes.DarkOliveGreen;
        }

        private void TrackMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Get mouse position
            var pos = e.GetPosition(Canvas);

            // Calculate ratio
            var grTrkLength = (float)Utility.CalculateDistance(
                TrackComponent.LX, TrackComponent.LY,
                TrackComponent.RX, TrackComponent.RY);

            var grDistanceToMouse = (float)Utility.CalculateDistance(
                pos.X, pos.Y, TrackComponent.LX, TrackComponent.LY);

            var ratio = grDistanceToMouse / grTrkLength;

            // Get Miles.
            MilepostInfo mpi = DetermineMilepostSequence(TrackComponent.LeftLimitMPRange, TrackComponent.RightLimitMPRange);
            var trackLengthInMiles = Math.Abs(mpi.RightMilepost -  mpi.LeftMilepost);
            MouseMiles = mpi.LeftMilepost + mpi.IncrementAmount * ratio * trackLengthInMiles;

        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _rect.MouseUp -= TrackMouseDown;
                    _rect.MouseDown -= TrackMouseDown;

                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Track() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


        private struct MilepostInfo
        {
            public MilepostInfo(float leftMp, float rightMp, int firstMp, int incrAmt)
            {
                LeftMilepost = leftMp;
                RightMilepost = rightMp;
                FirstMilepost = firstMp;
                IncrementAmount = incrAmt;
            }

            public float LeftMilepost;
            public float RightMilepost;
            public int FirstMilepost;
            public int IncrementAmount;
        }
    }
}
