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
using static NBPF.Controls.UC_InputBox;

namespace NBPF.NBPFClasses
{
    public class Project : NBPFObject
    {
        public ViewModel_ContentManager contentManager;
        public List<NBPFObject> nbpf_objects;

        public double fMin;
        public double fMax;
        public int points;
        public EUnits FrequencyUnits;
        public EUnits GeometryUnits;

        public UC_InputBox uc_fMin;
        public UC_InputBox uc_fMax;
        public UC_InputBox uc_points;
        public UC_SelectBox uc_freqUnit { get; set; } = new UC_SelectBox();
        public UC_SelectBox uc_geomUnit { get; set; } = new UC_SelectBox();

        public Project()
        {
            Name = "Проект";
            Analysis analysis = new Analysis("Анализ");
            Synthesis synthesis = new Synthesis("Синтез");
            StripStructure stripStructure = new StripStructure("Полосковая структура");
            FilterStructure filterStructure = new FilterStructure("Структура фильтра");
            Chart chart = new Chart("График 1");

            nbpf_objects = new List<NBPFObject>();
            nbpf_objects.Add(this);
            nbpf_objects.Add(analysis);
            nbpf_objects.Add(synthesis);
            nbpf_objects.Add(stripStructure);
            nbpf_objects.Add(filterStructure);
            nbpf_objects.Add(chart);

            uc_fMin = new UC_InputBox("1e6");
            uc_fMax = new UC_InputBox("1e10");
            uc_points = new UC_InputBox("1000");
            fMin = Tools.TextManager.ToNumber(uc_fMin.Value.Text);
            fMax = Tools.TextManager.ToNumber(uc_fMax.Value.Text);
            points = (int)Tools.TextManager.ToNumber(uc_points.Value.Text);


            uc_fMin.Description.Text = "Начальная частота анализа";
            uc_fMax.Description.Text = "Конечная частота анализа";
            uc_points.Description.Text = "Количество точек анализа";
            uc_freqUnit.Description.Text = "Единицы измерения частоты";
            uc_freqUnit.SelectBox.Items.Add("Гц");
            uc_freqUnit.SelectBox.Items.Add("кГц");
            uc_freqUnit.SelectBox.Items.Add("МГц");
            uc_freqUnit.SelectBox.Items.Add("ГГц");
            uc_freqUnit.SelectBox.SelectedIndex = 0;
            uc_geomUnit.Description.Text = "Единицы измерения геометрических размеров";
            uc_geomUnit.SelectBox.Items.Add("м");
            uc_geomUnit.SelectBox.Items.Add("дм");
            uc_geomUnit.SelectBox.Items.Add("см");
            uc_geomUnit.SelectBox.Items.Add("мм");
            uc_geomUnit.SelectBox.Items.Add("мкм");
            uc_geomUnit.SelectBox.Items.Add("нм");
            uc_geomUnit.SelectBox.SelectedIndex = 0;
            userControls.Add(uc_fMin);
            userControls.Add(uc_fMax);
            userControls.Add(uc_points);
            userControls.Add(uc_freqUnit);
            userControls.Add(uc_geomUnit);

            uc_fMin.ValueChanged += new ValueChangedHandler(SetNewValue);
            uc_fMax.ValueChanged += new ValueChangedHandler(SetNewValue);
            uc_points.ValueChanged += new ValueChangedHandler(SetNewValue);
        }


        public void SetNewValue(UC_InputBox sender, double value)
        {
            if (sender == uc_fMin) fMin = value;
            if (sender == uc_fMax) fMax = value;
            if (sender == uc_points) points = (int)value;

            Debug.WriteLine(fMin);
            Debug.WriteLine(fMax);
            Debug.WriteLine(points);
        }
    }
}
