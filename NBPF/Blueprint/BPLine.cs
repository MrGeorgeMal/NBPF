using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NBPF.Blueprint
{
    public class BPLine : BPObject
    {
        #region Private Member
        private float _x1 = 0.0f;
        private float _y1 = 0.0f;
        private float _x2 = 0.0f;
        private float _y2 = 100.0f;
        private float _actualX1 = 0.0f;
        private float _actualY1 = 0.0f;
        private float _actualX2 = 0.0f;
        private float _actualY2 = 10.0f;
        private float _thickess = 20.0f;
        private Tools.GlobalParameters.EBPLinePosition _linePosition = Tools.GlobalParameters.EBPLinePosition.center;
        private Tools.GlobalParameters.EMaterialType _material = Tools.GlobalParameters.EMaterialType.conductor;
        private double _dielectricPermittivity = 1.0;
        private double _potential = 1.0;
        private BPDimensionLines _dimensionLines;
        private bool _showDimensionLines = true;
        private bool _isDimensionLinesLeft = true;
        #endregion



        #region Public Member
        public float X1
        {
            get { return _x1; }
            set { _x1 = value; Update(); }
        }
        public float Y1
        {
            get { return -1.0f * _y1; }
            set { _y1 = -1.0f * value; Update(); }
        }
        public float X2
        {
            get { return _x2; }
            set { _x2 = value; Update(); }
        }
        public float Y2
        {
            get { return -1.0f * _y2; }
            set { _y2 = -1.0f * value; Update(); }
        }
        public float ActualX1
        {
            get { return _actualX1; }
            set { _actualX1 = value; }
        }
        public float ActualY1
        {
            get { return _actualY1; }
            set { _actualY1 = value; }
        }
        public float ActualX2
        {
            get { return _actualX2; }
            set { _actualX2 = value; }
        }
        public float ActualY2
        {
            get { return _actualY2; }
            set { _actualY2 = value; }
        }
        public Tools.GlobalParameters.EBPLinePosition StrokePosition
        {
            get { return _linePosition; }
            set { _linePosition = value; Update(); }
        }
        public Tools.GlobalParameters.EMaterialType Material
        {
            get { return _material; }
            set { _material = value; Update(); }
        }
        public double DielectricPermittivity
        {
            get { return _dielectricPermittivity; }
            set { _dielectricPermittivity = value; }
        }
        public double Potential
        {
            get { return _potential; }
            set { _potential = value; }
        }
        public bool IsDimensionLinesLeft
        {
            get { return _isDimensionLinesLeft; }
            set { _isDimensionLinesLeft = value; Update(); }
        }
        public bool ShowDimensionLinesLeft
        {
            get { return _showDimensionLines; }
            set { _showDimensionLines = value; Update(); }
        }
        public BPDimensionLines DimensionLines { get { return _dimensionLines; } }
        public float Thickness { get { return _thickess; } }
        #endregion



        #region Constructor
        public BPLine() : base() { }
        #endregion



        #region Protected Member
        protected override void SetupObject()
        {
            // Draw line
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

            System.Windows.Point p1;
            System.Windows.Point p2;
            System.Windows.Point pIn1;
            System.Windows.Point pIn2;
            float strokeThickness = Tools.GlobalParameters.BPObjectStrokeThickness;

            float bufferX1 = _x1, bufferY1 = _y1, bufferX2 = _x2, bufferY2 = _y2;
            if (_y1 == _y2)
            {
                if (_x1 > _x2)
                {
                    bufferX1 = _x2;
                    bufferX2 = _x1;
                }
                switch (_linePosition)
                {
                    case Tools.GlobalParameters.EBPLinePosition.center:
                        p1 = new System.Windows.Point(bufferX1, _y1 + _thickess / 2.0f);
                        p2 = new System.Windows.Point(bufferX2, _y2 - _thickess / 2.0f);
                        pIn1 = new System.Windows.Point(p1.X + strokeThickness, p1.Y - strokeThickness);
                        pIn2 = new System.Windows.Point(p2.X - strokeThickness, p2.Y + strokeThickness);
                        if (_isDimensionLinesLeft)
                        {
                            _dimensionLines = new BPDimensionLines(bufferX1, -1.0f * (float)p2.Y, bufferX2, -1.0f * (float)p2.Y);
                        }
                        else
                        {
                            _dimensionLines = new BPDimensionLines(bufferX1, -1.0f * (float)p1.Y, bufferX2, -1.0f * (float)p1.Y);
                        }
                        break;

                    case Tools.GlobalParameters.EBPLinePosition.left:
                        p1 = new System.Windows.Point(bufferX1, _y1);
                        p2 = new System.Windows.Point(bufferX2, _y2 - _thickess);
                        pIn1 = new System.Windows.Point(p1.X + strokeThickness, p1.Y - strokeThickness);
                        pIn2 = new System.Windows.Point(p2.X - strokeThickness, p2.Y + strokeThickness);
                        if (_isDimensionLinesLeft)
                        {
                            _dimensionLines = new BPDimensionLines(bufferX1, -1.0f * (float)p2.Y, bufferX2, -1.0f * (float)p2.Y);
                        }
                        else
                        {
                            _dimensionLines = new BPDimensionLines(bufferX1, -1.0f * (float)p1.Y, bufferX2, -1.0f * (float)p1.Y);
                        }
                        break;

                    case Tools.GlobalParameters.EBPLinePosition.right:
                        p1 = new System.Windows.Point(bufferX1, _y1);
                        p2 = new System.Windows.Point(bufferX2, _y2 + _thickess);
                        pIn1 = new System.Windows.Point(p1.X + strokeThickness, p1.Y + strokeThickness);
                        pIn2 = new System.Windows.Point(p2.X - strokeThickness, p2.Y - strokeThickness);
                        if (_isDimensionLinesLeft)
                        {
                            _dimensionLines = new BPDimensionLines(bufferX1, -1.0f * (float)p1.Y, bufferX2, -1.0f * (float)p1.Y);
                        }
                        else
                        {
                            _dimensionLines = new BPDimensionLines(bufferX1, -1.0f * (float)p2.Y, bufferX2, -1.0f * (float)p2.Y);
                        }
                        break;
                }
            }
            else if(_x1 == _x2)
            {
                if (_y1 < _y2)
                {
                    bufferY1 = _y2;
                    bufferY2 = _y1;
                }
                switch (_linePosition)
                {
                    case Tools.GlobalParameters.EBPLinePosition.center:
                        p1 = new System.Windows.Point(_x1 - _thickess / 2.0f, bufferY1);
                        p2 = new System.Windows.Point(_x2 + _thickess / 2.0f, bufferY2);
                        pIn1 = new System.Windows.Point(p1.X + strokeThickness, p1.Y - strokeThickness);
                        pIn2 = new System.Windows.Point(p2.X - strokeThickness, p2.Y + strokeThickness);
                        if (_isDimensionLinesLeft)
                        {
                            _dimensionLines = new BPDimensionLines((float)p1.X, -1.0f * bufferY1, (float)p1.X, -1.0f * bufferY2);
                        }
                        else
                        {
                            _dimensionLines = new BPDimensionLines((float)p2.X, -1.0f * bufferY1, (float)p2.X, -1.0f * bufferY2);
                        }
                        break;

                    case Tools.GlobalParameters.EBPLinePosition.left:
                        p1 = new System.Windows.Point(_x1, bufferY1);
                        p2 = new System.Windows.Point(_x2 - _thickess, bufferY2);
                        pIn1 = new System.Windows.Point(p1.X - strokeThickness, p1.Y - strokeThickness);
                        pIn2 = new System.Windows.Point(p2.X + strokeThickness, p2.Y + strokeThickness);
                        if (_isDimensionLinesLeft)
                        {
                            _dimensionLines = new BPDimensionLines((float)p2.X, -1.0f * bufferY1, (float)p2.X, -1.0f * bufferY2);
                        }
                        else
                        {
                            _dimensionLines = new BPDimensionLines((float)p1.X, -1.0f * bufferY1, (float)p1.X, -1.0f * bufferY2);
                        }
                        break;

                    case Tools.GlobalParameters.EBPLinePosition.right:
                        p1 = new System.Windows.Point(_x1, bufferY1);
                        p2 = new System.Windows.Point(_x2 + _thickess, bufferY2);
                        pIn1 = new System.Windows.Point(p1.X + strokeThickness, p1.Y - strokeThickness);
                        pIn2 = new System.Windows.Point(p2.X - strokeThickness, p2.Y + strokeThickness);
                        if (_isDimensionLinesLeft)
                        {
                            _dimensionLines = new BPDimensionLines((float)p1.X, -1.0f * bufferY1, (float)p1.X, -1.0f * bufferY2);
                        }
                        else
                        {
                            _dimensionLines = new BPDimensionLines((float)p2.X, -1.0f * bufferY1, (float)p2.X, -1.0f * bufferY2);
                        }
                        break;
                }
            }
            rect.Rect = new System.Windows.Rect(p1, p2);

            rectOutOutline.Rect = new System.Windows.Rect(p1, p2);
            rectInOutline.Rect = new System.Windows.Rect(pIn1, pIn2);

            _drawElements.Add(pathRect);
            _drawElements.Add(pathOutline);

            // Draw dimension lines
            if (_showDimensionLines && _dimensionLines != null)
            {
                _drawElements.Add(_dimensionLines.DrawLayer);
            }
        }
        #endregion
    }
}
