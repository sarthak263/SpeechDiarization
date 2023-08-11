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

        public Task<RecognitionResult> RecognizeSpeechAsync(string audioFilePath)
        {
            _recognizer.SetInputToWaveFile(audioFilePath);

            var tcs = new TaskCompletionSource<RecognitionResult>();

            _recognizer.RecognizeCompleted += (s, e) =>
            {
                if (e.Error != null) tcs.SetException(e.Error);
                else if (e.Cancelled) tcs.SetCanceled();
                else tcs.SetResult(e.Result);
            };

            _recognizer.RecognizeAsync(RecognizeMode.Single);
            

            return tcs.Task;
        }

    }
}
