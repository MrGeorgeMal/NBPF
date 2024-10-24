using NBPF.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NBPF.NBPFClasses
{
    public class NBPFObject
    {
        #region Event
        /*
         * Event for update Properties when userControls in NBPFObject is changed
         */
        public delegate void ObjectUpdatedEventHandler(NBPFObject sender);
        public event ObjectUpdatedEventHandler? ObjectUpdated;
        #endregion



        #region Public Member
        public string Name { get; set; } = "NBPFObject";
        public List<UserControl> userControls { get; set; } = new List<UserControl>();
        public UC_PanAndZoomCanvas? WorkspaceUserControl { get; set; }
        #endregion



        #region Constructor
        public NBPFObject() { SetupObject(); }

        public NBPFObject(string name) { Name = name; SetupObject(); }
        #endregion



        #region Protected Method
        /*
         * Method for setup NBPFObject
         */
        protected virtual void SetupObject() { }

        /*
         * Method for call Event ObjectUpdated
         */
        protected virtual void PropertiesNeedUpdate(NBPFObject sender)
        {
            if(ObjectUpdated != null)
            {
                ObjectUpdated(sender);
            }
        }

        protected void UpdateWorkspace(List<UIElement> elements)
        {
            if (WorkspaceUserControl != null)
            {
                foreach (UIElement element in elements)
                {
                    WorkspaceUserControl.Children.Add(element);
                    element.RenderTransform = WorkspaceUserControl.Transform;
                }
            }
        }
        #endregion
    }
}
