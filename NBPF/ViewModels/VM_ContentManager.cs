using NBPF.NBPFClasses;
using NBPF.Pages;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace NBPF.ViewModels
{
    public class VM_ContentManager : VM_Base
    {
        #region Private Member
        private Project _project;
        #endregion

        #region Public Member
        public Page_ProjectTree PageProjectTree { get; set; } = new Pages.Page_ProjectTree();
        public Page_Workspace PageWorkspace { get; set; } = new Pages.Page_Workspace();
        public Page_Properties PageProperties { get; set; } = new Pages.Page_Properties();
        public Page_OutputData PageOutputData { get; set; } = new Pages.Page_OutputData();
        #endregion


        public VM_ContentManager()
        {
            _project = Tools.SaveLoad.LoadNewProject();
            ProjectLoaded();
        }

        public void ProjectLoaded()
        {
            PageProjectTree.UpdateProjectTree(_project);
            PageProjectTree.SelectedItemChanged += new Page_ProjectTree.SelectedItemChangedHandler(ProjectTree_SelectedItemChanged);
        }

        public void ProjectTree_SelectedItemChanged(Page_ProjectTree sender, NBPFObject selectedItem)
        {
            PageProperties.UpdateProperties(selectedItem);
        }
    }
}
