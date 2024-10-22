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
        #region Public Member
        public string Name { get; set; } = "NBPFObject";
        public List<UserControl> userControls { get; set; } = new List<UserControl>();
        #endregion



        #region Constructor
        public NBPFObject() { SetupObject(); }

        public NBPFObject(string name) { Name = name; SetupObject(); }
        #endregion



        #region Protected Method
        /*
         * Method for setup NBPFObject
         */
        protected virtual void SetupObject() { }
        #endregion
    }
}
