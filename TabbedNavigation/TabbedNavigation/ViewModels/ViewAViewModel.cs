using System;
using Prism.Events;
using Prism.Navigation;

namespace TabbedNavigation.ViewModels
{
    public class ViewAViewModel : ChildViewModelBase
    {
        public ViewAViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            Title = "View A";
        }
    }
}
