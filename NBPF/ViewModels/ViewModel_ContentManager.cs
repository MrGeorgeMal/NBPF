using NBPF.NBPFClasses;
using NBPF.Pages;
using System.Windows.Controls;

namespace NBPF.ViewModels
{
    public class ViewModel_ContentManager : ViewModel_Base
    {
        public Page PageFrame1 { get; set; } = new Pages.Page_ProjectTree();
        public Page PageFrame2 { get; set; } = new Pages.Page_Workspace();
        public Page PageFrame3 { get; set; } = new Pages.Page_Properties();
        public Page PageFrame4 { get; set; } = new Pages.Page_OutputData();


        public Project project;
        public List<NBPFObject> nbpf_objects { get; set; } = new List<NBPFObject>();


        public ViewModel_ContentManager()
        {
            project = new Project(nbpf_objects);
        }
    }
}
