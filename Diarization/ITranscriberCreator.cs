using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Transcription;

namespace Transcriber.SpeechDiarization
{
    internal interface ITranscriberCreator
    {
        Task<ConversationTranscriber> CreateTranscriber(string audioFilePath);
    }
}
