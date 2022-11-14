using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace Dialogs.ViewModels
{
    public class SettingsDialogViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _title = "Notification";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public SettingsDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public event Action<IDialogResult> RequestClose;

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.OK;

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }
    }
}