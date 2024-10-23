using NBPF.Controls;
using NBPF.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NBPF.NBPFClasses
{
    public class Analysis : NBPFObject
    {
        #region Private Member
        private Tools.GlobalParameters.EAnalysisMethod _method = Tools.GlobalParameters.EAnalysisMethod.gridMethod;
        private bool _isGridMethodSetGridAutomatically = false;
        private bool _isGridMethodManuallyStep = false;
        private bool _isGridMethodUniformGrid = true;
        private double _gridMethodDivideMinSizeXY;
        private double _gridMethodDivideMinSizeX;
        private double _gridMethodDivideMinSizeY;
        private double _gridMethodStepXY;
        private double _gridMethodStepX;
        private double _gridMethodStepY;
        private UC_SelectBox? _uc_method;
        private UC_CheckBox? _uc_gridMethodSetGridAutomatically;
        private UC_CheckBox? _uc_gridMethodManuallyStep;
        private UC_CheckBox? _uc_gridMethodUniformGrid;
        private UC_InputBox? _uc_gridMethodDivideMinSizeXY;
        private UC_InputBox? _uc_gridMethodDivideMinSizeX;
        private UC_InputBox? _uc_gridMethodDivideMinSizeY;
        private UC_InputBox? _uc_gridMethodStepXY;
        private UC_InputBox? _uc_gridMethodStepX;
        private UC_InputBox? _uc_gridMethodStepY;
        #endregion



        #region Constructors
        public Analysis() : base() { }
        public Analysis(string name) : base(name) { }
        #endregion



        #region Protected Method
        protected override void SetupObject()
        {
            _uc_method = new UC_SelectBox(new Tools.GlobalParameters.EAnalysisMethod(), _method);
            _uc_gridMethodSetGridAutomatically = new UC_CheckBox(false);
            _uc_gridMethodManuallyStep = new UC_CheckBox(false);
            _uc_gridMethodUniformGrid = new UC_CheckBox(true);
            _uc_gridMethodDivideMinSizeXY = new UC_InputBox("10");
            _uc_gridMethodDivideMinSizeX = new UC_InputBox("10");
            _uc_gridMethodDivideMinSizeY = new UC_InputBox("10");
            _uc_gridMethodStepXY = new UC_InputBox("0.1");
            _uc_gridMethodStepX = new UC_InputBox("0.1");
            _uc_gridMethodStepY = new UC_InputBox("0.1");

            _gridMethodDivideMinSizeXY = Tools.TextManager.StringToNumber(_uc_gridMethodDivideMinSizeXY.Value.Text);
            _gridMethodDivideMinSizeX = Tools.TextManager.StringToNumber(_uc_gridMethodDivideMinSizeX.Value.Text);
            _gridMethodDivideMinSizeY = Tools.TextManager.StringToNumber(_uc_gridMethodDivideMinSizeY.Value.Text);
            _gridMethodStepXY = Tools.TextManager.StringToNumber(_uc_gridMethodStepXY.Value.Text);
            _gridMethodStepX = Tools.TextManager.StringToNumber(_uc_gridMethodStepX.Value.Text);
            _gridMethodStepY = Tools.TextManager.StringToNumber(_uc_gridMethodStepY.Value.Text);

            _uc_method.Description.Text = "Метод расчета погонных параметров";
            _uc_gridMethodSetGridAutomatically.Description.Text = "Определить сетку автоматически";
            _uc_gridMethodManuallyStep.Description.Text = "Пользовательская настройка шага сетки";
            _uc_gridMethodUniformGrid.Description.Text = "Равномерная сетка";
            _uc_gridMethodDivideMinSizeXY.Description.Text = "Деление минимального размера";
            _uc_gridMethodDivideMinSizeX.Description.Text = "Деление минимального размера по оси X";
            _uc_gridMethodDivideMinSizeY.Description.Text = "Деление минимального размера по оси Y";
            _uc_gridMethodStepXY.Description.Text = "Шаг сетки";
            _uc_gridMethodStepX.Description.Text = "Шаг сетки по оси X";
            _uc_gridMethodStepY.Description.Text = "Шаг сетки по оси Y";

            UpdateUserControls();

            _uc_method.SelectItemChanged += new UC_SelectBox.ValueChangedHandler(SelectBox_ValueChanged);
            _uc_gridMethodSetGridAutomatically.ValueChanged += new UC_CheckBox.ValueChangedHandler(CheckBox_ValueChanged);
            _uc_gridMethodManuallyStep.ValueChanged += new UC_CheckBox.ValueChangedHandler(CheckBox_ValueChanged);
            _uc_gridMethodUniformGrid.ValueChanged += new UC_CheckBox.ValueChangedHandler(CheckBox_ValueChanged);
            _uc_gridMethodDivideMinSizeXY.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_gridMethodDivideMinSizeX.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_gridMethodDivideMinSizeY.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_gridMethodStepXY.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_gridMethodStepX.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_gridMethodStepY.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
        }
        #endregion



        #region Private Method
        /*
         * Event handling when SelectBox's value changed
         */
        private void SelectBox_ValueChanged(UC_SelectBox sender, object value)
        {
            if (sender == _uc_method) _method = (Tools.GlobalParameters.EAnalysisMethod)value;
        }

        /*
         * Event handling when CheckBox's Flag value changed
         */
        private void CheckBox_ValueChanged(UC_CheckBox sender, bool value)
        {
            if (sender == _uc_gridMethodSetGridAutomatically) _isGridMethodSetGridAutomatically = value;
            if (sender == _uc_gridMethodManuallyStep) _isGridMethodManuallyStep = value;
            if ( sender == _uc_gridMethodUniformGrid) _isGridMethodUniformGrid = value;
            
            UpdateUserControls();
            base.PropertiesNeedUpdate(this);
        }

        /*
         * Event handling when InputBox's value changed
         */
        private void InputBox_ValueChanged(UC_InputBox sender, double value)
        {
            if (sender == _uc_gridMethodDivideMinSizeXY) _gridMethodDivideMinSizeXY = value;
            if (sender == _uc_gridMethodDivideMinSizeX) _gridMethodDivideMinSizeX = value;
            if (sender == _uc_gridMethodDivideMinSizeY) _gridMethodDivideMinSizeY = value;
            if (sender == _uc_gridMethodStepXY) _gridMethodStepXY = value;
            if (sender == _uc_gridMethodStepX) _gridMethodStepX = value;
            if (sender == _uc_gridMethodStepY) _gridMethodStepY = value;
        }

        /*
         * Method for update UserControls List
         */
        private void UpdateUserControls()
        {
            userControls.Clear();
            userControls.Add(_uc_method);
            userControls.Add(_uc_gridMethodSetGridAutomatically);

            if (_isGridMethodSetGridAutomatically == false)
            {
                userControls.Add(_uc_gridMethodManuallyStep);
                userControls.Add(_uc_gridMethodUniformGrid);

                switch (_isGridMethodManuallyStep)
                {
                    case true:
                        if (_isGridMethodUniformGrid == true)
                        {
                            userControls.Add(_uc_gridMethodStepXY);
                        }
                        else
                        {
                            userControls.Add(_uc_gridMethodStepX);
                            userControls.Add(_uc_gridMethodStepY);
                        }
                        break;

                    case false:
                        if (_isGridMethodUniformGrid == true)
                        {
                            userControls.Add(_uc_gridMethodDivideMinSizeXY);
                        }
                        else
                        {
                            userControls.Add(_uc_gridMethodDivideMinSizeX);
                            userControls.Add(_uc_gridMethodDivideMinSizeY);
                        }
                        break;
                }
            }
        }
        #endregion
    }
}
