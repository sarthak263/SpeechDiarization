using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using System.Threading.Tasks;

namespace Transcriber.SpeechToText
{
    internal interface ISpeechRecognizerFactory
    {
        SpeechRecognitionEngine CreateRecognizer();
    }
}
