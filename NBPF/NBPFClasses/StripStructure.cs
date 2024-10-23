using NBPF.Controls;
using NBPF.StripStructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static NBPF.Tools.GlobalParameters;

namespace NBPF.NBPFClasses
{
    public class StripStructure : NBPFObject
    {
        #region Private Member
        private Tools.GlobalParameters.EStripStructreType _stripStructreType = Tools.GlobalParameters.EStripStructreType.coupledStripLinesVIP;
        private StripStructure? _stripStructure;
        private UC_SelectBox? _uc_stripStructureType;
        #endregion



        #region Constructor
        public StripStructure() { }
        public StripStructure(string name) : base(name) { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            _uc_stripStructureType = new UC_SelectBox(new Tools.GlobalParameters.EStripStructreType(), _stripStructreType);

            _uc_stripStructureType.Description.Text = "Тип полосковой структуры";

            _stripStructure = new CoplanarStripLinesVIP();

            UpdateUserControls();

            _uc_stripStructureType.SelectItemChanged += new UC_SelectBox.ValueChangedHandler(SelectBox_SelectItemChanged);
        }
        #endregion



        #region Private Method
        /*
         * 
         */
        private void SelectBox_SelectItemChanged(UC_SelectBox sender, object value)
        {
            if (sender == _uc_stripStructureType) _stripStructreType = (Tools.GlobalParameters.EStripStructreType)value;
            UpdateUserControls();
        }

        /*
         * Method for update userControls List
         */
        private void UpdateUserControls()
        {
            userControls.Clear();
            userControls.Add(_uc_stripStructureType);

            switch(_stripStructreType)
            {
                case Tools.GlobalParameters.EStripStructreType.coupledStripLinesVIP:
                    _stripStructure = new CoplanarStripLinesVIP();
                    break;
                default:
                    _stripStructure = null;
                    break;
            }

            if(_stripStructure != null)
            {
                userControls.AddRange(_stripStructure.userControls);
            }

            base.PropertiesNeedUpdate(this);
        }
        #endregion
    }
}
