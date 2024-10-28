using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NBPF.Blueprint
{
    public class BPText : BPObject
    {
        #region Private Member
        private TextBlock textBlock = new TextBlock();
        private string _descriptionText = "text";
        private string _descriptionValue = "";
        #endregion



        #region Public Member
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
        public double Width
        {
            get
            {
                double widthCheckArea = textBlock.FontSize * 100;
                double hightCheckArea = textBlock.FontSize * 100;
                System.Windows.Size mesureSize = new System.Windows.Size(widthCheckArea, hightCheckArea);
                textBlock.Measure(mesureSize);
                System.Windows.Size descriptionSize = textBlock.DesiredSize;

                return descriptionSize.Width;
            }
        }
        public double Height
        {
            get
            {
                double widthCheckArea = textBlock.FontSize * 100;
                double hightCheckArea = textBlock.FontSize * 100;
                System.Windows.Size mesureSize = new System.Windows.Size(widthCheckArea, hightCheckArea);
                textBlock.Measure(mesureSize);
                System.Windows.Size descriptionSize = textBlock.DesiredSize;

                return descriptionSize.Height;
            }
        }
        #endregion



        #region Constructor
        public BPText() : base() { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            textBlock = new TextBlock();
            textBlock.Text = (_descriptionValue == "") ? _descriptionText : _descriptionText + " = " + _descriptionValue;
            textBlock.Foreground = Tools.GlobalParameters.WorkspaceFontColor;
            textBlock.FontSize = Tools.GlobalParameters.WorkspaceFontSize;

            Canvas.SetLeft(textBlock, _x);
            Canvas.SetTop(textBlock, _y);

            _drawElements.Add(textBlock);
        }
        #endregion
    }
}
