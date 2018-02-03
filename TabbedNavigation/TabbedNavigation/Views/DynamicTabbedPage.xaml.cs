using Prism.Navigation;
using Xamarin.Forms;

namespace TabbedNavigation.Views
{
    public partial class DynamicTabbedPage : TabbedPage, INavigatingAware
    {
        public DynamicTabbedPage()
        {
            InitializeComponent();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{Title} OnNavigatingTo");
            var tabs = parameters.GetValues<string>("addTab");
            foreach (var name in tabs)
                AddChild(name, parameters);
        }

        private void AddChild(string name, NavigationParameters parameters)
        {
            Page page = null;
            switch (name)
            {
                case "ViewA":
                    page = new ViewA(); 
                    break;

                case "ViewB":
                    page = new ViewB(); 
                    break;

                case "ViewC":
                    page = new ViewC(); 
                    break;
            }

            (page as INavigatingAware)?.OnNavigatingTo(parameters);
            (page?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);

            Children.Add(page); // It might be better use Prism Module to do it. 
        }
    }
}
