using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NBPF.Blueprint
{
    public class BPScreen : BPObject
    {
        #region Private Member
        private float _width = 100.0f;
        private float _height = 100.0f;
        private float _actualWidth = 10.0f;
        private float _actualHeight = 10.0f;
        private float _thickness = 20.0f;
        #endregion



        #region Public Member
        public float Width
        {
            get { return _width; }
            set { _width = value; Update(); }
        }
        public float Height
        {
            get { return _height; }
            set { _height = value; Update(); }
        }
        public float ActualWidth
        {
            get { return _actualWidth; }
            set { _actualWidth = value; }
        }
        public float ActualHeight
        {
            get { return _actualHeight; }
            set { _actualHeight = value; }
        }
        #endregion



        #region Constructor
        public BPScreen() : base() { }
        #endregion



        #region Protected Member
        protected override void SetupObject()
        {
            Path path = new Path();
            path.Fill = Tools.GlobalParameters.ScreenFillColor;
            path.StrokeThickness = 0.0f;

            RectangleGeometry rectIn = new RectangleGeometry();
            RectangleGeometry rectOut = new RectangleGeometry();

            rectIn.Rect = new System.Windows.Rect(
                new System.Windows.Point(_x, _y),
                new System.Windows.Point(_x + _width, _y - _height));
            rectOut.Rect = new System.Windows.Rect(
                new System.Windows.Point(_x - _thickness, _y + _thickness),
                new System.Windows.Point(_x + _width + _thickness, _y - _height - _thickness));

            CombinedGeometry combinedGeometry = new CombinedGeometry();
            combinedGeometry.Geometry1 = rectOut;
            combinedGeometry.Geometry2 = rectIn;
            combinedGeometry.GeometryCombineMode = GeometryCombineMode.Exclude;

            path.Data = combinedGeometry;

            _drawElements.Add(path);
        }
        #endregion
    }
}
