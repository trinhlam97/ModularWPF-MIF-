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

namespace QLGV_Module.Views
{
    /// <summary>
    /// Interaction logic for QLGV.xaml
    /// </summary>
    public partial class QLGV : UserControl
    {
        public QLGV()
        {
            InitializeComponent(); ShowDataLop();
            ShowDataGV();

        }
        List<Lop> dsLop = new List<Lop>();
        List<GiaoVien> dsgv = new List<GiaoVien>();
        private void ShowDataLop()
        {
            dsLop = DataLop();
            cbbLop.ItemsSource = dsLop;

        }
        public List<Lop> DataLop()
        {
            List<Lop> dsLop = new List<Lop>();
            dsLop.Add(new Lop() { Ma = "L1", Ten = "Lớp 1" });
            dsLop.Add(new Lop() { Ma = "L2", Ten = "Lớp 2" });
            dsLop.Add(new Lop() { Ma = "L3", Ten = "Lớp 3" });
            dsLop.Add(new Lop() { Ma = "L4", Ten = "Lớp 4" });
            dsLop.Add(new Lop() { Ma = "L5", Ten = "Lớp 5" });
            return dsLop;
        }

        private void ShowDataGV()
        {

            dsgv.Add(new GiaoVien() { MaGV = "GV001", TenGV = "Giáo Viên A", Lop = dsLop[0] });
            dsgv.Add(new GiaoVien() { MaGV = "GV002", TenGV = "Giáo Viên B", Lop = dsLop[1] });
            dsgv.Add(new GiaoVien() { MaGV = "GV003", TenGV = "Giáo Viên C", Lop = dsLop[2] });
            dsgv.Add(new GiaoVien() { MaGV = "GV004", TenGV = "Giáo Viên D", Lop = dsLop[3] });
            dsgv.Add(new GiaoVien() { MaGV = "GV005", TenGV = "Giáo Viên E", Lop = dsLop[4] });
            datagrid.ItemsSource = dsgv;

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
