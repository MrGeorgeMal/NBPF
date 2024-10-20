using NBPF.NBPFClasses;
using NBPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.Tools
{
    public static class SaveLoad
    {
        /*
         * 
        */
        #region Private Member
        private static Project _project;
        #endregion

        public static Project LoadNewProject()
        {
            _project = new Project();
            return _project;
        }
    }
}
