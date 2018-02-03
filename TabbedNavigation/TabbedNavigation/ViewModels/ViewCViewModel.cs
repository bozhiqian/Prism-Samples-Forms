using System;
using Prism.Events;
using Prism.Navigation;

namespace TabbedNavigation.ViewModels
{
    public class ViewCViewModel : ChildViewModelBase
    {
        public ViewCViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            Title = "View C";
        }
    }
}
