using NBPF.NBPFClasses;
using NBPF.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBPF
{
    public partial class MainWindow : Window
    {
        private VM_ContentManager _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new VM_ContentManager();
            this.DataContext = _viewModel;
            BtnStartAnalysis.Click += new RoutedEventHandler(StartAnalysis_Clicked);
        }

        private void StartAnalysis_Clicked(object sender, RoutedEventArgs e)
        {
            _viewModel.StartAnalysis();
        }
    }
}