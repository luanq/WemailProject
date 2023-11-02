using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wemail.Common.User;
using Wemail.Model;

namespace Wemail.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";

        //Region管理对象
        private IRegionManager _regionManager;
        private IModuleCatalog _moduleCatalog;
        private MainModel _currentModel;
        private ObservableCollection<MainModel> _modules;
        private IDialogService _dialogService;
        private DelegateCommand _loadModulesCommand;
        private DelegateCommand _loginCommand;
        private IUser _user;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ObservableCollection<MainModel> Modules
        {
            get => _modules ?? (_modules = new ObservableCollection<MainModel>());
        }

        public DelegateCommand LoadModulesCommand { get => _loadModulesCommand = new DelegateCommand(InitModules); }
        public DelegateCommand LoginCommand { get => _loginCommand = new DelegateCommand(LoginAtion); }
       
        public MainModel CurrentModel
        {
            get
            {
                return _currentModel;
            }

            set
            {
                _currentModel = value;
                Navigate(value);
            }
        }

        public MainWindowViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog,IDialogService dialogService,IUser user)
        {
            _dialogService = dialogService;
            _regionManager = regionManager;
            _moduleCatalog = moduleCatalog;
            _user = user;
        }

        private void LoginAtion()
        {
            _dialogService.ShowDialog("UserLoginView", (r) =>
            {
                var result = r.Result;
                if (result == ButtonResult.OK)
                {
                    var loginStatus = r.Parameters.GetValue<bool>("LoginStatus");
                    _user.SetUserLoginState(loginStatus);
                }
            });
        }

        private void InitModules()
        {
            var dirModuleCatalog = _moduleCatalog as DirectoryModuleCatalog;
            foreach (var module in dirModuleCatalog.Items)
            {
                var tempModule = module as ModuleInfo;
                switch (tempModule.ModuleName)
                {
                    case "Contact":
                        Modules.Add(new MainModel() { DisplayName = "联系人", Name = tempModule.ModuleName, IConPath = "/Wemail.Resource;component/imgs/contact_icon.png" });
                        break;
                    case "Schedule":
                        Modules.Add(new MainModel() { DisplayName = "规划", Name = tempModule.ModuleName, IConPath = "/Wemail.Resource;component/imgs/schedule_icon.png" });
                        break;
                    case "Mail":
                        Modules.Add(new MainModel() { DisplayName = "邮件", Name = tempModule.ModuleName, IConPath = "/Wemail.Resource;component/imgs/mail_icon.png" });
                        break;
                }
            }
        }
        private void Navigate(MainModel model)
        {
            var parameter = new NavigationParameters();
            parameter.Add($"{model.Name}", DateTime.Now.ToString());
            _regionManager.RequestNavigate("ContentRegion", $"{model.Name}View", parameter);
        }
    }
}
