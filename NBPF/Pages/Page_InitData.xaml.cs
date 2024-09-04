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
    /// Логика взаимодействия для Page_InitData.xaml
    /// </summary>
    public partial class Page_InitData : Page
    {
        public Page_InitData()
        {
            InitializeComponent();
            f0.Description.Text = "Центральная частота f0";
            df.Description.Text = "Погрешность синтеза \u0394f";
            Bandwidth.Description.Text = "Ширина полосы пропускания";
            StripStructure.Description.Text = "Полосковая структура";
            FilterStructure.Description.Text = "Структура фильтра";

            StripStructure.SelectBox.Items.Add("Пользовательский");
            StripStructure.SelectBox.Items.Add("Полосковая линия");
            StripStructure.SelectBox.Items.Add("Связанные полосковые линии");
            StripStructure.SelectBox.Items.Add("Связанные полосковые линии с вертикальной подложкой");

            FilterStructure.SelectBox.Items.Add("Пользовательский");
            FilterStructure.SelectBox.Items.Add("PRLC");
            FilterStructure.SelectBox.Items.Add("SRLC");
            FilterStructure.SelectBox.Items.Add("SR PLC");
            FilterStructure.SelectBox.Items.Add("PR SLC");
        }
    }
}
