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
        private double _a;
        private double _h1;
        private double? _h2;
        private double? _h3;
        private double? _h4;
        private double? _w1;
        private double? _w2;
        private double? _d;
        private double? _e1;
        private double? _e2;
        private double? _e3;
        private double? _e4;

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

        BPScreen? _screen;
        BPRectangle? _dielectric1;
        BPRectangle? _dielectric2;
        BPLine? _strip1;
        BPLine? _strip2;
        BPLine? _strip3;
        BPLine? _strip4;
        BPLine? _strip5;
        BPLine? _strip6;
        BPDimensionLines? _dimentionLineH1;
        BPDimensionLines? _dimentionLineH4;
        BPDimensionLines? _dimentionLineD;
        BPText? _textE1;
        BPText? _textE2;
        BPText? _textE3;
        BPText? _textE4;
        #endregion



        #region Constructor
        public CoplanarStripLinesVIP() { }
        #endregion



        #region Protected Method
        protected override void SetupStripStructure()
        {
            _uc_a = new UC_InputBox("1");
            _uc_h1 = new UC_InputBox("2");
            _uc_h2 = new UC_InputBox("3");
            _uc_h3 = new UC_InputBox("4");
            _uc_h4 = new UC_InputBox("5");
            _uc_w1 = new UC_InputBox("6");
            _uc_w2 = new UC_InputBox("7");
            _uc_d = new UC_InputBox("8");
            _uc_e1 = new UC_InputBox("9");
            _uc_e2 = new UC_InputBox("10");
            _uc_e3 = new UC_InputBox("11");
            _uc_e4 = new UC_InputBox("12");

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

            _uc_a.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_h1.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_h2.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_h3.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_h4.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_w1.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_w2.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_d.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_e1.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_e2.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_e3.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_e4.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);



            _screen = new BPScreen();
            _screen.Width = 500;
            _screen.Height = 500;
            _screen.X = -1.0f * _screen.Width / 2.0f - 20;
            _screen.Y = -1.0f * _screen.Height / 2.0f + 20;

            _dielectric1 = new BPRectangle();
            _dielectric1.Width = _screen.Width;
            _dielectric1.Height = 70;
            _dielectric1.X = _screen.X;
            _dielectric1.Y = _screen.Y + 100;
            _dielectric1.IsWidthDimensionLinesUp = false;
            _dielectric1.WidthDimensionLines.Length = _dielectric1.Y - 40.0f;
            _dielectric1.WidthDimensionLines.DescriptionText = "a";
            _dielectric1.HeightDimensionLines.DescriptionText = "h2";
            _dielectric1.WidthDimensionLines.DescriptionValue = _uc_a.Value.Text;
            _dielectric1.HeightDimensionLines.DescriptionValue = _uc_h2.Value.Text;

            _dielectric2 = new BPRectangle();
            _dielectric2.Width = 70;
            _dielectric2.Height = 200;
            _dielectric2.X = _screen.X + _screen.Width / 2.0f - _dielectric2.Width / 2.0f;
            _dielectric2.Y = _dielectric1.Y + _dielectric1.Height;
            _dielectric2.HeightDimensionLines.Length = (_screen.Width - _dielectric2.Width) / 2 + _dielectric1.HeightDimensionLines.Length;
            _dielectric2.WidthDimensionLines.DescriptionText = "h3";
            _dielectric2.HeightDimensionLines.DescriptionText = "w2";
            _dielectric2.WidthDimensionLines.DescriptionValue = _uc_h3.Value.Text;
            _dielectric2.HeightDimensionLines.DescriptionValue = _uc_w2.Value.Text;

            _strip1 = new BPLine();
            _strip1.X1 = _dielectric2.X;
            _strip1.Y1 = _dielectric2.Y;
            _strip1.X2 = _strip1.X1;
            _strip1.Y2 = _dielectric2.Y + _dielectric2.Height;
            _strip1.StrokePosition = Tools.GlobalParameters.EBPLinePosition.left;
            _strip1.ShowDimensionLinesLeft = false;

            _strip2 = new BPLine();
            _strip2.X1 = _strip1.X1 - _strip1.Thickness;
            _strip2.Y1 = _dielectric2.Y;
            _strip2.X2 = _strip2.X1 - 100;
            _strip2.Y2 = _dielectric2.Y;
            _strip2.StrokePosition = Tools.GlobalParameters.EBPLinePosition.left;
            _strip2.DimensionLines.DescriptionText = "w1";
            _strip2.DimensionLines.DescriptionValue = _uc_w1.Value.Text;

            _strip3 = new BPLine();
            _strip3.X1 = _dielectric2.X + _dielectric2.Width;
            _strip3.Y1 = _dielectric2.Y;
            _strip3.X2 = _strip3.X1;
            _strip3.Y2 = _dielectric2.Y + _dielectric2.Height;
            _strip3.StrokePosition = Tools.GlobalParameters.EBPLinePosition.right;
            _strip3.ShowDimensionLinesLeft = false;

            _strip4 = new BPLine();
            _strip4.X1 = _strip3.X1 + _strip3.Thickness;
            _strip4.Y1 = _dielectric2.Y;
            _strip4.X2 = _strip4.X1 + 100;
            _strip4.Y2 = _dielectric2.Y;
            _strip4.StrokePosition = Tools.GlobalParameters.EBPLinePosition.left;
            _strip4.DimensionLines.DescriptionText = "w1";
            _strip4.DimensionLines.DescriptionValue = _uc_w1.Value.Text;

            _strip5 = new BPLine();
            _strip5.X1 = _screen.X;
            _strip5.Y1 = _dielectric1.Y;
            _strip5.X2 = _strip5.X1 + _screen.Width / 2.0f - 40.0f;
            _strip5.Y2 = _dielectric1.Y;
            _strip5.StrokePosition = Tools.GlobalParameters.EBPLinePosition.right;
            _strip5.ShowDimensionLinesLeft = false;

            _strip6 = new BPLine();
            _strip6.X1 = _screen.X + _screen.Width;
            _strip6.Y1 = _dielectric1.Y;
            _strip6.X2 = _strip6.X1 - _screen.Width / 2.0f + 40.0f;
            _strip6.Y2 = _dielectric1.Y;
            _strip6.StrokePosition = Tools.GlobalParameters.EBPLinePosition.right;
            _strip6.ShowDimensionLinesLeft = false;

            _dimentionLineH1 = new BPDimensionLines(
                _screen.X + _screen.Width,
                _screen.Y,
                _screen.X + _screen.Width,
                _dielectric1.Y);
            _dimentionLineH1.DescriptionText = "h1";
            _dimentionLineH1.DescriptionValue = _uc_h1.Value.Text;

            _dimentionLineH4 = new BPDimensionLines(
                _screen.X + _screen.Width,
                _dielectric2.Y + _dielectric2.Height,
                _screen.X + _screen.Width,
                _screen.Y + _screen.Height);
            _dimentionLineH4.DescriptionText = "h4";
            _dimentionLineH4.DescriptionValue = _uc_h4.Value.Text;

            _dimentionLineD = new BPDimensionLines(
                _strip5.X2,
                _strip5.Y1 - _strip5.Thickness,
                _strip6.X2,
                _strip6.Y1 - _strip6.Thickness);
            _dimentionLineD.Length = -50;
            _dimentionLineD.DescriptionText = "d";
            _dimentionLineD.DescriptionValue = _uc_d.Value.Text;

            _textE1 = new BPText();
            _textE1.DescriptionText = "\u03B5r1";
            _textE1.DescriptionValue = _uc_e1.Value.Text;
            _textE1.X = (float)(_screen.X + _screen.Width - _textE1.Width - 5.0f);
            _textE1.Y = (float)(_screen.Y + (_strip6.Y1 - _strip6.Thickness - _screen.Y) / 2.0f + _textE1.Height / 2.0f);

            _textE2 = new BPText();
            _textE2.DescriptionText = "\u03B5r2";
            _textE2.DescriptionValue = _uc_e2.Value.Text;
            _textE2.X = (float)(_screen.X + _screen.Width - _textE2.Width - 5.0f);
            _textE2.Y = (float)(_dielectric1.Y + _dielectric1.Height / 2.0f + _textE2.Height / 2.0f);

            _textE3 = new BPText();
            _textE3.SizeBoxWidth = _dielectric2.Width;
            _textE3.DescriptionText = "\u03B5r3";
            _textE3.DescriptionValue = _uc_e3.Value.Text;
            _textE3.X = (float)(_dielectric2.X + _dielectric2.Width / 2.0f - _textE3.Width / 2.0f);
            _textE3.Y = (float)(_dielectric2.Y + _dielectric2.Height / 2.0f + _textE3.Height / 2.0f);

            _textE4 = new BPText();
            _textE4.DescriptionText = "\u03B5r4";
            _textE4.DescriptionValue = _uc_e4.Value.Text;
            _textE4.X = (float)(_screen.X + _screen.Width - _textE4.Width - 5.0f);
            _textE4.Y = (float)(_screen.Y + _screen.Height - 5.0f);

            _workspaceElements.Add(_dielectric1.DrawLayer);
            _workspaceElements.Add(_dielectric2.DrawLayer);
            _workspaceElements.Add(_strip1.DrawLayer);
            _workspaceElements.Add(_strip2.DrawLayer);
            _workspaceElements.Add(_strip3.DrawLayer);
            _workspaceElements.Add(_strip4.DrawLayer);
            _workspaceElements.Add(_strip5.DrawLayer);
            _workspaceElements.Add(_strip6.DrawLayer);
            _workspaceElements.Add(_dimentionLineH1.DrawLayer);
            _workspaceElements.Add(_dimentionLineH4.DrawLayer);
            _workspaceElements.Add(_dimentionLineD.DrawLayer);
            _workspaceElements.Add(_textE1.DrawLayer);
            _workspaceElements.Add(_textE2.DrawLayer);
            _workspaceElements.Add(_textE3.DrawLayer);
            _workspaceElements.Add(_textE4.DrawLayer);
            _workspaceElements.Add(_screen.DrawLayer);
        }
        #endregion



        #region Private Method
        /*
         * Event handling when InputBox's value changed
         */
        private void InputBox_ValueChanged(UC_InputBox sender, double value)
        {
            if(sender == _uc_a)
            {
                _a = value;
                _dielectric1.WidthDimensionLines.DescriptionValue = _uc_a.Value.Text;
            }
            if (sender == _uc_h1)
            {
                _h1 = value;
                _dimentionLineH1.DescriptionValue = _uc_h1.Value.Text;
            }
            if (sender == _uc_h2)
            {
                _h2 = value;
                _dielectric1.HeightDimensionLines.DescriptionValue = _uc_h2.Value.Text;
            }
            if (sender == _uc_h3)
            {
                _h3 = value;
                _dielectric2.WidthDimensionLines.DescriptionValue = _uc_h3.Value.Text;
            }
            if (sender == _uc_h4)
            {
                _h4 = value;
                _dimentionLineH4.DescriptionValue = _uc_h4.Value.Text;
            }
            if (sender == _uc_w1)
            {
                _w1 = value;
                _strip2.DimensionLines.DescriptionValue = _uc_w1.Value.Text;
                _strip4.DimensionLines.DescriptionValue = _uc_w1.Value.Text;
            }
            if (sender == _uc_w2)
            {
                _w2 = value;
                _dielectric2.HeightDimensionLines.DescriptionValue = _uc_w2.Value.Text;
            }
            if (sender == _uc_d)
            {
                _d = value;
                _dimentionLineD.DescriptionValue = _uc_d.Value.Text;
            }
            if (sender == _uc_e1)
            {
                _e1 = value;
                _textE1.DescriptionValue = _uc_e1.Value.Text;
                _textE1.X = (float)(_screen.X + _screen.Width - _textE1.Width - 5.0f);
                _textE1.Y = (float)(_screen.Y + (_strip6.Y - _screen.Y) / 2.0f + _textE1.Height / 2.0f);
            }
            if (sender == _uc_e2)
            {
                _e2 = value;
                _textE2.DescriptionValue = _uc_e2.Value.Text;
                _textE2.X = (float)(_screen.X + _screen.Width - _textE2.Width - 5.0f);
                _textE2.Y = (float)(_dielectric1.Y + _dielectric1.Height / 2.0f + _textE2.Height / 2.0f);
            }
            if (sender == _uc_e3)
            {
                _e3 = value;
                _textE3.DescriptionValue = _uc_e3.Value.Text;
                _textE3.X = (float)(_dielectric2.X + _dielectric2.Width / 2.0f - _textE3.Width / 2.0f);
                _textE3.Y = (float)(_dielectric2.Y + _dielectric2.Height / 2.0f + _textE3.Height / 2.0f);
            }
            if (sender == _uc_e4)
            {
                _e4 = value;
                _textE4.DescriptionValue = _uc_e4.Value.Text;
                _textE4.X = (float)(_screen.X + _screen.Width - _textE4.Width - 5.0f);
                _textE4.Y = (float)(_screen.Y + _screen.Height - 5.0f);
            }
        }
        #endregion
    }
}
