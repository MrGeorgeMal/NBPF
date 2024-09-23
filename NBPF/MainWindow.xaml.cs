using NBPF.Analysis;
using NBPF.NBPFClasses;
using NBPF.ViewModels;
using System.Diagnostics;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Analysis.StripStructure strip1;
        Analysis.GridMethod gridMethod1;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.ViewModel_ContentManager();

            strip1 = new Analysis.StripStructure();
            strip1.e1 = 1;
            strip1.e2 = 4.5;
            strip1.e3 = 3.0;
            strip1.e4 = 1;
            strip1.a = 24;
            strip1.h1 = 5;
            strip1.h2 = 1.5;
            strip1.h3 = 0.5;
            strip1.h4 = 8;
            strip1.w1 = 0.5;
            strip1.w2 = 2.3;
            strip1.d = 0;
            strip1.minSize = 0.5;

            gridMethod1= new Analysis.GridMethod(strip1);
            gridMethod1.NLowSize = 5;


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            gridMethod1.Calculation(1,1,false);

            ViewModels.ViewModel_ContentManager viewModel = (ViewModels.ViewModel_ContentManager)this.DataContext;

            for (int j = 0; j < gridMethod1.J; j++)
            {
                RowDefinition newRow = new RowDefinition();
                newRow.Height = new GridLength(20);
                viewModel.PageFrame2.grid.RowDefinitions.Add(newRow);
            }
            for (int i = 0; i < gridMethod1.I; i++)
            {
                ColumnDefinition newCol = new ColumnDefinition();
                newCol.Width = new GridLength(20);
                viewModel.PageFrame2.grid.ColumnDefinitions.Add(newCol);
            }

            
            for (int j = 0; j < gridMethod1.J; j++)
            {
                for (int i = 0; i < gridMethod1.I; i++)
                {
                    TextBlock newLable = new TextBlock();
                    newLable.Text = gridMethod1.field[j][i].ToString();
                    Grid.SetRow(newLable, j);
                    Grid.SetColumn(newLable, i);
                    viewModel.PageFrame2.grid.Children.Add(newLable);
                }
            }
            
        }
    }
}