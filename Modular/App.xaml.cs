using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.ModuleInjection;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using Modular.Properties;

using QLGV_Module.ViewModels;
using QLGV_Module.Views;
using QLSV_Module.ViewModels;
using QLSV_Module.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Modular
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
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
    }
    public partial class Bootstrapper
    {
        public virtual void Run()
        {
            ConfigureTypeLocators();
            RegisterServices();
            ConfigureServices();
            RegisterModules();
            if (!Manager.Restore(Settings.Default.LogicalState, Settings.Default.VisualState))
                InjectModules();
            ConfigureNavigation();
            
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
        protected virtual void RegisterServices()
        {
            //var imageService = new ImageService();
            //var dataService = new DataService();
            //var projectService = ProjectService.Create(imageService);
            //ServiceContainer.Default.RegisterService(imageService);
            //ServiceContainer.Default.RegisterService(dataService);
            //ServiceContainer.Default.RegisterService(projectService);
        }
        protected virtual void ConfigureServices()
        {
            Manager.GetRegion(Region.WindowedDocuments).LogicalSerializationMode = LogicalSerializationMode.Disabled;
            //ServiceContainer.Default.GetService<IProjectService>().LoadProject();
        }
       
        protected virtual void InjectModules()
        {
            
            Manager.Inject(Region.LeftHost, Modules.GiaoVien);
            Manager.Inject(Region.RightHost, Modules.SinhVien);
            //Manager.Inject(Regions.RightHost, AppModules.Explorer);
            //Manager.Inject(Regions.RightHost, AppModules.Properties);
        }
        protected virtual void ConfigureNavigation()
        {
            //ServiceContainer.Default.GetService<IProjectService>().ProjectItemOpened += OnProjectItemOpened;
            //ServiceContainer.Default.GetService<IProjectService>().ProjectChanged += OnProjectChanged;
        }
        protected virtual void ShowMainWindow()
        {
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
            //App.Current.MainWindow.Closing += OnClosing;
        }

        //void OnProjectItemOpened(object sender, ProjectItemOpenedEventArgs e)
        //{
        //    var dataService = ServiceContainer.Default.GetService<IDataService>();
        //    if (e.Item.Type == ProjectItemType.File)
        //    {
        //        Manager.RegisterOrInjectOrNavigate(Regions.Documents, new Module(e.Item.ID.ToString(), () => CollectionViewModel.Create(e.Item.ID), typeof(CollectionView)));
        //    }
        //    else if (e.Item.Type == ProjectItemType.Designer)
        //    {
        //        Manager.RegisterOrInjectOrNavigate(Regions.Documents, new Module(e.Item.ID.ToString(), () => DesignerViewModel.Create(e.Item.ID), typeof(DesignerView)));
        //    }
        //}
        //void OnProjectChanged(object sender, ProjectChangedEventArgs e)
        //{
        //    if (e.OldProject != null)
        //    {
        //        Manager.Clear(Regions.Documents);
        //        Manager.Clear(Regions.WindowedDocuments);
        //    }
        //}
        //void OnClosing(object sender, CancelEventArgs e)
        //{
        //    string logicalState;
        //    string visualState;
        //    Manager.Save(out logicalState, out visualState);
        //    Settings.Default.LogicalState = logicalState;
        //    Settings.Default.VisualState = visualState;
        //    Settings.Default.Save();
        //    ServiceContainer.Default.GetService<IProjectService>().SaveProject();
        //    Manager.Clear(Regions.WindowedDocuments);
        //}
    }
}
