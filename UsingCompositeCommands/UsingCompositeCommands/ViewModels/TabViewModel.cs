using System;
using System.Globalization;
using Prism.Commands;
using Prism.Navigation;

namespace UsingCompositeCommands.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        private string _lastSaved;

        public TabViewModel(INavigationService navigationService, IApplicationCommands applicationCommands) : base(navigationService)
        {
            applicationCommands.SaveCommand.RegisterCommand(SaveCommand);
            applicationCommands.ResetCommand.RegisterCommand(ResetCommand);
        }

        public string LastSaved
        {
            get => _lastSaved;
            set => SetProperty(ref _lastSaved, value);
        }

        public DelegateCommand SaveCommand => new DelegateCommand(Save);
        public DelegateCommand ResetCommand => new DelegateCommand(Reset);

        private void Save()
        {
            LastSaved = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        private void Reset()
        {
            LastSaved = "Reset - no value";
        }
    }
}