using Common;
using DevExpress.Mvvm.ModuleInjection;
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

namespace Modular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnSinhVien_Click(object sender, RoutedEventArgs e)
        {
            ModuleManager.DefaultManager.Navigate(Region.RightHost, Modules.SinhVien);
        }

        private void mnGiaoVien_Click(object sender, RoutedEventArgs e)
        {
            
            ModuleManager.DefaultManager.Navigate(Region.LeftHost, Modules.GiaoVien);
        }
    }
}
