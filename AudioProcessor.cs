using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Transcriber.SpeechDiarization;
using Transcriber.SpeechToText;

namespace Transcriber.SpeechProcessor
{
    public  class AudioProcessor
    {
        public async Task ProcessDiarizationFileAsync(string filePath)
        {
            await useSpeechDiarization(filePath);
        }

        public async Task ProcessSpeechToTextFileAsync(string filePath)
        {
            await useSimpleSpeechToText(filePath);
        }
        private async Task useSpeechDiarization(string filePath)
        {
            try
            {
                ITranscriberCreator transcriberCreator = new ConversationTranscriberCreator();
                var transcriber = await transcriberCreator.CreateTranscriber(filePath);

                ITranscriptionProcessor transcriptionProcessor = new ConversationTranscriptionProcessor(transcriber);
                await transcriptionProcessor.ProcessTranscription();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing {filePath}: {ex.Message}");
            }
        }

        private async Task useSimpleSpeechToText(string filePath)
        {
            try
            {
                ISpeechRecognizerFactory recognizerCreator = new SpeechRecognizerFactory();
                var recognizer = recognizerCreator.CreateRecognizer();
                ISpeechRecognitionStrategy speechProcessor = new SpeechRecognitionStrategy(recognizer);
                await speechProcessor.RecognizeSpeechAsync(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing {filePath}: {ex.Message}");
            }
        }
    }
}
