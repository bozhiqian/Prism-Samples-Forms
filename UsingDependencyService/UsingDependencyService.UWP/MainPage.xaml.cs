using Prism;
using Prism.Ioc;
using UsingDependencyService.Services;
using UsingDependencyService.UWP.Services;

namespace UsingDependencyService.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new UsingDependencyService.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterSingleton<ITextToSpeech, TextToSpeech_UWP>();
        }
    }
}