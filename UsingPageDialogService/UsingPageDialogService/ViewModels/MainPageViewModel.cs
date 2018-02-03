using System.Diagnostics;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace UsingPageDialogService.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService _pageDialogService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(
            navigationService)
        {
            Title = "Main Page";

            _pageDialogService = pageDialogService;

            DisplayAlertCommand = new DelegateCommand(DisplayAlert);
            DisplayActionSheetCommand = new DelegateCommand(DsiplayActionSheet);
            DisplayActionSheetUsingActionSheetButtonsCommand = new DelegateCommand(DisplayActionSheetUsingActionSheetButtons);
        }

        public DelegateCommand DisplayAlertCommand { get; set; }
        public DelegateCommand DisplayActionSheetCommand { get; set; }

        public DelegateCommand DisplayActionSheetUsingActionSheetButtonsCommand { get; set; }

        private async void DisplayAlert()
        {
            var result = await _pageDialogService.DisplayAlertAsync("Alert", "This is an alert from MainPageViewModel.", "Accept", "Cancel");
            Debug.WriteLine(result);
        }

        private async void DsiplayActionSheet()
        {
            var result = await _pageDialogService.DisplayActionSheetAsync("ActionSheet", "Cancel", "Destroy", "Option 1", "Option 2");
            Debug.WriteLine(result);
        }

        private async void DisplayActionSheetUsingActionSheetButtons()
        {
            var option1Action = ActionSheetButton.CreateButton("Option 1", new DelegateCommand(() => { Debug.WriteLine("Option 1"); }));
            var option2Action = ActionSheetButton.CreateButton("Option 2", new DelegateCommand(() => { Debug.WriteLine("Option 2"); }));
            var cancelAction = ActionSheetButton.CreateCancelButton("Cancel", new DelegateCommand(() => { Debug.WriteLine("Cancel"); }));
            var destroyAction = ActionSheetButton.CreateDestroyButton("Destroy", new DelegateCommand(() => { Debug.WriteLine("Destroy"); }));

            await _pageDialogService.DisplayActionSheetAsync("ActionSheet with ActionSheetButtons", option1Action, option2Action, cancelAction, destroyAction);
        }
    }
}