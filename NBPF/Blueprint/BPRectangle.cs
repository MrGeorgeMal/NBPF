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
        #endregion



        #region Constructor
        public BPRectangle() : base() { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            Path path = new Path();
            path.Fill = Tools.GlobalParameters.DielectricFillColor;
            path.Stroke = Tools.GlobalParameters.DielectricStrokeColor;

            RectangleGeometry rectangle = new RectangleGeometry();
            rectangle.Rect = new System.Windows.Rect(new System.Windows.Point(_x, _y), new System.Windows.Point(_x + _width, _y - _height));
            path.Data = rectangle;

            _drawElements.Add(path);
        }
        #endregion
    }
}
