using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class TextSynthesizer
    {
        static SpeechSynthesizer synthesizer;

        public TextSynthesizer()
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoice("Microsoft David Desktop");

        }

        public static void Speak(string text)
        {
            synthesizer.SpeakAsync(text);
        }

        public static void Stop()
        {
            synthesizer.SpeakAsyncCancelAll();
        }

        public void Close()
        {
            synthesizer.Dispose();
        }
    }
}
