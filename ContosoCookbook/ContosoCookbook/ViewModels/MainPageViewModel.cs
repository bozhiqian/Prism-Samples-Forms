using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContosoCookbook.Business;
using ContosoCookbook.Services;
using Prism.Navigation;

namespace ContosoCookbook.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<RecipeGroup> _recipeGroups;
        private readonly IRecipeService _recipeService;

        public MainPageViewModel(INavigationService navigationService, IRecipeService recipeService) : base(navigationService)
        {
            Title = "Contoso Cookbook";
            _recipeService = recipeService;
        }

        public ObservableCollection<RecipeGroup> RecipeGroups
        {
            get => _recipeGroups;
            set => SetProperty(ref _recipeGroups, value);
        }

        public async Task LoadRecipeGroups()
        {
            if (RecipeGroups == null)
            {
                var recipeGroups = await _recipeService.GetRecipeGroups();
                RecipeGroups = new ObservableCollection<RecipeGroup>(recipeGroups);
            }
        }
    }
}