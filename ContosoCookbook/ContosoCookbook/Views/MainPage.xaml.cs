using System.Linq;
using ContosoCookbook.Business;
using ContosoCookbook.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;

namespace ContosoCookbook.Views
{
    public partial class MainPage : TabbedPage, INavigatingAware
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPageViewModel ViewModel => (MainPageViewModel)BindingContext;
        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            if (ViewModel != null)
            {
                if (ViewModel.RecipeGroups == null)
                {
                    await ViewModel.LoadRecipeGroups();
                }

                if (ViewModel.RecipeGroups.Any())
                {
                    foreach (var recipeGroup in ViewModel.RecipeGroups)
                    {
                        AddChild(recipeGroup, parameters);
                    }
                }
                else
                {
                    AddChild(null, parameters); // Tabbed page needs at least one tab page otherwise exception will be thrown.
                }
            }

        }

        private void AddChild(RecipeGroup recipeGroup, NavigationParameters parameters)
        {
            Page page = new RecipeGroupPage();
            page.Title = recipeGroup != null ? recipeGroup.Title : "No data";
            if (page.BindingContext is RecipeGroupPageViewModel viewModel)
            {
                viewModel.RecipeGroup = recipeGroup;
            }

            Children.Add(page); // It might be better use Prism Module to do it. 
        }
    }
}