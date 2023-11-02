using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Wemail.DAL;

namespace Wemail.ViewModels
{
	public class UserLoginViewModel : BindableBase,IDialogAware
	{
        private string _account;
        private string _password;
        private DelegateCommand _loginCommand;
        private DelegateCommand _cancelCommand;

        public DelegateCommand LoginCommand
        {
            get => _loginCommand = new DelegateCommand(LoginAction);
        }
        public DelegateCommand CancelCommand
        {
            get => _cancelCommand = new DelegateCommand(CancelAction);
        }
        public string Account
        {
            get => _account;
            set { SetProperty(ref _account, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value);}
        }

        private void CancelAction()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        private void LoginAction()
        {
            var userDto = HTTPHelper.Login(Account, Password);

            if (userDto != null && !string.IsNullOrEmpty(userDto.Token))
            {
                var parameter = new DialogParameters();
                parameter.Add("LoginStatus", true);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameter));
            }
        }

        public UserLoginViewModel()
        {

        }

        public string Title => "登录";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
