using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.NBPFClasses
{
    public class NBPFObject
    {
        public string Name { get; set; } = "Object";

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
