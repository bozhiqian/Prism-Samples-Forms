using System.Collections.Generic;
using Prism.Commands;
using Prism.Navigation;

namespace TabbedNavigation.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _showViewA;
        private bool _showViewB;
        private bool _showViewC;

        public MainPageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Main Page";
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
            LaunchDynamicTabbedPageCommand = new DelegateCommand(OnLaunchDynamicTabbedPageCommandExecuted);
        }

        public bool ShowViewA
        {
            get => _showViewA;
            set => SetProperty(ref _showViewA, value);
        }

        public bool ShowViewB
        {
            get => _showViewB;
            set => SetProperty(ref _showViewB, value);
        }

        public bool ShowViewC
        {
            get => _showViewC;
            set => SetProperty(ref _showViewC, value);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        public DelegateCommand LaunchDynamicTabbedPageCommand { get; }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            base.OnNavigatedTo(parameters);
        }

        private async void OnNavigateCommandExecuted(string path) // path="NavigatingAwareTabbedPage?message=Hello%20from%20MainPage"
        {
            await NavigationService.NavigateAsync(path);
        }

        private async void OnLaunchDynamicTabbedPageCommandExecuted()
        {
            var path = "DynamicTabbedPage";
            var children = new List<string>();
            if (ShowViewA)
                children.Add("addTab=ViewA");

            if (ShowViewB)
                children.Add("addTab=ViewB");

            if (ShowViewC)
                children.Add("addTab=ViewC");

            if (children.Count > 0)
                path += "?" + string.Join("&", children);

            await NavigationService.NavigateAsync(path);
        }
    }
}