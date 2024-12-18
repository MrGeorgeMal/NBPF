﻿using NBPF.NBPFClasses;
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
    /// Логика взаимодействия для Page_Workspace.xaml
    /// </summary>
    public partial class Page_Workspace : Page
    {
        public Page_Workspace()
        {
            InitializeComponent();
        }

        /*
         * Method for update Workspace content
         */
        public void UpdateWorkspace(NBPFObject item)
        {
            WorkspaceGrid.Children.Clear();

            if (item != null && item.WorkspaceUserControl != null)
            {
                WorkspaceGrid.Children.Add(item.WorkspaceUserControl);
            }
        }

    }
}
