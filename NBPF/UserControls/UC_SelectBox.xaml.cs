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
        public delegate void ValueChangedHandler(UC_SelectBox sender, NBPFObject.EUnits units);
        public event ValueChangedHandler? ValueChanged;


        public UC_SelectBox(NBPFObject.EDimension dimension)
        {
            InitializeComponent();

            foreach (NBPFObject.EUnits val in Enum.GetValues(typeof(NBPFObject.EUnits)))
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = TextManager.CreateUnitsString(val, dimension);
                newItem.Tag = val;

                switch (dimension)
                {
                    case NBPFObject.EDimension.frequancy:
                        if((int)val >= 5)
                        {
                            SelectBox.Items.Add(newItem);
                        }
                        break;
                    case NBPFObject.EDimension.length:
                        if((int)val <= 5)
                        {
                            SelectBox.Items.Add(newItem);
                        }
                        break;
                    default:
                        SelectBox.Items.Add(newItem);
                        break;
                }
            }

            SelectBox.SelectedIndex = 0;
            SelectBox.SelectionChanged += new SelectionChangedEventHandler(SelectBox_SelectionChanged);
        }

        public void SelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NBPFObject.EUnits units;
            ComboBoxItem selectedItem = (ComboBoxItem)SelectBox.SelectedItem;
            units = (NBPFObject.EUnits)selectedItem.Tag;
            ValueChanged?.Invoke(this, units);
        }
    }
}
