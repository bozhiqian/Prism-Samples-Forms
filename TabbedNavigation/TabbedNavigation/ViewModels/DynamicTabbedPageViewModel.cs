using System;
using System.ComponentModel;
using Prism.Ioc;
using Prism.Navigation;

namespace TabbedNavigation.ViewModels
{
    public class DynamicTabbedPageViewModel : ViewModelBase
    {
        public DynamicTabbedPageViewModel() 
        {
            Title = "Dynamic Tabbed Page";
        }

        //public IContainerProvider Container { get; }
        //public override void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    System.Diagnostics.Debug.WriteLine($"{Title} OnNavigatingTo");
        //    var tabs = parameters.GetValues<string>("addTab");
        //    foreach (var name in tabs)
        //        AddChild(name, parameters);

        //    base.OnNavigatedTo(parameters);
        //}

    }
}
