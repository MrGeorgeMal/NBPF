using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace NBPF.Blueprint
{
    public class BPDimensionLines : BPObject
    {
        #region Private Member
        private float _x1, _y1, _x2, _y2;
        private float _length = 50.0f;
        private float _gap = 5.0f;
        private float _descriptionGap = 10.0f;
        private float _arrowSize = 8.0f;
        private string _descriptionText = "aaa";
        private string _descriptionValue = "";
        private bool _showDescriptionValue = false;
        #endregion



        #region Public Member
        public float X1
        {
            get { return _x1; }
            set { _x1 = value; base.Update(); }
        }
        public float Y1
        {
            get { return _y1; }
            set { _y1 = value; base.Update(); }
        }
        public float X2
        {
            get { return _x2; }
            set { _x2 = value; base.Update(); }
        }
        public float Y2
        {
            get { return _y2; }
            set { _y2 = value; base.Update(); }
        }
        public float Length
        {
            get { return _length; }
            set { _length = value; base.Update(); }
        }
        public string DescriptionText
        {
            get { return _descriptionText; }
            set { _descriptionText = value; Update(); }
        }
        public string DescriptionValue
        {
            get { return _descriptionValue; }
            set { _descriptionValue = value; Update(); }
        }
        public bool ShowDescriptionValue
        {
            get { return _showDescriptionValue; }
            set { _showDescriptionValue = value; Update(); }
        }
        #endregion



        #region Constructor
        public BPDimensionLines(float x1, float y1, float x2, float y2) : base()
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            Line l1 = new Line();
            Line l2 = new Line();
            Line l3 = new Line();
            Polygon arrow1 = new Polygon();
            Polygon arrow2 = new Polygon();
            TextBlock descrition = new TextBlock();

            l1.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;
            l2.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;
            l3.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;
            l1.StrokeThickness = Tools.GlobalParameters.DimentionLinesStrokeThickness;
            l2.StrokeThickness = Tools.GlobalParameters.DimentionLinesStrokeThickness;
            l3.StrokeThickness = Tools.GlobalParameters.DimentionLinesStrokeThickness;
            arrow1.Fill = Tools.GlobalParameters.DimensionLineStrokeColor;
            arrow2.Fill = Tools.GlobalParameters.DimensionLineStrokeColor;
            descrition.Text = (_descriptionValue == "") ? _descriptionText : _descriptionText + " = " + _descriptionValue;
            descrition.Foreground = Tools.GlobalParameters.DimensionLineStrokeColor;
            descrition.FontSize = Tools.GlobalParameters.WorkspaceFontSize;

            l1.X1 = _x1;
            l1.Y1 = _y1;
            l2.X1 = _x2;
            l2.Y1 = _y2;

            float bufferGap;
            if (_length == 0.0f) bufferGap = 0.0f;
            else if (_length > 0.0f) bufferGap = -1.0f * _gap;
            else bufferGap = _gap;

            Size mesureSize = new Size(1000, 1000);
            descrition.Measure(mesureSize);
            Size descriptionSize = descrition.DesiredSize;

            if (_y1 == _y2)
            {
                l1.X2 = _x1;
                l1.Y2 = _y1 - _length;
                l2.X2 = _x2;
                l2.Y2 = _y2 - _length;

                l3.X1 = _x1;
                l3.Y1 = l1.Y2 - bufferGap;
                l3.X2 = _x2;
                l3.Y2 = l2.Y2 - bufferGap;

                arrow1.Points = new PointCollection()
                    {
                        new Point(l3.X1, l3.Y1),
                        new Point(l3.X1 + _arrowSize, l3.Y1 - _arrowSize / 2.0f),
                        new Point(l3.X1 + _arrowSize, l3.Y1 + _arrowSize / 2.0f)
                    };
                arrow2.Points = new PointCollection()
                    {
                        new Point(l3.X2, l3.Y2),
                        new Point(l3.X2 - _arrowSize, l3.Y2 + _arrowSize / 2.0f),
                        new Point(l3.X2 - _arrowSize, l3.Y2 - _arrowSize / 2.0f)
                    };

                Canvas.SetLeft(descrition, l3.X1 + Math.Abs(l3.X2 - l3.X1) / 2.0f - descriptionSize.Width / 2.0f);
                Canvas.SetTop(descrition, l3.Y1 - descriptionSize.Height - _descriptionGap);
            }

            if (_x1 == _x2)
            {
                l1.X2 = _x1 + _length;
                l1.Y2 = _y1;
                l2.X2 = _x2 + _length;
                l2.Y2 = _y2;

                l3.X1 = l1.X2 + bufferGap;
                l3.Y1 = _y1;
                l3.X2 = l1.X2 + bufferGap;
                l3.Y2 = _y2;

                arrow1.Points = new PointCollection()
                    {
                        new Point(l3.X1, l3.Y1),
                        new Point(l3.X1 + _arrowSize / 2.0f, l3.Y1 - _arrowSize),
                        new Point(l3.X1 - _arrowSize / 2.0f, l3.Y1 - _arrowSize)
                    };
                arrow2.Fill = Tools.GlobalParameters.DimensionLineStrokeColor;
                arrow2.Points = new PointCollection()
                    {
                        new Point(l3.X2, l3.Y2),
                        new Point(l3.X2 + _arrowSize / 2.0f, l3.Y2 + _arrowSize),
                        new Point(l3.X2 - _arrowSize / 2.0f, l3.Y2 + _arrowSize)
                    };

                if (_length >= 0.0f)
                {
                    Canvas.SetLeft(descrition, l3.X1 + _descriptionGap);
                    Canvas.SetTop(descrition, l3.Y1 - Math.Abs(l3.Y2 - l3.Y1) / 2.0f - descriptionSize.Height / 1.6f);
                }
                else
                {
                    Canvas.SetLeft(descrition, l3.X1 - descriptionSize.Width - _descriptionGap);
                    Canvas.SetTop(descrition, l3.Y1 - Math.Abs(l3.Y2 - l3.Y1) / 2.0f - descriptionSize.Height / 1.6f);
                }
            }


            _drawElements.Add(l1);
            _drawElements.Add(l2);
            _drawElements.Add(l3);
            _drawElements.Add(arrow1);
            _drawElements.Add(arrow2);
            _drawElements.Add(descrition);
        }
        #endregion
    }
}
