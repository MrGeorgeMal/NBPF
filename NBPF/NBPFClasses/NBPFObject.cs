using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NBPF.NBPFClasses
{
    public class NBPFObject
    {
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

        public string Name { get; set; } = "Object";

        public List<UserControl> userControls { get; set; } = new List<UserControl>();

        public NBPFObject() { }

        public NBPFObject(string name)
        {
            Name = name;
        }

        public NBPFObject(List<NBPFObject> objects)
        {
            CheckName(Name, objects);
        }

        public int CheckName(string name, List<NBPFObject> objects)
        {
            foreach (NBPFObject obj in objects)
            {
                if(obj.Name == name)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
