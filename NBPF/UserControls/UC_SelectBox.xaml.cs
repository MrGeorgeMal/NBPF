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
using static NBPF.Tools.GlobalParameters;

namespace NBPF.Controls
{
    public partial class UC_SelectBox : UserControl
    {
        #region Event
        /*
         * Event triggered when the value in the ComboBox changes
         */
        public delegate void ValueChangedHandler(UC_SelectBox sender, object value);
        public event ValueChangedHandler? SelectItemChanged;
        #endregion



        #region Constructor
        public UC_SelectBox(Tools.GlobalParameters.EDimension dimension, Tools.GlobalParameters.EUnits defaultUnits)
        {
            InitializeComponent();
            UpdateSelectBox(dimension, defaultUnits);
        }

        public UC_SelectBox(Enum @enum, object? defaultValue = null)
        {
            InitializeComponent();
            UpdateSelectBox(@enum, defaultValue);
        }
        #endregion



        #region Private Method
        /*
         * Method for update combo box with dimension items
         */
        private void UpdateSelectBox(Tools.GlobalParameters.EDimension dimension, Tools.GlobalParameters.EUnits defaultUnits)
        {
            foreach (Tools.GlobalParameters.EUnits val in Enum.GetValues(typeof(Tools.GlobalParameters.EUnits)))
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = TextManager.CreateUnitsString(val, dimension);
                newItem.Tag = val;

                switch (dimension)
                {
                    case Tools.GlobalParameters.EDimension.frequancy:
                        if ((int)val >= 5)
                        {
                            SelectBox.Items.Add(newItem);
                        }
                        break;
                    case Tools.GlobalParameters.EDimension.length:
                        if ((int)val <= 5)
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
            foreach (ComboBoxItem item in SelectBox.Items)
            {
                if ((Tools.GlobalParameters.EUnits)item.Tag == defaultUnits)
                {
                    SelectBox.SelectedItem = item;
                }
            }
            SelectBox.SelectionChanged += new SelectionChangedEventHandler(SelectBox_SelectionChanged);
        }

        /*
         * Method for update combo box with universal items
         */
        private void UpdateSelectBox(Enum @enum, object defaultValue)
        {
            foreach (var val in Enum.GetValues(@enum.GetType()))
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = TextManager.CreateStringFromEnumItem(val);
                newItem.Tag = val;
                SelectBox.Items.Add(newItem);
            }

            SelectBox.SelectedIndex = 0;
            foreach (ComboBoxItem item in SelectBox.Items)
            {
                if (item.Tag.ToString() == defaultValue.ToString())
                {
                    SelectBox.SelectedItem = item;
                }
            }
            SelectBox.SelectionChanged += new SelectionChangedEventHandler(SelectBox_SelectionChanged);
        }

        /*
         * Event handling when select item in combo box is changed
         */
        private void SelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)SelectBox.SelectedItem;
            var value = selectedItem.Tag;
            SelectItemChanged?.Invoke(this, value);
        }
        #endregion
    }
}
