using NBPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.NBPFClasses
{
    public class Project : NBPFObject
    {
        public ViewModel_ContentManager contentManager;
        public double f_min { get; set; } = 1e6;
        public double f_max { get; set; } = 1e10;
        public int points { get; set; } = 1000;

        public Project(List<NBPFObject> objects) : base(objects) { }
    }
}
