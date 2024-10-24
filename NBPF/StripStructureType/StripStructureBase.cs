using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NBPF.StripStructureType
{
    public class StripStructureBase
    {
        #region Protected Member
        protected List<UserControl> _userControls = new List<UserControl>();
        protected List<UIElement> _workspaceElements = new List<UIElement>();
        #endregion



        #region Public Member
        public List<UserControl> UserControls { get { return _userControls; } }
        public List<UIElement> WorkspaceElements { get { return _workspaceElements; } }
        #endregion



        #region Constructor
        public StripStructureBase() { SetupStripStructure(); }
        #endregion



        #region Protected Method
        protected virtual void SetupStripStructure() { }
        #endregion
    }
}
