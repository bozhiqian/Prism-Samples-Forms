using Prism.Ioc;
using Prism.Modularity;
using UsingModules.SampleModule.ViewModels;
using UsingModules.SampleModule.Views;

namespace UsingModules.SampleModule
{
    public class SampleModuleModule : IModule
    {
        public void Initialize() { /* deprecated */ }

        public void OnInitialized()
        {

        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) // it will be called when this module is loaded.
        {
            containerRegistry.RegisterForNavigation<SamplePage, SamplePageViewModel>();
        }
    }
}
