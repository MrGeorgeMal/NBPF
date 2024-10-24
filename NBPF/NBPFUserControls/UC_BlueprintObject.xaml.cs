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

namespace NBPF.UserControls
{
    /// <summary>
    /// Interaction logic for UC_BlueprintObject.xaml
    /// </summary>
    public partial class UC_BlueprintObject : Canvas
    {
        protected delegate void BlueprintObjectChangedHandler(UC_BlueprintObject sender);
        event BlueprintObjectChangedHandler? BlueprintObjectChanged;



        public UC_BlueprintObject()
        {
            InitializeComponent();
        }



        protected virtual void UpdateBlueprintObject(UC_BlueprintObject sender)
        {
            if (BlueprintObjectChanged != null)
            {
                this.Children.Clear();
                Draw();
                BlueprintObjectChanged(sender);
            }
        }


        protected virtual void Draw() { }
    }
}
