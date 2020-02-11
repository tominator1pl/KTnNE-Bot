using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class Recognizer
    {
        public static List<byte> longerAudioList;
        public static bool working = false;
        public static int recognizer = 1;
        GoogleSpeech googleSpeech;
        WindowsSpeech windowsSpeech;

        public Recognizer()
        {
            googleSpeech = new GoogleSpeech();
            windowsSpeech = new WindowsSpeech();
        }


        public static void SetContext(List<string> contexts)
        {
            switch (recognizer)
            {
                case 0:
                    GoogleSpeech.SetContext(contexts);
                    break;
                case 1:
                    WindowsSpeech.SetContext(contexts);
                    break;
            }
        }

        public string Recognize()
        {
            switch (recognizer)
            {
                case 0:
                    return googleSpeech.Recognize();
                case 1:
                    return windowsSpeech.Recognize();
            }
            return "ERROR recognizer1";
        }

    }
}
