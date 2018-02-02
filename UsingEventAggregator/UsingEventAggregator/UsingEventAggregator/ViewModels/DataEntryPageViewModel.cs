using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using UsingEventAggregator.Models;

namespace UsingEventAggregator.ViewModels
{
    public class DataEntryPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        private bool _isFun;

        private ICommand _submitCommand;

        public DataEntryPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService)
        {
            _eventAggregator = eventAggregator;

            Title = "So what do you think?";
        }

        public bool IsFun
        {
            get => _isFun;
            set
            {
                SetProperty(ref _isFun, value);
                _eventAggregator.GetEvent<IsFunChangedEvent>().Publish(value);
            }
        }

        public ICommand SubmitCommand => _submitCommand ?? (_submitCommand = new DelegateCommand(OnSubmitTapped));

        private async void OnSubmitTapped()
        {
            await NavigationService.GoBackAsync();
        }
    }
}