using Microsoft.CognitiveServices.Speech.Transcription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;


namespace Transcriber.SpeechDiarization
{
    internal class ConversationTranscriptionProcessor : ITranscriptionProcessor
    {
        private readonly ConversationTranscriber _transcriber;
        private readonly TaskCompletionSource<int> _stopRecognition = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

        public ConversationTranscriptionProcessor(ConversationTranscriber transcriber)
        {
            _transcriber = transcriber;
            SetupTranscriberEvents();
        }

        public async Task ProcessTranscription()
        {
            await _transcriber.StartTranscribingAsync();
            Task.WaitAny(new[] { _stopRecognition.Task });
            await _transcriber.StopTranscribingAsync();
        }

        private void SetupTranscriberEvents()
        {
            _transcriber.Transcribing += (s, e) =>
            {
                Console.WriteLine($"TRANSCRIBING: Text={e.Result.Text}");
            };

            _transcriber.Transcribed += (s, e) =>
            {
                if (e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"TRANSCRIBED: Text={e.Result.Text} Speaker ID={e.Result.ResultId}");
                }
                else if (e.Result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be transcribed.");
                }
            };

            _transcriber.Canceled += (s, e) =>
            {
                Console.WriteLine($"CANCELED: Reason={e.Reason}");

                if (e.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                    Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                    _stopRecognition.TrySetResult(0);
                }

                _stopRecognition.TrySetResult(0);
            };

            _transcriber.SessionStopped += (s, e) =>
            {
                Console.WriteLine("\n    Session stopped event.");
                _stopRecognition.TrySetResult(0);
            };
        }
    }
}
