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
    public class BPRectangle : BPObject
    {
        #region Private Member
        private float _width = 100;
        private float _height = 100;
        private BPDimensionLines _widthDimensionLines;
        private BPDimensionLines _heightDimensionLines;
        private bool _showWidthDimensionLines = true;
        private bool _showHeightDimensionLines = true;
        #endregion



        #region Public Member
        public float Width
        {
            get { return _width; }
            set { _width = value; base.Update(); }
        }
        public float Height
        {
            get { return _height; }
            set { _height = value; base.Update(); }
        }
        public BPDimensionLines WidthDimensionLines
        {
            get { return _widthDimensionLines; }
        }
        public BPDimensionLines HeightDimensionLines
        {
            get { return _heightDimensionLines; }
        }
        public bool ShowWidthDimensionLines
        {
            get { return _showWidthDimensionLines; }
            set { _showWidthDimensionLines = value; base.Update(); }
        }
        public bool ShowHeightDimensionLines
        {
            get { return _showHeightDimensionLines; }
            set { _showHeightDimensionLines = value; base.Update(); }
        }

        #endregion



        #region Constructor
        public BPRectangle() : base() { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            // Draw rectangle
            Path path = new Path();
            path.Fill = Tools.GlobalParameters.DielectricFillColor;
            path.Stroke = Tools.GlobalParameters.DielectricStrokeColor;
            path.StrokeThickness = Tools.GlobalParameters.RectangleStrokeThickness;

            RectangleGeometry rectangle = new RectangleGeometry();
            rectangle.Rect = new System.Windows.Rect(new System.Windows.Point(_x, _y), new System.Windows.Point(_x + _width, _y - _height));
            path.Data = rectangle;

            _drawElements.Add(path);


            // Draw dimension lines
            if (_showWidthDimensionLines)
            {
                _widthDimensionLines = new BPDimensionLines(_x, _y - _height, _x + _width, _y - _height);
                _drawElements.Add(_widthDimensionLines.DrawLayer);
            }

            if (_showHeightDimensionLines)
            {
                _heightDimensionLines = new BPDimensionLines(_x + _width, _y, _x + _width, _y - _height);
                _drawElements.Add(_heightDimensionLines.DrawLayer);
            }
        }
        #endregion
    }
}
