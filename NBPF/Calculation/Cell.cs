
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.Calculation
{
    public class Cell
    {
        public Tools.GlobalParameters.EMaterialType Material { get; set; } = Tools.GlobalParameters.EMaterialType.none;
        public double Potencial { get; set; } = 0.0;
        public double DielectricPermittivity { get; set; } = 0.0;

    }
}
