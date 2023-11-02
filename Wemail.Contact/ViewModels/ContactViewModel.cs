using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Wemail.Common.MVVM;
using Wemail.Common.User;
using Wemail.Contact.Models;
using Wemail.DAL;
using Wemail.DAL.DTOs;

namespace Wemail.Contact.ViewModels
{
    public class ContactViewModel : BindableBase,INavigationAware
    {

        private IDialogService _dialogService;
        private IUser _user;
        private ObservableCollection<ContactModel> _contacts;
        private string _message;
        private DelegateCommand _launchCommand;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public ObservableCollection<ContactModel> Contacts
        {
            get => _contacts ?? (_contacts = new ObservableCollection<ContactModel>());
        }

        public ContactViewModel(IDialogService dialogService,IUser user)
        {
            _dialogService = dialogService;
            _user = user;
        }
        public IView View { get; set; }
        public DelegateCommand LaunchCommand
        {
            get => _launchCommand ?? (new DelegateCommand(LaunchAction));
        }
        private void LaunchAction()
        {
            View.Launch();
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //true表示不创建新实例
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //导航离开当前页面时
            Debug.WriteLine("Leave");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //导航到当前页面前
            if (!_user.IsLogin())
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
                if (!_user.IsLogin()) return;
            }
            InitData();
          
        }


        private void InitData()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Contacts.Clear();
                var contactsDTO = HTTPHelper.GetContacts();
                Contacts.AddRange(ConvertToModel(contactsDTO));
            });
        }
        private List<ContactModel> ConvertToModel(List<ContactDTO> contacts)
        {
            List<ContactModel> result = new List<ContactModel>();
            contacts.ForEach(contact =>
            {
                result.Add(new ContactModel
                {
                    Name = contact.Name,
                    Age = contact.Age,
                    Mail = contact.Mail,
                    Phone = contact.Phone,
                });
            });
            return result;

        }
    }
}
