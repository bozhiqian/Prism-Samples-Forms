using System.Collections.Generic;
using System.Diagnostics;
using Android.Speech.Tts;
using Java.Lang;
using UsingDependencyService.Droid.Services;
using UsingDependencyService.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechAndroid))]

namespace UsingDependencyService.Droid.Services
{
    public class TextToSpeechAndroid : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech _speaker;
        private string _toSpeak;

        #region IOnInitListener implementation

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");
                var p = new Dictionary<string, string>();
                _speaker.Speak(_toSpeak, QueueMode.Flush, p);
            }
            else
            {
                Debug.WriteLine("was quiet");
            }
        }

        #endregion

        public void Speak(string text)
        {
            var c = Forms.Context;
            _toSpeak = text;
            if (_speaker == null)
            {
                _speaker = new TextToSpeech(c, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                _speaker.Speak(_toSpeak, QueueMode.Flush, p);
                Debug.WriteLine("spoke " + _toSpeak);
            }
        }
    }
}