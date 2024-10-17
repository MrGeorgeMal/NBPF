using NBPF.NBPFClasses;
using NBPF.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NBPF.Controls
{
    /// <summary>
    /// Interaction logic for UC_SelectBox.xaml
    /// </summary>
    public partial class UC_SelectBox : UserControl
    {
        NBPFObject.EDimension dimension;
        NBPFObject.EUnits units;

        public UC_SelectBox(NBPFObject.EDimension dimension)
        {
            InitializeComponent();

            foreach (NBPFObject.EUnits val in Enum.GetValues(typeof(NBPFObject.EUnits)))
            {
                SelectBox.Items.Add(TextManager.CreateUnitsString(val, dimension));
            }

            SelectBox.SelectedIndex = 0;
            SelectBox.SelectionChanged += new SelectionChangedEventHandler(SelectBox_SelectionChanged);
        }

        public void SelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("SelectChanged");
        }
    }
}
