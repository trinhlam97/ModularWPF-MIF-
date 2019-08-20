using Common;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_Module.ViewModels
{
    public class QLGVModel
    {
        //Tiêu đề của Module
        public string Caption { get { return "Module Giáo Viên"; } }

        //Tạo Module
        public static QLGVModel Create()
        {
            return ViewModelSource.Create(() => new QLGVModel());
        }
        public QLGVModel() { }
    }
}
