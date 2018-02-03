using System;
using Prism.Events;
using Prism.Navigation;

namespace TabbedNavigation.ViewModels
{
    public class ViewBViewModel : ChildViewModelBase
    {
        public ViewBViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            Title = "View B";
        }
    }
}
