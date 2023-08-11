using System;
using System.IO;
using System.Runtime.Versioning;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using Transcriber.SpeechToText;
using Transcriber.SpeechDiarization;
using Transcriber.SpeechProcessor;

namespace Transcriber
{
    class Program
    {

        static async Task Main(string[] args)
        {
            //useSimpleSpeechToText();
            var files = new List<string>();
            files.Add(@"C:\Users\sarth\source\repos\Trasncriber\gettysburg10.wav");

            var audioProcessor = new AudioProcessor();

            // Process using the simple method
            var tasksSimple = files.Select(file => Task.Run(() => audioProcessor.ProcessSpeechToTextFileAsync(file))).ToList();

            // Process using speech diarization
            var tasksDiarization = files.Select(file => Task.Run(() => audioProcessor.ProcessDiarizationFileAsync(file))).ToList();
            
            //wait for all the tasks to compelete
            await Task.WhenAll(tasksSimple.Concat(tasksDiarization));
        }
        
    }
}
