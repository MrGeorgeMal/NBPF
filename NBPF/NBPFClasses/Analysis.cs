using NBPF.Controls;
using NBPF.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.NBPFClasses
{
    public class Analysis : NBPFObject
    {
        #region Private Member
        private Tools.GlobalParameters.EAnalysisMethod _method = Tools.GlobalParameters.EAnalysisMethod.gridMethod;
        private bool _isGridMethodSetGridAutomatically = false;
        private bool _isGridMethodManuallyStep = false;
        private bool _isGridMethodUniformFrid = true;
        private UC_SelectBox? _uc_method;
        private UC_CheckBox? _uc_gridMethodSetGridAutomatically;
        private UC_CheckBox? _uc_gridMethodManuallyStep;
        private UC_CheckBox? _uc_gridMethodUniformGrid;
        private UC_InputBox? _uc_gridMethodDivideMinSizeXY;
        private UC_InputBox? _uc_gridMethodDivideMinSizeX;
        private UC_InputBox? _uc_gridMethodDivideMinSizeY;
        private UC_InputBox? _uc_divideMinSizeY;
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
            _uc_gridMethodSetGridAutomatically = new UC_CheckBox();
            _uc_gridMethodManuallyStep = new UC_CheckBox();
            _uc_gridMethodUniformGrid = new UC_CheckBox();
            _uc_gridMethodDivideMinSizeXY = new UC_InputBox("10");
            _uc_gridMethodDivideMinSizeX = new UC_InputBox("10");
            _uc_gridMethodDivideMinSizeY = new UC_InputBox("10");
            _uc_gridMethodStepXY = new UC_InputBox("0.1");
            _uc_gridMethodStepX = new UC_InputBox("0.1");
            _uc_gridMethodStepY = new UC_InputBox("0.1");

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

            userControls.Add(_uc_method);
            userControls.Add(_uc_gridMethodSetGridAutomatically);
            userControls.Add(_uc_gridMethodManuallyStep);
            userControls.Add(_uc_gridMethodUniformGrid);
            userControls.Add(_uc_gridMethodDivideMinSizeXY);
            userControls.Add(_uc_gridMethodDivideMinSizeX);
            userControls.Add(_uc_gridMethodDivideMinSizeY);
            userControls.Add(_uc_gridMethodStepXY);
            userControls.Add(_uc_gridMethodStepX);
            userControls.Add(_uc_gridMethodStepY);

            _uc_method.SelectItemChanged += new UC_SelectBox.ValueChangedHandler(SelectBox_ValueChanged);
        }
        #endregion



        #region Private Method
        /*
         * Event handling when SelectBox's value changed
         */
        private void SelectBox_ValueChanged(UC_SelectBox sender, object value)
        {
            if (sender == _uc_method) _method = (Tools.GlobalParameters.EAnalysisMethod)value;
            Debug.WriteLine(_method);
        }
        #endregion
    }
}
