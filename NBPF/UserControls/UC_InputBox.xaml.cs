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
    public partial class UC_InputBox : UserControl
    {
        #region Event
        /*
         * Event triggered when the value in the TextBox changes
         */
        public delegate void ValueChangedHandler(UC_InputBox sender, double value);
        public event ValueChangedHandler? ValueChanged;
        #endregion



        #region Private Member
        private string _bufferValue; //Stores the last valid value
        #endregion



        #region Constructor
        public UC_InputBox(string defaultValue = "0")
        {
            InitializeComponent();

            Value.LostFocus += new RoutedEventHandler(Value_LostFocus);
            Value.KeyUp += new KeyEventHandler(Value_EnterPressed);
            Value.GotFocus += new RoutedEventHandler(Value_Focused);

            Value.Text = defaultValue;
            _bufferValue = Value.Text;
        }
        #endregion



        #region Private Method
        /*
         * Event handling when TextBox is focused
         */
        private void Value_Focused(object sender, RoutedEventArgs e)
        {
            // Storing the last valid value
            TextBox textBox = (TextBox)sender;
            _bufferValue = textBox.Text;
        }

        /*
         * Event handling when Key (Enter) is released
         */
        private void Value_EnterPressed(object sender, KeyEventArgs e)
        {
            // Focus loss from TextBox when pressing Enter
            if (e.Key == Key.Enter)
            {
                TextBox textBox = (TextBox)sender;
                FrameworkElement parent = (FrameworkElement)textBox.Parent;
                while (parent != null && parent is IInputElement && !((IInputElement)parent).Focusable)
                {
                    parent = (FrameworkElement)parent.Parent;
                }
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(textBox), parent as IInputElement);
            }
        }

        /*
         * Event handling when TextBox is inputted (lost focus or Enter pressed)
         */
        private void Value_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (Tools.TextManager.IsNumber(textBox.Text))
            {
                double value = TextManager.ToNumber(textBox.Text);
                ValueChanged?.Invoke(this, value);
            }
            else
            {
                textBox.Text = _bufferValue;
            }
        }
        #endregion
    }
}
