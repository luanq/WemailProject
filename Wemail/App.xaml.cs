using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Reflection;
using System.Windows;
using Wemail.Common.User;
using Wemail.Contact;
using Wemail.Contact.Views;
using Wemail.Controls.CustomControls;
using Wemail.Controls.Views;
using Wemail.ViewModels;
using Wemail.Views;

namespace Wemail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        UserModel _user;
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册MessageDialog
            containerRegistry.RegisterDialog<MessageDialogView, MessageDialogControl>();
            containerRegistry.RegisterDialog<UserLoginView,UserLoginViewModel>();
            //注册实例
            _user = new UserModel();
            containerRegistry.RegisterInstance<IUser>(_user);

        }
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            
            base.ConfigureModuleCatalog(moduleCatalog);

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //new ConfigurationModuleCatalog()

            //指定模块加载方式为从文件夹中以反射发现并加载module(推荐用法)
            return new DirectoryModuleCatalog() { ModulePath = @".\Apps" };
        }
    }
}
