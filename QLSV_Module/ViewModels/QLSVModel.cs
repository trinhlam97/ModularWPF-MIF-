using Common;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_Module.ViewModels
{
    public class QLSVModel
    {
        public string Caption { get { return "Module Sinh Viên"; } }
        public virtual bool IsActive { get; set; }

        public static QLSVModel Create()
        {
            return ViewModelSource.Create(() => new QLSVModel());
        }
        protected QLSVModel() { }
      
    }
}
