using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Transcription;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcriber.SpeechDiarization
{
    public class ConversationTranscriberCreator : ITranscriberCreator
    {
        static string? speechKey = Environment.GetEnvironmentVariable("SPEECH_KEY");
        static string? speechRegion = Environment.GetEnvironmentVariable("SPEECH_REGION");

        public async Task<ConversationTranscriber> CreateTranscriber(string audioFilePath)
        {
            var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
            speechConfig.SpeechRecognitionLanguage = "en-US";

            var audioConfig = AudioConfig.FromWavFileInput(audioFilePath);
            var conversationTranscriber = new ConversationTranscriber(audioConfig);

            return await Task.FromResult(conversationTranscriber);
        }
    }
}
