﻿using Prism;
using Prism.Ioc;
using UsingCompositeCommands.ViewModels;
using UsingCompositeCommands.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Unity.Lifetime;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UsingCompositeCommands
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<TabA, TabViewModel>();
            containerRegistry.RegisterForNavigation<TabB, TabViewModel>();
            containerRegistry.RegisterForNavigation<TabC, TabViewModel>();

            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>(); 
        }
    }
}
