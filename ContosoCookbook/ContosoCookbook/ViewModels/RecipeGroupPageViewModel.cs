using Prism.Commands;
using ContosoCookbook.Business;
using Prism.Navigation;

namespace ContosoCookbook.ViewModels
{
	public class RecipeGroupPageViewModel : ViewModelBase
    {
        private RecipeGroup _recipeGroup;
        private DelegateCommand<Recipe> _recipeSelectedCommand;
        public RecipeGroupPageViewModel()
        {

        }

        public RecipeGroup RecipeGroup
        {
            get => _recipeGroup;
            set => SetProperty(ref _recipeGroup, value);
        }

        public DelegateCommand<Recipe> RecipeSelectedCommand => _recipeSelectedCommand ?? (_recipeSelectedCommand = new DelegateCommand<Recipe>(RecipeSelected));

        private async void RecipeSelected(Recipe recipe)
        {
            var p = new NavigationParameters { { "recipe", recipe } };

            await NavigationService.NavigateAsync("RecipePage", p);
        }
    }
}
