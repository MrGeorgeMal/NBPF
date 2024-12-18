﻿using NBPF.Controls;
using NBPF.StripStructure;
using NBPF.StripStructureType;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static NBPF.Tools.GlobalParameters;

namespace NBPF.NBPFClasses
{
    public class StripStructure : NBPFObject
    {
        #region Private Member
        private Tools.GlobalParameters.EStripStructreType _stripStructreType = Tools.GlobalParameters.EStripStructreType.coupledStripLinesVIP;
        private StripStructureBase? _stripStructure;
        private UC_SelectBox? _uc_stripStructureType;
        #endregion



        #region Constructor
        public StripStructure() { }
        public StripStructure(string name) : base(name) { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            WorkspaceUserControl = new UserControls.UC_PanAndZoomCanvas();

            _uc_stripStructureType = new UC_SelectBox(new Tools.GlobalParameters.EStripStructreType(), _stripStructreType);

            _uc_stripStructureType.Description.Text = "Тип полосковой структуры";

            _stripStructure = new CoplanarStripLinesVIP();

            UpdateUserControls();

            _uc_stripStructureType.SelectItemChanged += new UC_SelectBox.ValueChangedHandler(SelectBox_SelectItemChanged);
        }
        #endregion



        #region Private Method
        /*
         * Event handling when SelectBox's value changed
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
            if (WorkspaceUserControl != null)
            {
                WorkspaceUserControl.Children.Clear();
            }

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
                userControls.AddRange(_stripStructure.UserControls);
                UpdateWorkspace(_stripStructure.WorkspaceElements);
            }

            base.PropertiesNeedUpdate(this);
        }
        #endregion
    }
}
