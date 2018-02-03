using System;
using System.Diagnostics;
using Prism;
using Prism.Events;
using Prism.Navigation;
using TabbedNavigation.Events;

namespace TabbedNavigation.ViewModels
{
    public class ChildViewModelBase : ViewModelBase, IActiveAware //, INavigatingAware, IDestructible
    {
        private readonly IEventAggregator _ea;
        private bool _isActive;
        private string _message;

        public ChildViewModelBase(IEventAggregator eventAggregator) 
        {
            _ea = eventAggregator;
            _ea.GetEvent<InitializeTabbedChildrenEvent>().Subscribe(OnInitializationEventFired);

            IsActiveChanged += (sender, e) => Debug.WriteLine($"{Title} IsActive: {IsActive}");
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public event EventHandler IsActiveChanged;

        public bool IsActive
        {
            get => _isActive;
            set { SetProperty(ref _isActive, value, () => Debug.WriteLine($"{Title} IsActive Changed: {value}")); }
        }

        private void OnInitializationEventFired(NavigationParameters parameters)
        {
            Debug.WriteLine($"{Title} Detected an initialization event");
            var message = parameters.GetValue<string>("message");
            Message = $"{Title} Initialized by Event: {message}";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"{Title} is executing OnNavigatingTo");
            var message = parameters.GetValue<string>("message");
            Message = $"{Title} Initialized by OnNavigatingTo: {message}";
        }

        public override void Destroy()
        {
            Debug.WriteLine($"{Title} is being Destroyed!");
            _ea.GetEvent<InitializeTabbedChildrenEvent>().Unsubscribe(OnInitializationEventFired);
        }
    }
}