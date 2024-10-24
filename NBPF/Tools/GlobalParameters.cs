using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Media;

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

        public enum EAnalysisMethod
        {
            gridMethod,
            finiteDifferenceMethod
        }

        public enum EStripStructreType
        {
            custom,
            stripLines,
            coplanarStripLines,
            coupledStripLines,
            coupledStripLinesVIP,
        }

        public enum EMaterialType
        {
            conductor,
            dielectric
        }
        #endregion



        #region Public Member
        public static Brush DimensionLineStrokeColor = Brushes.White;
        public static Brush ConductorStrokeColor = Brushes.Red;
        public static Brush ConductorFillColor = Brushes.Orange;
        public static Brush DielectricStrokeColor = Brushes.DarkGreen;
        public static Brush DielectricFillColor = Brushes.Green;
        public static Brush WorkspaceFontColor = Brushes.White;
        public static float WorkspaceFontSize = 30.0f;
        #endregion
    }
}
