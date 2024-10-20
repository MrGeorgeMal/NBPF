using NBPF.NBPFClasses;
using NBPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_ProjectTree.xaml
    /// </summary>
    public partial class Page_ProjectTree : Page
    {
        public delegate void SelectedItemChangedHandler(Page_ProjectTree sender, NBPFObject selectedItem);
        public event SelectedItemChangedHandler? SelectedItemChanged;

        private Project _project;

        public Page_ProjectTree()
        {
            InitializeComponent();
        }

        public void UpdateProjectTree(Project project)
        {
            _project = project;

            TreeViewItem projectHeader = new TreeViewItem();
            TreeViewItem chartsHeader = new TreeViewItem();

            projectHeader.Header = project.nbpf_objects.First().Name;
            chartsHeader.Header = "Графики";
            projectHeader.IsExpanded = true;
            chartsHeader.IsExpanded = true;
            ProjectTree.Items.Add(projectHeader);
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

            ProjectTree.SelectedItemChanged += ProjectTreeItem_Selected;
        }

        public void ProjectTreeItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)ProjectTree.SelectedItem;
            NBPFObject selectedItem = null;

            foreach (NBPFObject obj in _project.nbpf_objects)
            {
                if (item.Header.ToString() == obj.Name)
                {
                    selectedItem = obj;
                    break;
                }
            }

            SelectedItemChanged?.Invoke(this, selectedItem);
        }
    }
}
