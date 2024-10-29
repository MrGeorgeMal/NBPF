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
        #region Public Enum
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

        public enum EBPLinePosition
        {
            center,
            left,
            right
        }
        #endregion



        #region Public Member
        public static Brush DimensionLineStrokeColor = Brushes.White;
        public static Brush ConductorStrokeColor = Brushes.Yellow;
        public static Brush ConductorFillColor = Brushes.Orange;
        public static Brush DielectricStrokeColor = Brushes.LightGreen;
        public static Brush DielectricFillColor = Brushes.Green;
        public static Brush ScreenFillColor = Brushes.White;
        public static Brush WorkspaceFontColor = Brushes.White;
        public static float WorkspaceFontSize = 20.0f;
        public static float BPObjectStrokeThickness = 2.0f;
        public static float DimentionLinesStrokeThickness = 1.0f;
        #endregion
    }
}
