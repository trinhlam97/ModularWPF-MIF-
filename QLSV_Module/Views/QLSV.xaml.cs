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

namespace QLSV_Module.Views
{
    /// <summary>
    /// Interaction logic for QLSV.xaml
    /// </summary>
    public partial class QLSV : UserControl
    {
        public QLSV()
        {
            InitializeComponent();
            ShowDataLop();
            ShowDataSV();

        }
        List<Lop> dsLop = new List<Lop>();
        List<SinhVien> dsSV = new List<SinhVien>();
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

        private void ShowDataSV()
        {

            dsSV.Add(new SinhVien() { MSSV = "SV001", TenSV = "Giáo Viên A", Lop = dsLop[0] });
            dsSV.Add(new SinhVien() { MSSV = "SV002", TenSV = "Giáo Viên B", Lop = dsLop[1] });
            dsSV.Add(new SinhVien() { MSSV = "SV003", TenSV = "Giáo Viên C", Lop = dsLop[2] });
            dsSV.Add(new SinhVien() { MSSV = "SV004", TenSV = "Giáo Viên D", Lop = dsLop[3] });
            dsSV.Add(new SinhVien() { MSSV = "SV005", TenSV = "Giáo Viên E", Lop = dsLop[4] });
            datagrid.ItemsSource = dsSV;

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
