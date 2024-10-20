using NBPF.NBPFClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Логика взаимодействия для Page_Properties.xaml
    /// </summary>
    public partial class Page_Properties : Page
    {
        public Page_Properties()
        {
            InitializeComponent();
        }

        public void UpdateProperties(NBPFObject item)
        {
            PropertyGrid.Children.Clear();
            PropertyGrid.RowDefinitions.Clear();

            if (item != null)
            {
                for (int i = 0; i < item.userControls.Count; i++)
                {
                    PropertyGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35) });
                    Grid.SetRow(item.userControls[i], i);
                    PropertyGrid.Children.Add(item.userControls[i]);
                }
            }
        }
    }
}
