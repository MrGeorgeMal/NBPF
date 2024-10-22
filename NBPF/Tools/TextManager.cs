using NBPF.NBPFClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBPF.Tools
{
    public static class TextManager
    {
        #region Public Method
        /*
         * Method for check string for a number
         */
        public static bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^([+-]?\d+([.,]\d+)?(e[+-]?\d+([.,]\d+)?)?)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(text);
        }

        /*
         * Method for parse string into number
         */
        public static double StringToNumber(string text)
        {
            string bufferText = text.Replace(".", ",");
            return double.Parse(bufferText);
        }

        /*
         * Method for parse number to string
         */
        public static string NumberToString(double number)
        {
            string resultString = number.ToString();
            return resultString;
        }

        /*
         * Method for create a string from two arguments: units and dimension 
         */
        public static string CreateUnitsString(Tools.GlobalParameters.EUnits units, Tools.GlobalParameters.EDimension dimension)
        {
            string unitsString = string.Empty;
            
            switch(units)
            {
                case Tools.GlobalParameters.EUnits.pico: unitsString = "п"; break;
                case Tools.GlobalParameters.EUnits.nano: unitsString = "н"; break;
                case Tools.GlobalParameters.EUnits.micro: unitsString = "мк"; break;
                case Tools.GlobalParameters.EUnits.milli: unitsString = "м"; break;
                case Tools.GlobalParameters.EUnits.centi: unitsString = "с"; break;
                case Tools.GlobalParameters.EUnits.none: unitsString = ""; break;
                case Tools.GlobalParameters.EUnits.kilo: unitsString = "к"; break;
                case Tools.GlobalParameters.EUnits.mega: unitsString = "М"; break;
                case Tools.GlobalParameters.EUnits.giga: unitsString = "Г"; break;
                case Tools.GlobalParameters.EUnits.tera: unitsString = "Т"; break;
            }
            switch(dimension)
            {
                case Tools.GlobalParameters.EDimension.frequancy: unitsString += "Гц"; break;
                case Tools.GlobalParameters.EDimension.length: unitsString += "м"; break;
                case Tools.GlobalParameters.EDimension.resistance: unitsString += "Ом"; break;
                case Tools.GlobalParameters.EDimension.conductance: unitsString += "См"; break;
                case Tools.GlobalParameters.EDimension.capacitance: unitsString += "Ф"; break;
                case Tools.GlobalParameters.EDimension.inductance: unitsString += "Гн"; break;
                default:
                    unitsString += dimension;
                    break;
            }

            return unitsString;
        }

        /*
         * Method for create a string from enum
         */
        public static string CreateStringFromEnumItem(object enumItem)
        {
            string resultString = string.Empty;

            switch (enumItem)
            {
                case Tools.GlobalParameters.EAnalysisMethod:
                    switch (enumItem)
                    {
                        case Tools.GlobalParameters.EAnalysisMethod.gridMethod: resultString = "Метод Сеток"; break;
                        case Tools.GlobalParameters.EAnalysisMethod.finiteDifferenceMethod: resultString = "Метод Конечных Разностей"; break;
                    }
                    break;
            }

            return resultString;
        }
        #endregion
    }
}
