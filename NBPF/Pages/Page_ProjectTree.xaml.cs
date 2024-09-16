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
        public Page_ProjectTree()
        {
            InitializeComponent();
        }

        public int UpdateProjectTree(List<NBPFObject> nbpf_objects)
        {
            TreeViewItem project = new TreeViewItem();
            TreeViewItem charts = new TreeViewItem();

            project.Header = nbpf_objects.First().Name;
            charts.Header = "Графики";
            project.IsExpanded = true;
            charts.IsExpanded = true;
            projectTree.Items.Add(project);
            project.Items.Add(charts);

            foreach (NBPFObject obj in nbpf_objects)
            {
                if (obj is Chart)
                {
                    TreeViewItem newChart = new TreeViewItem();
                    newChart.Header = obj.Name;
                    charts.Items.Add(newChart);
                }
                else
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Header = obj.Name;
                    project.Items.Add(newItem);
                }
            }
            projectTree.SelectedItemChanged += ProjectItem_Selected;

            return 0;
        }

        public void ProjectItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)projectTree.SelectedItem;
            Debug.WriteLine(item.Header);
        }
    }
}
