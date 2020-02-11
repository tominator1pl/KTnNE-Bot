using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class SequentialWires : Module
    {
        int reds;
        int blues;
        int blacks;
        public SequentialWires()
        {
            TextSynthesizer.Speak("Sequential wires ok wire");
            Recognizer.SetContext(new List<string> { "blue", "red", "black", "ay", "be", "see"}, 2, 2);
            reds = 0;
            blues = 0;
            blacks = 0;
        }

        public override void Interpret(string text)
        {
            List<string> longText = text.Split(' ').ToList();
            if(longText.Count != 2)
            {
                TextSynthesizer.Speak("again");
                return;
            }
            if (!(new List<string> { "blue", "red", "black" }.Any(longText[0].Contains)))
            {
                TextSynthesizer.Speak("again");
                return;
            }
            if (!(new List<string> { "ay", "be", "see" }.Any(longText[1].Contains)))
            {
                TextSynthesizer.Speak("again");
                return;
            }
            if(longText[0] == "red")
            {
                reds++;
                switch (reds)
                {
                    case 1:
                        if (longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 2:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 3:
                        if (longText[1] == "ay") Cut(); else DontCut();
                        break;
                    case 4:
                        if (longText[1] == "ay" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 5:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 6:
                        if (longText[1] == "ay" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 7:
                        Cut();
                        break;
                    case 8:
                        if (longText[1] == "ay" || longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 9:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                }
            }
            if (longText[0] == "blue")
            {
                blues++;
                switch (blues)
                {
                    case 1:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 2:
                        if (longText[1] == "ay" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 3:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 4:
                        if (longText[1] == "ay") Cut(); else DontCut();
                        break;
                    case 5:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 6:
                        if (longText[1] == "by" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 7:
                        if (longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 8:
                        if (longText[1] == "ay" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 9:
                        if (longText[1] == "ay") Cut(); else DontCut();
                        break;
                }
            }
            if (longText[0] == "black")
            {
                blacks++;
                switch (blacks)
                {
                    case 1:
                        Cut();
                        break;
                    case 2:
                        if (longText[1] == "ay" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 3:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 4:
                        if (longText[1] == "ay" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 5:
                        if (longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 6:
                        if (longText[1] == "be" || longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 7:
                        if (longText[1] == "ay" || longText[1] == "be") Cut(); else DontCut();
                        break;
                    case 8:
                        if (longText[1] == "see") Cut(); else DontCut();
                        break;
                    case 9:
                        if (longText[1] == "see") Cut(); else DontCut();
                        break;
                }
            }

        }

        void Cut()
        {
            TextSynthesizer.Speak("Cut");
        }
        void DontCut()
        {
            TextSynthesizer.Speak("Dont");
        }
    }
}