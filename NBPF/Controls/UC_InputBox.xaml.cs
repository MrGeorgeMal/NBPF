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
    /// Interaction logic for UC_InputBox.xaml
    /// </summary>
    public partial class UC_InputBox : UserControl
    {
        public delegate void ValueChangedHandler(UC_InputBox sender, double value);
        public event ValueChangedHandler? ValueChanged;

        private string bufferValue;
        public UC_InputBox(string defaultValue)
        {
            InitializeComponent();

            Value.LostFocus += new RoutedEventHandler(TextInputed);
            Value.KeyUp += new KeyEventHandler(EnterPressed);
            Value.GotFocus += new RoutedEventHandler(TextFocused);

            Value.Text = defaultValue;
            bufferValue = Value.Text;
        }

        public void TextFocused(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            bufferValue = textBox.Text;
        }

        public void TextInputed(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (Tools.TextManager.IsNumber(textBox.Text))
            {
                double value = TextManager.ToNumber(textBox.Text);
                ValueChanged?.Invoke(this, value);
            }
            else
            {
                textBox.Text = bufferValue;
            }
        }

        public void EnterPressed(object sender, KeyEventArgs e)
        {
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
    }
}
