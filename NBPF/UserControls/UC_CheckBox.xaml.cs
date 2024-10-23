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

namespace NBPF.UserControls
{
    /// <summary>
    /// Interaction logic for UC_CheckBox.xaml
    /// </summary>
    public partial class UC_CheckBox : UserControl
    {
        #region Event
        /*
         * Event on Flag value change
         */
        public delegate void ValueChangedHandler(UC_CheckBox sender, bool value);
        public event ValueChangedHandler? ValueChanged;
        #endregion



        #region Constructor
        public UC_CheckBox(bool defaultValue)
        {
            InitializeComponent();
            Flag.IsChecked = defaultValue;
            Flag.Click += new RoutedEventHandler(Flag_Checked);
        }
        #endregion



        #region Private Method
        /*
         * Event handling when Flag value changed
         */
        private void Flag_Checked(object sender, RoutedEventArgs e)
        {
            if (Flag.IsChecked == null) return;
            ValueChanged?.Invoke(this, Flag.IsChecked.Value);
        }
        #endregion
    }
}
