using Prism.Mvvm;
using Prism.Navigation;

namespace UsingEventAggregator.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string _title;

        public ViewModelBase(INavigationService navigationService)
        {
            if (NavigationService == null)
            {
                NavigationService = navigationService;
            }
        }

        protected static INavigationService NavigationService { get; set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public virtual void Destroy()
        {
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}