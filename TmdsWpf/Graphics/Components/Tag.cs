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
    public class Tag 
        : IComponent, IDisposable
    {

        private double _width = 0;
        private double _offset = double.NaN;
        private Brush _strokeBrush;
        private Brush _fillBrush;
        private const double _strokeThickness = 0.7;



        public Tag(Canvas c, Tmds.Components.Tag componentTag)
        {
            Canvas = c;
            ComponentTag = componentTag;
            _strokeBrush = Brushes.Black;
            _fillBrush = CreateCheckerBrush();
            
        }

        public Canvas Canvas { get; set; }
        public Tmds.Components.Tag ComponentTag { get; private set; }
        public Polygon Outline { get; set; }
        public double Width
        {
            get
            {
                if (_width != 0) return _width;

                if (ComponentTag.AffectedTracks.Count == 0) return 0;

                var trk = ComponentTag.AffectedTracks[0];

                float dMtag = Math.Abs(ComponentTag.TagMpRight - ComponentTag.TagMpLeft);
                float dMtrk = Math.Abs(trk.RightLimitMPRange - trk.LeftLimitMPRange);
                float dUtrk = (float)Utility.CalculateDistance(trk.LX, trk.LY, trk.RX, trk.RY);

                _width = (dMtag / dMtrk) * dUtrk;

                return _width;
            }
        }
        public double Offset
        {
            get
            {
                if (!double.IsNaN(_offset)) return _offset;
                if (ComponentTag.AffectedTracks.Count == 0) return 0;

                var trk = ComponentTag.AffectedTracks[0];

                float tagOffsetInMiles = Math.Abs(ComponentTag.TagMpLeft - trk.LeftLimitMPRange);
                float trkLengthInMiles = Math.Abs(trk.RightLimitMPRange - trk.LeftLimitMPRange);
                float trkLengthInUnits = (float)Utility.CalculateDistance(trk.LX, trk.LY, trk.RX, trk.RY);

                _offset = (tagOffsetInMiles / trkLengthInMiles) * trkLengthInUnits;

                return _offset;

            }

        }

        public void Draw()
        {

            Outline = GetOutline();

            Outline.Stroke = _strokeBrush;
            Outline.Fill = _fillBrush;
            Outline.StrokeThickness = _strokeThickness;
            Outline.ToolTip = ComponentTag.DataString;

            Canvas.SetLeft(Outline, 0);
            Canvas.SetTop(Outline, 0);
            Canvas.Children.Add(Outline);

        }

        private Polygon GetOutline()
        {
            if (ComponentTag.AffectedTracks.Count == 0) return null;

            var trk = ComponentTag.AffectedTracks[0];
            const int height = 9;

            Polygon poly = new Polygon();
            poly.Points.Add(new Point(trk.LX + Offset, trk.LY));
            poly.Points.Add(new Point(trk.LX + Offset + Width, trk.RY));
            poly.Points.Add(new Point(trk.LX + Offset + Width, trk.RY + height));
            poly.Points.Add(new Point(trk.LX + Offset, trk.LY + height));

            return poly;

        }

        private DrawingBrush CreateCheckerBrush()
        {
            DrawingBrush b = new DrawingBrush();
            b.Viewport = new Rect(0, 0, 0.1, 1);
            b.TileMode = TileMode.Tile;

            GeometryDrawing square = new GeometryDrawing(
                Brushes.Cyan,
                null,
                new RectangleGeometry(new Rect(0, 0, 1, 1)));

            GeometryGroup gGroup = new GeometryGroup();
            gGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 0.5, 0.5)));
            gGroup.Children.Add(new RectangleGeometry(new Rect(0.5, 0.5, 0.5, 0.5)));

            GeometryDrawing checkers = new GeometryDrawing(new SolidColorBrush(Colors.Red), null, gGroup);

            DrawingGroup checkersDrawingGroup = new DrawingGroup();
            checkersDrawingGroup.Children.Add(square);
            checkersDrawingGroup.Children.Add(checkers);

            b.Drawing = checkersDrawingGroup;

            return b;

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
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Tag() {
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
    }
}
