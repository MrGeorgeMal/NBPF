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
        #region Private Member
        private static Project? _project; // Stores the current open project
        #endregion



        #region Public Method
        /*
         * Method for load new project
         */
        public static Project LoadNewProject()
        {
            _project = new Project();
            return _project;
        }
        #endregion
    }
}
