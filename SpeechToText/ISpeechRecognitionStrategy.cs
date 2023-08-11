using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Transcriber.SpeechToText
{
    internal interface ISpeechRecognitionStrategy
    {
        Task<RecognitionResult> RecognizeSpeechAsync(string audioFilePath);
    }
}
