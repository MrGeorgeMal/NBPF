using NBPF.Controls;
using NBPF.NBPFClasses;
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
    public class CoplanarStripLinesVIP : NBPFClasses.StripStructure
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
        public CoplanarStripLinesVIP(string name) : base(name) { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
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

            userControls.Add(_uc_a);
            userControls.Add(_uc_h1);
            userControls.Add(_uc_h2);
            userControls.Add(_uc_h3);
            userControls.Add(_uc_h4);
            userControls.Add(_uc_w1);
            userControls.Add(_uc_w2);
            userControls.Add(_uc_d);
            userControls.Add(_uc_e1);
            userControls.Add(_uc_e2);
            userControls.Add(_uc_e3);
            userControls.Add(_uc_e4);

            Rectangle rect = new Rectangle();
            rect.Width = 100;
            rect.Height = 100;
            rect.Fill = Brushes.White;
            rect.Stroke = Brushes.Red;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "100";
            textBlock.FontSize = 20;
            Canvas.SetLeft(textBlock, 150);

            DrawElements.Add(rect);
            DrawElements.Add(textBlock);
        }
        #endregion

    }
}
