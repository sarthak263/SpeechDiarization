﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcriber.SpeechDiarization
{
    internal interface ITranscriptionProcessor
    {
        Task ProcessTranscription();
    }
}
