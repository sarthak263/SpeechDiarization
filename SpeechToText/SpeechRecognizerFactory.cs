using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Transcriber.SpeechToText
{
    internal class SpeechRecognizerFactory : ISpeechRecognizerFactory
    {
        public SpeechRecognitionEngine CreateRecognizer()
        {
            var recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            recognizer.LoadGrammar(new DictationGrammar());
            recognizer.SpeechRecognized += (s, e) => Console.WriteLine("Recognized text: " + e.Result.Text);
            return recognizer;
        }
    }
}
