using NBPF.Controls;
using NBPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NBPF.NBPFClasses
{
    public class Project : NBPFObject
    {
        public ViewModel_ContentManager contentManager;
        public List<NBPFObject> nbpf_objects;

        public double fMin { get; set; } = 1e6;
        public double fMax { get; set; } = 1e10;
        public int points { get; set; } = 1000;

        public UC_InputBox uc_fMin { get; set; } = new UC_InputBox();
        public UC_InputBox uc_fMax { get; set; } = new UC_InputBox();
        public UC_InputBox uc_points { get; set; } = new UC_InputBox();

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


            userControls.Add(uc_fMin);
            userControls.Add(uc_fMax);
            userControls.Add(uc_points);
        }

        public Project(List<NBPFObject> nbpf_objects) : base(nbpf_objects)
        {
            this.nbpf_objects = nbpf_objects;
        }
    }
}
