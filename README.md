# ModularWPF-MIF-
TÍCH HỢP MODULE THEO MIF
-	Tạo project Main là WPF Application 
-	Tạo project ModuleGiaoVien là Class Library
-	Tạo project ModuleSinhVien là Class Library
-	Tạo project Common là Class Library

1.	Trong project Common 

Bước 1: Tạo Region.cs chứa các thuộc tính là vị trí hiển thị của các module

	public class Region
    {
        public static string MainWindow { get { return "MainWindow"; } }
        public static string LeftHost { get { return "LeftHost"; } }
        public static string RightHost { get { return "RightHost"; } }
        public static string Documents { get { return "Documents"; } }
        public static string WindowedDocuments { get { return "WindowedDocuments"; } }
        public static string DialogDocuments { get { return "DialogDocuments"; } }
}


Bước 2: Tạo Common.cs chứa từ khóa

	public class Modules
    {
        public static string Main { get { return "Main"; } }
        public static string GiaoVien { get { return "GiaoVien"; } }
        public static string SinhVien { get { return "SinhVien"; } }
}

2.	Trong project ModuleGiaoVien

Bước 3: Tạo 2 Folder Views và ViewModels

•	Trong Folder Views

		Bước 4: Tạo UserControl QLGV và thiết kế giao diện
    
	Bước 5: Add Reference… -> Projects ->Common
  
•	Trong Folder ViewModels

		Bước 6: Tạo QLGVModel.cs với nội dung sử dụng thư viện DevExpress.Mvvm.POCO
    
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
	
3.	Trong project ModuleSinhVien

Lặp lại các Bước 3 , 4, 5,6

4.	Trong Project Main 

Bước 7: Tạo Giao diện cho cửa số chính

Bước 8: Add Reference… -> Projects ->Common,ModuleGiaoVien,ModuleSinhVien
•	Trong Setting.Designer.cs 

	Bước 9: Kiểm tra giống với đoạn code dưới không, nếu giống thì không cần chỉnh sửa 
  
  
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LogicalState
        {
            get
            {
                return ((string)(this["LogicalState"]));
            }
            set
            {
                this["LogicalState"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string VisualState
        {
            get
            {
                return ((string)(this["VisualState"]));
            }
            set
            {
                this["VisualState"] = value;
            }
        }
    }


•	Trong App.xaml.cs

		Bước 10: Thêm đoạn code
    
		protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationThemeHelper.UpdateApplicationThemeName();
            new Bootstrapper().Run();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            ApplicationThemeHelper.SaveApplicationThemeName();
            base.OnExit(e);
        }

		Bước 11: Tạo lớp Bootstrapper

    public partial class Bootstrapper
    {
        public virtual void Run()
        {
            ConfigureTypeLocators();
           
            RegisterModules();
            if (!Manager.Restore(Settings.Default.LogicalState, Settings.Default.VisualState))
                InjectModules();
        }

        protected IModuleManager Manager { get { return ModuleManager.DefaultManager; } }

       
        protected virtual void ConfigureTypeLocators()
        {
            
            var moduleGVAssembly = typeof(QLGVModel).Assembly;
            var moduleSVAssembly = typeof(QLSVModel).Assembly;
            var assemblies = new[] { moduleGVAssembly, moduleSVAssembly };
            ViewModelLocator.Default = new ViewModelLocator(assemblies);
            ViewLocator.Default = new ViewLocator(assemblies);
        }
        protected virtual void RegisterModules()
        {
            
            Manager.Register(Region.LeftHost, new Module(Modules.GiaoVien, QLGVModel.Create, typeof(QLGV)));
            Manager.Register(Region.RightHost, new Module(Modules.SinhVien, QLSVModel.Create, typeof(QLSV)));
        }
       
       
       
        protected virtual void InjectModules()
        {
            
            Manager.Inject(Region.LeftHost, Modules.GiaoVien);
            Manager.Inject(Region.RightHost, Modules.SinhVien);
           
        }
      
     }

•	Trong trường hợp muốn mở Module thông qua Event:

ModuleManager.DefaultManager.Navigate(Region.[RightHost], Modules.[SinhVien]);

