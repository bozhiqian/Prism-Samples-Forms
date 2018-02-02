using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using UsingEventAggregator.Models;
using UsingEventAggregator.Views;

namespace UsingEventAggregator.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        public HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator,
            IPageDialogService pageDialogService) : base(navigationService)
        {
            _eventAggregator = eventAggregator;

            Title = "Your Feedback (Read only)";

            _eventAggregator.GetEvent<IsFunChangedEvent>().Subscribe(IsFunChanged);
        }

        public void IsFunChanged(bool isFun)
        {
            IsFun = isFun;
        }

        #region Overrides

        public override void Destroy()
        {
            _eventAggregator.GetEvent<IsFunChangedEvent>().Unsubscribe(IsFunChanged);
        }

        #endregion

        #region Properties

        private bool _isFun;

        public bool IsFun
        {
            get => _isFun;
            set => SetProperty(ref _isFun, value);
        }

        #endregion

        #region Commands

        private ICommand _entryCommand;
        public ICommand EntryCommand => _entryCommand ?? (_entryCommand = new DelegateCommand(OnEntryCommandTapped));

        private async void OnEntryCommandTapped()
        {
            await NavigationService.NavigateAsync("NavigationPage/" + nameof(DataEntryPage));
        }

        private ICommand _goBackCommand;

        public ICommand GoBackCommand =>
            _goBackCommand ?? (_goBackCommand = new DelegateCommand(OnGoBackCommandTapped));

        private async void OnGoBackCommandTapped()
        {
            await NavigationService.GoBackAsync();
        }

        #endregion
    }
}