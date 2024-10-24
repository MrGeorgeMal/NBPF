using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBPF.UserControls
{
    public partial class UC_RectangleStripElement : UC_BlueprintObject
    {
        private delegate void ElementChangedHandler();
        event ElementChangedHandler? ElementChanged;

        #region Private Member
        private Tools.GlobalParameters.EMaterialType _materialType = Tools.GlobalParameters.EMaterialType.dielectric;
        private float _x = 0.0f;
        private float _y = 0.0f;
        private float _widthElement = 100.0f;
        private float _heightElement = 100.0f;
        private float _widthDimensionLineLength = 50.0f;
        private float _heightDimensionLineLength = 50.0f;
        private float _dimensionLineGap = 10.0f;
        private float _descriptionGap = 20.0f;
        private float _arrowSize = 8.0f;
        private bool _showWidthDimensionLine = true;
        private bool _showHeightDimensionLine = true;
        private bool _showDimensionLines = true;
        private string _widthDescription = "a";
        private string _heightDescription = "b";
        #endregion



        #region Public Member
        public Tools.GlobalParameters.EMaterialType MaterialType
        {
            get { return _materialType; }
            set { _materialType = value; ElementChanged?.Invoke(); }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; ElementChanged?.Invoke(); }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; ElementChanged?.Invoke(); }
        }
        public float WidthElement
        {
            get { return _widthElement; }
            set { _widthElement = value; ElementChanged?.Invoke(); }
        }
        public float HeightElement
        {
            get { return _heightElement; }
            set { _heightElement = value; ElementChanged?.Invoke(); }
        }
        public float WidthDimensionLineLength
        {
            get { return _widthDimensionLineLength; }
            set { _widthDimensionLineLength = value; ElementChanged?.Invoke(); }
        }
        public float HeightDimensionLineLength
        {
            get { return _heightDimensionLineLength; }
            set { _heightDimensionLineLength = value; ElementChanged?.Invoke(); }
        }
        public bool ShowWidthDimensionLine
        {
            get { return _showWidthDimensionLine; }
            set { _showWidthDimensionLine = value; ElementChanged?.Invoke(); }
        }
        public bool ShowHeightDimensionLine
        {
            get { return _showHeightDimensionLine; }
            set { _showHeightDimensionLine = value; ElementChanged?.Invoke(); }
        }
        public bool ShowDimensionLines
        {
            get { return _showDimensionLines; }
            set { _showDimensionLines = value; ElementChanged?.Invoke(); }
        }
        public string WidthDescription
        {
            get { return _widthDescription; }
            set { _widthDescription = value; ElementChanged?.Invoke(); }
        }
        public string HeightDescription
        {
            get { return _heightDescription; }
            set { _heightDescription = value; ElementChanged?.Invoke(); }
        }
        #endregion



        #region Constructor
        public UC_RectangleStripElement()
        {
            InitializeComponent();
            UpdateElement();
            this.ElementChanged += new ElementChangedHandler(UpdateElement);
        }
        #endregion



        #region Public Mehtod
        public void UpdateElement()
        {
            this.Children.Clear();

            List<UIElement> drawElements = new List<UIElement>();

            Rectangle rect = new Rectangle();
            drawElements.Add(rect);
            rect.Width = _widthElement;
            rect.Height = _heightElement;
            switch (_materialType)
            {
                case Tools.GlobalParameters.EMaterialType.conductor:
                    rect.Fill = Tools.GlobalParameters.ConductorFillColor;
                    rect.Stroke = Tools.GlobalParameters.ConductorStrokeColor;
                    break;
                case Tools.GlobalParameters.EMaterialType.dielectric:
                    rect.Fill = Tools.GlobalParameters.DielectricFillColor;
                    rect.Stroke = Tools.GlobalParameters.DielectricStrokeColor;
                    break;
            }

            if (_showWidthDimensionLine && _widthDimensionLineLength != 0.0f)
            {
                Line line1 = new Line();
                Line line2 = new Line();
                Line line3 = new Line();
                Polygon arrow1 = new Polygon();
                Polygon arrow2 = new Polygon();
                TextBlock sizeDescription = new TextBlock();
                sizeDescription.Text = _widthDescription;
                sizeDescription.FontSize = Tools.GlobalParameters.WorkspaceFontSize;
                sizeDescription.Foreground = Tools.GlobalParameters.WorkspaceFontColor;

                drawElements.Add(line1);
                drawElements.Add(line2);
                drawElements.Add(line3);
                drawElements.Add(arrow1);
                drawElements.Add(arrow2);
                drawElements.Add(sizeDescription);

                if (_widthDimensionLineLength >= 0.0f)
                {
                    line1.X1 = 0;
                    line1.Y1 = 0;
                    line1.X2 = 0;
                    line1.Y2 = -1 * _widthDimensionLineLength;
                    line1.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line2.X1 = _widthElement;
                    line2.Y1 = 0;
                    line2.X2 = _widthElement;
                    line2.Y2 = -1 * _widthDimensionLineLength;
                    line2.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line3.X1 = 0;
                    line3.Y1 = line1.Y2 + _dimensionLineGap;
                    line3.X2 = _widthElement;
                    line3.Y2 = line2.Y2 + _dimensionLineGap;
                    line3.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    Canvas.SetTop(sizeDescription, -1 * _heightElement + line3.Y1 - sizeDescription.FontSize - _descriptionGap);
                    Canvas.SetLeft(sizeDescription, line3.X1 + _widthElement / 2.0f - sizeDescription.FontSize / 2.0f);
                }
                else
                {
                    line1.X1 = 0;
                    line1.Y1 = _heightElement;
                    line1.X2 = 0;
                    line1.Y2 = _heightElement - _widthDimensionLineLength;
                    line1.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line2.X1 = _widthElement;
                    line2.Y1 = _heightElement;
                    line2.X2 = _widthElement;
                    line2.Y2 = _heightElement - _widthDimensionLineLength;
                    line2.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line3.X1 = 0;
                    line3.Y1 = line1.Y2 - _dimensionLineGap;
                    line3.X2 = _widthElement;
                    line3.Y2 = line2.Y2 - _dimensionLineGap;
                    line3.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    Canvas.SetTop(sizeDescription, -1 * _heightElement + line3.Y1);
                    Canvas.SetLeft(sizeDescription, line3.X1 + _widthElement / 2.0f - sizeDescription.FontSize / 2.0f);
                }

                arrow1.Fill = Tools.GlobalParameters.DimensionLineStrokeColor;
                arrow1.Points = new PointCollection()
                    {
                        new Point(line3.X1, line3.Y1),
                        new Point(line3.X1 + _arrowSize, line3.Y1 - _arrowSize / 2),
                        new Point(line3.X1 + _arrowSize, line3.Y1 + _arrowSize / 2)
                    };
                arrow2.Fill = Tools.GlobalParameters.DimensionLineStrokeColor;
                arrow2.Points = new PointCollection()
                    {
                        new Point(line3.X2, line3.Y2),
                        new Point(line3.X2 - _arrowSize, line3.Y2 + _arrowSize / 2),
                        new Point(line3.X2 - _arrowSize, line3.Y2 - _arrowSize / 2)
                    };
            }

            if (_showHeightDimensionLine && _heightDimensionLineLength != 0.0f)
            {
                Line line1 = new Line();
                Line line2 = new Line();
                Line line3 = new Line();
                Polygon arrow1 = new Polygon();
                Polygon arrow2 = new Polygon();
                drawElements.Add(line1);
                drawElements.Add(line2);
                drawElements.Add(line3);
                drawElements.Add(arrow1);
                drawElements.Add(arrow2);

                if (_heightDimensionLineLength >= 0.0f)
                {
                    line1.X1 = _widthElement;
                    line1.Y1 = _heightElement;
                    line1.X2 = _widthElement + _heightDimensionLineLength;
                    line1.Y2 = _heightElement;
                    line1.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line2.X1 = _widthElement;
                    line2.Y1 = 0;
                    line2.X2 = _widthElement + _heightDimensionLineLength;
                    line2.Y2 = 0;
                    line2.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line3.X1 = line1.X2 - _dimensionLineGap;
                    line3.Y1 = _heightElement;
                    line3.X2 = line2.X2 - _dimensionLineGap;
                    line3.Y2 = 0;
                    line3.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;
                }
                else
                {
                    line1.X1 = 0;
                    line1.Y1 = _heightElement;
                    line1.X2 = _heightDimensionLineLength;
                    line1.Y2 = _heightElement;
                    line1.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line2.X1 = 0;
                    line2.Y1 = 0;
                    line2.X2 = _heightDimensionLineLength;
                    line2.Y2 = 0;
                    line2.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;

                    line3.X1 = line1.X2 + _dimensionLineGap;
                    line3.Y1 = _heightElement;
                    line3.X2 = line2.X2 + _dimensionLineGap;
                    line3.Y2 = 0;
                    line3.Stroke = Tools.GlobalParameters.DimensionLineStrokeColor;
                }

                arrow1.Fill = Tools.GlobalParameters.DimensionLineStrokeColor;
                arrow1.Points = new PointCollection()
                    {
                        new Point(line3.X1, line3.Y1),
                        new Point(line3.X1 + _arrowSize / 2, line3.Y1 - _arrowSize),
                        new Point(line3.X1 - _arrowSize / 2, line3.Y1 - _arrowSize)
                    };
                arrow2.Fill = Tools.GlobalParameters.DimensionLineStrokeColor;
                arrow2.Points = new PointCollection()
                    {
                        new Point(line3.X2, line3.Y2),
                        new Point(line3.X2 + _arrowSize / 2, line3.Y2 + _arrowSize),
                        new Point(line3.X2 - _arrowSize / 2, line3.Y2 + _arrowSize)
                    };
            }

            foreach (UIElement elememt in drawElements)
            {
                if(elememt is Shape)
                {
                    Canvas.SetTop(elememt, -1 * _heightElement);
                }
                this.Children.Add(elememt);
            }
        }
        #endregion


        protected override void Draw()
        {
            base.Draw();
        }
    }
}
