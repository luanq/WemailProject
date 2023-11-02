using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wemail.Controls.CustomControls
{
    public class MessageDialogControl : BindableBase,IDialogAware
    {
        private DelegateCommand _getMessageCommand;
        private DelegateCommand _cancelMessageCommand;
        private string _messageContent;

        public string MessageContent
        {
            get { return _messageContent; }
            set 
            { 
                _messageContent = value;
                //setProperty触发通知
                SetProperty<string>(ref _messageContent, value);
            }
        }
        public DelegateCommand GetMessageCommand
        {
            get => _getMessageCommand = new DelegateCommand(() =>
            {
                var parameter = new DialogParameters();
                parameter.Add("MessageContent", MessageContent);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK,parameter));
            });
        }
        public DelegateCommand CancelMessageCommand
        {
            get => _cancelMessageCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            });
        }

        public string Title => "sss";

        public event Action<IDialogResult> RequestClose;

        //允许关闭dialog
        public bool CanCloseDialog()
        {
            return true;
        }

        //关闭dialog时的操作
        public void OnDialogClosed()
        {
           
        }
        //dialog接收参数传递
        public void OnDialogOpened(IDialogParameters parameters)
        {
            var parameterContent = parameters.GetValue<string>("Value");

        }
    }
}
