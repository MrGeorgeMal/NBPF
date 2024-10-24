using NBPF.Blueprint;
using NBPF.Controls;
using NBPF.NBPFClasses;
using NBPF.StripStructureType;
using NBPF.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static NBPF.Tools.GlobalParameters;

namespace NBPF.StripStructure
{
    public class CoplanarStripLinesVIP : StripStructureBase
    {
        #region Private Member
        private UC_InputBox? _uc_a;
        private UC_InputBox? _uc_h1;
        private UC_InputBox? _uc_h2;
        private UC_InputBox? _uc_h3;
        private UC_InputBox? _uc_h4;
        private UC_InputBox? _uc_w1;
        private UC_InputBox? _uc_w2;
        private UC_InputBox? _uc_d;
        private UC_InputBox? _uc_e1;
        private UC_InputBox? _uc_e2;
        private UC_InputBox? _uc_e3;
        private UC_InputBox? _uc_e4;
        #endregion



        #region Constructor
        public CoplanarStripLinesVIP() { }
        #endregion



        #region Protected Method
        protected override void SetupStripStructure()
        {
            _uc_a = new UC_InputBox();
            _uc_h1 = new UC_InputBox();
            _uc_h2 = new UC_InputBox();
            _uc_h3 = new UC_InputBox();
            _uc_h4 = new UC_InputBox();
            _uc_w1 = new UC_InputBox();
            _uc_w2 = new UC_InputBox();
            _uc_d = new UC_InputBox();
            _uc_e1 = new UC_InputBox();
            _uc_e2 = new UC_InputBox();
            _uc_e3 = new UC_InputBox();
            _uc_e4 = new UC_InputBox();

            _uc_a.Description.Text = "(a) Ширина структуры";
            _uc_h1.Description.Text = "(h1) Расстояние от экрана до горизонтальной подложки";
            _uc_h2.Description.Text = "(h2) Толщина горизонтальной подложки";
            _uc_h3.Description.Text = "(h3) Толщина вертикальной подложки";
            _uc_h4.Description.Text = "(h4) Расстояние от экрана до вертикальной подложки";
            _uc_w1.Description.Text = "(w1) Ширина горизонтальных проводящей линий";
            _uc_w2.Description.Text = "(w2) Ширина вертикальной проводящей линии";
            _uc_d.Description.Text = "(d) Ширина зазора в заземпляемом основании";
            _uc_e1.Description.Text = "(\u03B5r1) Относительная диэлектрическая проницаемость";
            _uc_e2.Description.Text = "(\u03B5r2) Относительная диэлектрическая проницаемость";
            _uc_e3.Description.Text = "(\u03B5r3) Относительная диэлектрическая проницаемость";
            _uc_e4.Description.Text = "(\u03B5r4) Относительная диэлектрическая проницаемость";

            _userControls.Add(_uc_a);
            _userControls.Add(_uc_h1);
            _userControls.Add(_uc_h2);
            _userControls.Add(_uc_h3);
            _userControls.Add(_uc_h4);
            _userControls.Add(_uc_w1);
            _userControls.Add(_uc_w2);
            _userControls.Add(_uc_d);
            _userControls.Add(_uc_e1);
            _userControls.Add(_uc_e2);
            _userControls.Add(_uc_e3);
            _userControls.Add(_uc_e4);

            UC_RectangleStripElement newRect = new UC_RectangleStripElement();
            newRect.WidthElement = 500;
            newRect.HeightElement = 200;
            newRect.WidthDimensionLineLength = -50;
            newRect.HeightDimensionLineLength = -50;

            BPRectangle rectangle = new BPRectangle();

            _workspaceElements.Add(rectangle.DrawLayer);
        }
        #endregion

    }
}
