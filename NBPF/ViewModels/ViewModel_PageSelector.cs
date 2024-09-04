using NBPF.Pages;
using System.Windows.Controls;

namespace NBPF.ViewModels
{
    public class ViewModel_PageSelector : ViewModel_Base
    {
        public Page PageFrame1 { get; set; } = new Pages.Page_InitData();
        public Page PageFrame2 { get; set; } = new Pages.Page_OutputData();
        public Page PageFrame3 { get; set; } = new Pages.Page_Chart();

        public ViewModel_PageSelector()
        {

        }
    }
}
