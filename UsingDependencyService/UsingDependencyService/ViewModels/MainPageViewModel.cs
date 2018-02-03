using Prism.Commands;
using Prism.Navigation;
using UsingDependencyService.Services;

namespace UsingDependencyService.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ITextToSpeech _textToSpeech;
        private string _textToSay = "Hello from Xamarin Forms and Prism.";

        public MainPageViewModel(INavigationService navigationService, ITextToSpeech textToSpeech) : base(navigationService)
        {
            Title = "Main Page";
            _textToSpeech = textToSpeech;
            SpeakCommand = new DelegateCommand(Speak);
        }

        public string TextToSay
        {
            get => _textToSay;
            set => SetProperty(ref _textToSay, value);
        }

        public DelegateCommand SpeakCommand { get; set; }

        private void Speak()
        {
            _textToSpeech.Speak(TextToSay);
        }
    }
}