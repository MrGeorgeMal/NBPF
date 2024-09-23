using NBPF.NBPFClasses;
using NBPF.Pages;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace NBPF.ViewModels
{
    public class ViewModel_ContentManager : ViewModel_Base
    {
        public Page_ProjectTree PageFrame1 { get; set; } = new Pages.Page_ProjectTree();
        public Page PageFrame2 { get; set; } = new Pages.Page_Workspace();
        public Page_Properties PageFrame3 { get; set; } = new Pages.Page_Properties();
        public Page PageFrame4 { get; set; } = new Pages.Page_OutputData();


        public Project project;


        public ViewModel_ContentManager()
        {
            project = new Project();
            UpdateProjectTree();
            //ProjectTree.UpdateProjectTree(project.nbpf_objects);
        }


        public int UpdateProjectTree()
        {
            TreeViewItem projectHeader = new TreeViewItem();
            TreeViewItem chartsHeader = new TreeViewItem();

            projectHeader.Header = project.nbpf_objects.First().Name;
            chartsHeader.Header = "Графики";
            projectHeader.IsExpanded = true;
            chartsHeader.IsExpanded = true;
            PageFrame1.projectTree.Items.Add(projectHeader);
            projectHeader.Items.Add(chartsHeader);

            foreach (NBPFObject obj in project.nbpf_objects)
            {
                if (obj is not Project)
                {
                    if (obj is Chart)
                    {
                        TreeViewItem newChart = new TreeViewItem();
                        newChart.Header = obj.Name;
                        chartsHeader.Items.Add(newChart);
                    }
                    else
                    {
                        TreeViewItem newItem = new TreeViewItem();
                        newItem.Header = obj.Name;
                        projectHeader.Items.Add(newItem);
                    }
                }
            }
            PageFrame1.projectTree.SelectedItemChanged += ProjectTreeItem_Selected;
            return 0;
        }


        public void ProjectTreeItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)PageFrame1.projectTree.SelectedItem;

            PageFrame3.PropertyGrid.Children.Clear();
            PageFrame3.PropertyGrid.RowDefinitions.Clear();

            NBPFObject selectedItem = null;

            foreach (NBPFObject obj in project.nbpf_objects)
            {
                if(item.Header.ToString() == obj.Name)
                {
                    selectedItem = obj;
                    break;
                }
            }

            if (selectedItem != null)
            {
                for (int i = 0; i < selectedItem.userControls.Count; i++)
                {
                    PageFrame3.PropertyGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35) });
                    Grid.SetRow(selectedItem.userControls[i], i);
                    PageFrame3.PropertyGrid.Children.Add(selectedItem.userControls[i]);
                }
            }
        }
    }
}
