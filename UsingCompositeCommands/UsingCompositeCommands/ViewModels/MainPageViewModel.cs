using Prism.Navigation;

namespace UsingCompositeCommands.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IApplicationCommands _applicationCommand;

        public MainPageViewModel(INavigationService navigationService, IApplicationCommands applicationCommands) : base(navigationService)
        {
            Title = "Main Page";
            ApplicationCommands = applicationCommands;
        }

        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommand;
            set => SetProperty(ref _applicationCommand, value);
        }
    }
}