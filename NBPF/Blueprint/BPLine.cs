using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.Blueprint
{
    public class BPLine : BPObject
    {
        #region Private Member
        private float _x1 = 0.0f;
        private float _y1 = 0.0f;
        private float _x2 = 100.0f;
        private float _y2 = 100.0f;
        private Tools.GlobalParameters.EOutlinePosition _strokePosition = Tools.GlobalParameters.EOutlinePosition.center;
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
        public Tools.GlobalParameters.EOutlinePosition StrokePosition
        {
            get { return _strokePosition; }
            set { _strokePosition = value; Update(); }
        }
        #endregion



        #region Constructor
        public BPLine() : base() { }
        #endregion



        #region Protected Member
        protected override void SetupObject()
        {
            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
        }
        #endregion
    }
}
