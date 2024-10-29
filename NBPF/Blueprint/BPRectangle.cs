using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        private bool _isWidthDimensionLinesUp = true;
        private bool _isHeightDimensionLinesRight = true;
        private Tools.GlobalParameters.EMaterialType _material = Tools.GlobalParameters.EMaterialType.dielectric;
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
        public bool IsWidthDimensionLinesUp
        {
            get { return _isWidthDimensionLinesUp; }
            set { _isWidthDimensionLinesUp = value; base.Update(); }
        }
        public bool IsHeightDimensionLinesUp
        {
            get { return _isHeightDimensionLinesRight; }
            set { _isHeightDimensionLinesRight = value; base.Update(); }
        }
        public Tools.GlobalParameters.EMaterialType Material
        {
            get { return _material; }
            set { _material = value; Update(); }
        }
        #endregion



        #region Constructor
        public BPRectangle() : base() { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            // Draw rectangle
            System.Windows.Shapes.Path pathRect = new System.Windows.Shapes.Path();
            System.Windows.Shapes.Path pathOutline = new System.Windows.Shapes.Path();
            RectangleGeometry rect = new RectangleGeometry();
            RectangleGeometry rectInOutline = new RectangleGeometry();
            RectangleGeometry rectOutOutline = new RectangleGeometry();
            CombinedGeometry outline = new CombinedGeometry();

            switch (_material)
            {
                case Tools.GlobalParameters.EMaterialType.dielectric:
                    pathRect.Fill = Tools.GlobalParameters.DielectricFillColor;
                    pathOutline.Fill = Tools.GlobalParameters.DielectricStrokeColor;
                    break;
                case Tools.GlobalParameters.EMaterialType.conductor:
                    pathRect.Fill = Tools.GlobalParameters.ConductorFillColor;
                    pathOutline.Fill = Tools.GlobalParameters.ConductorStrokeColor;
                    break;
            }
            outline.GeometryCombineMode = GeometryCombineMode.Xor;
            outline.Geometry1 = rectInOutline;
            outline.Geometry2 = rectOutOutline;
            pathRect.Data = rect;
            pathOutline.Data = outline;

            rect.Rect = new System.Windows.Rect(new System.Windows.Point(_x, _y), new System.Windows.Point(_x + _width, _y - _height));

            System.Windows.Point p1;
            System.Windows.Point p2;
            float strokeThickness = Tools.GlobalParameters.BPObjectStrokeThickness;
            float bufferX = _x, bufferY = _y, bufferWidth = _width, bufferHeight = _height;
            if (_width < 0) { bufferX = _x + _width; bufferWidth *= -1.0f; }
            if (_height > 0) { bufferY = _y - _height; bufferHeight *= -1.0f; }
            p1 = new System.Windows.Point(bufferX + strokeThickness, bufferY + strokeThickness);
            p2 = new System.Windows.Point(bufferX + bufferWidth - strokeThickness, bufferY - bufferHeight - strokeThickness);

            rectOutOutline.Rect = rect.Rect;
            rectInOutline.Rect = new System.Windows.Rect(p1, p2);

            _drawElements.Add(pathRect);
            _drawElements.Add(pathOutline);


            // Draw dimension lines
            if (_showWidthDimensionLines)
            {
                if(_isWidthDimensionLinesUp)
                {
                    _widthDimensionLines = new BPDimensionLines(_x, -1.0f * _y + _height, _x + _width, -1.0f * _y + _height);
                }
                else
                {
                    _widthDimensionLines = new BPDimensionLines(_x, -1.0f * _y, _x + _width, -1.0f * _y);
                }
                _drawElements.Add(_widthDimensionLines.DrawLayer);
            }

            if (_showHeightDimensionLines)
            {
                if(_isHeightDimensionLinesRight)
                {
                    _heightDimensionLines = new BPDimensionLines(_x + _width, -1.0f * _y, _x + _width, -1.0f * _y + _height);
                }
                else
                {
                    _heightDimensionLines = new BPDimensionLines(_x, -1.0f * _y, _x, -1.0f * _y + _height);
                }
                _drawElements.Add(_heightDimensionLines.DrawLayer);
            }
        }
        #endregion
    }
}
