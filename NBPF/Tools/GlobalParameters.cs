using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.Tools
{
    public static class GlobalParameters
    {
        #region Enum
        public enum EUnits : int
        {
            pico,
            nano,
            micro,
            milli,
            centi,
            none,
            kilo,
            mega,
            giga,
            tera
        }

        public enum EDimension
        {
            custom,
            frequancy,
            length,
            speed,
            resistance,
            conductance,
            capacitance,
            inductance
        }
        #endregion
    }
}
