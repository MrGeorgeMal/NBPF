using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    public partial class UC_PanAndZoomCanvas : Canvas
    {
        #region Private Member
        private readonly MatrixTransform _transform = new MatrixTransform();
        private Point _initialMousePosition;
        private Color _backgroundColor = Color.FromArgb(0xFF, 0x33, 0x33, 0x33);
        #endregion

        #region Public Member
        public float Zoomfactor { get; set; } = 1.1f;
        public float MaxZoom { get; set; } = 2.0f;
        public float MinZoom { get; set; } = 0.2f;
        public MatrixTransform Transform { get { return _transform; } }
        public Color BackgroundColor
        {
            get { return _backgroundColor; }

            set
            {
                _backgroundColor = value;
                Background = new SolidColorBrush(_backgroundColor);
            }
        }
        #endregion

        public UC_PanAndZoomCanvas()
        {
            InitializeComponent();

            MouseDown += PanAndZoomCanvas_MouseDown;
            MouseMove += PanAndZoomCanvas_MouseMove;
            MouseWheel += PanAndZoomCanvas_MouseWheel;

            BackgroundColor = _backgroundColor;

            
            Loaded += (object sender, RoutedEventArgs e) =>
            {
                Matrix offsetMatrix;
                offsetMatrix.OffsetX = ActualWidth / 2.0f;
                offsetMatrix.OffsetY = ActualHeight / 2.0f;

                _transform.Matrix = offsetMatrix;
                Debug.WriteLine("M11: " + _transform.Matrix.M11);
                Debug.WriteLine("M12: " + _transform.Matrix.M12);
                Debug.WriteLine("M21: " + _transform.Matrix.M21);
                Debug.WriteLine("M22: " + _transform.Matrix.M22);
                Debug.WriteLine("OffsetX: " + _transform.Matrix.OffsetX);
                Debug.WriteLine("OffsetY: " + _transform.Matrix.OffsetY);
            };
        }

        private void PanAndZoomCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
            {
                _initialMousePosition = _transform.Inverse.Transform(e.GetPosition(this));
            }
        }

        private void PanAndZoomCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                Point mousePosition = _transform.Inverse.Transform(e.GetPosition(this));
                Vector delta = Point.Subtract(mousePosition, _initialMousePosition);
                var translate = new TranslateTransform(delta.X, delta.Y);
                _transform.Matrix = translate.Value * _transform.Matrix;

                foreach (UIElement child in this.Children)
                {
                    child.RenderTransform = _transform;
                }
            }
        }

        private void PanAndZoomCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            float scaleFactor = Zoomfactor;
            if (e.Delta < 0)
            {
                scaleFactor = 1f / scaleFactor;
                if (_transform.Matrix.M11 < MinZoom) return;
            }
            else
            {
                if (_transform.Matrix.M11 > MaxZoom) return;
            }

            Point mousePostion = e.GetPosition(this);

            Matrix scaleMatrix = _transform.Matrix;
            scaleMatrix.ScaleAt(scaleFactor, scaleFactor, mousePostion.X, mousePostion.Y);
            _transform.Matrix = scaleMatrix;

            Debug.WriteLine(_transform.Matrix.M11);

            foreach (UIElement child in this.Children)
            {
                double x = Canvas.GetLeft(child);
                double y = Canvas.GetTop(child);

                double sx = x * scaleFactor;
                double sy = y * scaleFactor;

                Canvas.SetLeft(child, sx);
                Canvas.SetTop(child, sy);

                child.RenderTransform = _transform;
            }
        }

        private void Canvas_Loaded(object? sender, EventArgs e)
        {
            Debug.WriteLine(this.Width);
            Debug.WriteLine(this.Height);
        }
    }
}