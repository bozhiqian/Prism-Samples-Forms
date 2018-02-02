using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Prism.Events;
using UsingEventAggregator.Models;

namespace UsingEventAggregator.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService)
        {
            _eventAggregator = eventAggregator;


            Title = "Prism.Forms EventAggregator";
        }

        #region Commands

        private ICommand _localCommand;
        public ICommand LocalCommand => _localCommand ?? (_localCommand = new DelegateCommand(OnLocalCommandTapped));

        private async void OnLocalCommandTapped()
        {
           await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        private ICommand _nativeCommand;

        public ICommand NativeCommand =>
            _nativeCommand ?? (_nativeCommand = new DelegateCommand(OnNativeCommandTapped));

        private void OnNativeCommandTapped()
        {
            _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Xamarin.Forms"));
        }

        #endregion
    }
}
