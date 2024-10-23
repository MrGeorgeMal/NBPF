using NBPF.Controls;
using NBPF.NBPFClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBPF.Tools.GlobalParameters;

namespace NBPF.StripStructure
{
    public class CoplanarStripLinesVIP : NBPFClasses.StripStructure
    {
        #region Private Member
        private UC_InputBox? _uc_a;
        #endregion



        #region Constructor
        public CoplanarStripLinesVIP() { }
        public CoplanarStripLinesVIP(string name) : base(name) { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            _uc_a = new UC_InputBox();
            _uc_a.Description.Text = "Ширина структуры (a)";
            userControls.Add(_uc_a);
        }
        #endregion

    }
}
