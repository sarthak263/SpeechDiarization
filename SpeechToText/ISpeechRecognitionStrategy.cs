using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcriber.SpeechToText
{
    internal interface ISpeechRecognitionStrategy
    {
        void RecognizeSpeech(string audioFilePath);
    }
}
