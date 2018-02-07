﻿using Prism.Mvvm;
using Prism.Navigation;

namespace UsingModules.SampleModule.ViewModels
{
    public class SamplePageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        private string _parameter;

        public SamplePageViewModel()
        {
            Title = "Sample Page from a Prism module";
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Parameter
        {
            get => _parameter;
            set => SetProperty(ref _parameter, value);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated away from.
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated to.
            
            var parameterName = "par";
            if (parameters.ContainsKey(parameterName))
                Parameter = $"Navigation Parameters (name/value): {parameterName}/{(string) parameters[parameterName]}";
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //Called before the implementor has been navigated to - but not called when using 
            // device hardware or software back buttons.
        }
    }
}