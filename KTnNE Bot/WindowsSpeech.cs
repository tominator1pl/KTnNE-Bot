using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.IO;

namespace KTnNE_Bot
{
    class WindowsSpeech
    {
        
        public static SpeechRecognitionEngine speechRecognizer;
        SpeechAudioFormatInfo formatInfo;

        public WindowsSpeech()
        {
            speechRecognizer = new SpeechRecognitionEngine();
            Grammar grammar = new Grammar(new GrammarBuilder("one two"));
            speechRecognizer.LoadGrammar(grammar);
            formatInfo = new SpeechAudioFormatInfo(16000, AudioBitsPerSample.Sixteen, AudioChannel.Mono);
            
            speechRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognizedHandler);
        }

        static void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                Console.WriteLine("Recognition result = {0}", e.Result.Text ?? "<no text>");
            }
            else
            {
                Console.WriteLine("No recognition result");
            }
        }

        public static void SetContext(List<string> contexts, int min, int max)
        {
            speechRecognizer.UnloadAllGrammars();
            GrammarBuilder grammarBuilder = new GrammarBuilder(new Choices(contexts.ToArray()));
            Grammar grammar = new Grammar(new GrammarBuilder(grammarBuilder,min,max));
            speechRecognizer.LoadGrammar(grammar);
            Grammar grammar1 = new Grammar(new GrammarBuilder("strike"));
            speechRecognizer.LoadGrammar(grammar1);
        }
        public string Recognize()
        {
            Stream stream;
            try
            {
                stream = new MemoryStream(Recognizer.longerAudioList.ToArray());
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            
            speechRecognizer.SetInputToAudioStream(stream, formatInfo);
            RecognitionResult res = speechRecognizer.Recognize();
            try
            {
                return res.Text;
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
        }

        public static void Close()
        {
            speechRecognizer.Dispose();
        }
    }
}
