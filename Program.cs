using System;
using System.IO;
using System.Runtime.Versioning;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using Transcriber.SpeechToText;
using Transcriber.SpeechDiarization;

#pragma warning disable CA1416

namespace Transcriber
{
    class Program
    {

        static async Task Main(string[] args)
        {
            useSimpleSpeechToText();
            await useSpeechDiarization();
        }

        static void useSimpleSpeechToText()
        {
            try
            {
                ISpeechRecognizerFactory recognizerCreator = new SpeechRecognizerFactory();
                var recognizer = recognizerCreator.CreateRecognizer();
                ISpeechRecognitionStrategy speechProcessor = new SpeechRecognitionStrategy(recognizer);
                speechProcessor.RecognizeSpeech(@"C:\Users\sarth\source\repos\Trasncriber\gettysburg10.wav");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in useSimpleSpeechToText: {ex.Message}");
            }
        }

        static async Task useSpeechDiarization()
        {
            try
            {
                ITranscriberCreator transcriberCreator = new ConversationTranscriberCreator();
                var transcriber = await transcriberCreator.CreateTranscriber("katiesteve.wav");

                ITranscriptionProcessor transcriptionProcessor = new ConversationTranscriptionProcessor(transcriber);
                await transcriptionProcessor.ProcessTranscription();

            }catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred in useSpeechDiarization: {ex.Message}");
            }
        }
    }
}


#pragma warning restore CA1416