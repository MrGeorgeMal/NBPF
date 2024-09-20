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
    }
}
