using NBPF.Controls;
using NBPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NBPF.NBPFClasses
{
    public class Project : NBPFObject
    {
        #region Private Member
        private List<NBPFObject>? _nbpfObjects;
        private double _fMin;
        private double _fMax;
        private int _points;
        private UC_InputBox? _uc_fMin;
        private UC_InputBox? _uc_fMax;
        private UC_InputBox? _uc_points;
        private UC_SelectBox? _uc_freqUnit;
        private UC_SelectBox? _uc_geomUnit;
        private Tools.GlobalParameters.EUnits _frequencyUnits = Tools.GlobalParameters.EUnits.none;
        private Tools.GlobalParameters.EUnits _geometryUnits = Tools.GlobalParameters.EUnits.milli;
        #endregion



        #region Public Member
        public List<NBPFObject> NBPFObjects { get { return _nbpfObjects; } }
        public double fMin { get { return _fMin; } }
        public double fMax { get { return _fMax; } }
        public int Points { get { return _points; } }
        #endregion



        #region Constructor
        public Project()
        {
            SetupNewProject();
        }
        #endregion



        #region Private Method
        /*
         * Method for setup new project
         */
        private void SetupNewProject()
        {
            Name = "Проект";
            Analysis analysis = new Analysis("Анализ");
            Synthesis synthesis = new Synthesis("Синтез");
            StripStructure stripStructure = new StripStructure("Полосковая структура");
            FilterStructure filterStructure = new FilterStructure("Структура фильтра");
            Chart chart = new Chart("График 1");

            _nbpfObjects = new List<NBPFObject>();
            _nbpfObjects.Add(this);
            _nbpfObjects.Add(analysis);
            _nbpfObjects.Add(synthesis);
            _nbpfObjects.Add(stripStructure);
            _nbpfObjects.Add(filterStructure);
            _nbpfObjects.Add(chart);

            _uc_fMin = new UC_InputBox("1e6");
            _uc_fMax = new UC_InputBox("1e10");
            _uc_points = new UC_InputBox("1000");
            _uc_freqUnit = new UC_SelectBox(Tools.GlobalParameters.EDimension.frequancy, _frequencyUnits);
            _uc_geomUnit = new UC_SelectBox(Tools.GlobalParameters.EDimension.length, _geometryUnits);
            _fMin = Tools.TextManager.ToNumber(_uc_fMin.Value.Text);
            _fMax = Tools.TextManager.ToNumber(_uc_fMax.Value.Text);
            _points = (int)Tools.TextManager.ToNumber(_uc_points.Value.Text);

            _uc_fMin.Description.Text = "Начальная частота анализа";
            _uc_fMax.Description.Text = "Конечная частота анализа";
            _uc_points.Description.Text = "Количество точек анализа";
            _uc_freqUnit.Description.Text = "Единицы измерения частоты";
            _uc_geomUnit.Description.Text = "Единицы измерения геометрических размеров";

            userControls.Add(_uc_fMin);
            userControls.Add(_uc_fMax);
            userControls.Add(_uc_points);
            userControls.Add(_uc_freqUnit);
            userControls.Add(_uc_geomUnit);

            _uc_fMin.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_fMax.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_points.ValueChanged += new UC_InputBox.ValueChangedHandler(InputBox_ValueChanged);
            _uc_freqUnit.SelectItemChanged += new UC_SelectBox.ValueChangedHandler(SelectBox_ValueChanged);
            _uc_geomUnit.SelectItemChanged += new UC_SelectBox.ValueChangedHandler(SelectBox_ValueChanged);
        }

        /*
         * Event handling when InputBox's value changed
         */
        private void InputBox_ValueChanged(UC_InputBox sender, double value)
        {
            if (sender == _uc_fMin) _fMin = value;
            if (sender == _uc_fMax) _fMax = value;
            if (sender == _uc_points) _points = (int)value;
        }

        /*
         * Event handling when SelectBox's value changed
         */
        private void SelectBox_ValueChanged(UC_SelectBox sender, Tools.GlobalParameters.EUnits value)
        {
            if (sender == _uc_freqUnit) _frequencyUnits = value;
            if (sender == _uc_geomUnit) _geometryUnits = value;
        }
        #endregion
    }
}
