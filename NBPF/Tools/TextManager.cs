using NBPF.NBPFClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBPF.Tools
{
    public static class TextManager
    {
        public static bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^([+-]?\d+([.,]\d+)?(e[+-]?\d+([.,]\d+)?)?)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(text);
        }


        public static double ToNumber(string text)
        {
            string bufferText = text.Replace(".", ",");
            return double.Parse(bufferText);
        }


        public static string CreateUnitsString(NBPFObject.EUnits units, NBPFObject.EDimension dimension)
        {
            string unitsString = string.Empty;
            
            switch(units)
            {
                case NBPFObject.EUnits.pico: unitsString = "п"; break;
                case NBPFObject.EUnits.nano: unitsString = "н"; break;
                case NBPFObject.EUnits.micro: unitsString = "мк"; break;
                case NBPFObject.EUnits.milli: unitsString = "м"; break;
                case NBPFObject.EUnits.centi: unitsString = "с"; break;
                case NBPFObject.EUnits.none: unitsString = ""; break;
                case NBPFObject.EUnits.kilo: unitsString = "к"; break;
                case NBPFObject.EUnits.mega: unitsString = "М"; break;
                case NBPFObject.EUnits.giga: unitsString = "Г"; break;
                case NBPFObject.EUnits.tera: unitsString = "Т"; break;
            }
            switch(dimension)
            {
                case NBPFObject.EDimension.frequancy: unitsString += "Гц"; break;
                case NBPFObject.EDimension.length: unitsString += "м"; break;
                case NBPFObject.EDimension.resistance: unitsString += "Ом"; break;
                case NBPFObject.EDimension.conductance: unitsString += "См"; break;
                case NBPFObject.EDimension.capacitance: unitsString += "Ф"; break;
                case NBPFObject.EDimension.inductance: unitsString += "Гн"; break;
                default:
                    unitsString += dimension;
                    break;
            }

            return unitsString;
        }
    }
}
