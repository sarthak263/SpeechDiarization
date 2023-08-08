using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Transcriber.SpeechToText
{
    internal class SpeechRecognitionStrategy : ISpeechRecognitionStrategy
    {

        private readonly SpeechRecognitionEngine _recognizer;

        public SpeechRecognitionStrategy(SpeechRecognitionEngine recognizer)
        {
            _recognizer = recognizer;
        }

        public void RecognizeSpeech(string audioFilePath)
        {
            _recognizer.SetInputToWaveFile(audioFilePath);
            _recognizer.Recognize();
        }

    }
}
