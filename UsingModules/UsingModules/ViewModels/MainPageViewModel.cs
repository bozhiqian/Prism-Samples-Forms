using System;
using Prism.Commands;
using Prism.Modularity;
using Prism.Navigation;

namespace UsingModules.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IModuleManager _moduleManager;
        private bool _isSampleModuleRegistered;
        private string _subTitle;

        public MainPageViewModel(INavigationService navigationService, IModuleManager moduleManager) : base(navigationService)
        {
            Title = "Main Page";

            _moduleManager = moduleManager;

            LoadSampleModuleCommand = new DelegateCommand(LoadSampleModule, () => !IsSampleModuleRegistered)
                .ObservesProperty(() => IsSampleModuleRegistered);
            NavigateToSamplePageCommand = new DelegateCommand(NavigateToSamplePage, () => IsSampleModuleRegistered)
                .ObservesProperty(() => IsSampleModuleRegistered);
        }

        public string SubTitle
        {
            get => _subTitle;
            set => SetProperty(ref _subTitle, value);
        }

        public bool IsSampleModuleRegistered
        {
            get => _isSampleModuleRegistered;
            set => SetProperty(ref _isSampleModuleRegistered, value);
        }

        public DelegateCommand LoadSampleModuleCommand { get; set; }

        public DelegateCommand NavigateToSamplePageCommand { get; set; }

        private async void NavigateToSamplePage()
        {
            await NavigationService.NavigateAsync("NavigationPage/SamplePage?par=test");
        }

        private void LoadSampleModule()
        {
            try
            {
                _moduleManager.LoadModule("SampleModuleModule");
                
                IsSampleModuleRegistered = true;
            }
            catch (Exception e)
            {

            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated to.
            if (parameters.ContainsKey("title"))
                SubTitle = (string)parameters["title"] + " and Prism";
        }
    }
}